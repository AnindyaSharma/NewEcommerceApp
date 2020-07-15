using Microsoft.EntityFrameworkCore;
using NewEcommerceApp.Database;
using NewEcommerceApp.Models.EntityModels;
using NewEcommerceApp.Repository.Abstrations;
using NewEcommerceApp.Repository.Abstrations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewEcommerceApp.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        NewEcommerceDbContext db;
        public CategoryRepository(DbContext _db) : base(_db)
        {
            db = (NewEcommerceDbContext)_db;
        }


        public Category GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return GetFirstOrDefault(c => c.Id == id);
        }
    }
}
