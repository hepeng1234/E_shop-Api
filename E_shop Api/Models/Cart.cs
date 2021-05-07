using E_shop_Api.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace E_shop_Api.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int ProductInfoId { get; set; }
        public int Count { get; set; }
        public string NewPrice { get; set; }
        public string PictureUrl { get; set; }
        public string Msg { get; set; }
        /// <summary>
        /// 获取购物车数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<Cart> Carts(string sql)
        {
            List<Cart> data = new List<Cart>();
            DataTable dt = SqlHelper.ExecuteTable(sql);
            if(dt.Rows.Count>0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data.Add(new Cart
                    {
                        Id = PublicFun.Int(dt.Rows[i]["Id"]),
                        ProductInfoId = PublicFun.Int(dt.Rows[i]["ProductInfoId"]),
                        Count = PublicFun.Int(dt.Rows[i]["Count"]),
                        NewPrice = dt.Rows[i]["NewPrice"].ToString(),
                        PictureUrl = dt.Rows[i]["PictureUrl"].ToString(),
                        Msg = dt.Rows[i]["Msg"].ToString()
                    });
                }
            }
            else
            {
                data.Add(new Cart
                {
                    Id = 0,
                    ProductInfoId = 0,
                    Count = 0,
                    NewPrice = "",
                    PictureUrl = "",
                    Msg = ""
                });
            }
            return data;
        }
        /// <summary>
        /// 修改购物车数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dataTable"></param>
        public static void SetCarts(string sql,DataTable dataTable)
        {
            SqlHelper.Set(sql, dataTable);
        }
    }
}
