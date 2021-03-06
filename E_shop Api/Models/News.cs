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
    /// 所有咨询标题信息
    /// </summary>
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Time { get; set; }
        public int ContentId { get; set; }
        public static List<News> GetNews(string sql)
        {
            List<News> data = new List<News>();
            DataTable dt = SqlHelper.ExecuteTable(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data.Add(new News
                    {
                        Id = (int)dt.Rows[i]["Id"],
                        Title = dt.Rows[i]["Title"].ToString(),
                        Url = dt.Rows[i]["Url"].ToString(),
                        Time = dt.Rows[i]["Time"].ToString(),
                        ContentId = PublicFun.Int(dt.Rows[i]["ContentId"])
                    });
                }
            }
            else
            {
                data.Add(new News
                {
                    Id = 0,
                    Title = "",
                    Url = "",
                    Time = "",
                    ContentId = 0
                });
            }

            return data;
        }
    }
    /// <summary>
    /// 单个咨询详情
    /// </summary>
    public class NewDetail
    {
        public News News1 { get; set; }
        public string Content { get; set; }
        public static NewDetail GetNewDetailFun(string sql,DataTable dataTable)
        {
            NewDetail data = new NewDetail();
            DataTable dt = SqlHelper.GetSum(sql, dataTable);

            if (dt.Rows.Count > 0)
            {
                data.News1 = new News
                {
                    Id = (int)dt.Rows[0]["Id"],
                    Title = dt.Rows[0]["Title"].ToString(),
                    Time = dt.Rows[0]["Time"].ToString()
                };
                data.Content = dt.Rows[0]["Content"].ToString();
            }
            else
            {
                data.News1 = new News
                {
                    Id = 0,
                    Title = "",
                    Url = "",
                    Time = ""
                };
                data.Content = "";
            }


            return data;
        }
    }
}
