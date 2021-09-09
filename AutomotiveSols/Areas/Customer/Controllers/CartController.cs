using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomotiveSols.BLL.Models;
using AutomotiveSols.BLL.ViewModels;
using AutomotiveSols.Data;
using AutomotiveSols.Static;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace AutomotiveSols.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public ShoppingCartVM ShoppingCartVM { get; set; }

        public CartController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var applicationUser = await _userManager.GetUserAsync(User);
            ShoppingCartVM = new ShoppingCartVM()
            {
                OrderHeader = new OrderHeader(),
                ListCart = _db.ShoppingCarts.Include(x => x.AutoPart).Where(x => x.ApplicationUserId == applicationUser.Id).ToList()
            };
            ShoppingCartVM.OrderHeader.OrderTotal = 0;
            ShoppingCartVM.OrderHeader.ApplicationUser = _db.ApplicationUsers.FirstOrDefault(x => x.Id == applicationUser.Id);

            foreach (var list in ShoppingCartVM.ListCart)
            {
                list.Price = StaticDetails.GetPriceBasedOnQuantity(list.Count, list.AutoPart.Price,
                                                    list.AutoPart.Price50, list.AutoPart.Price100);
                ShoppingCartVM.OrderHeader.OrderTotal += (list.Price * list.Count);
                list.AutoPart.Description = StaticDetails.ConvertToRawHtml(list.AutoPart.Description);
                if (list.AutoPart.Description.Length > 100)
                {
                    list.AutoPart.Description = list.AutoPart.Description.Substring(0, 99) + "...";
                }
            }


            ShoppingCartVM.OrderHeader.OrderTotalOriginal = ShoppingCartVM.OrderHeader.OrderTotal;


            if (HttpContext.Session.GetString(StaticDetails.ssCouponCode) != null)
            {
                ShoppingCartVM.OrderHeader.CouponCode = HttpContext.Session.GetString(StaticDetails.ssCouponCode);
                var couponFromDb = _db.Coupons.FirstOrDefault(c => c.Name.ToLower() == ShoppingCartVM.OrderHeader.CouponCode.ToLower());
                ShoppingCartVM.OrderHeader.OrderTotal = StaticDetails.DiscountedPrice(couponFromDb, ShoppingCartVM.OrderHeader.OrderTotalOriginal);
            }

            return View(ShoppingCartVM);
        }

        public IActionResult AddCoupon()
        {
            if (ShoppingCartVM.OrderHeader.CouponCode == null)
            {
                ShoppingCartVM.OrderHeader.CouponCode = "";
            }
            HttpContext.Session.SetString(StaticDetails.ssCouponCode, ShoppingCartVM.OrderHeader.CouponCode);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveCoupon()
        {

            HttpContext.Session.SetString(StaticDetails.ssCouponCode, string.Empty);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Plus(int cartId)
        {
            var cart = _db.ShoppingCarts.Include(x => x.AutoPart).FirstOrDefault
                            (c => c.Id == cartId);
            cart.Count += 1;
            cart.Price = StaticDetails.GetPriceBasedOnQuantity(cart.Count, cart.AutoPart.Price,
                                    cart.AutoPart.Price50, cart.AutoPart.Price100);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Minus(int cartId)
        {
            var cart = _db.ShoppingCarts.Include(x => x.AutoPart).FirstOrDefault
                            (c => c.Id == cartId);

            if (cart.Count == 1)
            {
                var cnt = _db.ShoppingCarts.Where(u => u.ApplicationUserId == cart.ApplicationUserId).ToList().Count;
                _db.ShoppingCarts.Remove(cart);
                _db.SaveChanges();
                HttpContext.Session.SetInt32(StaticDetails.ssShoppingCart, cnt - 1);
            }
            else
            {
                cart.Count -= 1;
                cart.Price = StaticDetails.GetPriceBasedOnQuantity(cart.Count, cart.AutoPart.Price,
                                    cart.AutoPart.Price50, cart.AutoPart.Price100);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int cartId)
        {
            var cart = _db.ShoppingCarts.Include(x => x.AutoPart).FirstOrDefault
                            (c => c.Id == cartId);

            var cnt = _db.ShoppingCarts.Where(u => u.ApplicationUserId == cart.ApplicationUserId).ToList().Count;
            _db.ShoppingCarts.Remove(cart);
            _db.SaveChanges();
            HttpContext.Session.SetInt32(StaticDetails.ssShoppingCart, cnt - 1);


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Summary()
        {


            var applicationUser = await _userManager.GetUserAsync(User);

            ShoppingCartVM = new ShoppingCartVM()
            {
                OrderHeader = new OrderHeader(),
                ListCart = _db.ShoppingCarts.Include(x => x.AutoPart).Where(c => c.ApplicationUserId == applicationUser.Id)
            };
            ShoppingCartVM.OrderHeader.OrderTotal = 0;
            ShoppingCartVM.OrderHeader.ApplicationUser = _db.ApplicationUsers
                                                            .FirstOrDefault(c => c.Id == applicationUser.Id);

            foreach (var list in ShoppingCartVM.ListCart)
            {
                list.Price = StaticDetails.GetPriceBasedOnQuantity(list.Count, list.AutoPart.Price,
                                                    list.AutoPart.Price50, list.AutoPart.Price100);
                ShoppingCartVM.OrderHeader.OrderTotal += (list.Price * list.Count);
            }
            ShoppingCartVM.OrderHeader.OrderTotalOriginal = ShoppingCartVM.OrderHeader.OrderTotal;

            ShoppingCartVM.OrderHeader.Name = ShoppingCartVM.OrderHeader.ApplicationUser.Name;
            ShoppingCartVM.OrderHeader.PhoneNumber = ShoppingCartVM.OrderHeader.ApplicationUser.PhoneNumber;
            ShoppingCartVM.OrderHeader.StreetAddress = ShoppingCartVM.OrderHeader.ApplicationUser.StreetAddress;
            ShoppingCartVM.OrderHeader.City = ShoppingCartVM.OrderHeader.ApplicationUser.City;
            ShoppingCartVM.OrderHeader.State = ShoppingCartVM.OrderHeader.ApplicationUser.State;
            ShoppingCartVM.OrderHeader.PostalCode = ShoppingCartVM.OrderHeader.ApplicationUser.PostalCode;
            if (HttpContext.Session.GetString(StaticDetails.ssCouponCode) != null)
            {
                ShoppingCartVM.OrderHeader.CouponCode = HttpContext.Session.GetString(StaticDetails.ssCouponCode);
                var couponFromDb = _db.Coupons.FirstOrDefault(c => c.Name.ToLower() == ShoppingCartVM.OrderHeader.CouponCode.ToLower());
                ShoppingCartVM.OrderHeader.OrderTotal = StaticDetails.DiscountedPrice(couponFromDb, ShoppingCartVM.OrderHeader.OrderTotalOriginal);
            }
            return View(ShoppingCartVM);
        }


        [HttpPost]
        [ActionName("Summary")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SummaryPost(string stripeToken)
        {

            var applicationUser = await _userManager.GetUserAsync(User);
            ShoppingCartVM.OrderHeader.ApplicationUser = _db.ApplicationUsers
                                                            .FirstOrDefault(c => c.Id == applicationUser.Id);

            ShoppingCartVM.ListCart = _db.ShoppingCarts.Include(x => x.AutoPart)
                                        .Where(c => c.ApplicationUserId == applicationUser.Id).ToList();

            ShoppingCartVM.OrderHeader.PaymentStatus = StaticDetails.PaymentStatusPending;
            ShoppingCartVM.OrderHeader.OrderStatus = StaticDetails.StatusPending;
            ShoppingCartVM.OrderHeader.ApplicationUserId = applicationUser.Id;
            ShoppingCartVM.OrderHeader.OrderDate = DateTime.Now;
            ShoppingCartVM.OrderHeader.ShippingDate = DateTime.Now.AddDays(7);
            _db.OrderHeaders.Add(ShoppingCartVM.OrderHeader);
            _db.SaveChanges();
            ShoppingCartVM.OrderHeader.OrderTotalOriginal = 0;

            foreach (var item in ShoppingCartVM.ListCart)
            {
                item.Price = StaticDetails.GetPriceBasedOnQuantity(item.Count, item.AutoPart.Price,
                    item.AutoPart.Price50, item.AutoPart.Price100);
                OrderDetails orderDetails = new OrderDetails()
                {
                    AutoPartId = item.AutoPartId,
                    OrderId = ShoppingCartVM.OrderHeader.Id,
                    Price = item.Price,
                    Count = item.Count
                };
                ShoppingCartVM.OrderHeader.OrderTotalOriginal += orderDetails.Count * orderDetails.Price;
                _db.OrderDetails.Add(orderDetails);

            }

            if (HttpContext.Session.GetString(StaticDetails.ssCouponCode) != null)
            {
                ShoppingCartVM.OrderHeader.CouponCode = HttpContext.Session.GetString(StaticDetails.ssCouponCode);
                var couponFromDb = _db.Coupons.FirstOrDefault(c => c.Name.ToLower() == ShoppingCartVM.OrderHeader.CouponCode.ToLower());
                ShoppingCartVM.OrderHeader.OrderTotal = StaticDetails.DiscountedPrice(couponFromDb, ShoppingCartVM.OrderHeader.OrderTotalOriginal);
            }
            else
            {
                ShoppingCartVM.OrderHeader.OrderTotal = ShoppingCartVM.OrderHeader.OrderTotalOriginal;
            }
            ShoppingCartVM.OrderHeader.CouponCodeDiscount = ShoppingCartVM.OrderHeader.OrderTotalOriginal - ShoppingCartVM.OrderHeader.OrderTotal;

            _db.ShoppingCarts.RemoveRange(ShoppingCartVM.ListCart);
            _db.SaveChanges();
            HttpContext.Session.SetInt32(StaticDetails.ssShoppingCart, 0);



            if (ShoppingCartVM.OrderHeader.CashonDelivery == true)
            {
                //order will be created for delayed payment for authroized company
                ShoppingCartVM.OrderHeader.PaymentDueDate = DateTime.Now.AddDays(10);
                ShoppingCartVM.OrderHeader.PaymentStatus = StaticDetails.PaymentStatusDelayedPayment;
                ShoppingCartVM.OrderHeader.OrderStatus = StaticDetails.StatusApproved;
            }
            else
            {
                //process the payment
                var options = new ChargeCreateOptions
                {
                    Amount = Convert.ToInt32(ShoppingCartVM.OrderHeader.OrderTotal * 100),
                    Currency = "usd",
                    Description = "Order ID : " + ShoppingCartVM.OrderHeader.Id,
                    Source = stripeToken
                };

                var service = new ChargeService();
                Charge charge = service.Create(options);

                if (charge.Id == null)
                {
                    ShoppingCartVM.OrderHeader.PaymentStatus = StaticDetails.PaymentStatusRejected;
                }
                else
                {
                    ShoppingCartVM.OrderHeader.TransactionId = charge.Id;
                }
                if (charge.Status.ToLower() == "succeeded")
                {
                    ShoppingCartVM.OrderHeader.PaymentStatus = StaticDetails.PaymentStatusApproved;
                    ShoppingCartVM.OrderHeader.OrderStatus = StaticDetails.StatusApproved;
                    ShoppingCartVM.OrderHeader.PaymentDate = DateTime.Now;
                }
                 
            }
            _db.SaveChanges();

            return RedirectToAction("OrderConfirmation", "Cart", new { id = ShoppingCartVM.OrderHeader.Id });

        }

        public IActionResult OrderConfirmation(int id)
        {
            OrderHeader orderHeader = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
            //TwilioClient.Init(_twilioOptions.AccountSid, _twilioOptions.AuthToken);
            //try
            //{
            //    var message = MessageResource.Create(
            //        body: "Order Placed on Bulky Book. Your Order ID:" + id,
            //        from: new Twilio.Types.PhoneNumber(_twilioOptions.PhoneNumber),
            //        to: new Twilio.Types.PhoneNumber(orderHeader.PhoneNumber)
            //        );
            //}
            //catch (Exception ex)
            //{

            //}



            return View(id);
        }

    }
}