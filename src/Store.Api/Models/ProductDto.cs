using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Models
{
    public class ProductDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductCode { get; set; }
        public DateTime? ReleaseDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal StarRating { get; set; }
        [Required]
        public string ImageUrl { get; set; }

    }
}
