﻿using Store.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }

        public int ShippingAddressId { get; set; }
        public int CustomerId { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }


    }
}
