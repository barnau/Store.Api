using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Api.Entities;

namespace Store.Api.Services
{
    public class OrderItemRepository : IOrderItemRepository
    {

        private StoreContext _storeContext;
        public OrderItemRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public void DeleteOrderItem(int orderId, OrderItem orderItem)
        {
            var order = _storeContext.Orders.Where(o => o.Id == orderId).FirstOrDefault();
            order.OrderItems.Remove(orderItem);

        }

        public OrderItem GetOrderItem(int orderId, int orderItemId)
        {
            var order = _storeContext.Orders.Where(o => o.Id == orderId).FirstOrDefault();
            var orderItem = order.OrderItems.Where(oi => oi.Id == orderItemId).FirstOrDefault();
            return orderItem;
        }

        public IEnumerable<OrderItem> GetOrderItems(int orderId)
        {
            return _storeContext.Orders.Where(o => o.Id == orderId).FirstOrDefault().OrderItems.ToList();
        }

        public bool OrderExists(int orderId)
        {
            return (_storeContext.Orders.Where(o => o.Id == orderId).Any());
        }

        public void PostOrderItem(int orderId, OrderItem orderItem)
        {
            var order = _storeContext.Orders.Where(o => o.Id == orderId).FirstOrDefault();
            order.OrderItems.Add(orderItem);
        }

        public bool Save()
        {
            return (_storeContext.SaveChanges() >= 0);
        }
    }
}
