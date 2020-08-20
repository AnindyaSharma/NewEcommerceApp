using AutoMapper;
using NewEcommerceApp.Models.EntityModels;
using NewEcommerceApp.Models.RequestModels;

namespace NewEcommerceApp.API.AutoMapperProfiles
{
    public class EcommerceAutoMapperProfile: Profile
    {
        public EcommerceAutoMapperProfile()
        {
            CreateMap<CustomerCreateDTO, Customer>();
            CreateMap<CustomerUpdateDTO, Customer>();
            CreateMap<Customer, CustomerUpdateDTO>();

            CreateMap<ProductCreateDTO, Product>();
            CreateMap<ProductUpdateDTO, Product>();
            CreateMap<Product, ProductUpdateDTO>();
        }
    }
}
