using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using E_shop_Api.Controllers;

namespace E_shop_Api.Common
{
    public class SqlHelper
    {
        /// <summary>
        /// 没有条件，直接返回所有数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable ExecuteTable(string sql)
        {
            using (MySqlConnection conn=new MySqlConnection(MainClass.ConnStr))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
        }
        /// <summary>
        /// 有条件的，返回条件成立的所有数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dataTable">DataTable类型sql变量，传入两个字段@Id(key)和Id(value)</param>
        /// <returns></returns>
        public static DataTable GetSum(string sql,DataTable dataTable)
        {
            using (MySqlConnection conn = new MySqlConnection(MainClass.ConnStr))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                foreach (DataRow item in dataTable.Rows)
                {
                    cmd.Parameters.AddWithValue(item[0].ToString(), item[1]);
                }

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
        }
        /// <summary>
        /// 返回总数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Count(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(MainClass.ConnStr))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                var a = cmd.ExecuteScalar().ToString();
                return (int)Convert.ToInt64(a);
            }
        }
        /// <summary>
        /// 修改或删除某个满足条件的数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dataTable"></param>
        public static void Set(string sql, DataTable dataTable)
        {
            using(MySqlConnection conn=new MySqlConnection(MainClass.ConnStr))
            {
                MySqlCommand cmd = new MySqlCommand(sql,conn);
                foreach (DataRow item in dataTable.Rows)
                {
                    cmd.Parameters.AddWithValue(item[0].ToString(), item[1]);
                }
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
