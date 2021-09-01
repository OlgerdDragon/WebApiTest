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
        private readonly IAllProducts _allProducts;
        public AdminController(IAllShops iAllShops, IAllProducts iAllProducts)
        {
            _allShops = iAllShops;
            _allProducts = iAllProducts;
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
        [HttpGet]
        [Route("GetProductList")]
        public string GetProductsList(string shopName)
        {
            Shop shop = new Shop();
            foreach (var shopItem in _allShops.AllProducts)
            {
                if(shopItem.Name==shopName) { shop = shopItem; break; }
            }
            string productList = JsonSerializer.Serialize<IEnumerable<Product>>(_allProducts.AllProducts(shop));
            return productList;
        }
        [HttpGet]
        [Route("AddProduct")]
        public string AddProduct(string shopName, string productName, int productPrice)
        {
            Shop shop = new Shop();
            foreach (var shopItem in _allShops.AllProducts)
            {
                if (shopItem.Name == shopName) { shop = shopItem; break; }
            }
            int id = shop.ProductList.Count;
            shop.ProductList.Add(Factory.Product(id, productName, productPrice));
            string list = JsonSerializer.Serialize<IEnumerable<Product>>(shop.ProductList);
            return "I add product!    " + list;
        }

        // Lockated ????
        class Factory
        {
            public static Product Product(int id, string productName, int productPrice)
            {
                Product product = new Product();
                product.Id = id;
                product.Name = productName;
                product.Price = productPrice;
                return product;
            }
        }
    }
}
