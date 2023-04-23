using Utils;
namespace WebApi.Models
{
    public class MemberRepository : BaseRepository
    {
        public MemberRepository(WatchStoreContext context) : base(context)
        {
        }
        public int Add(RegisterModel obj)
        {
            context.Members.Add(new Member
            {
                Id = Helper.RandomString(32),
                Phone = obj.Phone,
                Username = obj.Username,
                Password = Helper.Hash(obj.Username + "@#$!&" + obj.Password),
                Role = obj.Role
            });
            return context.SaveChanges();
        }
        public Member Login(LoginModel obj)
        {
            return context.Members
                .Where(p => p.Username == obj.Usr && p.Password == Helper.Hash(obj.Usr + "@#$!&" + obj.Pwd))
                .Select(p => new Member
                {
                    Id = p.Id,
                    Username = p.Username,
                    Phone = p.Phone,
                    Role = p.Role
                }).SingleOrDefault();
        }
    }
}
