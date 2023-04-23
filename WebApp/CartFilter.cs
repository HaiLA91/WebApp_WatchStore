using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApp.Models;

namespace WebApp
{
    public class CartFilter : Attribute, IActionFilter
    {
        const string CartName = "cart";
        SiteProvider provider;
        public CartFilter(SiteProvider provider)
        {
            this.provider = provider;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Controller is Controller con)
            {
                string? code = con.Request.Cookies[CartName];
                con.ViewBag.CountCart = string.IsNullOrEmpty(code) ? 0 : provider.Cart.Count(code);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
