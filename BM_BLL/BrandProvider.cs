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
    /// BrandProvider���ʾ��ƷƷ��ģ������Ĺ�����
    /// </summary>
    public class BrandProvider : ActionBase
    {

        #region --- Insert���� ---

        /// <summary>
        /// ���һ���µĲ�ƷƷ��
        /// </summary>
        /// <param unit="brand">�µĲ�ƷƷ��</param>
        /// <returns>��ӳɹ�����true,���򷵻�false</returns>
        public bool Insert(Brand brand)
        {
            if (String.IsNullOrEmpty(brand.Brand_name))
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_brand VALUES (@brand_name)";

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@brand_name";
                parmName.DbType = DbType.String;
                parmName.Value = brand.Brand_name;

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
        /// �޸Ĳ�ƷƷ�Ƶ�����
        /// </summary>
        /// <param name="brand">�µĲ�ƷƷ��</param>
        /// <returns>�޸ĳɹ�����true,���򷵻�false</returns>
        public bool Update(Brand brand)
        {
            if (brand.Brand_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_brand " +
                                  " SET brand_name=@brand_name " +
                                     " WHERE brand_id=@brand_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@brand_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = brand.Brand_id;

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@brand_name";
            parmName.DbType = DbType.String;
            parmName.Value = brand.Brand_name;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmName);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion

        #region --- Select���� ---

        /// <summary>
        /// ����ָ���Ĺ���������ѯ��ƷƷ��
        /// </summary>
        /// <param name="brand">��������</param>
        /// <returns></returns>
        public DataTable Select(Brand brand)
        {
            return this.Select(brand, 0, 0);
        }

        /// <summary>
        /// ���÷�ҳ����,����ָ���Ĺ���������ѯ��ƷƷ��
        /// </summary>
        /// <param name="brand">��������</param>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable Select(Brand brand, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT * FROM t_brand WHERE 1=1 ");
            IList parameters = new ArrayList();

            if (brand.Brand_id != 0)
            {
                commandText.Append(" AND brand_id=@brand_id ");
                DataParameter parmID = new DataParameter();
                parmID.ParameterName = "@brand_id";
                parmID.DbType = DbType.Int32;
                parmID.Value = brand.Brand_id;
                parameters.Add(parmID);

            }

            if (!String.IsNullOrEmpty(brand.Brand_name))
            {
                commandText.Append(" AND brand_name like @brand_name ");

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@brand_name";
                parmName.DbType = DbType.String;
                parmName.Value = brand.Brand_name;
                parameters.Add(parmName);
            }



            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        #endregion

        #region --- GetAll���� ---

        /// <summary>
        /// ��ȡ���еĲ�ƷƷ�Ƽ�¼
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_brand";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// ���÷�ҳ���ƻ�ȡ���еĲ�ƷƷ�Ƽ�¼
        /// </summary>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT * FROM t_brand";
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
            string commandText = "SELECT Count(brand_id) FROM t_brand";
            DataTable table = this.handler.Query(commandText);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        /// <summary>
        /// ��ȡ��ƷƷ������������
        /// </summary>
        /// <param name="brand">��ƷƷ��</param>
        /// <returns></returns>
        public int GetSize(Brand brand)
        {
            string commandText = "SELECT Count(brand_id) FROM t_brand WHERE brand_name like @brand_name";

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@brand_name";
            parmName.DbType = DbType.String;
            parmName.Value = brand.Brand_name;

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
        /// ɾ��ָ���Ĳ�ƷƷ��
        /// </summary>
        /// <param name="brand">��Ҫ��ɾ���Ĳ�ƷƷ��</param>
        /// <returns>ɾ���ɹ�����true,���򷵻�false</returns>
        public bool Delete(Brand brand)
        {
            if (brand.Brand_id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_brand WHERE brand_id=@brand_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@brand_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = brand.Brand_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 

    }
}
