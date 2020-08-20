using Microsoft.EntityFrameworkCore;
using NewEcommerceApp.BLL.Abstrations.Base;
using NewEcommerceApp.Database;
using NewEcommerceApp.Models.EntityModels;
using NewEcommerceApp.Models.RequestModels;
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
        public ICollection<Product> GetByRequest(ProductRequestModel product)
        {
            var result = db.Products.AsQueryable();
            if (product == null)
            {
                return result.ToList();
            }
            if (product.Id > 0)
            {
                result = result.Where(c => c.Id == product.Id);
            }
            if (!string.IsNullOrEmpty(product.Name))
            {
                result = result.Where(c => c.Name.ToLower().Contains(product.Name.ToLower()));
            }
            
            if (!string.IsNullOrEmpty(product.Price))
            {
                result = result.Where(c => c.Price.ToLower().Equals(product.Price.ToLower()));
            }
            if (!string.IsNullOrEmpty(product.Code))
            {
                result = result.Where(c => c.Code.ToLower().Contains(product.Code.ToLower()));
            }
            return result.ToList();
        }
    }
}
