using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online_Shop.Areas.Identity.Data;
using Online_Shop.Models;


namespace Online_Shop.Data
{
    public class Online_ShopContext : IdentityDbContext<Online_ShopUser>
    {
        public Online_ShopContext(DbContextOptions<Online_ShopContext> options)
            : base(options)
        {
        }

        public DbSet<Categories> Categories { get; set; }

        public DbSet<Online_Shop.Models.Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

           
        }

        


    }
}
