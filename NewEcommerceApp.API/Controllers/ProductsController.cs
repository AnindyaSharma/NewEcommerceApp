using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewEcommerceApp.BLL.Abstrations;
using NewEcommerceApp.Models.EntityModels;
using NewEcommerceApp.Models.RequestModels;

namespace NewEcommerceApp.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductManager _productManager;
        IMapper _mapper;
        public ProductsController(IProductManager productManager,IMapper mapper)
        {
            _productManager = productManager;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll([FromQuery]ProductRequestModel product)
        {
            var result = _productManager.GetByRequest(product);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        // api/product/1
        [HttpGet("{id}", Name = "GetById2")]
        public IActionResult GetbyId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be more then zero");
            }
            var product = _productManager.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult PostProduct([FromBody]ProductCreateDTO productDto)
        {
            if (ModelState.IsValid)
            {
                //map to customer entry
                var productEntry = _mapper.Map<Product>(productDto);
                //manager layer > db save custoemr
                bool isSaved = _productManager.Add(productEntry);
                if (isSaved)
                {
                    productDto.Id = productEntry.Id;
                    //if sucess result show
                    return CreatedAtRoute("GetById2", new { id = productDto.Id }, productDto);
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
        public IActionResult PutProduct(int id, [FromBody] ProductUpdateDTO productDTO)
        {
            try
            {
                var existingProduct = _productManager.GetById(id);

                if (existingProduct == null)
                {
                    return NotFound();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                // map update dto data to existing customer data
                var product = _mapper.Map(productDTO, existingProduct);

                bool isUpdate = _productManager.Update(product);

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
    }
}