using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(SiteProvider provider) : base(provider)
        {
        }

        [ServiceFilter(typeof(CategoryFilter))]
        public IActionResult Index()
        {

            ViewBag.carousels = provider.Carousel.GetCarousels();
            ViewBag.Brands = provider.Brand.GetBrands();


            IEnumerable<ProductAndBrand> productAndBrands = provider.Product.GetProductAndBrands();
            Dictionary<string, List<Product>> dict = new Dictionary<string, List<Product>>();
            foreach (var item in productAndBrands)
            {
                string h = item.BrandName;
                if (!dict.ContainsKey(h))
                {
                    dict[h] = new List<Product>();
                }
                dict[h].Add(item);
            }
            ViewBag.productAndBrands = dict;
            return View();
        }
        
        [ServiceFilter(typeof(CategoryFilter))]
        public IActionResult Citizen()
        {
            ViewBag.Brand = provider.Product.GetProductbyBrands(1);
            return View();
        }
        [ServiceFilter(typeof(CategoryFilter))]
        public IActionResult Calvin_Klein()
        {
            ViewBag.Brand = provider.Product.GetProductbyBrands(2);
            return View();
        }
        [ServiceFilter(typeof(CategoryFilter))]
        public IActionResult Orient()
        {
            ViewBag.Brand = provider.Product.GetProductbyBrands(3);
            return View();
        }
        [ServiceFilter(typeof(CategoryFilter))]
        public IActionResult Seiko()
        {
            ViewBag.Brand = provider.Product.GetProductbyBrands(4);
            return View();
        }
        [ServiceFilter(typeof(CategoryFilter))]
        public IActionResult GShock()
        {
            ViewBag.Brand = provider.Product.GetProductbyBrands(5);
            return View();
        }
        [ServiceFilter(typeof(CategoryFilter))]
        public IActionResult Casio()
        {
            ViewBag.Brand = provider.Product.GetProductbyBrands(6);
            return View();
        }
        public IActionResult Apple()
        {
            ViewBag.Brand = provider.Product.GetProductbyBrands(7);
            return View();
        }
        [ServiceFilter(typeof(CategoryFilter))]
        public IActionResult Garmin()
        {
            ViewBag.Brand = provider.Product.GetProductbyBrands(8);
            return View();
        }
        [ServiceFilter(typeof(CategoryFilter))]
        public IActionResult Hirsch()
        {
            ViewBag.Brand = provider.Product.GetProductbyBrands(9);
            return View();
        }
        [ServiceFilter(typeof(CategoryFilter))]
        public IActionResult MASUMU()
        {
            ViewBag.Brand = provider.Product.GetProductbyBrands(10);
            return View();
        }
        [ServiceFilter(typeof(CategoryFilter))]
        public IActionResult Quartz()
        {
            ViewBag.Brand = provider.Product.GetProductbyCategory(1);
            return View();
        }
        [ServiceFilter(typeof(CategoryFilter))]
        public IActionResult Automatic()
        {
            ViewBag.Brand = provider.Product.GetProductbyCategory(2);
            return View();
        }
        [ServiceFilter(typeof(CategoryFilter))]
        public IActionResult Solar()
        {
            ViewBag.Brand = provider.Product.GetProductbyCategory(3);
            return View();
        }
        [ServiceFilter(typeof(CategoryFilter))]
        public IActionResult SmartWatch()
        {
            ViewBag.Brand = provider.Product.GetProductbyCategory(4);
            return View();
        }
        [ServiceFilter(typeof(CategoryFilter))]
        public IActionResult Accessories()
        {
            ViewBag.Brand = provider.Product.GetProductbyCategory(5);
            return View();
        }
        //[ServiceFilter(typeof(CategoryFilter))]
        //public IActionResult ProductBrand()
        //{
        //    return View();
        //}


        [ServiceFilter(typeof(CategoryFilter))]
        [Authorize(Roles = "customer")]
        public IActionResult Customer()
        {
            return View();
        }
        [Authorize(Roles = "customer")]
        public IActionResult Saler()
        {
            return View();
        }
        [Authorize(Roles = "customer")]
        public IActionResult Manager()
        {
            return View();
        }
        [Authorize(Roles = "customer")]
        public IActionResult Admin()
        {
            return View();
        }
        [ServiceFilter(typeof(CategoryFilter))]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
