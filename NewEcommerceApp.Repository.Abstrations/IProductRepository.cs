using NewEcommerceApp.Models.EntityModels;
using NewEcommerceApp.Models.RequestModels;
using NewEcommerceApp.Repository.Abstrations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEcommerceApp.Repository.Abstrations
{
    public interface IProductRepository:IRepository<Product>
    {
        Product GetById(int? id);
        ICollection<Product> GetByRequest(ProductRequestModel customer);
    }
}
