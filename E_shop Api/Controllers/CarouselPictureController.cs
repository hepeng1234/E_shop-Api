using E_shop_Api.Common;
using E_shop_Api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;



namespace E_shop_Api.Controllers
{
    
    public class CarouselPictureController : MainClass
    {
        /// <summary>
        /// 返回首页轮播图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CarouselPicture()
        {
            string sql = "select * from carousel_picture";
            JsonResult data = Products.GetProductList(sql);
            return data;
        }
        /// <summary>
        /// 返回所有商品主要数据
        /// </summary>
        /// <param name="pageNo">从第几条数据开始,为0则是从第一条数据开始</param>
        /// <param name="pageSize">返回多少条</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ProductInfo(int pageNo,int pageSize)
        {
            string sql = "select * from product_info where Id > @pageNo limit @pageSize";
            string sql1 = "select count(Id) from product_info";

            DataTable dt = new DataTable("Datas");
            dt.Columns.Add("key", typeof(string));
            dt.Columns.Add("value", typeof(Int32));
            DataRow dr = dt.NewRow();
            dr["key"] = "@pageNo";
            dr["value"] = pageNo;
            dt.Rows.Add(dr);
            DataRow dr1 = dt.NewRow();
            dr1["key"] = "@pageSize";
            dr1["value"] = pageSize;
            dt.Rows.Add(dr1);


            JsonResult data = GetCount.GetCounts(sql,sql1, dt);
            return data;
        }
        /// <summary>
        /// 返回一个商品的详细数据
        /// </summary>
        /// <param name="id">商品id号</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ProductDetailed(int id)
        {
            string sql = "select Id,InfoSrc from product_detailed where Id=@Id";
            string sql1= "select ProductCarousel from product_carousel a,product_detailed b where a.Id=b.CarouselUrlId and b.Id=@Id";
            string sql2 = "select * from product_info where Id=@Id";

            DataTable dt = new DataTable("Datas");
            dt.Columns.Add("key", typeof(string));
            dt.Columns.Add("value", typeof(Int32));
            DataRow dr = dt.NewRow();
            dr["key"] = "@Id";
            dr["value"] = id;
            dt.Rows.Add(dr);


            JsonResult data = GetProductDetailed.GetProductDetailedFun(sql, sql1, sql2, dt);
            return data;
        }
        /// <summary>
        /// 返回所有咨询主要数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult New()
        {
            string sql = "SELECT * FROM `news`";
            JsonResult data = News.GetNews(sql);
            return data;
        }
        /// <summary>
        /// 返回一个咨询的详细数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetNewDetail(int id)
        {
            string sql = "select b.Id,b.Title,b.Url,b.Time,a.Content from news_detailed a,news b where a.Id=b.ContentId and b.Id=@Id";

            DataTable dt = new DataTable();
            dt.Columns.Add("key", typeof(string));
            dt.Columns.Add("value", typeof(Int32));
            DataRow dr = dt.NewRow();
            dr["key"] = "@Id";
            dr["value"] = id;
            dt.Rows.Add(dr);

            JsonResult data = NewDetail.GetNewDetailFun(sql,dt);

            return data;
        }
        /// <summary>
        /// 返回所有社区图片左侧标题栏数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult NavbarLeft()
        {
            string sql = "select * from navbar_left";
            JsonResult data = GetNavbarLeft.GetNavbarLefts(sql);
            return data;
        }
        /// <summary>
        /// 返回社区图片右侧内容数据
        /// </summary>
        /// <param name="NavbarLeftId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult NavbarRight(int NavbarLeftId)
        {
            string sql = "select PictureUrl,Msg from navbar_right where NavbarLeftId=@NavbarLeftId";
            DataTable dt = new DataTable();
            dt.Columns.Add("key", typeof(string));
            dt.Columns.Add("value", typeof(Int32));
            DataRow dr = dt.NewRow();
            dr["key"] = "@NavbarLeftId";
            dr["value"] = NavbarLeftId;
            dt.Rows.Add(dr);

            JsonResult data = GetNavbarRight.GetNavbarRights(sql, dt);

            return data;
        }
        /// <summary>
        /// 返回购物车所有数据
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //public object Cart()
        //{
        //    string sql = "";
        //}


    }
}
