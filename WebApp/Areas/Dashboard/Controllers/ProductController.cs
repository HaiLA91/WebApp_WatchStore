using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers;
using WebApp.Models;

namespace WebApp.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ProductController : BaseControllerContext
    {
        [ServiceFilter(typeof(CategoryFilter))]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product obj)
        {
            int ret = await providerContext.ProductContext.Add(obj);
            return Redirect(ret);
        }

        IActionResult Redirect(int ret)
        {
            if (ret > 0)
            {
                return Redirect("/dashboard/product");
            }
            return Redirect("/dashboard/error");
        }
        public async Task<IActionResult> Delete(byte id)
        {
            int ret = await providerContext.ProductContext.Delete(id);
            return Redirect(ret);
        }
        public async Task<IActionResult> Edit(byte id)
        {
            return View(await providerContext.ProductContext.GetStatusById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product obj)
        {
            int ret = await providerContext.ProductContext.Edit(obj);
            return Redirect(ret);
        }
    }
}
