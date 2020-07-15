using AutoMapper;
using NewEcommerceApp.Models;
using NewEcommerceApp.Models.EntityModels;
using NewEcommerceApp.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewEcommerceApp.AutoMapperProfiles
{
    public class EcommerceAutoMapperProfile: Profile
    {
        public EcommerceAutoMapperProfile()
        {
            CreateMap<CustomerCreateViewModel, Customer>();
            CreateMap<Customer, CustomerCreateViewModel>();
            CreateMap<Customer, CustomerRepsonseModel>();

            CreateMap<ProductCreateViewModel, Product>();
            CreateMap<Product, ProductCreateViewModel>();
        }
    }
}
