using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Models
{
    public class AddressForCreationDto
    {
        

        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}
