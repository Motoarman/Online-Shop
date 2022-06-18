using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Online_Shop.Models;

namespace Online_Shop.Data
{
    public class OnlineShopContext : DbContext
    {
        public OnlineShopContext (DbContextOptions<OnlineShopContext> options)
            : base(options)
        {
        }

        public DbSet<Online_Shop.Models.Categories> Categories { get; set; }

        public DbSet<Online_Shop.Models.Products> Products { get; set; }

        public DbSet<Online_Shop.Models.Orders> Orders { get; set; }

        public DbSet<Online_Shop.Models.PurchaceItem> PurchaceItems { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }






    }
}
