using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApp.Models;

namespace WebApp
{
    public class CategoryFilter : Attribute, IActionFilter
    {
        SiteProvider provider;
        public CategoryFilter(SiteProvider provider)
        {
            this.provider = provider;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Controller is Controller con)
            {

                
                IEnumerable<SubCategory> subCategories = provider.SubCategory.GetSubCategories();
                Dictionary<short, List<SubCategory>> dictSub = new Dictionary<short, List<SubCategory>>();
                foreach (SubCategory item in subCategories)
                {
                    short k = item.CategoryId;
                    if (!dictSub.ContainsKey(k))
                    {
                        dictSub[k] = new List<SubCategory>();
                    }
                    dictSub[k].Add(item);
                }
                con.ViewBag.subCategories = dictSub;
                con.ViewBag.categories = provider.Category.GetCategories();
                con.ViewBag.carousels = provider.Carousel.GetCarousels();
                con.ViewBag.Brands = provider.Brand.GetBrands();
                con.ViewBag.Products = provider.Product.GetProduct();
                con.ViewBag.Province = provider.Province.GetProvinces();
                con.ViewBag.District = provider.District.GetDistricts();
                con.ViewBag.Ward = provider.Ward.GetWards();
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //throw new NotImplementedException();
        }
    }
}
