using Microsoft.EntityFrameworkCore;
using NewEcommerceApp.Models;
using NewEcommerceApp.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewEcommerceApp.Database
{
    public class NewEcommerceDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectionString = "Server= ANINDYASHARMA01; Database=NewEcommerceDB; Integrated Security=true";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
