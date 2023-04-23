using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
//Api
builder.Services.AddControllers();//api
//khoa bi mat
byte[] key = Encoding.ASCII.GetBytes("qaxwsxedcedcefv@#$plokmijnuhb");
builder.Services.AddAuthentication(p => {
    p.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    p.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(p => {
    p.RequireHttpsMetadata = false;
    p.SaveToken = true;
    p.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
var app = builder.Build();
app.MapControllers();//api
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.Run();