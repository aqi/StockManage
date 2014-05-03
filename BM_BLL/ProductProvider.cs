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
    /// ProductProvider���ʾ��Ʒ���ģ������Ĺ�����
    /// </summary>
    public class ProductProvider : ActionBase
    {
        #region --- Insert���� ---

        /// <summary>
        /// ���һ���µĲ�Ʒ���
        /// </summary>
        /// <param unit="product">�µĲ�Ʒ���</param>
        /// <returns>��ӳɹ�����true,���򷵻�false</returns>
        public bool Insert(Product product)
        {
            if (String.IsNullOrEmpty(product.Product_name))
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_product VALUES (@product_name)";

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@product_name";
                parmName.DbType = DbType.String;
                parmName.Value = product.Product_name;

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
        /// �޸Ĳ�Ʒ��������
        /// </summary>
        /// <param name="product">�µĲ�Ʒ���</param>
        /// <returns>�޸ĳɹ�����true,���򷵻�false</returns>
        public bool Update(Product product)
        {
            if (product.Product_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_product " +
                                  " SET product_name=@product_name " +
                                     " WHERE product_id=@product_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@product_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = product.Product_id;

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@product_name";
            parmName.DbType = DbType.String;
            parmName.Value = product.Product_name;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmName);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion

        #region --- Select���� ---

        /// <summary>
        /// ����ָ���Ĺ���������ѯ��Ʒ���
        /// </summary>
        /// <param name="product">��������</param>
        /// <returns></returns>
        public DataTable Select(Product product)
        {
            return this.Select(product, 0, 0);
        }

        /// <summary>
        /// ���÷�ҳ����,����ָ���Ĺ���������ѯ��Ʒ���
        /// </summary>
        /// <param name="product">��������</param>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable Select(Product product, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT * FROM t_product WHERE 1=1 ");
            IList parameters = new ArrayList();

            if (product.Product_id != 0)
            {
                commandText.Append(" AND product_id=@product_id ");
                DataParameter parmID = new DataParameter();
                parmID.ParameterName = "@product_id";
                parmID.DbType = DbType.Int32;
                parmID.Value = product.Product_id;
                parameters.Add(parmID);

            }

            if ( false == String.IsNullOrEmpty(product.Product_name))
            {
                commandText.Append(" AND product_name like  @product_name ");

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@product_name";
                parmName.DbType = DbType.String;
                parmName.Value = product.Product_name;
                parameters.Add(parmName);
            }



            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        #endregion

        #region --- GetAll���� ---

        /// <summary>
        /// ��ȡ���еĲ�Ʒ����¼
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_product";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// ���÷�ҳ���ƻ�ȡ���еĲ�Ʒ����¼
        /// </summary>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT * FROM t_product";
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
            string commandText = "SELECT Count(product_id) FROM t_product";
            DataTable table = this.handler.Query(commandText);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        /// <summary>
        /// ��ȡ��Ʒ�������������
        /// </summary>
        /// <param name="product">��Ʒ���</param>
        /// <returns></returns>
        public int GetSize(Product product)
        {
            string commandText = "SELECT Count(product_id) FROM t_product WHERE product_name like @product_name";

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@product_name";
            parmName.DbType = DbType.String;
            parmName.Value = product.Product_name;

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
        /// ɾ��ָ���Ĳ�Ʒ���
        /// </summary>
        /// <param name="unit">��Ҫ��ɾ���Ĳ�Ʒ���</param>
        /// <returns>ɾ���ɹ�����true,���򷵻�false</returns>
        public bool Delete(Product product)
        {
            if (product.Product_id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_product WHERE product_id=@product_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@product_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = product.Product_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 
    }
}
