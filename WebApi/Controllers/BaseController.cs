using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    public abstract class BaseController : ControllerBase , IDisposable
    {
        protected SiteProvider provider = new SiteProvider();
        public void Dispose()
        {
            Console.WriteLine("************Disposable********************");
            provider.Dispose();
        }

    }
}
