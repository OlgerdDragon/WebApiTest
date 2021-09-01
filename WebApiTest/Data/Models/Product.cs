using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest.Data.Models
{
    public class Product
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool avalible { get; set; }

    }
}
