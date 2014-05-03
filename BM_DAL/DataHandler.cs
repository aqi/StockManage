using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Configuration;

namespace Web0204.BM.DAL
{
    /// <summary>
    /// /// <summary>
    /// DataHandler类提供数据库交互的事务处理功能
    /// </summary>
    /// </summary>
    public abstract class DataHandler : IDataHandler
    {
        protected string connectionString;

        #region --- Query方法 ---
        /// <summary>
        /// 执行查询操作
        /// </summary>
        /// <param name="commandText">命令文本</param>
        ///<returns>返回查询后的数据表</returns>
        public DataTable Query(string commandText)
        {
            return this.Query(commandText, null, 0, 0);
        }
        /// <summary>
        /// 执行查询操作
        /// </summary>
        /// <param name="commandText">命令文本</param>
        /// <param name="parameters">参数对象容器</param>
        /// <returns>返回查询后的数据表</returns>
        public DataTable Query(string commandText, IList parameters)
        {
            return this.Query(commandText, parameters, 0, 0);
        }

        /// <summary>
        /// 执行查询操作
        /// </summary>
        /// <param name="commandText">命令文本</param>
        /// <param name="start">查询的起始行索引号</param>
        /// <param name="max">分页的大小</param>
        /// <returns>返回查询后的数据表</returns>
        public DataTable Query(string commandText, int start, int max)
        {
            return this.Query(commandText, null, start, max);
        }
        /// <summary>
        /// 执行查询操作
        /// </summary>
        /// <param name="commandText">命令文本</param>
        /// <param name="parameters">参数对象容器</param>
        /// <param name="start">查询的起始行索引号</param>
        /// <param name="max">分页的大小</param>
        /// <returns>返回查询后的数据表</returns>
        public abstract DataTable Query(string commandText, IList parameters, int start, int max);

        #endregion

        #region --- ExecuteCommand方法 ---
        /// <summary>
        /// 执行更新操作的命令
        /// </summary>
        /// <param name="commandText">命令文本</param>
        /// <param name="parameters">参数对象容器</param>
        /// <returns>执行成功返回true,否则返回false</returns>
        public bool ExecuteCommand(string commandText)
        {
            return this.ExecuteCommand(commandText, null);
        }
        /// <summary>
        /// 执行更新操作的命令
        /// </summary>
        /// <param name="commandText">命令文本</param>
        /// <param name="parameters">参数对象容器</param>
        /// <returns>执行成功返回true,否则返回false</returns>
        public abstract bool ExecuteCommand(string commandText, IList parameters);

        #endregion

        #region ---- ExecuteBatchCommand方法 ---
        /// <summary>
        /// 批量执行更新操作的命令
        /// </summary>
        /// <param name="commandTexts">命令文本集合</param>
        /// <returns>执行成功返回true,否则返回false</returns>
        public bool ExecuteBatchCommand(IList commandTexts)
        {
            return ExecuteBatchCommand(commandTexts, null);
        }

        /// <summary>
        /// 批量执行更新操作的命令
        /// </summary>
        /// <param name="commandTexts">命令文本集合</param>
        /// <param name="parameters">参数对象容器的容器</param>
        /// <returns>执行成功返回true,否则返回false</returns>
        public abstract bool ExecuteBatchCommand(IList commandTexts, IList parameters);

        #endregion

        /// <summary>
        /// 创建数据库交互对象
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="dbType">数据库访问类型</param>
        /// <returns></returns>
        public static IDataHandler CreateHandler(string connectionString, DatabaseType dbType)
        {
            switch (dbType)
            {
                case DatabaseType.OleDb:

                    return new OleDbDataHandler(connectionString);

                case DatabaseType.Sql:

                    return new SqlDataHandler(connectionString);

                default:

                    return new SqlDataHandler(connectionString);
            }
        }

        /// <summary>
        /// 创建数据库交互对象,默认为Sql
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="dbType">数据库访问类型</param>
        public static IDataHandler CreateHandler(string connectionString)
        {
            return new SqlDataHandler(connectionString);
        }

        /// <summary>
        /// 根据配置文件的配置信息，创建数据库交互对象。
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="dbType">数据库访问类型</param>
        public static IDataHandler CreateHandler()
        {
            string dbType = ConfigurationManager.AppSettings["DbType"].ToLower();

            DatabaseType type = DatabaseType.Sql;
            if (dbType == "oledb")
            {
                type = DatabaseType.OleDb;
            }
            else if (dbType == "oracle")
            {
                type = DatabaseType.Oracle;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["BM_Connection"].ConnectionString;

            return CreateHandler(connectionString, type);
        }

        /// <summary>
        /// 释放指定对象的资源
        /// </summary>
        /// <param name="obj"></param>
        protected void Dispose(IDisposable obj)
        {
            if (obj != null)
            {
                obj.Dispose();
                obj = null;
            }
        }
    }
}
