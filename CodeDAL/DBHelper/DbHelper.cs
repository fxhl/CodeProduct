using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace CodeDAL.DBHelper
{
    public class DbHelper
    {
        private static readonly string connstr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            return conn;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public IEnumerable<T> GetQuery<T>(string sql,object param)
        {
            using (SqlConnection conn = GetConnection())
            {
                return conn.Query<T>(sql,param);
            }
        }

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int Execute(string sql, object param)
        {
            using (SqlConnection conn = GetConnection())
            {
                return conn.Execute(sql, param);
            }
        }

    }
}
