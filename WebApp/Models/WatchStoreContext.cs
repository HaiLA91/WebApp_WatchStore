using Microsoft.EntityFrameworkCore;
namespace WebApp.Models
{
    public class WatchStoreContext : DbContext
    {
            public DbSet<Member> Members { get; set; }
            public DbSet<Brand> Brands { get; set; }    
            public DbSet<Product> Products { get; set; }
            //thieu
            public DbSet<MemberAccessToken> MemberAccessTokens { get; set; }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<MemberAccessToken>().HasNoKey();
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                base.OnConfiguring(optionsBuilder);
                ConfigurationBuilder builder = new ConfigurationBuilder();
                var configuration = builder.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("WatchStore"));
            }

    }
}
