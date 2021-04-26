using E_shop_Api.Common;
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
        public static GetCount GetCounts(string sql,string sql1, DataTable dataTable)
        {
            List<GetProductInfo> products = GetProductInfo.GetProductInfo1(sql, dataTable);
            int count = SqlHelper.Count(sql1);
            GetCount getCounts = new GetCount
            {
                Count=count,
                Info=products
            };
            return getCounts;
        }
    }
    /// <summary>
    /// 返回商品数据
    /// </summary>
    public class GetProductInfo
    {
        public int Id { get; set; }
        public string Msg { get; set; }
        public string PictureUrl { get; set; }
        public string NewPrice { get; set; }
        public string OldPrice { get; set; }
        public int ProDetailsId { get; set; }
        public static List<GetProductInfo> GetProductInfo1(string sql)
        {
            List<GetProductInfo> products = new List<GetProductInfo>();
            DataTable dt = SqlHelper.ExecuteTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                products.Add(new GetProductInfo
                {
                    Id = (int)dt.Rows[i]["Id"],
                    Msg = dt.Rows[i]["Msg"].ToString(),
                    PictureUrl = dt.Rows[i]["PictureUrl"].ToString(),
                    NewPrice = dt.Rows[i]["NewPrice"].ToString(),
                    OldPrice = dt.Rows[i]["OldPrice"].ToString(),
                    ProDetailsId = Int(dt.Rows[i]["ProDetailsId"])
                });
            }
            return products;
        }
        public static List<GetProductInfo> GetProductInfo1(string sql, DataTable dataTable)
        {
            List<GetProductInfo> products = new List<GetProductInfo>();
            DataTable dt = SqlHelper.GetSum(sql, dataTable);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                products.Add(new GetProductInfo
                {
                    Id = (int)dt.Rows[i]["Id"],
                    Msg = dt.Rows[i]["Msg"].ToString(),
                    PictureUrl = dt.Rows[i]["PictureUrl"].ToString(),
                    NewPrice = dt.Rows[i]["NewPrice"].ToString(),
                    OldPrice = dt.Rows[i]["OldPrice"].ToString(),
                    ProDetailsId = Int(dt.Rows[i]["ProDetailsId"])
                });
            }
            return products;
        }
        public static int Int(object a)
        {
            try
            {
                int b = (int)a;
                if (b > 0)
                    return b;
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 0;
        }
    }
}
