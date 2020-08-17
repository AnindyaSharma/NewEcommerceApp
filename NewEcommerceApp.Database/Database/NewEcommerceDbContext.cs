using Microsoft.EntityFrameworkCore;
using NewEcommerceApp.Models.EntityModels;

namespace NewEcommerceApp.Database
{
    public class NewEcommerceDbContext:DbContext
    {
        public NewEcommerceDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    //string connectionString = "Server= ANINDYASHARMA01; Database=NewEcommerceDB; Integrated Security=true";
        //    //optionsBuilder.UseSqlServer(connectionString);
        //}
    }
}
