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
        public static DataTable DT(string key, string value, string key1, string value1)
        {
            DataTable dt = new DataTable("Datas");
            dt.Columns.Add("key", typeof(string));
            dt.Columns.Add("value", typeof(string));

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
        public static DataTable DT(string key, string value, string key1, string value1,string key2,string value2)
        {
            DataTable dt = new DataTable("Datas");
            dt.Columns.Add("key", typeof(string));
            dt.Columns.Add("value", typeof(string));

            DataRow dr = dt.NewRow();
            dr["key"] = key;
            dr["value"] = value;
            dt.Rows.Add(dr);

            DataRow dr1 = dt.NewRow();
            dr1["key"] = key1;
            dr1["value"] = value1;
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["key"] = key2;
            dr2["value"] = value2;
            dt.Rows.Add(dr2);


            return dt;
        }
    }
}
