using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Data.Interface;
using WebApiTest.Data.Models;

namespace WebApiTest.Data.Mocks
{
    public class MockShop : IAllShops
    {
        
        public IEnumerable<Shop> AllProducts
        {
            get 
            {
                return new List<Shop>
                {
                    new Shop{ Id = 1, Name = "IKEA", ProductList = new List<Product>()},
                    new Shop{ Id = 2, Name = "Silpo", ProductList = new List<Product>()},
                    new Shop{ Id = 3, Name = "Ashan", ProductList = new List<Product>()},
                    new Shop{ Id = 4, Name = "Toswa", ProductList = new List<Product>()} 
                };
            }
            
        }
    }
}
