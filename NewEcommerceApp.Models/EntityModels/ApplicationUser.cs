using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEcommerceApp.Models.EntityModels
{
    public class ApplicationUser: IdentityUser
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
    }
}
