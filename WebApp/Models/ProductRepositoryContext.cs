namespace WebApp.Models
{
    public class ProductRepositoryContext : BaseRepositoryContext
    {
        public ProductRepositoryContext(WatchStoreContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetStatuses()
        {
            return await Get<List<Product>>("/api/product");
        }
        public async Task<Product> GetStatusById(byte id)
        {
            return await Get<Product>($"/api/product/{id}");
        }
        public async Task<int> Add(Product obj)
        {
            return await Post<Product, int>("/api/product", obj);
        }
        public async Task<int> Edit(Product obj)
        {
            return await Put<Product, int>("/api/product", obj);
        }
        public async Task<int> Delete(byte id)
        {
            return await Delete<int>($"/api/product/{id}");
        }
    }
}
