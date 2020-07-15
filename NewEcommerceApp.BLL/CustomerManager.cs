using NewEcommerceApp.BLL.Abstrations;
using NewEcommerceApp.BLL.Abstrations.Base;
using NewEcommerceApp.Models.EntityModels;
using NewEcommerceApp.Models.RequestModels;
using NewEcommerceApp.Repository;
using NewEcommerceApp.Repository.Abstrations;
using System.Collections.Generic;

namespace NewEcommerceApp.BLL
{
    public class CustomerManager: Manager<Customer>,ICustomerManager
    {
        ICustomerRepository _customerRepository;
        public CustomerManager(ICustomerRepository customerManager) :base(customerManager)
        {
            _customerRepository = customerManager;
        }

        public Customer GetById(int? id)
        {
            if (id != null)
            {
                return _customerRepository.GetById(id);
            }
            return null;
        }

        public ICollection<Customer> GetByRequest(CustomerRequestModel customer)
        {
            return _customerRepository.GetByRequest(customer);
        }
    }
}
