using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : BaseController
    {
        [HttpPost("register")]
        public int Add(RegisterModel obj)
        {
            obj.Role = "customer";
            return provider.Member.Add(obj);
        }
        [HttpPost("login")]
        public object Login(LoginModel obj)
        {
            Member member = provider.Member.Login(obj);
            //tao token
            string token = CreateToken(member);
            return new
            {
                Token = token,
                Member = member
            };
        }
        const double ExpireHours = 1;
        public static string CreateToken(Member obj)
        {
            byte[] key = Encoding.ASCII.GetBytes("qaxwsxedcedcefv@#$plokmijnuhb");
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                new Claim(ClaimTypes.NameIdentifier, obj.Id),
                new Claim(ClaimTypes.Name, obj.Username),
                new Claim(ClaimTypes.OtherPhone, obj.Phone),
                new Claim(ClaimTypes.Role, obj.Role)
            }),
                Expires = DateTime.UtcNow.AddHours(ExpireHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = handler.CreateToken(descriptor);
            return handler.WriteToken(token);
        }
    }


}
