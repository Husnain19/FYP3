using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Reporting;
using AutomotiveSols.BLL.Models;
using AutomotiveSols.BLL.ViewModels;
using AutomotiveSols.Data;
using AutomotiveSols.Models;
using AutomotiveSols.ServicesReport;
using AutomotiveSols.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace AutomotiveSols.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly OrderHistoryService orderService = new OrderHistoryService();
        private readonly UserManager<ApplicationUser> _userManager;
        [BindProperty]
        public OrderVM OrderVM { get; set; }

        public OrderController(ApplicationDbContext db, UserManager<ApplicationUser> userManager,IWebHostEnvironment 
            webHostEnvironment)
        {
            _db = db;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index(string status = "")
        {
            var applicationUser = await _userManager.GetUserAsync(User);

              var part = _db.AutoParts.Where(x => x.ApplicationUser.Id == applicationUser.Id).FirstOrDefault();

            IEnumerable<OrderHeader> orderHeaderList;

            if (User.IsInRole(StaticDetails.Role_Admin))
            {
                orderHeaderList = _db.OrderHeaders.Include(x => x.ApplicationUser).ToList();
            }
            else if (User.IsInRole(StaticDetails.Role_Vendor))
            {
                 orderHeaderList = _db.OrderHeaders.Include(x => x.ApplicationUser)
                   .Where(x=>part.ApplicationUserId == applicationUser.Id).ToList();

                

            }
            else
            {
                orderHeaderList = _db.OrderHeaders.Include(x => x.ApplicationUser)
                    .Where(x => x.ApplicationUserId == applicationUser.Id).ToList();
            }

            switch (status)
            {
                case "pending":
                    orderHeaderList = orderHeaderList.Where(o => o.PaymentStatus == StaticDetails.PaymentStatusDelayedPayment);
                    break;
                case "inprocess":
                    orderHeaderList = orderHeaderList.Where(o => o.OrderStatus == StaticDetails.StatusApproved ||
                                                            o.OrderStatus == StaticDetails.StatusInProcess ||
                                                            o.OrderStatus == StaticDetails.StatusPending);
                    break;
                case "completed":
                    orderHeaderList = orderHeaderList.Where(o => o.OrderStatus == StaticDetails.StatusShipped);
                    break;
                case "rejected":
                    orderHeaderList = orderHeaderList.Where(o => o.OrderStatus == StaticDetails.StatusCancelled ||
                                                            o.OrderStatus == StaticDetails.StatusRefunded ||
                                                            o.OrderStatus == StaticDetails.PaymentStatusRejected);
                    break;
                default:
                    break;
            }

            return View( orderHeaderList );
        }


        public IActionResult OrderHistory()
        {
            var dt = new DataTable();
            dt = orderService.GetOrders();

            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\Report4.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();


            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("DataSet2", dt);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");


           
        }

        public IActionResult Invoice(int id)
        {
            OrderVM OrderVM = new OrderVM()
            {
                OrderHeader = _db.OrderHeaders.Include(x => x.ApplicationUser).FirstOrDefault(u => u.Id == id),
                OrderDetails = _db.OrderDetails.Include(x => x.AutoPart).Where(o => o.OrderId == id).ToList()

            };

            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\Report2.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();


            int count = OrderVM.OrderDetails.Count();
            int p = 1;
            while (count > 0)
            {
                foreach (var item in OrderVM.OrderDetails)
                {
                
                    parameters.Add("rp"+p.ToString(), item.AutoPart.Name);
                    p = p + 1;
                    parameters.Add("rp"+p.ToString(), item.AutoPart.Price.ToString());
                    p = p + 1;
                    count = count - 1;
                }
                
            }
            parameters.Add("rp5", OrderVM.OrderHeader.ApplicationUser.Name);
            parameters.Add("rp6", OrderVM.OrderHeader.ApplicationUser.Email);
            parameters.Add("rp7", OrderVM.OrderHeader.PhoneNumber);
            parameters.Add("rp9", OrderVM.OrderHeader.PostalCode);
            parameters.Add("rp10", OrderVM.OrderHeader.State);
            parameters.Add("rp11", OrderVM.OrderHeader.City);
            parameters.Add("rp12", OrderVM.OrderHeader.StreetAddress);
            parameters.Add("rp13", OrderVM.OrderHeader.ShippingDate.ToString());
            parameters.Add("rp14", OrderVM.OrderHeader.TrackingNumber);
            parameters.Add("rp15", OrderVM.OrderHeader.TransactionId);
            //parameters.Add("rp16", OrderVM.OrderHeader.CouponCode);
            parameters.Add("rp17", OrderVM.OrderHeader.Carrier);
            parameters.Add("rp18", OrderVM.OrderHeader.OrderDate.ToString());
            parameters.Add("rp19", OrderVM.OrderHeader.OrderTotalOriginal.ToString());
            parameters.Add("rp20", OrderVM.OrderHeader.PaymentStatus);
            LocalReport localReport = new LocalReport(path);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");


           
        }

        public IActionResult Details(int id)
        {
            OrderVM OrderVM = new OrderVM()
            {
                OrderHeader = _db.OrderHeaders.Include(x=>x.ApplicationUser).FirstOrDefault(u => u.Id == id),
                OrderDetails = _db.OrderDetails.Include(x=>x.AutoPart).Where(o => o.OrderId == id).ToList()

            };
            return View(OrderVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Details")]
        public IActionResult Details(string stripeToken)
        {
            OrderHeader orderHeader = _db.OrderHeaders.Include(x => x.ApplicationUser).FirstOrDefault(u => u.Id == OrderVM.OrderHeader.Id);
            if (stripeToken != null)
            {
                //process the payment
                var options = new ChargeCreateOptions
                {
                    Amount = Convert.ToInt32(orderHeader.OrderTotal * 100),
                    Currency = "usd",
                    Description = "Order ID : " + orderHeader.Id,
                    Source = stripeToken
                };

                var service = new ChargeService();
                Charge charge = service.Create(options);

                if (charge.Id == null)
                {
                    orderHeader.PaymentStatus = StaticDetails.PaymentStatusRejected;
                }
                else
                {
                    orderHeader.TransactionId = charge.Id;
                }
                if (charge.Status.ToLower() == "succeeded")
                {
                    orderHeader.PaymentStatus = StaticDetails.PaymentStatusApproved;

                    orderHeader.PaymentDate = DateTime.Now;
                }

                _db.SaveChanges();

            }
            return RedirectToAction("Details", "Order", new { id = orderHeader.Id });
        }




        [Authorize(Roles = StaticDetails.Role_Admin + "," + StaticDetails.Role_Vendor)]
        public IActionResult StartProcessing(int id)
        {
            OrderHeader orderHeader = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
            orderHeader.OrderStatus = StaticDetails.StatusInProcess;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = StaticDetails.Role_Admin + "," + StaticDetails.Role_Vendor)]
        public IActionResult ShipOrder()
        {
            OrderHeader orderHeader = _db.OrderHeaders.FirstOrDefault(u => u.Id == OrderVM.OrderHeader.Id);
            orderHeader.TrackingNumber = OrderVM.OrderHeader.TrackingNumber;
            orderHeader.Carrier = OrderVM.OrderHeader.Carrier;
            orderHeader.OrderStatus = StaticDetails.StatusShipped;
            orderHeader.ShippingDate = DateTime.Now;

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = StaticDetails.Role_Admin + "," + StaticDetails.Role_Vendor)]
        public IActionResult CancelOrder(int id)
        {
            OrderHeader orderHeader = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
            if (orderHeader.PaymentStatus == StaticDetails.StatusApproved)
            {
                var options = new RefundCreateOptions
                {
                    Amount = Convert.ToInt32(orderHeader.OrderTotal * 100),
                    Reason = RefundReasons.RequestedByCustomer,
                    Charge = orderHeader.TransactionId

                };
                var service = new RefundService();
                Refund refund = service.Create(options);

                orderHeader.OrderStatus = StaticDetails.StatusRefunded;
                orderHeader.PaymentStatus = StaticDetails.StatusRefunded;
            }
            else
            {
                orderHeader.OrderStatus = StaticDetails.StatusCancelled;
                orderHeader.PaymentStatus = StaticDetails.StatusCancelled;
            }

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateOrderDetails()
        {
            var orderHEaderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == OrderVM.OrderHeader.Id);
            orderHEaderFromDb.Name = OrderVM.OrderHeader.Name;
            orderHEaderFromDb.PhoneNumber = OrderVM.OrderHeader.PhoneNumber;
            orderHEaderFromDb.StreetAddress = OrderVM.OrderHeader.StreetAddress;
            orderHEaderFromDb.City = OrderVM.OrderHeader.City;
            orderHEaderFromDb.State = OrderVM.OrderHeader.State;
            orderHEaderFromDb.PostalCode = OrderVM.OrderHeader.PostalCode;
            if (OrderVM.OrderHeader.Carrier != null)
            {
                orderHEaderFromDb.Carrier = OrderVM.OrderHeader.Carrier;
            }
            if (OrderVM.OrderHeader.TrackingNumber != null)
            {
                orderHEaderFromDb.TrackingNumber = OrderVM.OrderHeader.TrackingNumber;
            }

            _db.SaveChanges();
            TempData["Error"] = "Order Details Updated Successfully.";
            return RedirectToAction("Details", "Order", new { id = orderHEaderFromDb.Id });
        }


        public IActionResult Print()
        {
            var orderData = _db.OrderHeaders.Where(x => x.OrderDate <= OrderVM.OrderHeader.OrderDate
                                        && x.OrderDate >= OrderVM.OrderHeader.OrderDate).ToList();
            return View(orderData);
        }

    }
}

