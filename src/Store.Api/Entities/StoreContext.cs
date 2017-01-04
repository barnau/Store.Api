using Microsoft.EntityFrameworkCore;
using Store.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Entities
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        
    }
}
