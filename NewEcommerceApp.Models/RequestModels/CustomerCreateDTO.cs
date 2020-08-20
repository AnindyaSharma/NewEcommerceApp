using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewEcommerceApp.Models.RequestModels
{
    public class CustomerCreateDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Customer should have a name")]
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public int? CustomerTypeId { get; set; }
    }
}
