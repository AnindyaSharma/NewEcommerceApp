using NewEcommerceApp.BLL.Abstrations;
using NewEcommerceApp.BLL.Abstrations.Base;
using NewEcommerceApp.Models.EntityModels;
using NewEcommerceApp.Repository.Abstrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEcommerceApp.BLL
{
    public class CategoryManager:Manager<Category>,ICategoryManager
    {
        ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category GetById(int? id)
        {
            if (id != null)
            {
                return _categoryRepository.GetById(id);
            }
            return null;
        }
    }
}
