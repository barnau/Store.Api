using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Models
{
    public class OrderForUpdateDto
    {
        public DateTime? OrderDate { get; set; }
        public int ShippingAddressId { get; set; }
    }
}
