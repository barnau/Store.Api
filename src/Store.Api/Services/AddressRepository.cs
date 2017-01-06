using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Api.Entities;
using Store.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Store.Api.Services
{
    public class AddressRepository : IAddressRepository
    {
        private StoreContext _storeContext;

        public AddressRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public void AddAddress(int customerId, Address address)
        {
            var customer = _storeContext.Customers.Where(c => c.Id == customerId).FirstOrDefault();
            customer.Addresses.Add(address);
        }

        public void DeleteAddress( Address address)
        {
            _storeContext.Addresses.Remove(address);
        }

        public IEnumerable<Address> GetAddresses(int customerId)
        {
            return _storeContext.Addresses.Where(a => a.CustomerId == customerId).ToList();
        }

        public Address GetAddressForCustomer(int customerId, int id)
        {
            return _storeContext.Addresses.Where(a => a.CustomerId == customerId && a.Id == id).FirstOrDefault();
        }

       

        public bool Save()
        {
            return (_storeContext.SaveChanges() >= 0);
        }

        public bool CustomerExists(int customerId)
        {
            return _storeContext.Customers.Any(c => c.Id == customerId);
        }

        public bool AddressExists(int customerId, int id)
        {
            if (!CustomerExists(customerId))
            {
                return false;
            }

            return _storeContext.Customers.Where(c => c.Id == customerId).FirstOrDefault().Addresses.Any(a => a.Id == id);
        }

        

    }
}
