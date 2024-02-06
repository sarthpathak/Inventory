using Inventory.Configurations;
using Inventory.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Inventory.Context
{
    public class Managementdbcontext : DbContext
    {
       

        public Managementdbcontext(DbContextOptions<Managementdbcontext> options) : base(options) { }

        public Managementdbcontext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CategoryConfiguration().Configure(modelBuilder.Entity<ProductCategory>());
            new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
            new OrderConfiguration().Configure(modelBuilder.Entity<Order>());
            new CustomerConfiguration().Configure(modelBuilder.Entity<Customer>());
        }
    }
}
