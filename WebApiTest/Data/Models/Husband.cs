using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest.Data.Models
{
    public class Husband
    {
        public int id { get; set; }
        public string Name { get; set; }
        public Wife Wife { get; set; }
    }
}
