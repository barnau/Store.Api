﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Models
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<AddressDto> Addresses { get; set; }
        public List<ProductDto> Products { get; set; }
        public List<OrderDto> Orders { get; set; }
    }
}
