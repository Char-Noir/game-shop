#nullable disable
using GameShop.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Data
{
    public class GameShopContext : IdentityDbContext<IdentityUser>
    {
        public GameShopContext (DbContextOptions<GameShopContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> Product_Type { get; set; }
        public DbSet<Product_Type> ProductType { get; set; }
        public DbSet<WarhouseItem> WarhouseItem { get; set; }
    }
}
