using Microsoft.AspNetCore.Mvc;
using Store.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Controllers
{
    [Route("api/customers")]
    public class CustomersController : Controller
    {
        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer = new CustomerDto()
            {
                Id = id,
                FirstName = "Blaine",
                LastName = "Arnau",
                Email = "blainearnau@gmail.com"
            };

            return Ok(customer);
        }

        [HttpGet()]
        public IActionResult GetCustomers()
        {
            var customers = new List<CustomerDto>()
            {
                new CustomerDto()
                {
                    Id = 1,
                    FirstName = "Blaine",
                    LastName = "Arnau",
                    Email = "blainearnau@gmail.com"
                },
                new CustomerDto()
                {
                    Id = 2,
                    FirstName = "Patty",
                    LastName = "Roots",
                    Email = "pattyroots@gmail.com"
                }
            };

            return Ok(customers);
        }

        [HttpPost()]
        public IActionResult AddCustomer()
        {
            string result = "Add/post customer route executed";

            return Ok(result);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchCustomer(int id)
        {
            string result = "Patch customer route executed for customer id: " + id;

            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id)
        {
            string result = "Put customer route executed for customer id: " + id;

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            return Ok("This is the delete route for customer id: " + id);
        }
    }
}
