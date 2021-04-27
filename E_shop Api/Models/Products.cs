using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using E_shop_Api.Common;
using Microsoft.AspNetCore.Mvc;

namespace E_shop_Api.Models
{
    /// <summary>
    /// 首页轮播图
    /// </summary>
    public class Products
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public static JsonResult GetProductList(string sql)
        {
            List<Products> data = new List<Products>();
            DataTable dt = SqlHelper.ExecuteTable(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data.Add(new Products
                    {
                        Id = PublicFun.Int(dt.Rows[i]["Id"]),
                        Url = dt.Rows[i]["Url"].ToString()
                    });
                }
            }
            else
            {
                data.Add(new Products
                {
                    Id = 0,
                    Url = ""
                });
            }
            
            return new JsonResult(new { data });
        }
    }
}
