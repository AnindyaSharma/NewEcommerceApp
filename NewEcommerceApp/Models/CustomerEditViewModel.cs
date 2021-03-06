﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewEcommerceApp.Models
{
    public class CustomerEditViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public int CustomerTypeId { get; set; }
                
        public ICollection<SelectListItem> CustomerTypeItem { get; set; }
    }
}
