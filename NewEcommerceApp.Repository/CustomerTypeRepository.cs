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
    public class CustomerTypeRepository : Repository<CustomerType>, ICustomerTypeRepository
    {
        NewEcommerceDbContext db;
        public CustomerTypeRepository (DbContext _db) : base(_db)
        {
            db = (NewEcommerceDbContext)_db;
        }

        public override ICollection<CustomerType> GetAll()
        {
            return db.CustomerTypes.ToList();
        }

        public CustomerType GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return GetFirstOrDefault(c => c.Id == id);
        }
    }
}
