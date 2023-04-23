using Dapper;
using System.Data;

namespace WebApp.Models
{
    public class CarouselRepository : BaseRepository
    {
        public CarouselRepository(IDbConnection connection) : base(connection)
        {
        }
        public IEnumerable<Carousel> GetCarousels()
        {
            return connection.Query<Carousel>("SELECT Carousel.*, CategoryName FROM Carousel JOIN Category ON CarouselId = CategoryId");
        }
    }
}
