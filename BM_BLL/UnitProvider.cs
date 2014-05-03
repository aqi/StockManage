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
    /// UnitProvider���ʾ��Ʒ��λģ������Ĺ�����
    /// </summary>
    public class UnitProvider : ActionBase
    {
        #region --- Insert���� ---

        /// <summary>
        /// ���һ���µĲ�Ʒ��λ
        /// </summary>
        /// <param unit="staff">�µĲ�Ʒ��λ</param>
        /// <returns>��ӳɹ�����true,���򷵻�false</returns>
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

        #region --- Update���� ---

        /// <summary>
        /// �޸Ĳ�Ʒ��λ������
        /// </summary>
        /// <param name="unit">�µĲ�Ʒ��λ</param>
        /// <returns>�޸ĳɹ�����true,���򷵻�false</returns>
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

        #region --- Select���� ---

        /// <summary>
        /// ����ָ���Ĺ���������ѯ��Ʒ��λ
        /// </summary>
        /// <param name="unit">��������</param>
        /// <returns></returns>
        public DataTable Select(Units unit)
        {
            return this.Select(unit, 0, 0);
        }

        /// <summary>
        /// ���÷�ҳ����,����ָ���Ĺ���������ѯ��Ʒ��λ
        /// </summary>
        /// <param name="unit">��������</param>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
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

            if ( false == String.IsNullOrEmpty(unit.Unit_name))
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

        #region --- GetAll���� ---

        /// <summary>
        /// ��ȡ���еĲ�Ʒ��λ��¼
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_unit";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// ���÷�ҳ���ƻ�ȡ���еĲ�Ʒ��λ��¼
        /// </summary>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT * FROM t_unit";
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
            string commandText = "SELECT Count(unit_id) FROM t_unit";
            DataTable table = this.handler.Query(commandText);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        /// <summary>
        /// ��ȡ��Ʒ��λ����������
        /// </summary>
        /// <param name="unit">��Ʒ��λ</param>
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

        #region --- Delete���� ---

        /// <summary>
        /// ɾ��ָ���Ĳ�Ʒ��λ
        /// </summary>
        /// <param name="unit">��Ҫ��ɾ���Ĳ�Ʒ��λ</param>
        /// <returns>ɾ���ɹ�����true,���򷵻�false</returns>
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
