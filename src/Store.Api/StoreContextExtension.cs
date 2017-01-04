using Store.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api
{
    public static class StoreContextExtension
    {
        public static void EnsureSeedDataForContext(this StoreContext context)
        {
            if (context.Products.Any())
            {
                return;
            }

            var products = new List<Product>()
            {
                new Product()
                {
                    ProductName = "Hammer",
                    Description = "stock metal hammer with rubber grip",
                    ImageUrl = "http://image.com/image1",
                    Price = 15.33M,
                    ProductCode = "234ab",
                    StarRating = 4.3M,
                },
                new Product()
                {
                    ProductName = "Screw Driver",
                    Description = "stock metal screwdriver with rubber grip",
                    ImageUrl = "http://image.com/image1",
                    Price = 9.33M,
                    ProductCode = "234abc",
                    StarRating = 4.3M,
                },
                new Product()
                {
                    ProductName = "Chair",
                    Description = "Folding chair",
                    ImageUrl = "http://image.com/image1",
                    Price = 40.33M,
                    ProductCode = "234abd",
                    StarRating = 4.3M,
                }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
