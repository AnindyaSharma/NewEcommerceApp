using NewEcommerceApp.Models.EntityModels;
using NewEcommerceApp.Repository.Abstrations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEcommerceApp.Repository.Abstrations
{
    public interface ICustomerTypeRepository:IRepository<CustomerType>
    {
        CustomerType GetById(int? id);
    }
}
