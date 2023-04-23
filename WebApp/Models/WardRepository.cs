using Dapper;
using System.Data;
namespace WebApp.Models
{
    public class WardRepository : BaseRepository
    {
        public WardRepository(IDbConnection connection) : base(connection)
        {
        }
        public Ward GetWardById(int id)
        {
            string sql = "SELECT Ward.*, DistrictName, ProvinceName FROM Ward JOIN District ON Ward.DistrictId = District.DistrictId JOIN " +
                "Province ON Province.ProvinceId = District.ProvinceId AND WardId = @Id";
            return connection.QuerySingleOrDefault<Ward>(sql, new { Id = id });
        }
        public IEnumerable<item> SearchWard(string term)
        {
            return connection.Query<item>("SELECT WardId AS Id, WardName As Value FROM Ward WHERE WardName LIKE @Term",
                new { Term = '%' + term + '%' });
        }
        public int Add(List<Ward> list)
        {
            return connection.Execute("INSERT INTO Ward (WardId, DistrictId, WardName, WardType) VALUES (@WardId, @DistrictId, @WardName, @WardType)", list);
        }
        public IEnumerable<Ward> GetWards()
        {
            return connection.Query<Ward>("SELECT * FROM Ward");
        }
        public IEnumerable<Ward> GetWards(short id)
        {
            return connection.Query<Ward>("SELECT * FROM Ward WHERE DistrictId = @Id", new { Id = id });
        }
    }
}
