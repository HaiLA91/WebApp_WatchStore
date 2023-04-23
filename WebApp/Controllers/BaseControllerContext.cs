using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
namespace WebApp.Controllers
{
    public class BaseControllerContext : Controller, IDisposable
    {
        protected SiteProviderContext providerContext = new SiteProviderContext();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            providerContext.Dispose();
        }
    }
}
