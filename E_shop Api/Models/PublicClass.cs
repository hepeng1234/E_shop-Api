using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_shop_Api.Models
{
    public class PublicClass
    {
        public int status { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public static PublicClass PublicClassFun(string sql)
        {
            PublicClass publicClass;

            var data = Products.GetProductList(sql);
            publicClass= new PublicClass()
            {
                status = 200,
                message = "请求成功",
                data = data
            };
            return publicClass;
        }
    }
}
