using NewEcommerceApp.Models.EntityModels;
using NewEcommerceApp.Repository.Abstrations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEcommerceApp.Repository.Abstrations
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Category GetById(int? id);
    }
}
