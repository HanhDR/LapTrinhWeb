using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021067.DataLayers.SQLServer
{ /// <summary>
  /// lớp cơ sở cho các lớp cài đăt chức năng xử lý dữ liệu trên sql server
  /// </summary>
    public abstract class _BaseDAL
    {/// <summary>
     /// chuỗi tham số kết nối sql
     /// </summary>
        protected string _connectionString;
        /// <summary>
        /// contructer
        /// </summary>
        /// <param name="connectionString"></param>
        public _BaseDAL(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            return connection;
        }
    }
}
