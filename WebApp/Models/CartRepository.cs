using Dapper;
using System.Data;

namespace WebApp.Models
{
    public class CartRepository : BaseRepository
    {
        public CartRepository(IDbConnection connection) : base(connection)
        {
        }
        public int Delete(Cart obj)
        {
            return connection.Execute("DELETE FROM Cart WHERE CartCode = @Code AND ProductId = @ProductId", new
            {
                Code = obj.CartCode,
                ProductId = obj.ProductId
            });
        }
        public int Edit(Cart obj)
        {
            return connection.Execute("UPDATE Cart SET Quantity= @Quantity, UpdateDate = GETDATE() WHERE CartCode = @Code AND ProductId = @ProductId",
                new { Code = obj.CartCode, ProductId = obj.ProductId, Quantity = obj.Quantity });
        }
        public int Save(Cart obj)
        {
            return connection.Execute("SaveCart", new { Code = obj.CartCode, ProductId = obj.ProductId, Quantity = obj.Quantity }, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<Cart> GetCarts(string code)
        {
            string sql = "SELECT CartCode, Cart.ProductId, Quantity, ProductName, UnitPrice, SaleOfPrice, ImageUrl FROM Cart JOIN Product " +
                            "ON Cart.ProductId = Product.ProductId AND CartCode = @Code";
            return connection.Query<Cart>(sql, new { Code = code });
        }
        public int Count(string code)
        {
            string sql = "SELECT SUM(Quantity) FROM Cart WHERE CartCode = @Code";
            return connection.ExecuteScalar<int>(sql, new { Code = code });
        }
    }
}
