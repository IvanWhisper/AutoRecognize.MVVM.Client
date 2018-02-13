using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRecognize.Dao.DbDao
{
    /// <summary>
    /// 连接工厂
    /// </summary>
    public class ConnectionFactory
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string DbConnection = "";
        /// <summary>
        /// 数据库类型
        /// </summary>
        public static DBConnectionType dBConnectionType = 0;
        /// <summary>
        /// 创建连接并打开连接
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IDbConnection CreateConnection<T>() where T : IDbConnection, new()
        {
            IDbConnection connection = new T();
            connection.ConnectionString = DbConnection;
            connection.Open();
            return connection;
        }
        /// <summary>
        /// 根据类型创建打开连接
        /// </summary>
        /// <returns></returns>
        public static IDbConnection CreateSqlConnection()
        {
            switch (dBConnectionType)
            {
                case DBConnectionType.Mysql:
                    return CreateConnection<MySqlConnection>();
                case DBConnectionType.SqlServer:
                    return CreateConnection<SqlConnection>();
                default:
                    return CreateConnection<MySqlConnection>();
            }
        }
    }
    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum DBConnectionType
    {
        Mysql,
        SqlServer,
    }
}
