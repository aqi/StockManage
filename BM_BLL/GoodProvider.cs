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
    /// GoodProvider���ʾ��Ʒ��Ϣģ������Ĺ�����
    /// </summary>
    public class GoodProvider : ActionBase
    {
        #region --- Insert���� ---

        /// <summary>
        /// ���һ���µĲ�Ʒ��Ϣ
        /// </summary>
        /// <param unit="good">�µĲ�Ʒ��Ϣ</param>
        /// <returns>��ӳɹ�����true,���򷵻�false</returns>
        public bool Insert(Good good)
        {
            if (String.IsNullOrEmpty(good.Good_name))
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_good VALUES(@good_img,@good_name,@good_num,@purchase_priceMin,@purchase_priceMax)";

                DataParameter parmImg = new DataParameter();
                parmImg.ParameterName = "@good_img";
                parmImg.DbType = DbType.String;
                parmImg.Value = good.Good_img;

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@good_name";
                parmName.DbType = DbType.String;
                parmName.Value = good.Good_name;

                DataParameter parmNum = new DataParameter();
                parmNum.ParameterName = "@good_num";
                parmNum.DbType = DbType.String;
                parmNum.Value = good.Good_Num;

                DataParameter parmPriceMin = new DataParameter();
                parmPriceMin.ParameterName = "@purchase_priceMin";
                parmPriceMin.DbType = DbType.Int32;
                parmPriceMin.Value = good.Purchase_PriceMin;

                DataParameter parmPriceMax = new DataParameter();
                parmPriceMax.ParameterName = "@purchase_priceMax";
                parmPriceMax.DbType = DbType.Int32;
                parmPriceMax.Value = good.Purchase_PriceMax;

                IList parameters = new ArrayList();
                parameters.Add(parmImg);
                parameters.Add(parmName);
                parameters.Add(parmNum);
                parameters.Add(parmPriceMin);
                parameters.Add(parmPriceMax);

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
        /// �޸Ĳ�Ʒ��Ϣ������
        /// </summary>
        /// <param name="good">�µĲ�Ʒ��Ϣ</param>
        /// <returns>�޸ĳɹ�����true,���򷵻�false</returns>
        public bool Update(Good good)
        {
            if (good.Good_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_good " +
                                  " SET good_img=@good_img,good_name=@good_name,good_num=@good_num," +
            "purchase_priceMin=@purchase_priceMin,purchase_priceMax=@purchase_priceMax " +
                                     " WHERE good_id=@good_id ";

            DataParameter parmId = new DataParameter();
            parmId.ParameterName = "@good_id";
            parmId.DbType = DbType.Int32;
            parmId.Value = good.Good_id;

            DataParameter parmImg = new DataParameter();
            parmImg.ParameterName = "@good_img";
            parmImg.DbType = DbType.String;
            parmImg.Value = good.Good_img;

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@good_name";
            parmName.DbType = DbType.String;
            parmName.Value = good.Good_name;

            DataParameter parmNum = new DataParameter();
            parmNum.ParameterName = "@good_num";
            parmNum.DbType = DbType.String;
            parmNum.Value = good.Good_Num;

            DataParameter parmPriceMin = new DataParameter();
            parmPriceMin.ParameterName = "@purchase_priceMin";
            parmPriceMin.DbType = DbType.Int32;
            parmPriceMin.Value = good.Purchase_PriceMax;

            DataParameter parmPriceMax = new DataParameter();
            parmPriceMax.ParameterName = "@purchase_priceMax";
            parmPriceMax.DbType = DbType.Int32;
            parmPriceMin.Value = good.Purchase_PriceMin;

            IList parameters = new ArrayList();
            parameters.Add(parmId);
            parameters.Add(parmImg);
            parameters.Add(parmName);
            parameters.Add(parmNum);
            parameters.Add(parmPriceMin);
            parameters.Add(parmPriceMax);
     
            return this.handler.ExecuteCommand(commandText, parameters);
        }

        /// <summary>
        /// �޸Ĳ�Ʒ��Ϣ������
        /// </summary>
        /// <param name="good">�µĲ�Ʒ��Ϣ</param>
        /// <returns>�޸ĳɹ�����true,���򷵻�false</returns>
        public bool UpdateInfo(Good good)
        {
            if (good.Good_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_good " +
                                  " SET good_img=@good_img,good_name=@good_name,good_num=@good_num" +
                                     " WHERE good_id=@good_id ";

            DataParameter parmId = new DataParameter();
            parmId.ParameterName = "@good_id";
            parmId.DbType = DbType.Int32;
            parmId.Value = good.Good_id;

            DataParameter parmImg = new DataParameter();
            parmImg.ParameterName = "@good_img";
            parmImg.DbType = DbType.String;
            parmImg.Value = good.Good_img;

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@good_name";
            parmName.DbType = DbType.String;
            parmName.Value = good.Good_name;

            DataParameter parmNum = new DataParameter();
            parmNum.ParameterName = "@good_num";
            parmNum.DbType = DbType.String;
            parmNum.Value = good.Good_Num;

            IList parameters = new ArrayList();
            parameters.Add(parmId);
            parameters.Add(parmImg);
            parameters.Add(parmName);
            parameters.Add(parmNum);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        /// <summary>
        /// �޸Ĳ�Ʒ�޼۵�����
        /// </summary>
        /// <param name="good">�µĲ�Ʒ��Ϣ</param>
        /// <returns>�޸ĳɹ�����true,���򷵻�false</returns>
        public bool UpdatePrice(Good good)
        {
            if (good.Good_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE t_good " +
                                  " SET purchase_priceMin=@purchase_priceMin,purchase_priceMax=@purchase_priceMax " +
                                     " WHERE good_id=@good_id ";

            DataParameter parmId = new DataParameter();
            parmId.ParameterName = "@good_id";
            parmId.DbType = DbType.Int32;
            parmId.Value = good.Good_id;


            DataParameter parmPriceMin = new DataParameter();
            parmPriceMin.ParameterName = "@purchase_priceMin";
            parmPriceMin.DbType = DbType.Int32;
            parmPriceMin.Value = good.Purchase_PriceMin;

            DataParameter parmPriceMax = new DataParameter();
            parmPriceMax.ParameterName = "@purchase_priceMax";
            parmPriceMax.DbType = DbType.Int32;
            parmPriceMax.Value = good.Purchase_PriceMax;

            IList parameters = new ArrayList();
            parameters.Add(parmId);
            parameters.Add(parmPriceMin);
            parameters.Add(parmPriceMax);

            return this.handler.ExecuteCommand(commandText, parameters);
        }
       
        #endregion

        #region --- Select���� ---

        /// <summary>
        /// ����ָ���Ĺ���������ѯ��Ʒ��Ϣ
        /// </summary>
        /// <param name="good">��������</param>
        /// <returns></returns>
        public DataTable Select(Good good)
        {
            return this.Select(good, 0, 0);
        }

        /// <summary>
        /// ���÷�ҳ����,����ָ���Ĺ���������ѯ��Ʒ��Ϣ
        /// </summary>
        /// <param name="good">��������</param>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable Select(Good good, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT * FROM t_good good WHERE 1=1 ");
            IList parameters = new ArrayList();

            if ( false == String.IsNullOrEmpty(good.Good_Num))
            {
                commandText.Append(" AND good_num=@good_num ");

                DataParameter parmNum = new DataParameter();
                parmNum.ParameterName = "@good_num";
                parmNum.DbType = DbType.String;
                parmNum.Value = good.Good_Num;
                parameters.Add(parmNum);
            }

            if (good.Good_id != 0)
            {
                commandText.Append(" AND good_id=@good_id ");
                DataParameter parmID = new DataParameter();
                parmID.ParameterName = "@good_id";
                parmID.DbType = DbType.Int32;
                parmID.Value = good.Good_id;
                parameters.Add(parmID);

            }

            if ( false == String.IsNullOrEmpty(good.Good_img))
            {
                commandText.Append(" AND good_img=@good_img ");

                DataParameter parmImg = new DataParameter();
                parmImg.ParameterName = "@good_img";
                parmImg.DbType = DbType.String;
                parmImg.Value = good.Good_img;
                parameters.Add(parmImg);
            }

            if ( false == String.IsNullOrEmpty(good.Good_name))
            {
                commandText.Append(" AND good_name like @good_name ");

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@good_name";
                parmName.DbType = DbType.String;
                parmName.Value = good.Good_name;
                parameters.Add(parmName);
            }

            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        #endregion

        #region --- GetAll���� ---

        /// <summary>
        /// ��ȡ���еĲ�Ʒ��Ϣ��¼
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_good good";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// ���÷�ҳ���ƻ�ȡ���еĲ�Ʒ��Ϣ��¼
        /// </summary>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT * FROM t_good good ";
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
            string commandText = "SELECT Count(good_id) FROM t_good";
            DataTable table = this.handler.Query(commandText);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        /// <summary>
        /// ��ȡ��Ʒ��Ϣ��¼����������
        /// </summary>
        /// <param name="good">��Ʒ��Ϣ</param>
        /// <returns></returns>
        public int GetSize(Good good)
        {

            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT Count(good_id) FROM t_good WHERE 1=1 ");
            IList parameters = new ArrayList();

            if ( false == String.IsNullOrEmpty(good.Good_name))
            {
                commandText.Append(" AND good_name like @good_name ");

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@good_name";
                parmName.DbType = DbType.String;
                parmName.Value = good.Good_name;
                parameters.Add(parmName);
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
        /// ɾ��ָ���Ĳ�Ʒ��Ϣ
        /// </summary>
        /// <param name="good">��Ҫ��ɾ���Ĳ�Ʒ��Ϣ</param>
        /// <returns>ɾ���ɹ�����true,���򷵻�false</returns>
        public bool Delete(Good good)
        {
            if (good.Good_id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_good WHERE good_id=@good_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@good_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = good.Good_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 
    }
}
