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
    /// StaffProvider类表示员工信息模块操作的管理者
    /// </summary>
    public class StaffProvider : ActionBase
    {
        #region --- Insert方法 ---

        /// <summary>
        /// 添加一条新的员工信息
        /// </summary>
        /// <param name="staff">新的员工信息</param>
        /// <returns>添加成功返回true,否则返回false</returns>
        public bool Insert(Staff staff)
        {
            if (String.IsNullOrEmpty(staff.Staffinfo_num))
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_staff VALUES (@staffinfo_position,@staffinfo_num,@staffinfo_cell,@staffinfo_sex,@staffinfo_exp)";

                DataParameter parmPosition = new DataParameter();
                parmPosition.ParameterName = "@staffinfo_position";
                parmPosition.DbType = DbType.String;
                parmPosition.Value = staff.Staffionfo_position;

                DataParameter parmNum = new DataParameter();
                parmNum.ParameterName = "@staffinfo_num";
                parmNum.DbType = DbType.String;
                parmNum.Value = staff.Staffinfo_num;

                DataParameter parmCell = new DataParameter();
                parmCell.ParameterName = "@staffinfo_cell";
                parmCell.DbType = DbType.String;
                parmCell.Value = staff.Staffinfo_cell;

                DataParameter parmSex = new DataParameter();
                parmSex.ParameterName = "@staffinfo_sex";
                parmSex.DbType = DbType.String;
                parmSex.Value = staff.Staffinfo_sex;

                DataParameter parmExp = new DataParameter();
                parmExp.ParameterName = "@staffinfo_exp";
                parmExp.DbType = DbType.String;
                parmExp.Value = staff.Staffinfo_exp;

                IList parameters = new ArrayList();
                parameters.Add(parmPosition);
                parameters.Add(parmNum);
                parameters.Add(parmCell);
                parameters.Add(parmSex);
                parameters.Add(parmExp);

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
        /// 修改员工信息的内容
        /// </summary>
        /// <param name="staff">新的员工信息</param>
        /// <returns>修改成功返回true,否则返回false</returns>
        public bool Update(Staff staff)
        {
            if (staff.Staffinfo_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_staff " +
                                  " SET staffinfo_position=@staffinfo_position,staffinfo_num=@staffinfo_num,staffinfo_cell=@staffinfo_cell,staffinfo_sex=@staffinfo_sex,staffinfo_exp=@staffinfo_exp " +
                                     " WHERE staffinfo_id=@staffinfo_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@staffinfo_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = staff.Staffinfo_id;

            DataParameter parmPosition = new DataParameter();
            parmPosition.ParameterName = "@staffinfo_position";
            parmPosition.DbType = DbType.String;
            parmPosition.Value = staff.Staffionfo_position;

            DataParameter parmNum = new DataParameter();
            parmNum.ParameterName = "@staffinfo_num";
            parmNum.DbType = DbType.String;
            parmNum.Value = staff.Staffinfo_num;

            DataParameter parmCell = new DataParameter();
            parmCell.ParameterName = "@staffinfo_cell";
            parmCell.DbType = DbType.String;
            parmCell.Value = staff.Staffinfo_cell;

            DataParameter parmSex = new DataParameter();
            parmSex.ParameterName = "@staffinfo_sex";
            parmSex.DbType = DbType.String;
            parmSex.Value = staff.Staffinfo_sex;

            DataParameter parmExp = new DataParameter();
            parmExp.ParameterName = "@staffinfo_exp";
            parmExp.DbType = DbType.String;
            parmExp.Value = staff.Staffinfo_exp;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmPosition);
            parameters.Add(parmNum);
            parameters.Add(parmCell);
            parameters.Add(parmSex);
            parameters.Add(parmExp);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion

        #region --- Select方法 ---

        /// <summary>
        /// 根据指定的过滤条件查询员工信息
        /// </summary>
        /// <param name="staff">过滤条件</param>
        /// <returns></returns>
        public DataTable Select(Staff staff)
        {
            return this.Select(staff, 0, 0);
        }

        /// <summary>
        /// 利用分页机制,根据指定的过滤条件查询员工信息
        /// </summary>
        /// <param name="staff">过滤条件</param>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable Select(Staff staff, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT * FROM t_staff WHERE 1=1 ");
            IList parameters = new ArrayList();

            if (staff.Staffinfo_id != 0)
            {
                commandText.Append(" AND staffinfo_id=@staffinfo_id ");
                DataParameter parmID = new DataParameter();
                parmID.ParameterName = "@staffinfo_id";
                parmID.DbType = DbType.Int32;
                parmID.Value = staff.Staffinfo_id;
                parameters.Add(parmID);

            }

            if (!String.IsNullOrEmpty(staff.Staffionfo_position))
            {
                commandText.Append(" AND staffinfo_position like @staffinfo_position ");

                DataParameter parmPosition = new DataParameter();
                parmPosition.ParameterName = "@staffinfo_position";
                parmPosition.DbType = DbType.String;
                parmPosition.Value = staff.Staffionfo_position;
                parameters.Add(parmPosition);
            }

            if (!String.IsNullOrEmpty(staff.Staffinfo_num))
            {
                commandText.Append(" AND staffinfo_num=@staffinfo_num ");

                DataParameter parmNum = new DataParameter();
                parmNum.ParameterName = "@staffinfo_num";
                parmNum.DbType = DbType.String;
                parmNum.Value = staff.Staffinfo_num;
                parameters.Add(parmNum);
            }

            if (!String.IsNullOrEmpty(staff.Staffinfo_cell))
            {
                commandText.Append(" AND staffinfo_cell=@staffinfo_cell ");

                DataParameter parmCell = new DataParameter();
                parmCell.ParameterName = "@staffinfo_cell";
                parmCell.DbType = DbType.String;
                parmCell.Value = staff.Staffinfo_cell;
                parameters.Add(parmCell);
            }

            if (!String.IsNullOrEmpty(staff.Staffinfo_sex))
            {
                commandText.Append(" AND staffinfo_sex=@staffinfo_sex ");

                DataParameter parmSex = new DataParameter();
                parmSex.ParameterName = "@staffinfo_sex";
                parmSex.DbType = DbType.String;
                parmSex.Value = staff.Staffinfo_sex;
                parameters.Add(parmSex);
            }

            if (!String.IsNullOrEmpty(staff.Staffinfo_exp))
            {
                commandText.Append(" AND staffinfo_exp=@staffinfo_exp ");

                DataParameter parmExp = new DataParameter();
                parmExp.ParameterName = "@staffinfo_exp";
                parmExp.DbType = DbType.String;
                parmExp.Value = staff.Staffinfo_exp;
                parameters.Add(parmExp);
            }

            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        #endregion

        #region --- GetAll方法 ---

        /// <summary>
        /// 获取所有的员工信息记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_staff";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// 利用分页机制获取所有的员工信息记录
        /// </summary>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT * FROM t_staff";
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
            string commandText = "SELECT Count(staffinfo_id) FROM t_staff";
            DataTable table = this.handler.Query(commandText);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        /// <summary>
        /// 获取公司职位总行数
        /// </summary>
        /// <param name="staff">员工信息</param>
        /// <returns></returns>
        public int GetSize(Staff staff)
        {
            string commandText = "SELECT Count(staffinfo_id) FROM t_staff WHERE staffinfo_position like @staffinfo_position";

            DataParameter parmPosition = new DataParameter();
            parmPosition.ParameterName = "@staffinfo_position";
            parmPosition.DbType = DbType.String;
            parmPosition.Value = staff.Staffionfo_position;

            IList parameters = new ArrayList();
            parameters.Add(parmPosition);

            DataTable table = this.handler.Query(commandText,parameters);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        #endregion

        #region --- Delete方法 ---

        /// <summary>
        /// 删除指定的员工信息
        /// </summary>
        /// <param name="staff">将要被删除的员工信息</param>
        /// <returns>删除成功返回true,否则返回false</returns>
        public bool Delete(Staff staff)
        {
            if (staff.Staffinfo_id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_staff WHERE staffinfo_id=@id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@id";
            parmID.DbType = DbType.String;
            parmID.Value = staff.Staffinfo_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 
    }
}
