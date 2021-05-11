using E_shop_Api.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace E_shop_Api.Models
{
    public class Users
    {
        public string UserName { get; set; }
        public int Code { get; set; }
        public string UserPicture { get; set; }
        public static Users GetUser(string sql,DataTable dataTable)
        {
            DataTable dt = SqlHelper.GetSum(sql, dataTable);
            Users data;
            if (dt.Rows.Count > 0)
            {
                data = new Users
                {
                    UserName = dt.Rows[0]["UserName"].ToString(),
                    UserPicture = dt.Rows[0]["UserPicture"].ToString(),
                    Code =1
                };
                return data;
            }else
            {
                data = new Users
                {
                    UserName = "",
                    UserPicture = "",
                    Code = 0
                };
                return data;
            }
        }
        public static int RegisterUser(string sql,DataTable dataTable)
        {
            return SqlHelper.Insert(sql, dataTable);
        }
    }
}
