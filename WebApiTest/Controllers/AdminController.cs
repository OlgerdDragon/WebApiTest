using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebApiTest.Data.Interface;
using WebApiTest.Data.Models;

namespace WebApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAllShops _allShops;
        public AdminController(IAllShops iAllShops)
        {
            _allShops = iAllShops;
        }
        [HttpGet]
        public string Get()
        {
            return "Hello Admin!";
        }

        [HttpGet]
        [Route("GetShopsList")]
        public string GetShopsList()
        {
            string shopList = JsonSerializer.Serialize<IEnumerable<Shop>>(_allShops.AllProducts);
            return shopList;
        }
    }
}
