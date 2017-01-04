using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ShippingAddressId { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
