using System;
using System.Collections.Generic;
using System.Text;
using Web0204.BM.DAL;
using Web0204.BM.Info;
using System.Collections;
using System.Data;

namespace Web0204.BM.BLL
{
    /// <summary>
    /// ManagerProvider类表示管理模块操作的管理者
    /// </summary>
    public class ManagerProvider :ActionBase
    {
        /// <summary>
        /// 查询管理信息
        /// </summary>
        /// <returns>管理信息表</returns>
        public DataTable Select()
        {
            string commandText = "SELECT * FROM t_manage";

            return this.handler.Query(commandText);
        }
    }
}
