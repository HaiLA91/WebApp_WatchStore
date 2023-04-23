using Microsoft.AspNetCore.Authentication.Cookies;
using WebApp;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddScoped(p => new SiteProvider(builder.Configuration));
builder.Services.AddScoped(p => new CartFilter(p.GetRequiredService<SiteProvider>()));
builder.Services.AddScoped(p => new CategoryFilter(p.GetRequiredService<SiteProvider>()));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(p =>
{
    p.LoginPath = "/auth/Login";
});
var app = builder.Build();
app.UseRouting();
app.UseStaticFiles();
app.MapDefaultControllerRoute();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Dashboard", 
    pattern: "{area:exists}/{controller=home}/{action=index}/{id?}");
app.UseAuthentication();
app.UseAuthorization();
app.Run();
