using System;
using System.Collections.Generic;
using System.Text;

namespace NewEcommerceApp.Models.RequestModels
{
    public class CustomerRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
