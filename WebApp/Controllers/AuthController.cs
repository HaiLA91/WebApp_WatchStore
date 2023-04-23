using Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{
    public class AuthController : BaseControllerContext
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Register(RegisterModel obj)
        {
            int ret = await providerContext.Member.Add(obj);
            if (ret > 0)
            {
                return Redirect("/auth/login");
            }
            return Redirect("/error");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel obj)
        {
            ResponseLogin response = await providerContext.Member.Login(obj);
            if (response != null)
            {
                //JWT (CREATE TOKEN)
                Member member = response.Member;
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, obj.Usr),
                    new Claim(ClaimTypes.Role, member.Role),
                    new Claim(ClaimTypes.OtherPhone, member.Phone),
                    new Claim(ClaimTypes.NameIdentifier, member.Id),
                    new Claim("JwtToken", response.Token)
                };
                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                AuthenticationProperties properties = new AuthenticationProperties
                {
                    IsPersistent = obj.Rem
                };
                await HttpContext.SignInAsync(principal, properties);
                string token = Helper.RandomString(32);
                HttpContext.Response.Cookies.Append("AccessToken", token, new CookieOptions { Path = "/home/index", Expires = DateTime.Now.AddDays(30) });
                member.AccessToken = token;
                providerContext.Member.UpdateToken(member);
                return Redirect($"/home/{member.Role}");
            }
            return View(obj);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/auth/login");
        }
    }
}
