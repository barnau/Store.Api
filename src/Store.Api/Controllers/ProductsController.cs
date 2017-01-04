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
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet()]
        public IActionResult GetProducts()
        {
            var products = _productRepository.GetProducts();
            var results = Mapper.Map<IEnumerable<ProductDto>>(products);

            return Ok(results);
           

        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetProduct(int id)
        {
            if(!_productRepository.ProductExists(id))
            {
                return NotFound();
            }

            var product = _productRepository.GetProduct(id);
            var result = Mapper.Map<ProductDto>(product);

            return Ok(result);


        }

        [HttpPost()]
        public IActionResult PostProduct([FromBody] ProductForCreationDto product)
        {

            if (product == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            
            var finalProduct = Mapper.Map<Product>(product);

            _productRepository.AddProduct(finalProduct);

            if (!_productRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            var createdProductToReturn = Mapper.Map<ProductDto>(finalProduct);
            return CreatedAtRoute("GetProduct", new { id = finalProduct.Id }, createdProductToReturn);

            

           
        }

        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, [FromBody] ProductForUpdateDto product)
        {
            if(product == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_productRepository.ProductExists(id))
            {
                return NotFound();
            }

            var productEntity = _productRepository.GetProduct(id);
            Mapper.Map(product, productEntity);

            if(!_productRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchProduct(int id, [FromBody] JsonPatchDocument<ProductForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }


            if (!_productRepository.ProductExists(id))
            {
                return NotFound();
            }

            var productEntity = _productRepository.GetProduct(id);

            if (productEntity == null)
            {
                return NotFound();
            }

            var productToPatch = Mapper.Map<ProductForUpdateDto>(productEntity);

            patchDoc.ApplyTo(productToPatch, ModelState);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TryValidateModel(productToPatch);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mapper.Map(productToPatch, productEntity);

            if(!_productRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();


        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            if(!_productRepository.ProductExists(id))
            {
                return NotFound();
            }

            var productEntity = _productRepository.GetProduct(id);

            _productRepository.DeleteProduct(productEntity);

            if(!_productRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

    }
}
