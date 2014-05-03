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
    /// UserProvider��ʾ��¼�û���Ϣ�����Ĺ�����
    /// </summary>
    public class UserProvider : ActionBase
    {

        #region --- Login���� ---

        /// <summary>
        /// �жϵ�ǰ�û��Ƿ��½�ɹ�
        /// </summary>
        /// <param name="user">�û�ʵ����</param>
        /// <returns>�û��Ƿ��½�ɹ�</returns>
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
                return true;
            }
            return false;
        }
        #endregion

        #region --- Insert���� ---

        /// <summary>
        /// ���һ���µ��û���Ϣ
        /// </summary>
        /// <param unit="user">�µ��û���Ϣ</param>
        /// <returns>��ӳɹ�����true,���򷵻�false</returns>
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
                string commandText = "INSERT INTO t_users VALUES(@role_id,@user_name,@user_phone,@user_fax,@user_email,@user_datetime,@user_account,@user_pass)";

                DataParameter parmRoleId = new DataParameter();
                parmRoleId.ParameterName = "@role_id";
                parmRoleId.DbType = DbType.Int32;
                parmRoleId.Value = user.Role_id;

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

        #region --- Update���� ---

        /// <summary>
        /// �޸��û���Ϣ������
        /// </summary>
        /// <param name="user">�µ��û���Ϣ</param>
        /// <returns>�޸ĳɹ�����true,���򷵻�false</returns>
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
            parameters.Add(parmName);
            parameters.Add(parmPhone);
            parameters.Add(parmFax);
            parameters.Add(parmEmail);
            parameters.Add(parmDatetime);
            parameters.Add(parmAccount);
            parameters.Add(parmPass);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion

        #region --- Select���� ---

        /// <summary>
        /// ����ָ���Ĺ���������ѯ�û���Ϣ
        /// </summary>
        /// <param name="user">��������</param>
        /// <returns></returns>
        public DataTable Select(Users user)
        {
            return this.Select(user, 0, 0);
        }

        /// <summary>
        /// ���÷�ҳ����,����ָ���Ĺ���������ѯ�û���Ϣ
        /// </summary>
        /// <param name="product">��������</param>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable Select(Users user, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT * FROM t_users users,t_role roles WHERE users.role_id=roles.role_id ");
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

            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        #endregion

        #region --- GetAll���� ---

        /// <summary>
        /// ��ȡ���е��û���Ϣ��¼
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_users users,t_role roles WHERE users.role_id=roles.role_id";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// ���÷�ҳ���ƻ�ȡ���е��û���Ϣ��¼
        /// </summary>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT * FROM t_users users,t_role roles WHERE users.role_id=roles.role_id";
            return this.handler.Query(commandText, start, max);
        }

        #endregion

        #region --- GetSize���� ---

        /// <summary>
        /// ��ȡ������
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
        /// ��ȡ�û�����������
        /// </summary>
        /// <param name="user">�û���Ϣ</param>
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

        #region --- Delete���� ---

        /// <summary>
        /// ɾ��ָ�����û���Ϣ
        /// </summary>
        /// <param name="user">��Ҫ��ɾ�����û���Ϣ</param>
        /// <returns>ɾ���ɹ�����true,���򷵻�false</returns>
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
