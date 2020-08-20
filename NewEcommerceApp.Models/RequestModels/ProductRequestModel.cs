using System;
using System.Collections.Generic;
using System.Text;

namespace NewEcommerceApp.Models.RequestModels
{
    public class ProductRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
        public string Code { get; set; }
        public int? CategoryId { get; set; }
    }
}
