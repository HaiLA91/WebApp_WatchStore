using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class WatchStoreContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            builder.UseSqlServer(configuration.GetConnectionString("WatchStore"));
        }
    }
}
