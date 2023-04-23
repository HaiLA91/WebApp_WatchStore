namespace WebApi.Models
{
    public class CarouselRepository : BaseRepository
    {
        public CarouselRepository(WatchStoreContext context) : base(context)
        {

        }
        public List<Carousel> GetCarousels()
        {
            return null;
            //return context.Carousels.Join(Category inner )
            //    .Select(c => new (Carousel, Category)
            //    {
            //        c.
                    

            //    });

                //("SELECT Carousel.*, CategoryName FROM Carousel JOIN Category ON CarouselId = CategoryId");
        }
    }
}
