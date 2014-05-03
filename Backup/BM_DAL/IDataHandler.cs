using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace Web0204.BM.DAL
{
    /// <summary>
    /// IDataHandler接口提供与数据库交互的事务处理功能
    /// </summary>
    public interface IDataHandler
    {
        /// <summary>
        /// 执行查询操作
        /// </summary>
        /// <param name="commandText">命令文本</param>
        ///<returns>返回查询后的数据表</returns>
        DataTable Query(string commandText);

        /// <summary>
        /// 执行查询操作
        /// </summary>
        /// <param name="commandText">命令文本</param>
        /// <param name="parameters">参数对象容器</param>
        /// <returns>返回查询后的数据表</returns>
        DataTable Query(string commandText, IList parameters);
        /// <summary>
        /// 执行查询操作
        /// </summary>
        /// <param name="commandText">命令文本</param>
        /// <param name="start">查询的起始行索引号</param>
        /// <param name="max">分页的大小</param>
        /// <returns>返回查询后的数据表</returns>
        DataTable Query(string commandText, int start, int max);

        /// <summary>
        /// 执行查询操作
        /// </summary>
        /// <param name="commandText">命令文本</param>
        /// <param name="parameters">参数对象容器</param>
        /// <param name="start">查询的起始行索引号</param>
        /// <param name="max">分页的大小</param>
        /// <returns>返回查询后的数据表</returns>
        DataTable Query(string commandText, IList parameters, int start, int max);

        /// <summary>
        /// 执行更新操作的命令
        /// </summary>
        /// <param name="commandText">命令文本</param>
        /// <param name="parameters">参数对象容器</param>
        /// <returns>执行成功返回true,否则返回false</returns>
        bool ExecuteCommand(string commandText);
        /// <summary>
        /// 执行更新操作的命令
        /// </summary>
        /// <param name="commandText">命令文本</param>
        /// <param name="parameters">参数对象容器</param>
        /// <returns>执行成功返回true,否则返回false</returns>
        bool ExecuteCommand(string commandText, IList parameters);

        /// <summary>
        /// 批量执行更新操作的命令
        /// </summary>
        /// <param name="commandTexts">命令文本集合</param>
        /// <returns>执行成功返回true,否则返回false</returns>
        bool ExecuteBatchCommand(IList commandTexts);

        /// <summary>
        /// 批量执行更新操作的命令
        /// </summary>
        /// <param name="commandTexts">命令文本集合</param>
        /// <param name="parameters">参数对象容器的容器</param>
        /// <returns>执行成功返回true,否则返回false</returns>
        bool ExecuteBatchCommand(IList commandTexts, IList parameters);

    }
}
