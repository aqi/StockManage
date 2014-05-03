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
    /// FreightProvider���ʾ�˷Ѹ��㷽ʽģ������Ĺ�����
    /// </summary>
    public class FreightProvider : ActionBase
    {
        #region --- Insert���� ---

        /// <summary>
        /// ���һ���µ��˷Ѹ��㷽ʽ
        /// </summary>
        /// <param unit="freight">�µ��˷Ѹ��㷽ʽ</param>
        /// <returns>��ӳɹ�����true,���򷵻�false</returns>
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

        #region --- Update���� ---

        /// <summary>
        /// �޸��˷Ѹ��㷽ʽ������
        /// </summary>
        /// <param name="freight">�µ��˷Ѹ��㷽ʽ</param>
        /// <returns>�޸ĳɹ�����true,���򷵻�false</returns>
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

        #region --- Select���� ---

        /// <summary>
        /// ����ָ���Ĺ���������ѯ�˷Ѹ��㷽ʽ
        /// </summary>
        /// <param name="freight">��������</param>
        /// <returns></returns>
        public DataTable Select(Freight freight)
        {
            return this.Select(freight, 0, 0);
        }

        /// <summary>
        /// ���÷�ҳ����,����ָ���Ĺ���������ѯ�˷Ѹ��㷽ʽ
        /// </summary>
        /// <param name="freight">��������</param>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
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

        #region --- GetAll���� ---

        /// <summary>
        /// ��ȡ���е��˷Ѹ��㷽ʽ��¼
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_freight";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// ���÷�ҳ���ƻ�ȡ���е��˷Ѹ��㷽ʽ��¼
        /// </summary>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT * FROM t_freight";
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
            string commandText = "SELECT Count(freight_id) FROM t_freight";
            DataTable table = this.handler.Query(commandText);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        /// <summary>
        /// ��ȡ�˷Ѹ��㷽ʽ����������
        /// </summary>
        /// <param name="freight">��Ʒ���</param>
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

        #region --- Delete���� ---

        /// <summary>
        /// ɾ��ָ�����˷Ѹ��㷽ʽ
        /// </summary>
        /// <param name="freight">��Ҫ��ɾ�����˷Ѹ��㷽ʽ</param>
        /// <returns>ɾ���ɹ�����true,���򷵻�false</returns>
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
