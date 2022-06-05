#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameShop.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Data
{
    public class GameShopContext : DbContext
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
