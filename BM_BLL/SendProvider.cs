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
    /// SendProvider类表示寄件方式模块操作的管理者
    /// </summary>
    public class SendProvider : ActionBase
    {
        #region --- Insert方法 ---

        /// <summary>
        /// 添加一条新的寄件方式
        /// </summary>
        /// <param unit="send">新的寄件方式</param>
        /// <returns>添加成功返回true,否则返回false</returns>
        public bool Insert(Send send)
        {
            if (String.IsNullOrEmpty(send.Send_name))
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_send VALUES (@send_name)";

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@send_name";
                parmName.DbType = DbType.String;
                parmName.Value = send.Send_name;

                IList parameters = new ArrayList();
                parameters.Add(parmName);

                return this.handler.ExecuteCommand(commandText, parameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        #endregion

        #region --- Update方法 ---

        /// <summary>
        /// 修改寄件方式的内容
        /// </summary>
        /// <param name="send">新的寄件方式</param>
        /// <returns>修改成功返回true,否则返回false</returns>
        public bool Update(Send send)
        {
            if (send.Send_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_send " +
                                  " SET send_name=@send_name " +
                                     " WHERE send_id=@send_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@send_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = send.Send_id;

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@send_name";
            parmName.DbType = DbType.String;
            parmName.Value = send.Send_name;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmName);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion

        #region --- Select方法 ---

        /// <summary>
        /// 根据指定的过滤条件查询寄件方式
        /// </summary>
        /// <param name="send">过滤条件</param>
        /// <returns></returns>
        public DataTable Select(Send send)
        {
            return this.Select(send, 0, 0);
        }

        /// <summary>
        /// 利用分页机制,根据指定的过滤条件查询寄件方式
        /// </summary>
        /// <param name="send">过滤条件</param>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable Select(Send send, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT * FROM t_send WHERE 1=1 ");
            IList parameters = new ArrayList();

            if (send.Send_id != 0)
            {
                commandText.Append(" AND send_id=@send_id ");
                DataParameter parmID = new DataParameter();
                parmID.ParameterName = "@send_id";
                parmID.DbType = DbType.Int32;
                parmID.Value = send.Send_id;
                parameters.Add(parmID);

            }

            if ( false == String.IsNullOrEmpty(send.Send_name))
            {
                commandText.Append(" AND send_name like @send_name ");

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@send_name";
                parmName.DbType = DbType.String;
                parmName.Value = send.Send_name;
                parameters.Add(parmName);
            }



            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        #endregion

        #region --- GetAll方法 ---

        /// <summary>
        /// 获取所有的寄件方式记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_send";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// 利用分页机制获取所有的寄件方式记录
        /// </summary>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT * FROM t_send";
            return this.handler.Query(commandText, start, max);
        }

        #endregion

        #region --- GetSize方法 ---

        /// <summary>
        /// 获取总行数
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            string commandText = "SELECT Count(send_id) FROM t_send";
            DataTable table = this.handler.Query(commandText);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        /// <summary>
        /// 获取寄件方式名称总行数
        /// </summary>
        /// <param name="send">寄件方式</param>
        /// <returns></returns>
        public int GetSize(Send send)
        {
            string commandText = "SELECT Count(send_id) FROM t_send WHERE send_name like @send_name";

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@send_name";
            parmName.DbType = DbType.String;
            parmName.Value = send.Send_name;

            IList parameters = new ArrayList();
            parameters.Add(parmName);

            DataTable table = this.handler.Query(commandText, parameters);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        #endregion

        #region --- Delete方法 ---

        /// <summary>
        /// 删除指定的寄件方式
        /// </summary>
        /// <param name="send">将要被删除的寄件方式</param>
        /// <returns>删除成功返回true,否则返回false</returns>
        public bool Delete(Send send)
        {
            if (send.Send_id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_send WHERE send_id=@send_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@send_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = send.Send_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 
    }
}
