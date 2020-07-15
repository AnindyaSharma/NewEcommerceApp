using System;
using System.Collections.Generic;
using System.Text;

namespace NewEcommerceApp.Models.EntityModels
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
