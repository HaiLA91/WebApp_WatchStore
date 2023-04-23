using Dapper;
using System.Data;

namespace WebApp.Models
{
    public class BrandRepository : BaseRepository
    {
        public BrandRepository(IDbConnection connection) : base(connection)
        {
        }

        public IEnumerable<Brand> GetBrands()
        {
            return connection.Query<Brand>("SELECT * FROM Brand");
        }
        //public async Task<List<Brand>> GetAllBrands()
        //{
        //    return await Get<List<Brand>>("/api/Brand");
        //}

    }
}
