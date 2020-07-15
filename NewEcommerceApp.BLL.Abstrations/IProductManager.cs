using NewEcommerceApp.BLL.Abstrations.Base;
using NewEcommerceApp.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEcommerceApp.BLL.Abstrations
{
    public interface IProductManager:IManager<Product>
    {
        Product GetById(int? id);
    }
}
