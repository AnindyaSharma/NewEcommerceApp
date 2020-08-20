using NewEcommerceApp.BLL.Abstrations;
using NewEcommerceApp.BLL.Abstrations.Base;
using NewEcommerceApp.Models.EntityModels;
using NewEcommerceApp.Models.RequestModels;
using NewEcommerceApp.Repository.Abstrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEcommerceApp.BLL
{
    public class ProductManager : Manager<Product>, IProductManager
    {
        IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetById(int? id)
        {
            if (id != null)
            {
                return _productRepository.GetById(id);
            }
            return null;
        }
        public ICollection<Product> GetByRequest(ProductRequestModel product)
        {
            return _productRepository.GetByRequest(product);
        }
    }
}
