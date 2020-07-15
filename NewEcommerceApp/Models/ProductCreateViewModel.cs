﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewEcommerceApp.Models
{
    public class ProductCreateViewModel
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
        public string Code { get; set; }
        public int? CategoryId { get; set; }
        public byte[] Image { get; set; }
        
        public ICollection<SelectListItem> CatagoryItem { get; set; }
    }
}
