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
            _storeContext.Customers.Where(c => c.Id == customerId).FirstOrDefault()
                .Orders.Add(order);
        }

        public void DeleteOrder(int customerId, Order order)
        {
            _storeContext.Customers.Where(c => c.Id == customerId).FirstOrDefault()
                .Orders.Remove(order);
        }

        public Order GetOrder(int customerId, int orderId)
        {
            return _storeContext.Customers.Where(c => c.Id == customerId).FirstOrDefault()
                .Orders.Where(o => o.Id == orderId).FirstOrDefault();
        }

        public bool OrderExists(int customerId, int orderId)
        {
           return  _storeContext.Customers.Where(c => c.Id == customerId).FirstOrDefault()
                .Orders.Any(o => o.Id == orderId);
        }

        public bool Save()
        {
            return (_storeContext.SaveChanges() >= 0);
        }
    }
}
