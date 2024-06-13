using Microsoft.EntityFrameworkCore;
using PhoneShopSharedLib.Models;

namespace PhoneShopServer.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        //use prop to create the property
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Category>Categories  { get; set; } = default!;
    }
}
