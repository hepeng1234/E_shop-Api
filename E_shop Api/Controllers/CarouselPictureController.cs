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
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

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
            List<Products> data = Products.GetProductList(sql);
            return Ok(data);
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

            GetCount data = GetCount.GetCounts(sql, sql1, DataTableCondition.DT("@pageNo", pageNo, "@pageSize", pageSize));

            return Ok(data);
        }
        /// <summary>
        /// 返回一个商品的详细数据
        /// </summary>
        /// <param name="id">商品id号</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ProductDetailed(int Id)
        {
            string sql = "select Id,InfoSrc from product_detailed where Id=@Id";
            string sql1 = "select a.ProductCarousel from product_carousel a,product_detailed b where a.Id=b.CarouselUrlId and b.Id=@Id";
            string sql2 = "select * from product_info where Id=@Id";


            GetProductDetailed data = GetProductDetailed.GetProductDetailedFun(sql, sql1, sql2, DataTableCondition.DT("@Id", Id));
            return Ok(data);
        }
        /// <summary>
        /// 返回所有咨询主要数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult New()
        {
            string sql = "SELECT * FROM `news`";
            List<News> data = News.GetNews(sql);
            return Ok(data);
        }
        /// <summary>
        /// 返回一个咨询的详细数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetNewDetail(int Id)
        {
            string sql = "select b.Id,b.Title,b.Url,b.Time,a.Content from news_detailed a,news b where a.Id=b.ContentId and b.Id=@Id";


            NewDetail data = NewDetail.GetNewDetailFun(sql, DataTableCondition.DT("@Id", Id));
            return Ok(data);
        }
        /// <summary>
        /// 返回所有社区图片左侧标题栏数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult NavbarLeft()
        {
            string sql = "select * from navbar_left";
            List<GetNavbarLeft> data = GetNavbarLeft.GetNavbarLefts(sql);
            return Ok(data);
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


            List<GetNavbarRight> data = GetNavbarRight.GetNavbarRights(sql, DataTableCondition.DT("@NavbarLeftId", NavbarLeftId));
            return Ok(data);
        }
        /// <summary>
        /// 返回购物车所有数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCart()
        {
            string sql = "select a.Id,a.ProductInfoId,a.Count,b.NewPrice,b.PictureUrl,b.Msg from `cart` a,product_info b where a.ProductInfoId=b.Id";
            var data = Cart.Carts(sql);
            return Ok(data);
        }
        /// <summary>
        /// 修改购物车某个商品的个数
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SettCartCount(int ProductInfoId, int Count)
        {
            string sql = "update cart set Count=@Count where ProductInfoId=@ProductInfoId";


            Cart.SetCarts(sql, DataTableCondition.DT("@ProductInfoId", ProductInfoId, "@Count", Count));

            return Ok();
        }
        /// <summary>
        /// 删除购物车中的某个产品
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult GetDeleCart([FromForm] int Id)
        {
            string sql = "delete from cart where Id=@Id";
            //DataTable dt = new DataTable();
            //dt.Columns.Add("key", typeof(string));
            //dt.Columns.Add("value", typeof(Int32));
            //DataRow dr = dt.NewRow();
            //dr["key"] = "@Id";
            //dr["value"] = Id;
            //dt.Rows.Add(dr);

            Cart.SetCarts(sql, DataTableCondition.DT("@Id", Id));

            return Ok();
        }
        /// <summary>
        /// 购物车添加商品
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostAddCart([FromForm] int ProductInfoId, [FromForm] int Count)
        {


            string sql = "insert into cart (Id,ProductInfoId,Count) values (null,@ProductInfoId,@Count)";



            Cart.SetCarts(sql, DataTableCondition.DT("@ProductInfoId", ProductInfoId, "@Count", Count));


            return Ok();
        }



    }
}
