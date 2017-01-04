using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Api.Entities;
using Store.Api.Models;

namespace Store.Api.Services
{
    public class ProductRepository : IProductRepository
    {
        private StoreContext _storeContext;
        public ProductRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public void AddProduct(Product product)
        {
            _storeContext.Products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            _storeContext.Products.Remove(product);
        }

       
        public IEnumerable<Product> GetProducts()
        {
            return _storeContext.Products.OrderBy(p => p.ProductName).ToList();
        }

        public Product GetProduct(int productId)
        {
            return _storeContext.Products.Where(p => p.Id == productId).FirstOrDefault();
        }

        public bool ProductExists(int productId)
        {
            return (_storeContext.Products.Any(p => p.Id == productId));
        }

        public bool Save()
        {
            return (_storeContext.SaveChanges() >= 0);
        }

      
    }
}
