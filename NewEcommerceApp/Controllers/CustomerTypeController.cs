using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NewEcommerceApp.BLL.Abstrations;
using NewEcommerceApp.Models.EntityModels;

namespace NewEcommerceApp.Controllers
{
    public class CustomerTypeController : Controller
    {
        ICustomerTypeManager _customerTypeManager;
        public CustomerTypeController(ICustomerTypeManager customerTypeManager)
        {
            _customerTypeManager = customerTypeManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerType model)
        {

            if (ModelState.IsValid)
            {
                CustomerType customerType = new CustomerType();
                customerType.Id = model.Id;
                customerType.Name = model.Name;

                bool isSaved = _customerTypeManager.Add(customerType);

                if (isSaved)
                {
                    return RedirectToAction("List", "CustomerType", null);
                }

            }

            return View();
        }


        public IActionResult List()
        {
            // get all customers from db 

            ICollection<CustomerType> customerTypes = _customerTypeManager.GetAll();

            //show the customers in VIEW
            return View(customerTypes);
        }

        //customer/edit/id
        public IActionResult Edit(int? id)
        {

            if (id != null && id > 0)
            {
                CustomerType existingCustomerType = _customerTypeManager.GetById(id);

                if (existingCustomerType != null)
                {
                    return View(existingCustomerType);
                }

            }

            return View();

        }

        [HttpPost]
        public IActionResult Edit(CustomerType customerType)
        {
            bool isUpdated = _customerTypeManager.Update(customerType);

            if (isUpdated)
            {
                return RedirectToAction("List");
            }

            return View(customerType);
        }

        public IActionResult Delete(int? id)
        {
            if (id != null && id > 0)
            {
                CustomerType customerType = _customerTypeManager.GetById(id);

                bool isdelete = _customerTypeManager.Remove(customerType);
                if (isdelete)
                {
                    return RedirectToAction("List");
                }
            }
            return RedirectToAction("List");
        }
    }
}