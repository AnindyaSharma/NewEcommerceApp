using NewEcommerceApp.BLL.Abstrations.Base;
using NewEcommerceApp.Models.EntityModels;
using NewEcommerceApp.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEcommerceApp.BLL.Abstrations
{
    public interface ICustomerManager:IManager<Customer>
    {
        
        Customer GetById(int? id);
        ICollection<Customer> GetByRequest(CustomerRequestModel customer);
    }
}
