﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using NewEcommerceApp.BLL.Abstrations;
using NewEcommerceApp.Models;
using NewEcommerceApp.Models.EntityModels;
using NewEcommerceApp.Models.ResponseModels;

namespace NewEcommerceApp.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        ICustomerManager _customerManager;
        ICustomerTypeManager _customerTypeManager;
        private readonly ILogger logger;
        IMapper _mapper;
        public CustomerController(ICustomerManager customerManager, IMapper mapper, ICustomerTypeManager customerTypeManager, ILogger<CustomerController> logger)
        {
            _customerManager = customerManager;
            _mapper = mapper;
            _customerTypeManager = customerTypeManager;
            this.logger = logger;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Create()
        {
            CustomerCreateViewModel customer = new CustomerCreateViewModel();
            customer.CustomerList = _customerManager.GetAll().Select(cust => _mapper.Map<CustomerRepsonseModel>(cust)).ToList();

            customer.CustomerTypeItem = _customerTypeManager.GetAll().Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()

            }).ToList();
            return View(customer);
        }

        [HttpPost]
        public IActionResult Create(Customer model)
        {

            if (ModelState.IsValid)
            {
                Customer customer = _mapper.Map<Customer>(model);
                bool isSaved = _customerManager.Add(customer);

                if (isSaved)
                {
                    return RedirectToAction("List", "Customer", null);
                }

            }

            return View();
        }


        public IActionResult List()
        {
            logger.LogTrace("Trace Log");
            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");
            logger.LogError("Error Log");
            logger.LogCritical("Critical Log");
            // get all customers from db 

            ICollection<Customer> customers = _customerManager.GetAll();

            //show the customers in VIEW
            return View(customers);
        }

        //customer/edit/id
        [HttpGet]
        [Authorize]
        public IActionResult Edit(int? id)
        {
            //throw new Exception("Error in Edit View");
                        
            var model = new CustomerEditViewModel();
            model.CustomerTypeItem = _customerTypeManager.GetAll().Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();

            if (id != null && id > 0)
            {
                Customer customer = _customerManager.GetById(id);

                if (customer != null)
                {
                    _mapper.Map<Customer, CustomerEditViewModel>(customer, model);

                    //model.Id = customer.Id;
                    //model.Name = customer.Name;
                    //model.PhoneNo = customer.PhoneNo;
                    //model.Address = customer.Address;
                    //model.CustomerTypeItem = _customerTypeManager.GetAll().Select(c => new SelectListItem()
                    //{
                    //    Text = c.Name,
                    //    Value = c.Id.ToString()
                    //}).ToList();
                    //return View(existingCustomer);

                }

            }

            return View(model);

        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            bool isUpdated = _customerManager.Update(customer);

            if (isUpdated)
            {
                return RedirectToAction("List");
            }

            return View(customer);
        }

        
        //public IActionResult Details(int? id)
        //{
        //    Customer customer = _customerManager.GetById(id.Value);
        //    if (customer == null)
        //    {
        //        Response.StatusCode = 404;
        //        return View("CustomerNotFound", id.Value);
        //    }

        //    if (id != null)
        //    {
        //        return View(customer);
        //    }
        //    return View();
        //}

        public IActionResult Delete(int? id)
        {
            if (id != null && id > 0)
            {
                var customer = _customerManager.GetById(id);

                bool isdelete = _customerManager.Remove(customer);
                if (isdelete)
                {
                    return RedirectToAction("List");
                }
            }
            return RedirectToAction("List");
        }
    }
}