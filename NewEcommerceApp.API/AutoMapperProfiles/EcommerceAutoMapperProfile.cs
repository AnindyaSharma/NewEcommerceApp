using AutoMapper;
using NewEcommerceApp.Models;
using NewEcommerceApp.Models.EntityModels;
using NewEcommerceApp.Models.RequestModels;
using NewEcommerceApp.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewEcommerceApp.API.AutoMapperProfiles
{
    public class EcommerceAutoMapperProfile: Profile
    {
        public EcommerceAutoMapperProfile()
        {
            CreateMap<CustomerCreateDTO, Customer>();
            CreateMap<CustomerUpdateDTO, Customer>();
            CreateMap<Customer, CustomerUpdateDTO>();
        }
    }
}
