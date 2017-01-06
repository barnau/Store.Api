using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Store.Api.Services
{
    public class CustomerRepository : ICustomerRepository
    {


        private StoreContext _storeContext;

        public CustomerRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return _storeContext.Customers.OrderBy(c => c.LastName).ToList();
        }

        public Customer GetCustomer(int customerId)
        {
            return _storeContext.Customers.Include(c => c.Addresses).Where(c => c.Id == customerId).FirstOrDefault();
        }
        public void AddCustomer(Customer customer)
        {
            _storeContext.Customers.Add(customer);
        }

        public bool CustomerExists(int customerId)
        {
            return _storeContext.Customers.Any(c => c.Id == customerId);
        }

        public void DeleteCustomer(Customer customer)
        {
            _storeContext.Customers.Remove(customer);
        }



        public bool Save()
        {
            return (_storeContext.SaveChanges() >= 0);
        }


    }
}
