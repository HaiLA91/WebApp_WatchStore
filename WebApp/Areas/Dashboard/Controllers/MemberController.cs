using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers;

namespace WebApp.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class MemberController : BaseControllerContext
    {
        [Authorize]
        public /*async*/IActionResult Index()
        {

            return View( /*await providerContext.Member.GetMembers(token)*/);
        }

    }
}
