using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewEcommerceApp.BLL.Abstrations;
using NewEcommerceApp.Models;
using NewEcommerceApp.Models.EntityModels;

namespace NewEcommerceApp.Controllers
{
    public class ProductController : Controller
    {
        IProductManager productManager;
        ICategoryManager categoryManager;
        IMapper mapper;
        public ProductController(IProductManager _productManager,ICategoryManager _categoryManager,IMapper _mapper)
        {
            productManager = _productManager;
            categoryManager = _categoryManager;
            mapper = _mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            ProductCreateViewModel product = new ProductCreateViewModel();
            product.CatagoryItem = categoryManager.GetAll()
                                                   .Select(c => new SelectListItem()
                                                   {
                                                       Text = c.Name,
                                                       Value = c.Id.ToString()
                                                   }).ToList();
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateViewModel entity, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product()
                {
                    Name = entity.Name,
                    Quantity = entity.Quantity,
                    Code = entity.Code,
                    Price = entity.Price,
                    CategoryId = entity.CategoryId
                };

                if (Image.Length > 0)
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        await Image.CopyToAsync(stream);
                        product.Image = stream.ToArray();
                    }
                }

                bool isSave = productManager.Add(product);
                if (isSave)
                {
                    return RedirectToAction("List");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            ICollection<Product> products = productManager.GetAll();
            return View(products);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var model = new ProductEditViewModel();
            model.CatagoryItem = categoryManager.GetAll()
                                                   .Select(c => new SelectListItem()
                                                   {
                                                       Text = c.Name,
                                                       Value = c.Id.ToString()
                                                   }).ToList();

            if (id != null && id > 0)
            {
                Product product = productManager.GetById(id);
                if (product != null)
                {
                    mapper.Map<Product, ProductEditViewModel>(product, model);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task< IActionResult> Edit(Product product, IFormFile Image)
        {
            if (Image.Length > 0)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    await Image.CopyToAsync(stream);
                    product.Image = stream.ToArray();
                }
            }
            bool isSave = productManager.Update(product);
            if (isSave)
            {
                return RedirectToAction("List");
            }
            return View(product);
        }

        public IActionResult Delete(int? id)
        {
            if (id != null && id > 0)
            {
                Product product = productManager.GetById(id);
                bool isSave = productManager.Remove(product);
                if (isSave)
                {
                    return RedirectToAction("List");
                }
            }
            return RedirectToAction("List");
        }
    }
}