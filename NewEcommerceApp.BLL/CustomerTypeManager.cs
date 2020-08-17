using NewEcommerceApp.BLL.Abstrations;
using NewEcommerceApp.BLL.Abstrations.Base;
using NewEcommerceApp.Models.EntityModels;
using NewEcommerceApp.Repository.Abstrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEcommerceApp.BLL
{
    public class CustomerTypeManager:Manager<CustomerType>, ICustomerTypeManager
    {
        ICustomerTypeRepository _customerTypeRepository;
        public CustomerTypeManager(ICustomerTypeRepository customerTypeRepository) : base(customerTypeRepository)
        {
            _customerTypeRepository = customerTypeRepository;
        }

        public CustomerType GetById(int? id)
        {
            if (id != null)
            {
                return _customerTypeRepository.GetById(id);
            }
            return null;
        }
    }
}
