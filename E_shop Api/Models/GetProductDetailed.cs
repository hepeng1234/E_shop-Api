using E_shop_Api.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace E_shop_Api.Models
{
    /// <summary>
    /// 商品详细信息
    /// </summary>
    public class GetProductDetailed
    {
        public GetProductInfo GetProductInfo { get; set; }
        public int Id { get; set; }
        public string InfoSrc { get; set; }
        public List<string> ProductCarousel1 { get; set; }
        public static GetProductDetailed GetProductDetailedFun(string sql,string sql1, string sql2,DataTable dataTable)
        {
            DataTable dt1 = SqlHelper.GetSum(sql, dataTable);


            List<string> ListProductCarousel = ProductCarousel.ProductCarouselFun(sql1, dataTable);


            DataTable dt = SqlHelper.GetSum(sql2, dataTable);
            GetProductInfo getProductInfo = new GetProductInfo
            {
                Id = (int)dt.Rows[0]["Id"],
                Msg = dt.Rows[0]["Msg"].ToString(),
                PictureUrl = dt.Rows[0]["PictureUrl"].ToString(),
                NewPrice = dt.Rows[0]["NewPrice"].ToString(),
                OldPrice = dt.Rows[0]["OldPrice"].ToString(),
            };
            GetProductDetailed getProductDetailed = new GetProductDetailed
            {
                GetProductInfo = getProductInfo,
                ProductCarousel1 = ListProductCarousel,
                Id = (int)dt1.Rows[0]["Id"],
                InfoSrc = dt1.Rows[0]["InfoSrc"].ToString()
            };
            return getProductDetailed;
        }
    }
    public static class ProductCarousel
    {
        public static List<string> ProductCarouselFun(string sql, DataTable dataTable)
        {
            List<string> Vs = new List<string>();
            DataTable dt = SqlHelper.GetSum(sql, dataTable);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Vs.Add(dt.Rows[i]["ProductCarousel"].ToString());
            }
            return Vs;
        }
    }
}
