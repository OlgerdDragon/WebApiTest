using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Data.Interface;
using WebApiTest.Data.Models;

namespace WebApiTest.Data.Mocks
{
    public class MockProduct : IAllProducts
    {
        public IEnumerable<Product> AllProducts(Shop shop)
        {
            return new List<Product>
            {
                new Product{ Id = 0, Name = "bread", Price = 100},
                new Product{ Id = 1, Name = "milk", Price = 120},
                new Product{ Id = 2, Name = "iphone", Price = 1}
            };
        }
    }
}
