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
    /// SendProvider���ʾ�ļ���ʽģ������Ĺ�����
    /// </summary>
    public class SendProvider : ActionBase
    {
        #region --- Insert���� ---

        /// <summary>
        /// ���һ���µļļ���ʽ
        /// </summary>
        /// <param unit="send">�µļļ���ʽ</param>
        /// <returns>��ӳɹ�����true,���򷵻�false</returns>
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

        #region --- Update���� ---

        /// <summary>
        /// �޸ļļ���ʽ������
        /// </summary>
        /// <param name="send">�µļļ���ʽ</param>
        /// <returns>�޸ĳɹ�����true,���򷵻�false</returns>
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

        #region --- Select���� ---

        /// <summary>
        /// ����ָ���Ĺ���������ѯ�ļ���ʽ
        /// </summary>
        /// <param name="send">��������</param>
        /// <returns></returns>
        public DataTable Select(Send send)
        {
            return this.Select(send, 0, 0);
        }

        /// <summary>
        /// ���÷�ҳ����,����ָ���Ĺ���������ѯ�ļ���ʽ
        /// </summary>
        /// <param name="send">��������</param>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
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

            if (!String.IsNullOrEmpty(send.Send_name))
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

        #region --- GetAll���� ---

        /// <summary>
        /// ��ȡ���еļļ���ʽ��¼
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_send";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// ���÷�ҳ���ƻ�ȡ���еļļ���ʽ��¼
        /// </summary>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT * FROM t_send";
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
            string commandText = "SELECT Count(send_id) FROM t_send";
            DataTable table = this.handler.Query(commandText);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        /// <summary>
        /// ��ȡ�ļ���ʽ����������
        /// </summary>
        /// <param name="send">�ļ���ʽ</param>
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

        #region --- Delete���� ---

        /// <summary>
        /// ɾ��ָ���ļļ���ʽ
        /// </summary>
        /// <param name="send">��Ҫ��ɾ���ļļ���ʽ</param>
        /// <returns>ɾ���ɹ�����true,���򷵻�false</returns>
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
