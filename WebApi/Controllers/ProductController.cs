using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        public List<Product> Get()
        {
            return provider.Product.GetStatuses();
        }
        [HttpGet("{id}")]
        public Product Get(byte id)
        {
            return provider.Product.GetStatusById(id);
        }

        [HttpPut]
        public int Put(Product obj)
        {
            return provider.Product.Edit(obj);
        }
        [HttpDelete("{id}")]
        public int Delete(byte id)
        {
            return provider.Product.Delete(id);
        }
        [HttpPost]
        public int Add(Product obj)
        {
            return provider.Product.Add(obj);
        }

    }
}
