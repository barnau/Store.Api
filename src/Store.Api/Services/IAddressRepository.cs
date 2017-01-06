using Store.Api.Entities;
using Store.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Services
{
    public interface IAddressRepository
    {

        bool CustomerExists(int customerId);
        bool AddressExists(int customerId, int id);
        Address GetAddressForCustomer(int customerId, int addressId);
        IEnumerable<Address> GetAddresses(int customerId);
       
        void AddAddress(int customerId, Address address);

        void DeleteAddress( Address address);
        bool Save();
    }
}
