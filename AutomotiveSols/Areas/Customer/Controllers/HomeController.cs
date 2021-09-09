using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutomotiveSols.BLL.Models;
using AutomotiveSols.Data;
using Microsoft.EntityFrameworkCore;
using AutomotiveSols.Extensions;
using AutomotiveSols.BLL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using AutomotiveSols.Static;
using Microsoft.AspNetCore.Authorization;

namespace AutomotiveSols.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private IndexViewModel IndexVM;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db,
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _db = db;
            _userManager = userManager;
        }

        public async  Task<IActionResult> Index()
        {
            IndexVM = new IndexViewModel()
            {
                CategoryList = await _db.Categories.ToListAsync(),
                AutoPartList = await _db.AutoParts.Include(x => x.ApplicationUser).Include(x => x.Category)
                                    .Include(x => x.SubCategory)
                                    .Include(x => x.PartGalleries)
                                    .ToListAsync(),
                ServiceTypes = await _db.ServiceTypes.ToListAsync(),
                Services = await _db.Services.Include(x => x.ApplicationUser)
                                    .Include(x => x.ServiceType)
                                    .ToListAsync(),
                Brands = await _db.Brands.ToListAsync(),

                Cars = await _db.Cars.Include(x => x.ApplicationUser)
                                    .Include(x => x.Brand)
                                    .Include(x => x.Model)
                                    .Include(x => x.Mileage)
                                    .Include(x => x.Transmission)
                                    .Include(x => x.Trim)
                                    .Include(x => x.RegistrationCity)
                                    .Include(x => x.Year)
                                    .ToListAsync()

            };
            var applicationUser = await _userManager.GetUserAsync(User);
            if(applicationUser != null)
            {
                var count = _db.ShoppingCarts.Where(x => x.ApplicationUserId == applicationUser.Id).ToList().Count();
                HttpContext.Session.SetInt32(StaticDetails.ssShoppingCart, count);
            }

            return View(IndexVM);
        }
        [HttpGet]
        public async Task<ActionResult> Index(string searchString)
        {
            ViewData["searchString"] = searchString;
            if (!string.IsNullOrEmpty(searchString)) {

                IndexVM = new IndexViewModel()
                {
                    
                    CategoryList = await _db.Categories.ToListAsync(),
                    AutoPartList = await _db.AutoParts.Include(x => x.ApplicationUser).Include(x => x.Category)
                                    .Include(x => x.SubCategory)
                                    .Include(x => x.PartGalleries)
                                    .Where(x=>x.Name.Contains(searchString) || x.Description.Contains(searchString))
                                    .ToListAsync(),
                    ServiceTypes = await _db.ServiceTypes.ToListAsync(),
                    Services = await _db.Services.Include(x => x.ApplicationUser)
                                    .Include(x => x.ServiceType)
                                    .Where(x=>x.Name.Contains(searchString) || x.Description.Contains(searchString))
                                    .ToListAsync(),
                    Brands = await _db.Brands.ToListAsync(),

                    Cars = await _db.Cars.Include(x => x.ApplicationUser)
                                    .Include(x => x.Brand)
                                    .Include(x => x.Model)
                                    .Include(x => x.Mileage)
                                    .Include(x => x.Transmission)
                                    .Include(x => x.Trim)
                                    .Include(x => x.RegistrationCity)
                                    .Include(x => x.Year)
                                    .Where(x=>x.Brand.Name.Contains(searchString) || x.Mileage.NumberKm.Contains(searchString)
                                    || x.RegistrationCity.Name.Contains(searchString) || x.Transmission.Name.Contains(searchString)
                                    || x.Trim.Name.Contains(searchString ) || x.Year.SolarYear.Contains(searchString))
                                    .ToListAsync()

                };
                var applicationUser = await _userManager.GetUserAsync(User);
                if (applicationUser != null)
                {
                    var count = _db.ShoppingCarts.Where(x => x.ApplicationUserId == applicationUser.Id).ToList().Count();
                    HttpContext.Session.SetInt32(StaticDetails.ssShoppingCart, count);
                }

                return View(IndexVM);
            }
            else
            {
                IndexVM = new IndexViewModel()
                {
                    CategoryList = await _db.Categories.ToListAsync(),
                    AutoPartList = await _db.AutoParts.Include(x => x.ApplicationUser).Include(x => x.Category)
                                    .Include(x => x.SubCategory)
                                    .Include(x => x.PartGalleries)
                                    .ToListAsync(),
                    ServiceTypes = await _db.ServiceTypes.ToListAsync(),
                    Services = await _db.Services.Include(x => x.ApplicationUser)
                                    .Include(x => x.ServiceType)
                                    .ToListAsync(),
                    Brands = await _db.Brands.ToListAsync(),

                    Cars = await _db.Cars.Include(x => x.ApplicationUser)
                                    .Include(x => x.Brand)
                                    .Include(x => x.Model)
                                    .Include(x => x.Mileage)
                                    .Include(x => x.Transmission)
                                    .Include(x => x.Trim)
                                    .Include(x => x.RegistrationCity)
                                    .Include(x => x.Year)
                                    .ToListAsync()

                };
                var applicationUser = await _userManager.GetUserAsync(User);
                if (applicationUser != null)
                {
                    var count = _db.ShoppingCarts.Where(x => x.ApplicationUserId == applicationUser.Id).ToList().Count();
                    HttpContext.Session.SetInt32(StaticDetails.ssShoppingCart, count);
                }

                return View(IndexVM);
            }
            

        }


        public async Task<IActionResult> DetailsPart(int id)
        {
            var partFromDb =await _db.AutoParts.Include(x => x.ApplicationUser).Include(x => x.Category)
                                    .Include(x => x.SubCategory)
                                    .Include(x => x.PartGalleries)
                                    .FirstOrDefaultAsync();
             ShoppingCart cartObj = new ShoppingCart()
            {
                AutoPart = partFromDb,
                AutoPartId = partFromDb.Id
            };
            return View(cartObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
         [Authorize]
        public async Task<IActionResult> DetailsPart(ShoppingCart CartObject)
        {
            CartObject.Id = 0;
            if (ModelState.IsValid)
            {
                //then we will add to cart
                var applicationUser = await _userManager.GetUserAsync(User);
                CartObject.ApplicationUserId = applicationUser.Id;

                ShoppingCart cartFromDb = await _db.ShoppingCarts.Where(u => u.ApplicationUserId == CartObject.ApplicationUserId
                && u.AutoPartId == CartObject.AutoPartId).Include(x => x.AutoPart).Include(x => x.ApplicationUser)
                .FirstOrDefaultAsync();
                   

                if (cartFromDb == null)
                {
                    //no records exists in database for that product for that user
                    _db.ShoppingCarts.Add(CartObject);
                }
                else
                {
                    cartFromDb.Count += CartObject.Count;
                    //_unitOfWork.ShoppingCart.Update(cartFromDb);
                }
                await _db.SaveChangesAsync();


                var count = _db.ShoppingCarts.Where(x => x.ApplicationUserId == CartObject.ApplicationUserId)
                    .ToList().Count();
                    


                //HttpContext.Session.SetObject(SD.ssShoppingCart, CartObject);
                HttpContext.Session.SetInt32(StaticDetails.ssShoppingCart, count);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                var partFromDb = await _db.AutoParts.Where(x => x.Id == CartObject.AutoPartId)
                    .Include(x => x.Category)
                    .Include(x => x.SubCategory).FirstOrDefaultAsync();

                ShoppingCart cartObj = new ShoppingCart()
                {
                    AutoPart = partFromDb,
                    AutoPartId = partFromDb.Id
                };
                return View(cartObj);
            }


        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> DetailsCar(int id)
        {
            var car = await _db.Cars.Include(m => m.ApplicationUser)
                .Include(x => x.Brand)
                                    .Include(x => x.Model)
                                    .Include(x => x.Mileage)
                                    .Include(x => x.Transmission)
                                    .Include(x => x.Trim)
                                    .Include(x => x.RegistrationCity)
                                    .Include(x => x.Year)
                                    .Where(m => m.Id == id).FirstOrDefaultAsync();
           return View(car);
        }

        [HttpPost, ActionName("DetailsCar")]
        [ValidateAntiForgeryToken]
        public IActionResult DetailsCarPost(int id)
        {
            List<int> tempCart = HttpContext.Session.Get<List<int>>("carCart");
            if (tempCart == null)
            {
                tempCart = new List<int>();
            }
            tempCart.Add(id);
            HttpContext.Session.Set("carCart", tempCart);

            return RedirectToAction("Index", "Home", new { area = "Customer" });

        }
        public IActionResult RemoveCar(int id)
        {
            List<int> tempCart = HttpContext.Session.Get<List<int>>("carCart");
            if (tempCart.Count > 0)
            {
                if (tempCart.Contains(id))
                {
                    tempCart.Remove(id);
                }
            }

            HttpContext.Session.Set("carCart", tempCart);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var service = await _db.Services.Include(m => m.ServiceType).Where(m => m.Id == id).FirstOrDefaultAsync();


            return View(service);
        }
        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public IActionResult DetailsPost(int id)
        {
            List<int> tempCart = HttpContext.Session.Get<List<int>>("tempCart");
            if (tempCart == null)
            {
                tempCart = new List<int>();
            }
            tempCart.Add(id);
            HttpContext.Session.Set("tempCart", tempCart);

            return RedirectToAction("Index", "Home", new { area = "Customer" });

        }

        public IActionResult Remove(int id)
        {
            List<int> tempCart = HttpContext.Session.Get<List<int>>("tempCart");
            if (tempCart.Count > 0)
            {
                if (tempCart.Contains(id))
                {
                    tempCart.Remove(id);
                }
            }

            HttpContext.Session.Set("tempCart", tempCart);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
