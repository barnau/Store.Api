using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Entities;
using Store.Api.Models;
using Store.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Controllers
{
    [Route("api/customers")]
    public class CustomersController : Controller
    {
        private ICustomerRepository _customerRepository;
        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult GetCustomer(int id)
        {
            if (!_customerRepository.CustomerExists(id))
            {
                return NotFound();
            }

            var customerEntity = _customerRepository.GetCustomer(id);

           
            var result = Mapper.Map<CustomerDto>(customerEntity);

            return Ok(result);

        }

        [HttpGet()]
        public IActionResult GetCustomers()
        {
            var customerEntities = _customerRepository.GetCustomers();
            var results = Mapper.Map<List<CustomerDto>>(customerEntities);

            return Ok(results);

        }

        [HttpPost()]
        public IActionResult AddCustomer([FromBody] CustomerForCreationDto customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerEntity = Mapper.Map<Customer>(customer);

            _customerRepository.AddCustomer(customerEntity);

            if (!_customerRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            var createdCustomerToReturn = Mapper.Map<CustomerDto>(customerEntity);
            return CreatedAtRoute("GetCustomer", new { id = customerEntity.Id, name = customerEntity.FirstName + " " + customerEntity.LastName }, createdCustomerToReturn);


        }

        [HttpPatch("{id}")]
        public IActionResult PatchCustomer(int id, [FromBody] JsonPatchDocument<CustomerForUpdateDto> patchDoc)
        {
            if(patchDoc == null)
            {
                return BadRequest();
            }

            if(!_customerRepository.CustomerExists(id))
            {
                return NotFound();
            }

            var customerEntity = _customerRepository.GetCustomer(id);

            if (customerEntity == null)
            {
                return NotFound();
            }

            var customerToPatch = Mapper.Map<CustomerForUpdateDto>(customerEntity);

            patchDoc.ApplyTo(customerToPatch, ModelState);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TryValidateModel(customerToPatch);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mapper.Map(customerToPatch, customerEntity);

            if(!_customerRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id, [FromBody] CustomerForUpdateDto customer)
        {
            if(customer == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_customerRepository.CustomerExists(id))
            {
                return NotFound();
            }

            var customerEntity = _customerRepository.GetCustomer(id);

            Mapper.Map(customer, customerEntity);

            if(!_customerRepository.Save())
            {
                return StatusCode(500, "There was a problem handling your request");
            }

            return NoContent();


        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            if(!_customerRepository.CustomerExists(id))
            {
                return NotFound();
            }

            var customerToDelete = _customerRepository.GetCustomer(id);

            _customerRepository.DeleteCustomer(customerToDelete);

            if(!_customerRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }

            return NoContent();
        }
    }
}
