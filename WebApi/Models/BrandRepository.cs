namespace WebApi.Models
{
    public class BrandRepository : BaseRepository
    {
        public BrandRepository(WatchStoreContext context) : base(context)
        {

        }
        public List<Brand> GetBrands()
        {
            return context.Brands.ToList();
        } 
    }
}
