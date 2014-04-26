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
    /// UserProvider表示登录用户信息操作的管理者
    /// </summary>
    public class UserProvider : ActionBase
    {

        #region --- Login方法 ---

        /// <summary>
        /// 判断当前用户是否登陆成功
        /// </summary>
        /// <param name="user">用户实体类</param>
        /// <returns>用户是否登陆成功</returns>
        public bool Login(Users user)
        {
            if (user.User_account == "" || user.User_pass == "")
            {
                return false;
            }
            string sql = "SELECT * FROM t_users " +
                        "WHERE user_account=@user_account AND user_pass=@user_pass";

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@user_account";
            parmName.DbType = DbType.String;
            parmName.Value = user.User_account;

            DataParameter parmPassword = new DataParameter();
            parmPassword.ParameterName = "@user_pass";
            parmPassword.DbType = DbType.String;
            parmPassword.Value = user.User_pass;

            IList parameters = new ArrayList();
            parameters.Add(parmName);
            parameters.Add(parmPassword);

            DataTable table = this.handler.Query(sql, parameters);
            if (table != null && table.Rows.Count == 1)
            {
                MaileSend mailSend = new MaileSend();
                mailSend.SendMail(table.Rows[0]["user_email"].ToString());
                return true;
            }
            return false;
        }
        #endregion


        #region --- Insert方法 ---

        /// <summary>
        /// 添加一条新的用户信息
        /// </summary>
        /// <param unit="user">新的用户信息</param>
        /// <returns>添加成功返回true,否则返回false</returns>
        public bool Insert(Users user)
        {
            if (String.IsNullOrEmpty(user.User_account))
            {
                return false;
            }

            if (String.IsNullOrEmpty(user.User_pass))
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_users VALUES(@role_id,@user_manage,@user_name,@user_phone,@user_fax,@user_email,@user_datetime,@user_account,@user_pass)";

                DataParameter parmRoleId = new DataParameter();
                parmRoleId.ParameterName = "@role_id";
                parmRoleId.DbType = DbType.Int32;
                parmRoleId.Value = user.Role_id;

                DataParameter parmManageId = new DataParameter();
                parmManageId.ParameterName = "@user_manage";
                parmManageId.DbType = DbType.Int32;
                parmManageId.Value = user.User_Manage;

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@user_name";
                parmName.DbType = DbType.String;
                parmName.Value = user.User_name;

                DataParameter parmPhone = new DataParameter();
                parmPhone.ParameterName = "@user_phone";
                parmPhone.DbType = DbType.String;
                parmPhone.Value = user.User_phone;

                DataParameter parmFax = new DataParameter();
                parmFax.ParameterName = "@user_fax";
                parmFax.DbType = DbType.String;
                parmFax.Value = user.User_fax;

                DataParameter parmEmail = new DataParameter();
                parmEmail.ParameterName = "@user_email";
                parmEmail.DbType = DbType.String;
                parmEmail.Value = user.User_email;

                DataParameter parmDatetime = new DataParameter();
                parmDatetime.ParameterName = "@user_datetime";
                parmDatetime.DbType = DbType.String;
                parmDatetime.Value = user.User_datetime;

                DataParameter parmAccount = new DataParameter();
                parmAccount.ParameterName = "@user_account";
                parmAccount.DbType = DbType.String;
                parmAccount.Value = user.User_account;

                DataParameter parmPass = new DataParameter();
                parmPass.ParameterName = "@user_pass";
                parmPass.DbType = DbType.String;
                parmPass.Value = user.User_pass;

                IList parameters = new ArrayList();
                parameters.Add(parmRoleId);
                parameters.Add(parmManageId);
                parameters.Add(parmName);
                parameters.Add(parmPhone);
                parameters.Add(parmFax);
                parameters.Add(parmEmail);
                parameters.Add(parmDatetime);
                parameters.Add(parmAccount);
                parameters.Add(parmPass);

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
        /// 修改用户信息的内容
        /// </summary>
        /// <param name="user">新的用户信息</param>
        /// <returns>修改成功返回true,否则返回false</returns>
        public bool Update(Users user)
        {
            if (user.User_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_users " +
                                  " SET role_id=@role_id,user_name=@user_name, user_phone=@user_phone, user_fax=@user_fax, user_email=@user_email, user_datetime=@user_datetime, user_account=@user_account, user_pass=@user_pass  " +
                                     " WHERE user_id=@user_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@user_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = user.User_id;

            DataParameter parmRoleId = new DataParameter();
            parmRoleId.ParameterName = "@role_id";
            parmRoleId.DbType = DbType.Int32;
            parmRoleId.Value = user.Role_id;

            DataParameter parmManageId = new DataParameter();
            parmManageId.ParameterName = "@user_manage";
            parmManageId.DbType = DbType.Int32;
            parmManageId.Value = user.User_Manage;

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@user_name";
            parmName.DbType = DbType.String;
            parmName.Value = user.User_name;

            DataParameter parmPhone = new DataParameter();
            parmPhone.ParameterName = "@user_phone";
            parmPhone.DbType = DbType.String;
            parmPhone.Value = user.User_phone;

            DataParameter parmFax = new DataParameter();
            parmFax.ParameterName = "@user_fax";
            parmFax.DbType = DbType.String;
            parmFax.Value = user.User_fax;

            DataParameter parmEmail = new DataParameter();
            parmEmail.ParameterName = "@user_email";
            parmEmail.DbType = DbType.String;
            parmEmail.Value = user.User_email;

            DataParameter parmDatetime = new DataParameter();
            parmDatetime.ParameterName = "@user_datetime";
            parmDatetime.DbType = DbType.String;
            parmDatetime.Value = user.User_datetime;

            DataParameter parmAccount = new DataParameter();
            parmAccount.ParameterName = "@user_account";
            parmAccount.DbType = DbType.String;
            parmAccount.Value = user.User_account;

            DataParameter parmPass = new DataParameter();
            parmPass.ParameterName = "@user_pass";
            parmPass.DbType = DbType.String;
            parmPass.Value = user.User_pass;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmRoleId);
            parameters.Add(parmManageId);
            parameters.Add(parmName);
            parameters.Add(parmPhone);
            parameters.Add(parmFax);
            parameters.Add(parmEmail);
            parameters.Add(parmDatetime);
            parameters.Add(parmAccount);
            parameters.Add(parmPass);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="newPassWord">新密码</param>
        /// <returns>修改成功返回true,否则返回false</returns>
        public bool UpdatePassWord(int userId, string newPassWord)
        {
            if (userId == 0 || newPassWord == "")
            {
                return false;
            }

            string commandText = " UPDATE  t_users " +
                                  " SET user_pass=@user_pass  " +
                                     " WHERE user_id=@user_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@user_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = userId;

            DataParameter parmPass = new DataParameter();
            parmPass.ParameterName = "@user_pass";
            parmPass.DbType = DbType.String;
            parmPass.Value = newPassWord;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmPass);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion

        #region --- Select方法 ---

        /// <summary>
        /// 根据指定的过滤条件查询用户信息
        /// </summary>
        /// <param name="user">过滤条件</param>
        /// <returns></returns>
        public DataTable Select(Users user)
        {
            return this.Select(user, 0, 0);
        }

        public DataTable SelectStaff(Users user)
        {
            return this.SelectStaff(user, 0, 0);
        }
        /// <summary>
        /// 利用分页机制,根据指定的过滤条件查询用户信息
        /// </summary>
        /// <param name="product">过滤条件</param>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable Select(Users user, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT * FROM t_users users,t_role roles WHERE users.role_id=roles.role_id");
            IList parameters = new ArrayList();

            if (user.User_id != 0)
            {
                commandText.Append(" AND user_id=@user_id ");
                DataParameter parmID = new DataParameter();
                parmID.ParameterName = "@user_id";
                parmID.DbType = DbType.Int32;
                parmID.Value = user.User_id;
                parameters.Add(parmID);

            }

            if (user.Role_id != 0)
            {
                commandText.Append(" AND users.role_id=@role_id ");
                DataParameter parmRoleId = new DataParameter();
                parmRoleId.ParameterName = "@role_id";
                parmRoleId.DbType = DbType.Int32;
                parmRoleId.Value = user.Role_id;
                parameters.Add(parmRoleId);

            }

            if (user.User_Login != 1)
            {
                commandText.Append(" AND user_manage=@user_manage ");
                DataParameter parmManageID = new DataParameter();
                parmManageID.ParameterName = "@user_manage";
                parmManageID.DbType = DbType.Int32;
                parmManageID.Value = user.User_Manage;
                parameters.Add(parmManageID);
            }

            if (!String.IsNullOrEmpty(user.User_name))
            {
                commandText.Append(" AND user_name like @user_name ");

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@user_name";
                parmName.DbType = DbType.String;
                parmName.Value = user.User_name;
                parameters.Add(parmName);
            }

            if (!String.IsNullOrEmpty(user.User_phone))
            {
                commandText.Append(" AND user_phone=@user_phone ");

                DataParameter parmPhone = new DataParameter();
                parmPhone.ParameterName = "@user_phone";
                parmPhone.DbType = DbType.String;
                parmPhone.Value = user.User_phone;
                parameters.Add(parmPhone);
            }

            if (!String.IsNullOrEmpty(user.User_fax))
            {
                commandText.Append(" AND user_fax=@user_fax ");

                DataParameter parmFax = new DataParameter();
                parmFax.ParameterName = "@user_fax";
                parmFax.DbType = DbType.String;
                parmFax.Value = user.User_fax;
                parameters.Add(parmFax);
            }

            if (!String.IsNullOrEmpty(user.User_email))
            {
                commandText.Append(" AND user_email=@user_email ");

                DataParameter parmEmail = new DataParameter();
                parmEmail.ParameterName = "@user_email";
                parmEmail.DbType = DbType.String;
                parmEmail.Value = user.User_email;
                parameters.Add(parmEmail);
            }

            if (!String.IsNullOrEmpty(user.User_account))
            {
                commandText.Append(" AND user_account=@user_account ");

                DataParameter parmAccount = new DataParameter();
                parmAccount.ParameterName = "@user_account";
                parmAccount.DbType = DbType.String;
                parmAccount.Value = user.User_account;
                parameters.Add(parmAccount);
            }

            if (!String.IsNullOrEmpty(user.User_pass))
            {
                commandText.Append(" AND user_pass=@user_pass ");

                DataParameter parmPass = new DataParameter();
                parmPass.ParameterName = "@user_pass";
                parmPass.DbType = DbType.String;
                parmPass.Value = user.User_pass;
                parameters.Add(parmPass);
            }

            commandText.Append("  order by users.role_id,users.user_manage DESC,users.user_name");

            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        /// <summary>
        /// 利用分页机制,根据指定的过滤条件查询用户信息
        /// </summary>
        /// <param name="product">过滤条件</param>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable SelectStaff(Users user, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            //commandText.Append("SELECT * FROM t_users users,t_role roles WHERE users.role_id=roles.role_id");
            commandText.Append("SELECT users.*,roles.*, '是' manage FROM t_users users,t_role roles WHERE" + 
                " users.role_id=roles.role_id and users.user_manage = 1 "); 

            IList parameters = new ArrayList();


            if (!String.IsNullOrEmpty(user.User_name))
            {
                commandText.Append(" AND user_name like @user_name ");

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@user_name";
                parmName.DbType = DbType.String;
                parmName.Value = user.User_name;
                parameters.Add(parmName);
            }
            commandText.Append(" union all SELECT users1.*,roles1.*, '否' manage FROM t_users users1,t_role roles1 " + 
                            "WHERE users1.role_id=roles1.role_id and users1.user_manage = 0 ");
            if (!String.IsNullOrEmpty(user.User_name))
            {
                commandText.Append(" AND users1.user_name like @user_name1 ");

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@user_name1";
                parmName.DbType = DbType.String;
                parmName.Value = user.User_name;
                parameters.Add(parmName);
            }
            
            commandText.Append("order by users.role_id,users.user_manage DESC,users.user_name");

            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        #endregion

        #region --- GetAll方法 ---

        /// <summary>
        /// 获取所有的用户信息记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_users users,t_role roles WHERE users.role_id=roles.role_id order by users.role_id,users.user_manage DESC,users.user_name";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// 利用分页机制获取所有的用户信息记录
        /// </summary>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            //string commandText = "SELECT * FROM t_users users,t_role roles WHERE " +
             //   "users.role_id=roles.role_id order by users.role_id,users.user_manage DESC,users.user_name";
            string commandText = "SELECT users.*,roles.*, '是' manage FROM t_users users,t_role roles " + 
                "WHERE users.role_id=roles.role_id and users.user_manage = 1 " + 
                "union all SELECT users1.*,roles1.*, '否' manage FROM t_users users1,t_role roles1 " + 
                "WHERE users1.role_id=roles1.role_id and users1.user_manage = 0 " + 
                "order by users.role_id,users.user_manage DESC,users.user_name";
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
            string commandText = "SELECT Count(user_id) FROM t_users";
            DataTable table = this.handler.Query(commandText);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        /// <summary>
        /// 获取用户名称总行数
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns></returns>
        public int GetSize(Users user)
        {
            string commandText = "SELECT Count(user_id) FROM t_users WHERE user_name like @user_name";

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@user_name";
            parmName.DbType = DbType.String;
            parmName.Value = user.User_name;

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

        #region --- GetUserId方法 ---

        /// <summary>
        /// 获取账号USER_ID
        /// </summary>
        /// <returns></returns>
        public int GetUserId(string account)
        {
            string commandText = "SELECT user_id FROM t_users where t_users.user_account=@user_account";

            DataParameter parmAccount = new DataParameter();
            parmAccount.ParameterName = "@user_account";
            parmAccount.DbType = DbType.String;
            parmAccount.Value = account;

            IList parameters = new ArrayList();
            parameters.Add(parmAccount);

            DataTable table = this.handler.Query(commandText,parameters);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }
        #endregion

        #region --- GetUserManage方法 ---

        /// <summary>
        /// 获取账号经理标志
        /// </summary>
        /// <returns></returns>
        public int GetUserManage(string account)
        {
            string commandText = "SELECT user_manage FROM t_users where t_users.user_account=@user_account";

            DataParameter parmAccount = new DataParameter();
            parmAccount.ParameterName = "@user_account";
            parmAccount.DbType = DbType.String;
            parmAccount.Value = account;

            IList parameters = new ArrayList();
            parameters.Add(parmAccount);

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
        /// 删除指定的用户信息
        /// </summary>
        /// <param name="user">将要被删除的用户信息</param>
        /// <returns>删除成功返回true,否则返回false</returns>
        public bool Delete(Users user)
        {
            if (user.User_id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_users WHERE user_id=@user_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@user_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = user.User_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 
    }
}
