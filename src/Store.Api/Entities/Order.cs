using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }


        public int ShippingAddressId { get; set; }
        public Address ShippingAddress { get; set; }
        
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
