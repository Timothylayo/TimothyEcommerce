using Microsoft.EntityFrameworkCore;
using PhoneShopSharedLib.Models;

namespace PhoneShopServer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //use prop to create the property
        public DbSet<Product> Products { get; set; } = default!;
    }
}
