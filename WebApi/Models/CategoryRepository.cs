namespace WebApi.Models
{
    public class CategoryRepository : BaseRepository
    {
        public CategoryRepository(WatchStoreContext context) : base(context)
        {

        }
        public List<Category> GetCategories()
        {
            return context.Categories.ToList();
        }
    }
}
