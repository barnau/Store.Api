using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Controllers
{
    [Route("api/orderdisplays")]
    public class OrderDisplaysController : Controller
    {
        [HttpGet("{id}")]
        public IActionResult GetOrderDisplay(int id)
        {
            var result = "Get route by order id";
            return Ok(result);
        }

        [HttpPost()]
        public IActionResult PostOrderDisplay()
        {
            return Ok("This is the post order route.");
        }

        [HttpPut("{id}")]
        public IActionResult PutOrderDisplay(int id)
        {
            return Ok("This is the put order route id: " + id);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchOrderDisplay(int id)
        {
            return Ok("This is the put order route id: " + id);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrderDisplay(int id)
        {
            return Ok("This is the delete route for order id: " + id);
        }



    }
}
