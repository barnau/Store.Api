using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Api.Entities;

namespace Store.Api.Services
{
    public class OrderRepository : IOrderRepository
    {
        private StoreContext _storeContext;
        public OrderRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public void AddOrder(int customerId, Order order)
        {
            var customer = _storeContext.Customers.Where(c => c.Id == customerId).FirstOrDefault();
            customer.Orders.Add(order);
        }

        public bool CustomerExists(int customerId)
        {
            return _storeContext.Customers.Any(c => c.Id == customerId);
        }

        public void DeleteOrder(Order order)
        {
            
            _storeContext.Orders.Remove(order);
        }

        public Customer GetCustomer(int customerId)
        {
            return _storeContext.Customers.Where(c => c.Id == customerId).FirstOrDefault();
        }

        public Order GetOrderForCustomer(int customerId, int orderId)
        {
            return _storeContext.Orders.Where(o => o.CustomerId == customerId && o.Id == orderId).FirstOrDefault();
        }

        public IEnumerable<Order> GetOrdersForCustomer(int customerId)
        {
            return _storeContext.Orders.Where(o => o.CustomerId == customerId).ToList();
        }

        public bool Save()
        {
            return (_storeContext.SaveChanges() >= 0);
        }
    }
}
