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
    /// UnitProvider类表示产品单位模块操作的管理者
    /// </summary>
    public class UnitProvider : ActionBase
    {
        #region --- Insert方法 ---

        /// <summary>
        /// 添加一条新的产品单位
        /// </summary>
        /// <param unit="staff">新的产品单位</param>
        /// <returns>添加成功返回true,否则返回false</returns>
        public bool Insert(Units unit)
        {
            if (String.IsNullOrEmpty(unit.Unit_name))
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_unit VALUES (@unit_name)";

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@unit_name";
                parmName.DbType = DbType.String;
                parmName.Value = unit.Unit_name;

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
        /// 修改产品单位的内容
        /// </summary>
        /// <param name="unit">新的产品单位</param>
        /// <returns>修改成功返回true,否则返回false</returns>
        public bool Update(Units unit)
        {
            if (unit.Unit_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_unit " +
                                  " SET unit_name=@unit_name " +
                                     " WHERE unit_id=@unit_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@unit_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = unit.Unit_id;

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@unit_name";
            parmName.DbType = DbType.String;
            parmName.Value = unit.Unit_name;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmName);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion

        #region --- Select方法 ---

        /// <summary>
        /// 根据指定的过滤条件查询产品单位
        /// </summary>
        /// <param name="unit">过滤条件</param>
        /// <returns></returns>
        public DataTable Select(Units unit)
        {
            return this.Select(unit, 0, 0);
        }

        /// <summary>
        /// 利用分页机制,根据指定的过滤条件查询产品单位
        /// </summary>
        /// <param name="unit">过滤条件</param>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable Select(Units unit, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT * FROM t_unit WHERE 1=1 ");
            IList parameters = new ArrayList();

            if (unit.Unit_id != 0)
            {
                commandText.Append(" AND unit_id=@unit_id ");
                DataParameter parmID = new DataParameter();
                parmID.ParameterName = "@unit_id";
                parmID.DbType = DbType.Int32;
                parmID.Value = unit.Unit_id;
                parameters.Add(parmID);

            }

            if (!String.IsNullOrEmpty(unit.Unit_name))
            {
                commandText.Append(" AND unit_name like @unit_name ");

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@unit_name";
                parmName.DbType = DbType.String;
                parmName.Value = unit.Unit_name;
                parameters.Add(parmName);
            }

            

            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        #endregion

        #region --- GetAll方法 ---

        /// <summary>
        /// 获取所有的产品单位记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_unit";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// 利用分页机制获取所有的产品单位记录
        /// </summary>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT * FROM t_unit";
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
            string commandText = "SELECT Count(unit_id) FROM t_unit";
            DataTable table = this.handler.Query(commandText);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        /// <summary>
        /// 获取产品单位名称总行数
        /// </summary>
        /// <param name="unit">产品单位</param>
        /// <returns></returns>
        public int GetSize(Units unit)
        {
            string commandText = "SELECT Count(unit_id) FROM t_unit WHERE unit_name like @unit_name";

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@unit_name";
            parmName.DbType = DbType.String;
            parmName.Value = unit.Unit_name;

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
        /// 删除指定的产品单位
        /// </summary>
        /// <param name="unit">将要被删除的产品单位</param>
        /// <returns>删除成功返回true,否则返回false</returns>
        public bool Delete(Units unit)
        {
            if (unit.Unit_id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_unit WHERE unit_id=@unit_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@unit_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = unit.Unit_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 
    }
}
