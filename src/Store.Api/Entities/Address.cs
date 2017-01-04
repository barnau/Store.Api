using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Entities
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        //[ForeignKey("CustomerId")]
        //public Customer customer { get; set; }
        //public int CustomerId { get; set; }

        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}
