using Microsoft.AspNetCore.Mvc;
using Store.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Controllers
{
    public class DummyController : Controller
    {
        private StoreContext _storeContext;

        public DummyController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        [HttpGet("api/testdatabase")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }

    }
}
