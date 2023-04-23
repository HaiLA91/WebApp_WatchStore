using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp.Models;
using Utils;
namespace WebApp.Controllers
{
    public class CartController : BaseController
    {
        public CartController(SiteProvider provider) : base(provider)
        {
        }
        const string CartCode = "cart";
        [ServiceFilter(typeof(CategoryFilter))]
        [ServiceFilter(typeof(CartFilter))]
        public IActionResult Index()
        {
            string? code = Request.Cookies[CartCode];
            if (!string.IsNullOrEmpty(code))
            {
                return View(provider.Cart.GetCarts(code));
            }
            return Redirect("/");
        }
        [ServiceFilter(typeof(CartFilter))]
        [ServiceFilter(typeof(CategoryFilter))]
        [Authorize]
        public IActionResult Checkout()
        {
            string code = Request.Cookies[CartCode];
            return View(provider.Cart.GetCarts(code));
        }
        [Authorize, HttpPost]
        public IActionResult Checkout(Invoice obj)
        {
            string code = Request.Cookies[CartCode];
            obj.CartCode = code;
            obj.MemberId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            provider.Invoice.Add(obj);
            return Redirect($"/incoice/detail/{obj.InvoiceId}");
        }
        public IActionResult Add(Cart obj)
        {
            string? code = Request.Cookies[CartCode];
            if (string.IsNullOrEmpty(code))
            {
                code = Helper.RandomString(32);
                Response.Cookies.Append(CartCode, code);
            }
            obj.CartCode = code;
            provider.Cart.Save(obj);
            return Redirect("/cart");
        }
        [HttpPost]
        public IActionResult Edit(Cart obj)
        {
            obj.CartCode = Request.Cookies[CartCode];
            return Json(provider.Cart.Edit(obj));
        }
        [HttpPost]
        public IActionResult Delete(Cart obj)
        {
            obj.CartCode = Request.Cookies[CartCode];
            return Json(provider.Cart.Delete(obj));
        }
        [Authorize]
        public IActionResult Address(Address obj)
        {
            if (ModelState.IsValid)
            {
                obj.MemberId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                provider.Address.Add(obj);
                return Redirect("/cart/checkout");
            }
            ViewBag.provinces = new SelectList(provider.Province.GetProvinces(), "ProvinceId", "ProvinceName");
            return View("checkout", obj);

        }
        public IActionResult District(byte id)
        {
            return Json(provider.District.GetDistricts(id));
        }
        public IActionResult Ward(short id)
        {
            return Json(provider.Ward.GetWards(id));
        }
    }
}
