using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public abstract class BaseController : Controller
    {
        protected SiteProvider provider;
        public BaseController(SiteProvider provider)
        {
            this.provider = provider;
        }
        //protected override void Dispose(bool disposing)
        //{
        //    base.Dispose(disposing);
        //    provider.Dispose();
        //}
    }
}
