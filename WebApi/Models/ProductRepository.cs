namespace WebApi.Models
{
    public class ProductRepository : BaseRepository
    {
        public ProductRepository(WatchStoreContext context) : base(context)
        {

        }
        public List<Product> GetStatuses()
        {
            return context.Products.ToList();
        }
        public int Add(Product obj)
        {
            context.Products.Add(obj);
            return context.SaveChanges();
        }
        public int Edit(Product obj)
        {
            context.Products.Update(obj);
            return context.SaveChanges();
        }
        public int Delete(byte id)
        {
            context.Products.Remove(new Product { ProductId = id });
            return context.SaveChanges();
        }
        public Product GetStatusById(byte id)
        {

            return context.Products.Find(id);

        }

    }
}
