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
            if (String.IsNullOrEmpty(staff.Staffinfo_Name))
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_staff VALUES (@user_id,@department_id,@staffinfo_position,@staffinfo_name,@staffinfo_cell,@staffinfo_sex)";

                DataParameter parmUserId = new DataParameter();
                parmUserId.ParameterName = "@user_id";
                parmUserId.DbType = DbType.Int32;
                parmUserId.Value = staff.User_id;

                DataParameter parmDepartmentId = new DataParameter();
                parmDepartmentId.ParameterName = "@department_id";
                parmDepartmentId.DbType = DbType.String;
                parmDepartmentId.Value = staff.Role_id.ToString();

                DataParameter parmPosition = new DataParameter();
                parmPosition.ParameterName = "@staffinfo_position";
                parmPosition.DbType = DbType.String;
                parmPosition.Value = staff.Staffinfo_position;

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@staffinfo_name";
                parmName.DbType = DbType.String;
                parmName.Value = staff.Staffinfo_Name;

                DataParameter parmCell = new DataParameter();
                parmCell.ParameterName = "@staffinfo_cell";
                parmCell.DbType = DbType.String;
                parmCell.Value = staff.Staffinfo_cell;

                DataParameter parmSex = new DataParameter();
                parmSex.ParameterName = "@staffinfo_sex";
                parmSex.DbType = DbType.String;
                parmSex.Value = staff.Staffinfo_sex;

                IList parameters = new ArrayList();
                parameters.Add(parmUserId);
                parameters.Add(parmDepartmentId);
                parameters.Add(parmPosition);
                parameters.Add(parmName);
                parameters.Add(parmCell);
                parameters.Add(parmSex);


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
//@user_id,@department_id,@staffinfo_position,@staffinfo_name,@staffinfo_cell,@staffinfo_sex,)";
            string commandText = " UPDATE  t_staff " +
                                  " SET department_id=@department_id,staffinfo_name=@staffinfo_name,staffinfo_cell=@staffinfo_cell,staffinfo_sex=@staffinfo_sex " +
                                     " WHERE staffinfo_id=@staffinfo_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@staffinfo_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = staff.Staffinfo_id;

            DataParameter parmRoleId = new DataParameter();
            parmRoleId.ParameterName = "@department_id";
            parmRoleId.DbType = DbType.String;
            parmRoleId.Value = staff.Role_id.ToString();


            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@staffinfo_name";
            parmName.DbType = DbType.String;
            parmName.Value = staff.Staffinfo_Name;

            DataParameter parmCell = new DataParameter();
            parmCell.ParameterName = "@staffinfo_cell";
            parmCell.DbType = DbType.String;
            parmCell.Value = staff.Staffinfo_cell;

            DataParameter parmSex = new DataParameter();
            parmSex.ParameterName = "@staffinfo_sex";
            parmSex.DbType = DbType.String;
            parmSex.Value = staff.Staffinfo_sex;


            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmRoleId);
            parameters.Add(parmName);
            parameters.Add(parmCell);
            parameters.Add(parmSex);

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
            commandText.Append("SELECT staffs.*");// FROM t_staff staffs, "); //WHERE users.user_id=staffs.user_id ");
            IList parameters = new ArrayList();

            if (staff.Role_id == 2)
            {
                commandText.Append(" ,isnull(purchase.sum, 0) sum from t_staff staffs left join (select staffinfo_id, " +
                    "SUM(convert(int,t_purchase.purchase_price) * convert(int,t_purchase.purchase_num)) sum " +
                    " from t_purchase group by t_purchase.staffinfo_id) purchase on staffs.staffinfo_id = purchase.staffinfo_id" +
                    " where 1=1 ");
//                    " from t_purchase where t_purchase.staffinfo_id in (select staffinfo_id from t_staff staffs " + 
//                    "where 1=1 "); 
            }
            else if (staff.Role_id == 3)
            {
                commandText.Append(" ,isnull(sale.sum, 0) sum from t_staff staffs left join (select staffinfo_id, " +
                    "SUM(convert(int,t_sale.sale_price) * convert(int,t_sale.sale_num)) sum " +
                    " from t_sale group by t_sale.staffinfo_id) sale on staffs.staffinfo_id = sale.staffinfo_id " +
                    "where 1=1 ");
            }
            else if (staff.Role_id == 4)
            {
                commandText.Append(" ,isnull(stock.sum, 0) sum from t_staff staffs left join (select " +
                    "SUM(convert(int,t_stock.purchase_price) * convert(int,t_stock.stock_num)) sum " +
                    " from t_stock) stock on 1=1" +
                    "where 1=1 ");
            }
            else
            {
                commandText.Append(" from t_staff staffs WHERE 1=1");
            }
            if (staff.Staffinfo_id != 0)
            {
                commandText.Append(" AND staffs.staffinfo_id=@staffinfo_id ");
                DataParameter parmID = new DataParameter();
                parmID.ParameterName = "@staffinfo_id";
                parmID.DbType = DbType.Int32;
                parmID.Value = staff.Staffinfo_id;
                parameters.Add(parmID);

            }

            if (staff.Role_Manage == 1)
            {
                commandText.Append(" AND staffs.department_id=@role_id ");
                DataParameter parmRoleID = new DataParameter();
                parmRoleID.ParameterName = "@role_id";
                parmRoleID.DbType = DbType.Int32;
                parmRoleID.Value = staff.Role_id;
                parameters.Add(parmRoleID);
            }
            else
            {
                if (staff.Role_id != 0)
                {
                    commandText.Append(" AND staffs.department_id=@role_id ");
                    DataParameter parmRoleID = new DataParameter();
                    parmRoleID.ParameterName = "@role_id";
                    parmRoleID.DbType = DbType.Int32;
                    parmRoleID.Value = staff.Role_id;
                    parameters.Add(parmRoleID);
                }
                if (staff.User_id != 0)
                {
                    commandText.Append(" AND staffs.user_id=@user_id ");
                    DataParameter parmUserID = new DataParameter();
                    parmUserID.ParameterName = "@user_id";
                    parmUserID.DbType = DbType.Int32;
                    parmUserID.Value = staff.User_id;
                    parameters.Add(parmUserID);
                }
            }

            if (!String.IsNullOrEmpty(staff.Staffinfo_Name))
            {
                commandText.Append(" AND staffs.staffinfo_name like @staffinfo_name ");

                DataParameter parmPosition = new DataParameter();
                parmPosition.ParameterName = "@staffinfo_name";
                parmPosition.DbType = DbType.String;
                parmPosition.Value = staff.Staffinfo_Name;
                parameters.Add(parmPosition);
            }

            if (!String.IsNullOrEmpty(staff.Staffinfo_position))
            {
                commandText.Append(" AND staffs.staffinfo_position like @staffinfo_position ");

                DataParameter parmPosition = new DataParameter();
                parmPosition.ParameterName = "@staffinfo_position";
                parmPosition.DbType = DbType.String;
                parmPosition.Value = staff.Staffinfo_position;
                parameters.Add(parmPosition);
            }

            if (!String.IsNullOrEmpty(staff.Staffinfo_cell))
            {
                commandText.Append(" AND staffs.staffinfo_cell=@staffinfo_cell ");

                DataParameter parmCell = new DataParameter();
                parmCell.ParameterName = "@staffinfo_cell";
                parmCell.DbType = DbType.String;
                parmCell.Value = staff.Staffinfo_cell;
                parameters.Add(parmCell);
            }

            if (!String.IsNullOrEmpty(staff.Staffinfo_sex))
            {
                commandText.Append(" AND staffs.staffinfo_sex=@staffinfo_sex ");

                DataParameter parmSex = new DataParameter();
                parmSex.ParameterName = "@staffinfo_sex";
                parmSex.DbType = DbType.String;
                parmSex.Value = staff.Staffinfo_sex;
                parameters.Add(parmSex);
            }

            if (staff.Role_id == 2)
            {
 //               commandText.Append(" )group by t_purchase.staffinfo_id) purchase on t_staff.staffinfo_id = purchase.staffinfo_id ");
            }
            else if (staff.Role_id == 3)
            {
 //               commandText.Append(" )group by t_sale.staffinfo_id) sale on t_staff.staffinfo_id = sale.staffinfo_id ");
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
            string commandText = "SELECT * FROM t_users users,t_staff staffs WHERE users.user_id=staffs.user_id";
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
            string commandText = "SELECT * FROM t_users users,t_staff staffs WHERE users.role_id =@role_id And users.user_id=staffs.user_id";

            return this.handler.Query(commandText, start, max);
        }

        /// <summary>
        /// 获取当前部门所有的员工信息记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetRoleAll(Staff staff, int start, int max)
        {
/*            string commandText = "SELECT * FROM t_users users,t_staff staffs WHERE users.role_id =@role_id And users.user_id=staffs.user_id";

            IList parameters = new ArrayList();
            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@staffinfo_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = role_id;
            parameters.Add(parmID);*/

            return Select(staff, start, max);
           // return this.handler.Query(commandText, parameters, start, max);
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
        /// 获取类似姓名员工个数
        /// </summary>
        /// <param name="staff">员工信息</param>
        /// <returns></returns>
        public int GetSize(Staff staff)
        {
            string commandText = "SELECT Count(staffinfo_id) FROM t_staff WHERE department_id=@role_id";

            DataParameter parmRoleId = new DataParameter();
            parmRoleId.ParameterName = "@role_id";
            parmRoleId.DbType = DbType.String;
            parmRoleId.Value = staff.Role_id;

            IList parameters = new ArrayList();
            parameters.Add(parmRoleId);

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
            parmID.DbType = DbType.Int32;
            parmID.Value = staff.Staffinfo_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 

        #region --- GetStaffinfoId方法 ---

        /// <summary>
        /// 获取指定的用户员工号
        /// </summary>
        /// <param name="user">将要被删除的用户信息</param>
        /// <returns>删除成功返回true,否则返回false</returns>
        public int GetStaffinfoId(int userid)
        {
            string commandText = "select staffinfo_id FROM t_staff WHERE user_id=@user_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@user_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = userid;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            DataTable table = this.handler.Query(commandText, parameters);
            if (table != null && table.Rows.Count == 1)
            {
                return Convert.ToInt32(table.Rows[0]["staffinfo_id"].ToString());
            }
            else
            {
                return 0;
            }
        }

        public int GetStaffinfoId(string name)
        {
            string commandText = "select staffinfo_id FROM t_staff WHERE staffinfo_name=@staffinfo_name";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@staffinfo_name";
            parmID.DbType = DbType.String;
            parmID.Value = name;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            DataTable table = this.handler.Query(commandText, parameters);
            if (table != null && table.Rows.Count == 1)
            {
                return Convert.ToInt32(table.Rows[0]["staffinfo_id"].ToString());
            }
            else
            {
                return 0;
            }
        }

        #endregion 
    }
}
