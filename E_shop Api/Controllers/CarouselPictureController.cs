﻿using E_shop_Api.Common;
using E_shop_Api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace E_shop_Api.Controllers
{
    
    public class CarouselPictureController : SqlHelper
    {
        /// <summary>
        /// 返回首页轮播图url
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Products> CarouselPicture()
        {
            string sql = "select * from carousel_picture";
            List<Products> da = Products.GetProductList(sql);
            return da;
        }
        /// <summary>
        /// 返回商品全部数据
        /// </summary>
        /// <param name="pageNo">从第几条数据,从0开始</param>
        /// <param name="pageSize">返回多少条</param>
        /// <returns></returns>
        [HttpGet]
        public GetCount ProductInfo(int pageNo,int pageSize)
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


            GetCount products = GetCount.GetCounts(sql,sql1, dt);
            return products;
        }
        /// <summary>
        /// 返回一个商品的详细数据
        /// </summary>
        /// <param name="id">商品id号</param>
        /// <returns></returns>
        [HttpGet]
        public object ProductDetailed(int id)
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


            GetProductDetailed products = GetProductDetailed.GetProductDetailedFun(sql, sql1, sql2, dt);
            return products;
        }
    }
}
