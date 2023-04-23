using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace WebApp.Models
{
    public class MemberRepository : BaseRepositoryContext
    {
        public MemberRepository(WatchStoreContext context) : base(context)
        {
        }
        public async Task<int> Add(RegisterModel obj)
        {
            return await Post<RegisterModel, int>("/api/member/register", obj);
        }
        public async Task<ResponseLogin> Login(LoginModel obj)
        {
            return await Post<LoginModel, ResponseLogin>("/api/member/login", obj);
        }
        public int UpdateToken(Member obj)
        {
            string sql = "UPDATE Member SET AccessToken = @Token WHERE MemberId = @Id";
            SqlParameter[] sp =
            {
                new SqlParameter("@Token", obj.AccessToken),
                new SqlParameter("@Id", obj.Id)
            };
            return context.Database.ExecuteSqlRaw(sql, sp);
        }
    }
}
