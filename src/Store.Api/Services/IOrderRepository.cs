using Store.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Services
{
    public interface IOrderRepository
    {
        Customer GetCustomer(int customerId);
        bool CustomerExists(int customerId);
        Order GetOrderForCustomer(int customerId, int orderId);
        IEnumerable<Order> GetOrdersForCustomer(int customerId);
        void AddOrder(int customerId, Order order);

        void DeleteOrder(Order order);
        bool Save();
    }
}
