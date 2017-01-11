using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Models
{
    public class OrderItemForCreationDto
    {
       
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public decimal PurchasePrice { get; set; }
        
    }
}
