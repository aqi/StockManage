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
    /// FreightProvider类表示运费付汇方式模块操作的管理者
    /// </summary>
    public class FreightProvider : ActionBase
    {
        #region --- Insert方法 ---

        /// <summary>
        /// 添加一条新的运费付汇方式
        /// </summary>
        /// <param unit="freight">新的运费付汇方式</param>
        /// <returns>添加成功返回true,否则返回false</returns>
        public bool Insert(Freight freight)
        {
            if (String.IsNullOrEmpty(freight.Freight_name))
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_freight VALUES (@freight_name)";

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@freight_name";
                parmName.DbType = DbType.String;
                parmName.Value = freight.Freight_name;

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
        /// 修改运费付汇方式的内容
        /// </summary>
        /// <param name="freight">新的运费付汇方式</param>
        /// <returns>修改成功返回true,否则返回false</returns>
        public bool Update(Freight freight)
        {
            if (freight.Freight_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_freight " +
                                  " SET freight_name=@freight_name " +
                                     " WHERE freight_id=@freight_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@freight_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = freight.Freight_id;

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@freight_name";
            parmName.DbType = DbType.String;
            parmName.Value = freight.Freight_name;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmName);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion

        #region --- Select方法 ---

        /// <summary>
        /// 根据指定的过滤条件查询运费付汇方式
        /// </summary>
        /// <param name="freight">过滤条件</param>
        /// <returns></returns>
        public DataTable Select(Freight freight)
        {
            return this.Select(freight, 0, 0);
        }

        /// <summary>
        /// 利用分页机制,根据指定的过滤条件查询运费付汇方式
        /// </summary>
        /// <param name="freight">过滤条件</param>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable Select(Freight freight, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT * FROM t_freight WHERE 1=1 ");
            IList parameters = new ArrayList();

            if (freight.Freight_id != 0)
            {
                commandText.Append(" AND freight_id=@freight_id ");
                DataParameter parmID = new DataParameter();
                parmID.ParameterName = "@freight_id";
                parmID.DbType = DbType.Int32;
                parmID.Value = freight.Freight_id;
                parameters.Add(parmID);

            }

            if ( false == String.IsNullOrEmpty(freight.Freight_name))
            {
                commandText.Append(" AND freight_name like @freight_name ");

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@freight_name";
                parmName.DbType = DbType.String;
                parmName.Value = freight.Freight_name;
                parameters.Add(parmName);
            }



            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        #endregion

        #region --- GetAll方法 ---

        /// <summary>
        /// 获取所有的运费付汇方式记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_freight";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// 利用分页机制获取所有的运费付汇方式记录
        /// </summary>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT * FROM t_freight";
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
            string commandText = "SELECT Count(freight_id) FROM t_freight";
            DataTable table = this.handler.Query(commandText);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        /// <summary>
        /// 获取运费付汇方式名称总行数
        /// </summary>
        /// <param name="freight">产品类别</param>
        /// <returns></returns>
        public int GetSize(Freight freight)
        {
            string commandText = "SELECT Count(freight_id) FROM t_freight WHERE freight_name like @freight_name";

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@freight_name";
            parmName.DbType = DbType.String;
            parmName.Value = freight.Freight_name;

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
        /// 删除指定的运费付汇方式
        /// </summary>
        /// <param name="freight">将要被删除的运费付汇方式</param>
        /// <returns>删除成功返回true,否则返回false</returns>
        public bool Delete(Freight freight)
        {
            if (freight.Freight_id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_freight WHERE freight_id=@freight_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@freight_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = freight.Freight_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 
    }
}
