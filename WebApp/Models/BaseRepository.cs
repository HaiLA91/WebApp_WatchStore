using System.Data;

namespace WebApp.Models
{
    public class BaseRepository
    {
        protected IDbConnection connection;
        public BaseRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

    }
}
