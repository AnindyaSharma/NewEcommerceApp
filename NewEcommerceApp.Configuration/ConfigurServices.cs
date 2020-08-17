using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewEcommerceApp.BLL;
using NewEcommerceApp.BLL.Abstrations;
using NewEcommerceApp.Database;
using NewEcommerceApp.Repository;
using NewEcommerceApp.Repository.Abstrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEcommerceApp.Configuration
{
    public static class ConfigurServices
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NewEcommerceDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetSection("Connectionstring:Defaultconnection").Value);
            });

            services.AddTransient<ICustomerManager, CustomerManager>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddTransient<ICategoryManager, CategoryManager>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddTransient<IProductManager, ProductManager>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<ICustomerTypeManager, CustomerTypeManager>();
            services.AddTransient<ICustomerTypeRepository, CustomerTypeRepository>();

            services.AddTransient<DbContext, NewEcommerceDbContext>();
            

        }
    }
}
