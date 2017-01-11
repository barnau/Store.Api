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
    [Route("api/customers/{customerId}/orders")]
    public class OrdersController : Controller
    {
        private IOrderRepository _orderRepository;
        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("{id}", Name ="GetOrder")]
        public IActionResult GetOrder(int customerId, int id)
        {
            var order = _orderRepository.GetOrderForCustomer(customerId, id);

            if (order == null)
            {
                return NotFound();
            }

            var result = Mapper.Map<OrderDto>(order);
            return Ok(result);
        }
        [HttpGet()]
        public IActionResult GetOrders(int customerId)
        {
            if(!_orderRepository.CustomerExists(customerId))
            {
                return NotFound();
            }

            var orders = _orderRepository.GetOrdersForCustomer(customerId);

            if(orders == null)
            {
                return NotFound();
            }

            var ordersToReturn = Mapper.Map<List<OrderDto>>(orders);

            return Ok(ordersToReturn);
        }

        [HttpPost()]
        public IActionResult PostOrder(int customerId, [FromBody] OrderForCreationDto order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(!_orderRepository.CustomerExists(customerId))
            {
                return NotFound();
            }
            if (order == null)
            {
                return BadRequest();
            }


            var orderEntity = Mapper.Map<Order>(order);

            _orderRepository.AddOrder(customerId, orderEntity);

            if(!_orderRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling this request.");
            }

            var orderToReturn = Mapper.Map<OrderDto>(orderEntity);
            return CreatedAtRoute("GetOrder", new { customerId = orderEntity.CustomerId, id = orderEntity.Id }, orderToReturn);
        }

        [HttpPut("{id}")] 
        public IActionResult PutOrder(int customerId, int id, [FromBody] OrderForUpdateDto order)
        {
            if(order == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_orderRepository.CustomerExists(customerId))
            {
                return NotFound();
            }

            var orderEntity = _orderRepository.GetOrderForCustomer(customerId, id);

            Mapper.Map(order, orderEntity);

            if(!_orderRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling this request");
            }

            return NoContent();



        }

        [HttpPatch("{id}")]
        public IActionResult PatchOrder(int customerId, int id, [FromBody] JsonPatchDocument<OrderForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }
            if (!_orderRepository.CustomerExists(customerId))
            {
                return NotFound();
            }

            var orderEntity = _orderRepository.GetOrderForCustomer(customerId, id);

            if (orderEntity == null)
            {
                return NotFound();
            }

            var orderToPatch = Mapper.Map<OrderForUpdateDto>(orderEntity);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            patchDoc.ApplyTo(orderToPatch, ModelState);

            TryValidateModel(orderToPatch);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mapper.Map(orderToPatch, orderEntity);

            if (!_orderRepository.Save())
            {
                return StatusCode(500, "A problem happend while handling your request.");
            }

            return NoContent();


        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int customerId, int id)
        {
            if (!_orderRepository.CustomerExists(customerId))
            {
                return NotFound();
            }

            var orderEntity = _orderRepository.GetOrderForCustomer(customerId, id);
            _orderRepository.DeleteOrder(orderEntity);

            if (!_orderRepository.Save())
            {
                return StatusCode(500, "A problem happend while handling your request.");
            }
            return NoContent();
        }



    }
}
