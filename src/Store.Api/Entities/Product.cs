using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal StarRating { get; set; }
        public string ImageUrl { get; set; }
    }
}
