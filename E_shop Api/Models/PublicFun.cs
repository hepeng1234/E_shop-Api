using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_shop_Api.Models
{
    public static class PublicFun
    {
        /// <summary>
        /// 返回一个int类型
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int Int(object a)
        {
            try
            {
                int b = (int)a;
                return b;
            }
            catch
            {
                return 0;
            }
        }
    }
}
