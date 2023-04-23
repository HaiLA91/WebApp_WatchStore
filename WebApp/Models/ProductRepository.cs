using Dapper;
using System.Data;

namespace WebApp.Models
{
    public class ProductRepository : BaseRepository
    {
        public ProductRepository(IDbConnection connection) : base(connection)
        {
        }

        public IEnumerable<ProductAndBrand> GetProductAndBrands()
        {
            string sql = "SELECT Product.*, BrandName FROM Product JOIN Brand ON Product.BrandId = Brand.BrandId AND Product.IsPopular = 1";
            return connection.Query<ProductAndBrand>(sql);
        }

        public IEnumerable<Product> GetProductbyBrands(short id)
        {
            string sql = "SELECT * FROM Product WHERE BrandId = @Id";
            return connection.Query<Product>(sql, new { Id = id });
        }
        public IEnumerable<Product> GetProductbyCategory(short id)
        {
            string sql = "SELECT * FROM Product WHERE CategoryId = @Id";
            return connection.Query<Product>(sql, new { Id = id });
        }
        public IEnumerable<Product> GetProduct()
        {
            string sql = "SELECT * From Product";
            return connection.Query<ProductAndBrand>(sql);
        }
        //public async Task<List<Product>> GetStatuses()
        //{
        //    return await Get<List<Product>>("/api/product");
        //}
        //public async Task<Product> GetStatusById(byte id)
        //{
        //    return await Get<Product>($"/api/product/{id}");
        //}
        //public async Task<int> Add(Product obj)
        //{
        //    return await Post<Product, int>("/api/product", obj);
        //}
        //public async Task<int> Edit(Product obj)
        //{
        //    return await Put<Product, int>("/api/product", obj);
        //}
        //public async Task<int> Delete(byte id)
        //{
        //    return await Delete<int>($"/api/product/{id}");
        //}
    }
}
