using Microsoft.EntityFrameworkCore;
using NewEcommerceApp.Database;
using NewEcommerceApp.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEcommerceApp.Repositories
{
    public class CustomerRepository
    {
        NewEcommerceDbContext db;
        public CustomerRepository(DbContext _db)
        {
            db = (NewEcommerceDbContext)_db;
        }

        public bool Add (Customer entity)
        {

        }
    }
}
