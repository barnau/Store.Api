using Microsoft.AspNetCore.Mvc;
using Store.Api.Entities;
using Store.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Controllers
{
    [Route("api/customers/{customerId}/orders")]
    public class OrdersController : Controller
    {
        [HttpGet("{id}")]
        public IActionResult GetOrder(int customerId, int id)
        {
            var result = "Customer id is : " + customerId + " order id is : " + id;
            return Ok(result);
        }
        
        [HttpPost()]
        public IActionResult PostOrder(int customerId, CustomerForCreationDto customer)
        {
            return Ok("This is the post order route.");
        }

        [HttpPut("{id}")] 
        public IActionResult PutOrder(int id)
        {
            return Ok("This is the put order route id: " + id);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchOrder(int id)
        {
            return Ok("This is the put order route id: " + id);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            return Ok("This is the delete route for order id: " + id);
        }



    }
}
