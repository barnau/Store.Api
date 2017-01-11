using Store.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Services
{
    public interface IOrderItemRepository
    {
        OrderItem GetOrderItem(int orderId, int orderItemId);

        IEnumerable<OrderItem> GetOrderItems(int orderId);


        void PostOrderItem(int orderId, OrderItem orderItem);
        void DeleteOrderItem(int orderId, OrderItem orderItem);
        bool Save();

        bool OrderExists(int orderId);

    }
}
