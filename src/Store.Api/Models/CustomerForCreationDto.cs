using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Models
{
    public class CustomerForCreationDto
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public AddressForCreationDto MyProperty { get; set; }
    }
}
