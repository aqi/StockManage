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
    /// ManagerProvider���ʾ����ģ������Ĺ�����
    /// </summary>
    public class ManagerProvider :ActionBase
    {
        /// <summary>
        /// ��ѯ������Ϣ
        /// </summary>
        /// <returns>������Ϣ��</returns>
        public DataTable Select()
        {
            string commandText = "SELECT * FROM t_manage";

            return this.handler.Query(commandText);
        }
    }
}
