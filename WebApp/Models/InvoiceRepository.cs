using Dapper;
using System.Data;
using Utils;

namespace WebApp.Models
{
    public class InvoiceRepository : BaseRepository
    {
        public InvoiceRepository(IDbConnection connection) : base(connection)
        {
        }
        public int Add(Invoice obj)
        {
            obj.InvoiceId = Helper.RandomString(8);
            return connection.Execute("AddInvoice", new
            {
                AddressId = obj.AddressId,
                CartCode = obj.CartCode,
                MemberId = obj.MemberId,
                InvoiceId = obj.InvoiceId
            }, commandType: CommandType.StoredProcedure);

        }
    }
}
