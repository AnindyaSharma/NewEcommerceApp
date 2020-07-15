using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewEcommerceApp.BLL.Abstrations;
using NewEcommerceApp.Models.EntityModels;

namespace NewEcommerceApp.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryManager _categoryManager;
        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
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
        public IActionResult Create(Category model)
        {

            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.Id = model.Id;
                category.Name = model.Name;

                bool isSaved = _categoryManager.Add(category);

                if (isSaved)
                {
                    return RedirectToAction("List", "Category", null);
                }

            }

            return View();
        }


        public IActionResult List()
        {
            // get all customers from db 

            ICollection<Category> categories = _categoryManager.GetAll();

            //show the customers in VIEW
            return View(categories);
        }

        //customer/edit/id
        public IActionResult Edit(int? id)
        {

            if (id != null && id > 0)
            {
                Category existingCategory = _categoryManager.GetById(id);

                if (existingCategory != null)
                {
                    return View(existingCategory);
                }

            }

            return View();

        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            bool isUpdated = _categoryManager.Update(category);

            if (isUpdated)
            {
                return RedirectToAction("List");
            }

            return View(category);
        }

        public IActionResult Delete(int? id)
        {
            if (id != null && id > 0)
            {
                var category = _categoryManager.GetById(id);

                bool isdelete = _categoryManager.Remove(category);
                if (isdelete)
                {
                    return RedirectToAction("List");
                }
            }
            return RedirectToAction("List");
        }
    }
}