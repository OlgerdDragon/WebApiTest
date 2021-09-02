using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Data.Models;

namespace WebApiTest.Data.Interface
{
    public interface IAllShops
    {
        IEnumerable<Shop> AllShops {  get; }
        public void AddProductInShop(int shopID, int productID);
        public void AddProduct(int productID, string productName, int price);
        public void AddShop(int shopID, string shopName);
    }
}
