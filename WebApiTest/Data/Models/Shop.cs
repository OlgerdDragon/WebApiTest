using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest.Data.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> ProductList { get; set; }
    }
}
