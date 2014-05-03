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
    public class SupplierProvider : ActionBase
    {
        #region --- Insert���� ---

        /// <summary>
        /// ���һ���µ��û���Ϣ
        /// </summary>
        /// <param unit="supplier">�µ��û���Ϣ</param>
        /// <returns>��ӳɹ�����true,���򷵻�false</returns>
        public bool Insert(Supplier supplier)
        {
            if (String.IsNullOrEmpty(supplier.Supplier_Name))
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_supplier VALUES(@supplier_name,@supplier_address,@supplier_postcode,@supplier_cell,@supplier_phone,@supplier_fax,@supplier_email,@supplier_liaison)";

                DataParameter parmSupplierName = new DataParameter();
                parmSupplierName.ParameterName = "@supplier_name";
                parmSupplierName.DbType = DbType.String;
                parmSupplierName.Value = supplier.Supplier_Name;

                DataParameter parmSupplierAddress = new DataParameter();
                parmSupplierAddress.ParameterName = "@supplier_address";
                parmSupplierAddress.DbType = DbType.String;
                parmSupplierAddress.Value = supplier.Supplier_Address;

                DataParameter parmSupplierPostcode = new DataParameter();
                parmSupplierPostcode.ParameterName = "@supplier_postcode";
                parmSupplierPostcode.DbType = DbType.String;
                parmSupplierPostcode.Value = supplier.Supplier_Postcode;

                DataParameter parmSupplierCell = new DataParameter();
                parmSupplierCell.ParameterName = "@supplier_cell";
                parmSupplierCell.DbType = DbType.String;
                parmSupplierCell.Value = supplier.Supplier_Cell;

                DataParameter parmSupplierPhone = new DataParameter();
                parmSupplierPhone.ParameterName = "@supplier_phone";
                parmSupplierPhone.DbType = DbType.String;
                parmSupplierPhone.Value = supplier.Supplier_Phone;

                DataParameter parmSupplierFax = new DataParameter();
                parmSupplierFax.ParameterName = "@supplier_fax";
                parmSupplierFax.DbType = DbType.String;
                parmSupplierFax.Value = supplier.Supplier_Fax;

                DataParameter parmSupplierEmail = new DataParameter();
                parmSupplierEmail.ParameterName = "@supplier_email";
                parmSupplierEmail.DbType = DbType.String;
                parmSupplierEmail.Value = supplier.Supplier_Email;

                DataParameter parmSupplierLiaison = new DataParameter();
                parmSupplierLiaison.ParameterName = "@supplier_liaison";
                parmSupplierLiaison.DbType = DbType.String;
                parmSupplierLiaison.Value = supplier.Supplier_Liaison;

                IList parameters = new ArrayList();
                parameters.Add(parmSupplierName);
                parameters.Add(parmSupplierAddress);
                parameters.Add(parmSupplierPostcode);
                parameters.Add(parmSupplierCell);
                parameters.Add(parmSupplierPhone);
                parameters.Add(parmSupplierFax);
                parameters.Add(parmSupplierEmail);
                parameters.Add(parmSupplierLiaison);

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
        /// <param name="supplier">�µ��û���Ϣ</param>
        /// <returns>�޸ĳɹ�����true,���򷵻�false</returns>
        public bool Update(Supplier supplier)
        {
            if (supplier.Supplier_Id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_supplier " +
                                  " SET supplier_name=@supplier_name," + 
                                    " supplier_address=@supplier_address, supplier_postcode=@supplier_postcode,"+
                                    " supplier_cell=@supplier_cell, supplier_phone=@supplier_phone," +
                                    " supplier_fax=@supplier_fax, supplier_email=@supplier_email," + 
                                    " supplier_liaison=@supplier_liaison" +
                                     " WHERE supplier_id=@supplier_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@supplier_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = supplier.Supplier_Id;

            DataParameter parmSupplierName = new DataParameter();
            parmSupplierName.ParameterName = "@supplier_name";
            parmSupplierName.DbType = DbType.String;
            parmSupplierName.Value = supplier.Supplier_Name;

            DataParameter parmSupplierAddress = new DataParameter();
            parmSupplierAddress.ParameterName = "@supplier_address";
            parmSupplierAddress.DbType = DbType.String;
            parmSupplierAddress.Value = supplier.Supplier_Address;

            DataParameter parmSupplierPostcode = new DataParameter();
            parmSupplierPostcode.ParameterName = "@supplier_postcode";
            parmSupplierPostcode.DbType = DbType.String;
            parmSupplierPostcode.Value = supplier.Supplier_Postcode;

            DataParameter parmSupplierCell = new DataParameter();
            parmSupplierCell.ParameterName = "@supplier_cell";
            parmSupplierCell.DbType = DbType.String;
            parmSupplierCell.Value = supplier.Supplier_Cell;

            DataParameter parmSupplierPhone = new DataParameter();
            parmSupplierPhone.ParameterName = "@supplier_phone";
            parmSupplierPhone.DbType = DbType.String;
            parmSupplierPhone.Value = supplier.Supplier_Phone;

            DataParameter parmSupplierFax = new DataParameter();
            parmSupplierFax.ParameterName = "@supplier_fax";
            parmSupplierFax.DbType = DbType.String;
            parmSupplierFax.Value = supplier.Supplier_Fax;

            DataParameter parmSupplierEmail = new DataParameter();
            parmSupplierEmail.ParameterName = "@supplier_email";
            parmSupplierEmail.DbType = DbType.String;
            parmSupplierEmail.Value = supplier.Supplier_Email;

            DataParameter parmSupplierLiaison = new DataParameter();
            parmSupplierLiaison.ParameterName = "@supplier_liaison";
            parmSupplierLiaison.DbType = DbType.String;
            parmSupplierLiaison.Value = supplier.Supplier_Liaison;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmSupplierName);
            parameters.Add(parmSupplierAddress);
            parameters.Add(parmSupplierPostcode);
            parameters.Add(parmSupplierCell);
            parameters.Add(parmSupplierPhone);
            parameters.Add(parmSupplierFax);
            parameters.Add(parmSupplierEmail);
            parameters.Add(parmSupplierLiaison);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion

        #region --- Select���� ---

        /// <summary>
        /// ����ָ���Ĺ���������ѯ�û���Ϣ
        /// </summary>
        /// <param name="supplier">��������</param>
        /// <returns></returns>
        public DataTable Select(Supplier supplier)
        {
            return this.Select(supplier, 0, 0);
        }

        /// <summary>
        /// ���÷�ҳ����,����ָ���Ĺ���������ѯ�û���Ϣ
        /// </summary>
        /// <param name="product">��������</param>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable Select(Supplier supplier, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT *, ('S' + right('000000' + convert(varchar(8), supplier_id), 7)) supplier_bh FROM t_Supplier suppliers WHERE 1 = 1");
            IList parameters = new ArrayList();

            if ( false == String.IsNullOrEmpty(supplier.Supplier_Name))
            {
                commandText.Append(" And supplier_name like @supplier_name ");

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@supplier_name";
                parmName.DbType = DbType.String;
                parmName.Value = supplier.Supplier_Name;
                parameters.Add(parmName);
            }

            if ( false == String.IsNullOrEmpty(supplier.Supplier_Phone))
            {
                commandText.Append(" AND supplier_phone=@supplier_phone ");

                DataParameter parmPhone = new DataParameter();
                parmPhone.ParameterName = "@supplier_phone";
                parmPhone.DbType = DbType.String;
                parmPhone.Value = supplier.Supplier_Phone;
                parameters.Add(parmPhone);
            }

            if ( false == String.IsNullOrEmpty(supplier.Supplier_Fax))
            {
                commandText.Append(" AND supplier_fax=@supplier_fax ");

                DataParameter parmFax = new DataParameter();
                parmFax.ParameterName = "@supplier_fax";
                parmFax.DbType = DbType.String;
                parmFax.Value = supplier.Supplier_Fax;
                parameters.Add(parmFax);
            }

            if ( false == String.IsNullOrEmpty(supplier.Supplier_Email))
            {
                commandText.Append(" AND supplier_email=@supplier_email ");

                DataParameter parmEmail = new DataParameter();
                parmEmail.ParameterName = "@supplier_email";
                parmEmail.DbType = DbType.String;
                parmEmail.Value = supplier.Supplier_Email;
                parameters.Add(parmEmail);
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
            string commandText = "SELECT *,('S' + right('000000' + convert(varchar(8), supplier_id), 7)) supplier_bh  FROM t_supplier";
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
            string commandText = "SELECT *,('S' + right('000000' + convert(varchar(8), supplier_id), 7)) supplier_bh FROM t_supplier ";
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
            string commandText = "SELECT Count(supplier_id) FROM t_supplier";
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
        /// <param name="supplier">�û���Ϣ</param>
        /// <returns></returns>
        public int GetSize(Supplier supplier)
        {
            string commandText = "SELECT Count(supplier_id) FROM t_supplier WHERE supplier_name like @supplier_name";

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@supplier_name";
            parmName.DbType = DbType.String;
            parmName.Value = supplier.Supplier_Name;

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
        public bool Delete(Supplier supplier)
        {
            if (supplier.Supplier_Id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_supplier WHERE supplier_id=@supplier_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@supplier_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = supplier.Supplier_Id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 
    }
}
