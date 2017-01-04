using Store.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(70)]
        public string Email { get; set; }
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        //public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
