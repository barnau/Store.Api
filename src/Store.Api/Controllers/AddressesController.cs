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
    [Route("api/customers/{customerid}/addresses")]
    public class AddressesController : Controller
    {
        IAddressRepository _addressRepository;

        public AddressesController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet("{id}", Name = "GetAddress")]
        public IActionResult GetAddress(int customerId, int id)
        {
           var address = _addressRepository.GetAddressForCustomer(customerId, id);

            if(address == null)
            {
                return NotFound();
            }

            var addressToRetrun = Mapper.Map<AddressDto>(address);

            return Ok(addressToRetrun);
        }

        [HttpGet()]
        public IActionResult getAddress(int customerId)
        {
            var addresses = _addressRepository.GetAddresses(customerId);
            var result = Mapper.Map<List<AddressDto>>(addresses);

            return Ok(result);
        }

        [HttpPost()]
        public IActionResult AddAddress(int customerId, [FromBody] AddressForCreationDto address)
        {

            if(!_addressRepository.CustomerExists(customerId))
            {
                return NotFound();
            }

            if (address == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var addressEntity = Mapper.Map<Address>(address);

            _addressRepository.AddAddress(customerId, addressEntity);

            if (!_addressRepository.Save())
            {
                return StatusCode(500, "There was a problem handling this request.");
            }

            return NoContent();




        }

        [HttpPatch("{id}")]
        public IActionResult PatchAddress(int customerId, int id, [FromBody] JsonPatchDocument<AddressForUpdateDto> patchDoc)
        {
            if(patchDoc == null)
            {
                return BadRequest();
            }

            if (!_addressRepository.CustomerExists(customerId))
            {
                return NotFound();
            }

            var addressEntity = _addressRepository.GetAddressForCustomer(customerId, id);
            if (addressEntity == null)
            {
                return NotFound();
            }

            var addressToPatch = Mapper.Map<AddressForUpdateDto>(addressEntity);

            

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            patchDoc.ApplyTo(addressToPatch, ModelState);

            TryValidateModel(addressToPatch);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mapper.Map(addressToPatch, addressEntity);

            if (!_addressRepository.Save())
            {
                return StatusCode(500, "A problem happend while handling this request");
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutAddress(int customerId, int id, [FromBody] AddressForUpdateDto address)
        {
            if (address == null)
            {
                BadRequest();
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            var addressEntity = _addressRepository.GetAddressForCustomer(customerId, id);

            if (addressEntity == null)
            {
                return NotFound();
            }

            Mapper.Map(address, addressEntity);

            if (!_addressRepository.Save())
            {
                return StatusCode(500, "A problem happend while handling your request");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAddress(int customerId, int id)
        {
            if(_addressRepository.AddressExists(customerId, id))
            {
                return NotFound();
            }

            var addressToRemove = _addressRepository.GetAddressForCustomer(customerId, id);
            _addressRepository.DeleteAddress(addressToRemove);

            if (!_addressRepository.Save())
            {
                return StatusCode(500, "A problem happend while handling your request.");
            }

            return NoContent();
        }
    }
}
