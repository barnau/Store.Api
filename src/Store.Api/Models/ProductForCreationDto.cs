using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Models
{
    public class ProductForCreationDto
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal StarRating { get; set; }
        public string ImageUrl { get; set; }
    }
}
