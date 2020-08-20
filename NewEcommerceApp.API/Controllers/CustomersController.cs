using System;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NewEcommerceApp.BLL.Abstrations;
using NewEcommerceApp.Models.EntityModels;
using NewEcommerceApp.Models.RequestModels;

namespace NewEcommerceApp.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerManager _customerManager;
        IMapper _mapper;
        public CustomersController(ICustomerManager customerManager, IMapper mapper)
        {
            _customerManager = customerManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery]CustomerRequestModel customer)
        {
            var result = _customerManager.GetByRequest(customer);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        // api/customers/1
        [HttpGet("{id}", Name = "GetById")]
        public IActionResult GetbyId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be more then zero");
            }
            var customer = _customerManager.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult PostCustomer([FromBody]CustomerCreateDTO customerDto)
        {
            if (ModelState.IsValid)
            {
                //map to customer entry
                var customerEntry = _mapper.Map<Customer>(customerDto);
                //manager layer > db save custoemr
                bool isSaved = _customerManager.Add(customerEntry);
                if (isSaved)
                {
                    customerDto.Id = customerEntry.Id;
                    //if sucess result show
                    return CreatedAtRoute("GetById", new { id = customerDto.Id }, customerDto);
                }
                else
                {
                    return BadRequest("Customer could not be Save!");
                }

            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // api/customers/1
        [HttpPut("{Id}")]
        public IActionResult PutCustomer(int id,[FromBody] CustomerUpdateDTO customerDTO)
        {
            try
            {
                var existingCustomer = _customerManager.GetById(id);

                if (existingCustomer == null)
                {
                    return NotFound();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                // map update dto data to existing customer data
                var customer = _mapper.Map(customerDTO,existingCustomer);

                bool isUpdate = _customerManager.Update(customer);

                if (isUpdate)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Update Faild!");
                }

            }
            catch (Exception ex)
            {
                return BadRequest("System error occurred please contact vendor!");
            }
            

        }

        [HttpPatch("{Id}")]
        public IActionResult PatchCustomer(int id, [FromBody]JsonPatchDocument<CustomerUpdateDTO> patchDoct)
        {
            var customer = _customerManager.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            var customerDTO = _mapper.Map<CustomerUpdateDTO>(customer);

            patchDoct.ApplyTo(customerDTO);

            _mapper.Map(customerDTO, customer);

            bool isUpdate = _customerManager.Update(customer);

            if (isUpdate)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Update Faild!");
            }
        }
    }
}