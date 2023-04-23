using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarouselController : BaseController
    {
        public List<Carousel> Get()
        {
            return provider.Carousel.GetCarousels();
        }
    }
}
