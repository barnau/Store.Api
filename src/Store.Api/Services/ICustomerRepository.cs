using Store.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Services
{
    public interface ICustomerRepository
    {
        bool CustomerExists(int customerId);

        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int customerId);
        void AddCustomer(Customer customer);

        void DeleteCustomer(Customer customer);
        bool Save();
    }
}
