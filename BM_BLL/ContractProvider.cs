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
    /// ContractProvider���ʾ��ͬ��Ϣģ������Ĺ�����
    /// </summary>
    public class ContractProvider : ActionBase
    {
        #region --- Insert���� ---

        /// <summary>
        /// ���һ���µĺ�ͬ��Ϣ
        /// </summary>
        /// <param unit="contract">�µĺ�ͬ��Ϣ</param>
        /// <returns>��ӳɹ�����true,���򷵻�false</returns>
        public bool Insert(Contract contract)
        {
            if (String.IsNullOrEmpty(contract.Contrac__num))
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_contract VALUES(@contrac_num,@company_id,@contrac_purpose,@contrac_time,@contrac_mark,@contrac_state)";

                DataParameter parmNum = new DataParameter();
                parmNum.ParameterName = "@contrac_num";
                parmNum.DbType = DbType.String;
                parmNum.Value = contract.Contrac__num;

                DataParameter parmCompanyId = new DataParameter();
                parmCompanyId.ParameterName = "@company_id";
                parmCompanyId.DbType = DbType.Int32;
                parmCompanyId.Value = contract.Company_id;

                DataParameter parmPurpose = new DataParameter();
                parmPurpose.ParameterName = "@contrac_purpose";
                parmPurpose.DbType = DbType.String;
                parmPurpose.Value = contract.Contrac_purpose;

                DataParameter parmTime = new DataParameter();
                parmTime.ParameterName = "@contrac_time";
                parmTime.DbType = DbType.DateTime;
                parmTime.Value = contract.Contrac_time;

                DataParameter parmMark = new DataParameter();
                parmMark.ParameterName = "@contrac_mark";
                parmMark.DbType = DbType.String;
                parmMark.Value = contract.Contrac_mark;

                DataParameter parmState = new DataParameter();
                parmState.ParameterName = "@contrac_state";
                parmState.DbType = DbType.String;
                parmState.Value = contract.Contrac_state;

                IList parameters = new ArrayList();
                parameters.Add(parmNum);
                parameters.Add(parmCompanyId);
                parameters.Add(parmPurpose);
                parameters.Add(parmTime);
                parameters.Add(parmMark);
                parameters.Add(parmState);

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
        /// �޸ĺ�ͬ��Ϣ������
        /// </summary>
        /// <param name="contract">�µĺ�ͬ��Ϣ</param>
        /// <returns>�޸ĳɹ�����true,���򷵻�false</returns>
        public bool Update(Contract contract)
        {
            if (contract.Contrac_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_contract " +
                                  " SET company_id=@company_id,contrac_num=@contrac_num,contrac_purpose=@contrac_purpose,contrac_time=@contrac_time,contrac_mark=@contrac_mark,contrac_state=@contrac_state " +
                                     " WHERE contrac_id=@contrac_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@contrac_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = contract.Contrac_id;

            DataParameter parmNum = new DataParameter();
            parmNum.ParameterName = "@contrac_num";
            parmNum.DbType = DbType.String;
            parmNum.Value = contract.Contrac__num;

            DataParameter parmCompanyId = new DataParameter();
            parmCompanyId.ParameterName = "@company_id";
            parmCompanyId.DbType = DbType.Int32;
            parmCompanyId.Value = contract.Company_id;

            DataParameter parmPurpose = new DataParameter();
            parmPurpose.ParameterName = "@contrac_purpose";
            parmPurpose.DbType = DbType.String;
            parmPurpose.Value = contract.Contrac_purpose;

            DataParameter parmTime = new DataParameter();
            parmTime.ParameterName = "@contrac_time";
            parmTime.DbType = DbType.DateTime;
            parmTime.Value = contract.Contrac_time;

            DataParameter parmMark = new DataParameter();
            parmMark.ParameterName = "@contrac_mark";
            parmMark.DbType = DbType.String;
            parmMark.Value = contract.Contrac_mark;

            DataParameter parmState = new DataParameter();
            parmState.ParameterName = "@contrac_state";
            parmState.DbType = DbType.String;
            parmState.Value = contract.Contrac_state;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmNum);
            parameters.Add(parmCompanyId);
            parameters.Add(parmPurpose);
            parameters.Add(parmTime);
            parameters.Add(parmMark);
            parameters.Add(parmState);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        public bool Update(string contrac_id, string contrac_state)
        {
            if (Convert.ToInt32(contrac_id) == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_contract " +
                                  " SET contrac_state=@contrac_state " +
                                     " WHERE contrac_id=@contrac_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@contrac_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = contrac_id;

            DataParameter parmState = new DataParameter();
            parmState.ParameterName = "@contrac_state";
            parmState.DbType = DbType.String;
            parmState.Value = contrac_state;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmState);

            return this.handler.ExecuteCommand(commandText, parameters);
        }
        #endregion

        #region --- Select���� ---

        /// <summary>
        /// ����ָ���Ĺ���������ѯ��ͬ��Ϣ
        /// </summary>
        /// <param name="contract">��������</param>
        /// <returns></returns>
        public DataTable Select(Contract contract)
        {
            return this.Select(contract, 0, 0);
        }

        /// <summary>
        /// ���÷�ҳ����,����ָ���Ĺ���������ѯ��ͬ��Ϣ
        /// </summary>
        /// <param name="contract">��������</param>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable Select(Contract contract, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT * FROM t_contract contracts,t_company company WHERE contracts.company_id=company.company_id ");
            IList parameters = new ArrayList();

            if (contract.Contrac_id != 0)
            {
                commandText.Append(" AND contrac_id=@contrac_id ");
                DataParameter parmID = new DataParameter();
                parmID.ParameterName = "@contrac_id";
                parmID.DbType = DbType.Int32;
                parmID.Value = contract.Contrac_id;
                parameters.Add(parmID);

            }

            if ( false == String.IsNullOrEmpty(contract.Contrac__num))
            {
                commandText.Append(" AND contrac_num like @contrac_num ");

                DataParameter parmNum = new DataParameter();
                parmNum.ParameterName = "@contrac_num";
                parmNum.DbType = DbType.String;
                parmNum.Value = contract.Contrac__num;
                parameters.Add(parmNum);
            }

            if (contract.Company_id != 0)
            {
                commandText.Append(" AND company_id=@company_id ");
                DataParameter parmCompanyId = new DataParameter();
                parmCompanyId.ParameterName = "@company_id";
                parmCompanyId.DbType = DbType.Int32;
                parmCompanyId.Value = contract.Company_id;
                parameters.Add(parmCompanyId);

            }

            if ( false == String.IsNullOrEmpty(contract.Contrac_state))
            {
                commandText.Append(" AND contrac_state like @contrac_state ");
                DataParameter parmState = new DataParameter();
                parmState.ParameterName = "@contrac_state";
                parmState.DbType = DbType.String;
                parmState.Value = contract.Contrac_state;
                parameters.Add(parmState);

            }


            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        #endregion

        #region --- GetAll���� ---

        /// <summary>
        /// ��ȡ���еĺ�ͬ��Ϣ��¼
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_contract contracts,t_company company WHERE contracts.company_id=company.company_id ";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// ���÷�ҳ���ƻ�ȡ���еĺ�ͬ��Ϣ��¼
        /// </summary>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT * FROM t_contract contracts,t_company company WHERE contracts.company_id=company.company_id ";
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
            string commandText = "SELECT Count(contrac_id) FROM t_contract";
            DataTable table = this.handler.Query(commandText);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        /// <summary>
        /// ��ȡ��������������
        /// </summary>
        /// <param name="contract">��ͬ��Ϣ</param>
        /// <returns></returns>
        public int GetSize(Contract contract)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT Count(contrac_id) FROM t_contract WHERE 1=1 ");
            IList parameters = new ArrayList();

            if ( false == String.IsNullOrEmpty(contract.Contrac__num))
            {
                commandText.Append(" AND contrac_num like @contrac_num ");

                DataParameter parmNum = new DataParameter();
                parmNum.ParameterName = "@contrac_num";
                parmNum.DbType = DbType.String;
                parmNum.Value = contract.Contrac__num;
                parameters.Add(parmNum);
            }

            if ( false == String.IsNullOrEmpty(contract.Contrac_state))
            {
                commandText.Append(" AND contrac_state like @contrac_state ");
                DataParameter parmState = new DataParameter();
                parmState.ParameterName = "@contrac_state";
                parmState.DbType = DbType.String;
                parmState.Value = contract.Contrac_state;
                parameters.Add(parmState);

            }

            DataTable table = this.handler.Query(commandText.ToString(), parameters);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        #endregion

        #region --- Delete���� ---

        /// <summary>
        /// ɾ��ָ���ĺ�ͬ��Ϣ
        /// </summary>
        /// <param name="contract">��Ҫ��ɾ���ĺ�ͬ��Ϣ</param>
        /// <returns>ɾ���ɹ�����true,���򷵻�false</returns>
        public bool Delete(Contract contract)
        {
            if (contract.Contrac_id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_contract WHERE contrac_id=@contrac_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@contrac_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = contract.Contrac_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 
    }
}
