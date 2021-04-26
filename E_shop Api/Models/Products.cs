using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using E_shop_Api.Common;

namespace E_shop_Api.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public static List<Products> GetProductList(string sql)
        {
            List<Products> products = new List<Products>();
            DataTable dt = SqlHelper.ExecuteTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                products.Add(new Products
                {
                    Id = (int)dt.Rows[i]["Id"],
                    Url= dt.Rows[i]["Url"].ToString()
                });
            }
            return products;
        }
        
    }
}
