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
        public DbSet<GameShop.Models.Entity.User> MyUser { get; set; }
        public DbSet<ShopCart> ShopCart { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        public DbSet<GameShop.Models.Entity.Orders> Orders { get; set; }
        public DbSet<GameShop.Models.Entity.OrderDetail> OrderDetails { get; set; }
    }
}
