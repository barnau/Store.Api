using Store.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Services
{
    public interface IOrderRepository
    {
        bool OrderExists(int customerId, int orderId);
        Order GetOrder(int customerId, int orderId);
        void AddOrder(int customerId, Order order);

        void DeleteOrder(int customerId, Order order);
        bool Save();
    }
}
