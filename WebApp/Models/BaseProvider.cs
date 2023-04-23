using System.Data;
using System.Data.SqlClient;

namespace WebApp.Models
{
    public class BaseProvider : IDisposable
    {
        IDbConnection connection;
        string connectionString;
        public BaseProvider(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("WatchStore");
        }
        //lop con se thay properties
        protected IDbConnection Connection
        {
            get
            {
                if (connection is null)
                {
                    connection = new SqlConnection(connectionString);
                }
                return connection;
            }
        }
        public void Dispose()
        {
            if (connection != null)
            {
                connection.Dispose();
            };
        }
    }
}
