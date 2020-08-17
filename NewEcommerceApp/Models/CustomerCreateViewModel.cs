using Microsoft.AspNetCore.Mvc.Rendering;
using NewEcommerceApp.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewEcommerceApp.Models
{
    public class CustomerCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public int CustomerTypeId { get; set; }

        public ICollection<CustomerRepsonseModel> CustomerList { get; set; }
        public ICollection<SelectListItem> CustomerTypeItem { get; set; }
    }
}
