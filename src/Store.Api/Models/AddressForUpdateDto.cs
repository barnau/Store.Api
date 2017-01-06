using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Models
{
    public class AddressForUpdateDto
    {
        [Required]
        [MaxLength(150)]
        public string StreetLine1 { get; set; }
        [MaxLength(150)]
        public string StreetLine2 { get; set; }
        [Required]
        [MaxLength(75)]
        public string City { get; set; }
        [Required]
        [MaxLength(2)]
        public string State { get; set; }
        [Required]
        public string PostalCode { get; set; }
    }
}
