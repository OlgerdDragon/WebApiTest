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


            string shopList = JsonSerializer.Serialize<IEnumerable<Shop>>(_allShops.AllShops);
            return shopList;
        }
        [HttpGet]
        [Route("GetProductList")]
        public string GetProductsList(int shopID)
        {
            
            string productList = JsonSerializer.Serialize<IEnumerable<Product>>(_allProducts.AllProducts(shopID));
            return productList;
        }
        [HttpGet]
        [Route("AddProduct")]
        public string AddProduct(string shopName, string productName, int productPrice)
        {
            Shop shop = new Shop();
            foreach (var shopItem in _allShops.AllShops)
            {
                if (shopItem.Name == shopName) {shop = shopItem; break; }
            }
            int id = shop.ProductList.Count;
            shop.ProductList.Add(Factory.Product(id, productName, productPrice));
            string list = JsonSerializer.Serialize<IEnumerable<Product>>(shop.ProductList);
            return "I add product!    " + list;
        }
        [HttpGet]
        [Route("RemoveProduct")]
        public string RemoveProduct(string shopName, string productName)
        {
            Shop shop = NededShop(shopName);
            Product product = NededShopForRemove(productName, shop);
            shop.ProductList.Remove(product);
            string list = JsonSerializer.Serialize<IEnumerable<Product>>(shop.ProductList);
            return "I add removed!    " + list;
        }

        Shop NededShop(string shopName)
        {
            Shop shop = new Shop();
            foreach (var shopItem in _allShops.AllShops)
            {
                if (shopItem.Name == shopName) { shop = shopItem; break; }
            }
            return shop;
        }
        Product NededShopForRemove(string productName, Shop shop)
        {
            int id = shop.ProductList.Count;
            shop.ProductList.Add(Factory.Product(id, "matatabi", 100));
            shop.ProductList.Add(Factory.Product(id++, "milili", 21));
            shop.ProductList.Add(Factory.Product(id++, "avto", 1221));
            Product product = new Product();
            foreach (var item in shop.ProductList)
            {
                if (item.Name == productName) product = item;
            }
            return product;
        }

    }
}
