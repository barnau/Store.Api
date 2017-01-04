using Store.Api.Entities;
using Store.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Services
{
    public interface IProductRepository
    {
        bool ProductExists(int productId);
        Product GetProduct(int productId);
        IEnumerable<Product> GetProducts();
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        bool Save();
    }
}
