using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Data.Models;

namespace WebApiTest.Data.Interface
{
    public interface IAllProducts
    {
        IEnumerable<Product> AllProducts(Shop shop);
    }
}
