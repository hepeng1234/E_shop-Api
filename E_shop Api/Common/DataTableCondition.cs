using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace E_shop_Api.Common
{
    public class DataTableCondition
    {
        public static DataTable DT(string key,int value)
        {
            DataTable dt = new DataTable("Datas");
            dt.Columns.Add("key", typeof(string));
            dt.Columns.Add("value", typeof(Int32));

            DataRow dr = dt.NewRow();
            dr["key"] = key;
            dr["value"] = value;
            dt.Rows.Add(dr);
            return dt;
        }
        public static DataTable DT(string key, int value, string key1, int value1)
        {
            DataTable dt = new DataTable("Datas");
            dt.Columns.Add("key", typeof(string));
            dt.Columns.Add("value", typeof(Int32));

            DataRow dr = dt.NewRow();
            dr["key"] = key;
            dr["value"] = value;
            dt.Rows.Add(dr);

            DataRow dr1 = dt.NewRow();
            dr1["key"] = key1;
            dr1["value"] = value1;
            dt.Rows.Add(dr1);


            return dt;
        }
    }
}
