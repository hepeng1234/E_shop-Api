using E_shop_Api.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace E_shop_Api.Models
{
    /// <summary>
    /// 总数与商品数据全部返回
    /// </summary>
    public class GetCount
    {
        public int Count { get; set; }
        public List<GetProductInfo> Info { get; set; }
        public static JsonResult GetCounts(string sql,string sql1, DataTable dataTable)
        {
            List<GetProductInfo> products = GetProductInfo.GetProductInfo1(sql, dataTable);
            int count = SqlHelper.Count(sql1);
            GetCount data = new GetCount
            {
                Count=count,
                Info=products
            };
            return new JsonResult(new { data});
        }
    }
    /// <summary>
    /// 返回所有商品数据
    /// </summary>
    public class GetProductInfo
    {
        public int Id { get; set; }
        public string Msg { get; set; }
        public string PictureUrl { get; set; }
        public string NewPrice { get; set; }
        public string OldPrice { get; set; }
        public int ProDetailsId { get; set; }
        /// <summary>
        /// 不带条件，返回所有数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<GetProductInfo> GetProductInfo1(string sql)
        {
            List<GetProductInfo> products = new List<GetProductInfo>();
            DataTable dt = SqlHelper.ExecuteTable(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    products.Add(new GetProductInfo
                    {
                        Id = (int)dt.Rows[i]["Id"],
                        Msg = dt.Rows[i]["Msg"].ToString(),
                        PictureUrl = dt.Rows[i]["PictureUrl"].ToString(),
                        NewPrice = dt.Rows[i]["NewPrice"].ToString(),
                        OldPrice = dt.Rows[i]["OldPrice"].ToString(),
                        ProDetailsId = PublicFun.Int(dt.Rows[i]["ProDetailsId"])
                    });
                }
            }
            else
            {
                products.Add(new GetProductInfo
                {
                    Id = 0,
                    Msg = "",
                    PictureUrl = "",
                    NewPrice = "",
                    OldPrice = "",
                    ProDetailsId = 0
                });
            }
            
            return products;
        }
        /// <summary>
        /// 带条件，返回符合条件的全部数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static List<GetProductInfo> GetProductInfo1(string sql, DataTable dataTable)
        {
            List<GetProductInfo> products = new List<GetProductInfo>();
            DataTable dt = SqlHelper.GetSum(sql, dataTable);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    products.Add(new GetProductInfo
                    {
                        Id = (int)dt.Rows[i]["Id"],
                        Msg = dt.Rows[i]["Msg"].ToString(),
                        PictureUrl = dt.Rows[i]["PictureUrl"].ToString(),
                        NewPrice = dt.Rows[i]["NewPrice"].ToString(),
                        OldPrice = dt.Rows[i]["OldPrice"].ToString(),
                        ProDetailsId = PublicFun.Int(dt.Rows[i]["ProDetailsId"])
                    });
                }
            }
            else
            {
                products.Add(new GetProductInfo
                {
                    Id = 0,
                    Msg = "",
                    PictureUrl = "",
                    NewPrice = "",
                    OldPrice = "",
                    ProDetailsId = 0
                });
            }
            
            return products;
        }
    }
}
