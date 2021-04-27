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
    /// 左侧标题栏
    /// </summary>
    public class GetNavbarLeft
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public static JsonResult GetNavbarLefts(string sql)
        {
            List<GetNavbarLeft> data = new List<GetNavbarLeft>();
            DataTable dt = SqlHelper.ExecuteTable(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data.Add(new GetNavbarLeft
                    {
                        Id = (int)dt.Rows[i]["Id"],
                        Title = dt.Rows[i]["Title"].ToString()
                    });
                }
            }
            else
            {
                data.Add(new GetNavbarLeft
                {
                    Id = 0,
                    Title = null
                });
            }
            return new JsonResult(new { data });
        }
    }
    /// <summary>
    /// 右侧内容栏
    /// </summary>
    public class GetNavbarRight
    {
        public string PictureUrl { get; set; }
        public string Msg { get; set; }
        public static JsonResult GetNavbarRights(string sql,DataTable dataTable)
        {
            List<GetNavbarRight> data = new List<GetNavbarRight>(); ;
            DataTable dt = SqlHelper.GetSum(sql, dataTable);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data.Add(new GetNavbarRight
                    {
                        PictureUrl = dt.Rows[i]["PictureUrl"].ToString(),
                        Msg = dt.Rows[i]["Msg"].ToString()
                    });
                }
            }
            else
            {
                data.Add(new GetNavbarRight
                {
                    PictureUrl = null,
                    Msg = null
                });
            }
            return new JsonResult(new { data });
        }
    }
}
