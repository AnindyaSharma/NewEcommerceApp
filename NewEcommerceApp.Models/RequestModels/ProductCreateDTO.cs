using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewEcommerceApp.Models.RequestModels
{
    public class ProductCreateDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product should have a name")]
        public string Name { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
        public string Code { get; set; }
        public byte[] Image { get; set; }
        public int? CategoryId { get; set; }
    }
}
