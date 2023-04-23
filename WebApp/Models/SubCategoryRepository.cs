using Dapper;
using System.Data;

namespace WebApp.Models
{
    public class SubCategoryRepository : BaseRepository
    {
        public SubCategoryRepository(IDbConnection connection) : base(connection)
        {
        }

        public IEnumerable<SubCategory> GetSubCategories()
        {
            return connection.Query<SubCategory>("SELECT * FROM SubCategory");
        }
    }
}
