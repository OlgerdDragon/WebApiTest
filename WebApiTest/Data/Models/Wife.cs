using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest.Data.Models
{
    public class Wife
    {
        public int id { get; set; }
        public string Name { get; set; }
        public List<Product> WantedList { get; set; }
    }
}
