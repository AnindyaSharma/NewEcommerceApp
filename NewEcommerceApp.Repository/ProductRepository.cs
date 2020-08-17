using Microsoft.EntityFrameworkCore;
using NewEcommerceApp.BLL.Abstrations.Base;
using NewEcommerceApp.Database;
using NewEcommerceApp.Models.EntityModels;
using NewEcommerceApp.Repository.Abstrations;
using NewEcommerceApp.Repository.Abstrations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NewEcommerceApp.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        NewEcommerceDbContext db;
        public ProductRepository(DbContext _db) : base(_db)
        {
            db = (NewEcommerceDbContext)_db;
        }

        public override ICollection<Product> GetAll()
        {
            return db.Products.Include(c=>c.Category) .ToList();
        }

        public Product GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return GetFirstOrDefault(c => c.Id == id);
        }
    }
}
