using Microsoft.Data.SqlClient;
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
        
        public IEnumerable<Shop> AllShops
        {
            get 
            {
                List<Shop> shopsList = new List<Shop>();
                SqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();
                //string getSQLBougthList = "SELECT [ProductID],[ProductName],[ProductPrice] FROM[dbo].[Products]";
                string getSQLBougthList = "SELECT [ShopID],[ShopName] FROM[dbo].[Shops]";
                SqlCommand commandBougthList = new SqlCommand(getSQLBougthList, conn);
                SqlDataReader reader = commandBougthList.ExecuteReader();
                while (reader.Read())
                {
                    shopsList.Add(new Shop {Id= Convert.ToInt32(reader[0].ToString()), Name = reader[1].ToString() });
                }

                return shopsList;
            }
            
        }
    }
}
