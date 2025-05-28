using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MyFootwear.Models
{
    public class MyFootwearContext:DbContext
    {
        public MyFootwearContext()
        {

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyFootwearContext>());
        }
        public DbSet<Product> Products { get; set; }        
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<RegCust> CustomerRegister { get; set; }
        public DbSet<Cart> Carts { get; set; }

    }
}