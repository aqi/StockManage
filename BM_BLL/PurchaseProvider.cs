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
    public class PurchaseProvider : ActionBase
    {
        #region --- Insert���� ---

        /// <summary>
        /// ���һ���µ��û���Ϣ
        /// </summary>
        /// <param unit="purchase">�µ��û���Ϣ</param>
        /// <returns>��ӳɹ�����true,���򷵻�false</returns>
        public bool Insert(Purchase purchase)
        {
            if (String.IsNullOrEmpty(purchase.Good_Id)  == true)
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_purchase VALUES(@good_id,@good_name,"+
                                    "@purchase_price,@purchase_num,@purchase_datetime,@staffinfo_id,@supplier_id,@year_month)";
                DataParameter parmGoodId = new DataParameter();
                parmGoodId.ParameterName = "@good_id";
                parmGoodId.DbType = DbType.String;
                parmGoodId.Value = purchase.Good_Id;

                DataParameter parmGoodName = new DataParameter();
                parmGoodName.ParameterName = "@good_name";
                parmGoodName.DbType = DbType.String;
                parmGoodName.Value = purchase.Good_Name;

                DataParameter parmPurchasePrice = new DataParameter();
                parmPurchasePrice.ParameterName = "@purchase_price";
                parmPurchasePrice.DbType = DbType.String;
                parmPurchasePrice.Value = purchase.Purchase_Price;

                DataParameter parmPurchaseNum = new DataParameter();
                parmPurchaseNum.ParameterName = "@purchase_num";
                parmPurchaseNum.DbType = DbType.String;
                parmPurchaseNum.Value = purchase.Purchase_Num;

                DataParameter parmPurchaseDatetime = new DataParameter();
                parmPurchaseDatetime.ParameterName = "@purchase_datetime";
                parmPurchaseDatetime.DbType = DbType.String;
                parmPurchaseDatetime.Value = purchase.Purchase_Datetime;

                DataParameter parmStaffinfoId = new DataParameter();
                parmStaffinfoId.ParameterName = "@staffinfo_id";
                parmStaffinfoId.DbType = DbType.Int32;
                parmStaffinfoId.Value = purchase.Staffinfo_Id;

                DataParameter parmSupplierId = new DataParameter();
                parmSupplierId.ParameterName = "@supplier_id";
                parmSupplierId.DbType = DbType.Int32;
                parmSupplierId.Value = purchase.Supplier_Id;

                DataParameter parmYearMonth = new DataParameter();
                parmYearMonth.ParameterName = "@year_month";
                parmYearMonth.DbType = DbType.Int32;
                parmYearMonth.Value = purchase.Year_Month;

                IList parameters = new ArrayList();
                parameters.Add(parmGoodId);
                parameters.Add(parmGoodName);
                parameters.Add(parmPurchasePrice);
                parameters.Add(parmPurchaseNum);
                parameters.Add(parmPurchaseDatetime);
                parameters.Add(parmStaffinfoId);
                parameters.Add(parmSupplierId);
                parameters.Add(parmYearMonth);

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
        /// <param name="purchase">�µ��û���Ϣ</param>
        /// <returns>�޸ĳɹ�����true,���򷵻�false</returns>
        public bool Update(Purchase purchase)
        {
            if (purchase.Purchase_Id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_purchase " +
                                  " SET good_id=@good_id," +
                                    " purchase_price=@purchase_price," +
                                    " purchase_num=@purchase_num, purchase_datetime=@purchase_datetime," +
                                    " supplier_id=@supplier_id, year_month=@year_month " + 
                                     " WHERE purchase_id=@purchase_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@purchase_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = purchase.Purchase_Id;

            DataParameter parmGoodId = new DataParameter();
            parmGoodId.ParameterName = "@good_id";
            parmGoodId.DbType = DbType.String;
            parmGoodId.Value = purchase.Good_Id;

            DataParameter parmPurchasePrice = new DataParameter();
            parmPurchasePrice.ParameterName = "@purchase_price";
            parmPurchasePrice.DbType = DbType.String;
            parmPurchasePrice.Value = purchase.Purchase_Price;

            DataParameter parmPurchaseNum = new DataParameter();
            parmPurchaseNum.ParameterName = "@purchase_num";
            parmPurchaseNum.DbType = DbType.String;
            parmPurchaseNum.Value = purchase.Purchase_Num;

            DataParameter parmPurchaseDatetime = new DataParameter();
            parmPurchaseDatetime.ParameterName = "@purchase_datetime";
            parmPurchaseDatetime.DbType = DbType.String;
            parmPurchaseDatetime.Value = purchase.Purchase_Datetime;

            DataParameter parmSupplierId = new DataParameter();
            parmSupplierId.ParameterName = "@supplier_id";
            parmSupplierId.DbType = DbType.String;
            parmSupplierId.Value = purchase.Supplier_Id;

            DataParameter parmYearMonth = new DataParameter();
            parmYearMonth.ParameterName = "@year_month";
            parmYearMonth.DbType = DbType.Int32;
            parmYearMonth.Value = purchase.Year_Month;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmGoodId);
            parameters.Add(parmPurchasePrice);
            parameters.Add(parmPurchaseNum);
            parameters.Add(parmPurchaseDatetime);
            parameters.Add(parmSupplierId);
            parameters.Add(parmYearMonth);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion

        #region --- Select���� ---

        /// <summary>
        /// ����ָ���Ĺ���������ѯ�ɹ�����Ϣ
        /// </summary>
        /// <param name="purchase">��������</param>
        /// <returns></returns>
        public DataTable Select(Purchase purchase)
        {
            return this.Select(purchase, 0, 0);
        }

        /// <summary>
        /// ���÷�ҳ����,����ָ���Ĺ���������ѯ�û���Ϣ
        /// </summary>
        /// <param name="product">��������</param>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable Select(Purchase purchase, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT convert(char,purchase_id) purchase_id,good_id,purchase_price,purchase_num, " +
    "convert(int,purchase_price) * convert(int,purchase_num) purchase_total, purchase_datetime," +
    " ('S' + right('000000' + convert(varchar(8), supplier_id), 7)) supplier_bh FROM t_Purchase purchases WHERE 1 = 1");
            IList parameters = new ArrayList();

            if (purchase.Purchase_Id != 0)
            {
                commandText.Append(" And purchase_id=@purchase_id ");

                DataParameter parmPurchaseId = new DataParameter();
                parmPurchaseId.ParameterName = "@purchase_id";
                parmPurchaseId.DbType = DbType.Int32;
                parmPurchaseId.Value = purchase.Purchase_Id;
                parameters.Add(parmPurchaseId);
            }

            if ( false == String.IsNullOrEmpty(purchase.Good_Id))
            {
                commandText.Append(" And good_id=@good_id ");

                DataParameter parmGoodId = new DataParameter();
                parmGoodId.ParameterName = "@good_id";
                parmGoodId.DbType = DbType.String;
                parmGoodId.Value = purchase.Good_Id;
                parameters.Add(parmGoodId);
            }

            if (purchase.Staffinfo_Id != 0)
            {
                commandText.Append(" AND staffinfo_id=@staffinfo_id ");

                DataParameter parmStaffinfoId = new DataParameter();
                parmStaffinfoId.ParameterName = "@purchase_phone";
                parmStaffinfoId.DbType = DbType.Int32;
                parmStaffinfoId.Value = purchase.Staffinfo_Id;
                parameters.Add(parmStaffinfoId);
            }

            if (purchase.Supplier_Id != 0)
            {
                commandText.Append(" AND supplier_id=@supplier_id ");

                DataParameter parmSupplierId = new DataParameter();
                parmSupplierId.ParameterName = "@supplier_id";
                parmSupplierId.DbType = DbType.String;
                parmSupplierId.Value = purchase.Supplier_Id;
                parameters.Add(parmSupplierId);
            }

            if (purchase.Year_Month != 0)
            {
                commandText.Append(" AND year_month=@year_month ");

                DataParameter parmYearMonth= new DataParameter();
                parmYearMonth.ParameterName = "@year_month";
                parmYearMonth.DbType = DbType.Int32;
                parmYearMonth.Value = purchase.Year_Month;
                parameters.Add(parmYearMonth);
            }

            commandText.Append("union all select ");
            if ( false == String.IsNullOrEmpty(purchase.Good_Id) && purchase.Year_Month != 0)
            {
                commandText.Append("'���±���źϼ�', ");
            }
            else if ( false == String.IsNullOrEmpty(purchase.Good_Id))
            {
                commandText.Append("'����źϼ�', ");
            }
            else if (purchase.Year_Month != 0)
            {
                commandText.Append("'���ºϼ�', ");
            }
            else
            {
                commandText.Append("'�ϼ�', ");
            }

            if ( false == String.IsNullOrEmpty(purchase.Good_Id))
                commandText.Append("@good_id1, ");
            else
                commandText.Append("'', ");

            commandText.Append("'', '', SUM(convert(int,purchase_price) * convert(int,purchase_num)) purchase_total, ");

            if (purchase.Year_Month != 0)
                commandText.Append("@year_month1, ");
            else
                commandText.Append("'', ");

            commandText.Append("'' FROM t_Purchase purchases WHERE 1 = 1 ");

            if ( false == String.IsNullOrEmpty(purchase.Good_Id))
            {
                commandText.Append(" And good_id=@good_id1 ");

                DataParameter parmGoodId1 = new DataParameter();
                parmGoodId1.ParameterName = "@good_id1";
                parmGoodId1.DbType = DbType.String;
                parmGoodId1.Value = purchase.Good_Id;
                parameters.Add(parmGoodId1);
            }

            if (purchase.Year_Month != 0)
            {
                commandText.Append(" AND year_month=@year_month1 ");

                DataParameter parmYearMonth1 = new DataParameter();
                parmYearMonth1.ParameterName = "@year_month1";
                parmYearMonth1.DbType = DbType.String;
                parmYearMonth1.Value = purchase.Year_Month;
                parameters.Add(parmYearMonth1);
            }

            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        /// <summary>
        /// ����ָ���Ĺ���������ѯ�ɹ�����Ϣ
        /// </summary>
        /// <param name="purchase">��������</param>
        /// <returns></returns>
        public DataTable SelectRec(Purchase purchase)
        {
            return this.SelectRec(purchase, 0, 0);
        }
        /// <summary>
        /// ���÷�ҳ����,����ָ���Ĺ���������ѯԱ���ɹ���¼
        /// </summary>
        /// <param name="product">��������</param>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable SelectRec(Purchase purchase, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
 /*           commandText.Append("select staffs.staffinfo_id, staffs.staffinfo_name, " +
                "staffs.staffinfo_cess, staffs,isnull(purchases.good_id, 0) good_id, " +
                "isnull(purchases.purchase_num, 0) purchase_num, " + 
                " isnull(purchases.purchase_price, 0) purchase_price, " +
                " isnull(purchases.sum, 0) sum, isnull(purchases.purchase_datetime, '0') purchase_datetime" +
                " isnull(purchases.supplier_id, '0') supplier_id from t_staff staffs " +
                "left join (SELECT staffinfo_id,good_id,purchase_num,purchase_price, " +
    "convert(int,purchase_price) * convert(int,purchase_num) sum, purchase_datetime," +
    " supplier_id FROM t_Purchase) purchases  on purchases.staffinfo_id = staffs.staffinfo_id WHERE 1 = 1");

            commandText.Append("select isnull(purchases.purchase_id, 0) purchase_id, staffs.staffinfo_id staffinfo_id, staffs.staffinfo_name staffinfo_name, " +
    "staffs.staffinfo_cell staffinfo_cell, isnull(purchases.good_id, 0) good_id, " +
    " isnull(purchases.purchase_num, 0) purchase_num, " +
    " isnull(purchases.purchase_price, 0) purchase_price, " +
    " isnull(convert(int,purchases.purchase_price) * convert(int,purchases.purchase_num), 0) sum, isnull(purchases.purchase_datetime, '0') purchase_datetime," +
    " isnull(purchases.supplier_id, '0') supplier_id from t_staff staffs, t_Purchase purchases " +
    " where purchases.staffinfo_id = staffs.staffinfo_id ");
  */
            commandText.Append("select convert(char,purchase_id) purchase_id, good_id, good_name, purchase_price, purchase_num," +
                " staffinfo_id, supplier_id, purchase_datetime , convert(int,purchase_price) * convert(int,purchase_num) sum" +
                " from t_purchase where 1 = 1 ");
            IList parameters = new ArrayList();

            if (purchase.Staffinfo_Id != 0)
            {
                commandText.Append(" AND staffinfo_id=@staffinfo_id ");

                DataParameter parmStaffinfoId = new DataParameter();
                parmStaffinfoId.ParameterName = "@staffinfo_id";
                parmStaffinfoId.DbType = DbType.Int32;
                parmStaffinfoId.Value = purchase.Staffinfo_Id;
                parameters.Add(parmStaffinfoId);
            }

            if (purchase.Purchase_Id != 0)
            {
                commandText.Append(" AND purchase_id=@purchase_id ");

                DataParameter parmPurchaseId = new DataParameter();
                parmPurchaseId.ParameterName = "@purchase_id";
                parmPurchaseId.DbType = DbType.Int32;
                parmPurchaseId.Value = purchase.Purchase_Id;
                parameters.Add(parmPurchaseId);
            }

            if (purchase.Year_Month != 0)
            {
                commandText.Append(" AND year_month=@year_month ");
                DataParameter parmYearMonth = new DataParameter();
                parmYearMonth.ParameterName = "@year_month";
                parmYearMonth.DbType = DbType.String;
                parmYearMonth.Value = purchase.Year_Month;
                parameters.Add(parmYearMonth);
            }
            commandText.Append(" union all select ");

            if (purchase.Purchase_Id != 0 && purchase.Year_Month != 0)
            {
                commandText.Append("'���±����ϼ�', ");
            }
            else if (purchase.Purchase_Id != 0)
            {
                commandText.Append("'�����ϼ�', ");
            }
            else if (purchase.Year_Month != 0)
            {
                commandText.Append("'���ºϼ�', ");
            }
            else
            {
                commandText.Append("'�ϼ�', ");
            }

            commandText.Append(" NULL, NULL, NULL, NULL, NULL, NULL, ");

            if (purchase.Year_Month != 0)
            {
                commandText.Append("convert(char, @year_month1) purchase_datetime, ");
            }
            else
            {
                commandText.Append("convert(char, year_month) purchase_datetime, ");
            }

            commandText.Append(" SUM(convert(int,purchases.purchase_price) * convert(int,purchases.purchase_num)) sum ");
            commandText.Append("  from t_purchase purchases where 1 = 1 ");

            if (purchase.Staffinfo_Id != 0)
            {
                commandText.Append(" AND purchases.staffinfo_id=@staffinfo_id1 ");

                DataParameter parmStaffinfoId1 = new DataParameter();
                parmStaffinfoId1.ParameterName = "@staffinfo_id1";
                parmStaffinfoId1.DbType = DbType.Int32;
                parmStaffinfoId1.Value = purchase.Staffinfo_Id;
                parameters.Add(parmStaffinfoId1);
            }

            if (purchase.Purchase_Id != 0)
            {
                commandText.Append(" AND purchases.purchase_id=@purchase_id1 ");

                DataParameter parmPurchaseId1 = new DataParameter();
                parmPurchaseId1.ParameterName = "@purchase_id1";
                parmPurchaseId1.DbType = DbType.Int32;
                parmPurchaseId1.Value = purchase.Purchase_Id;
                parameters.Add(parmPurchaseId1);
            }

            if (purchase.Year_Month != 0)
            {
                commandText.Append(" AND purchases.year_month=@year_month1 ");
                DataParameter parmYearMonth1 = new DataParameter();
                parmYearMonth1.ParameterName = "@year_month1";
                parmYearMonth1.DbType = DbType.Int32;
                parmYearMonth1.Value = purchase.Year_Month;
                parameters.Add(parmYearMonth1);
            }

            commandText.Append(" group by year_month order by purchase_datetime DESC");
            //commandText.Append(" group by staffs.staffinfo_id,purchases.year_month,staffinfo_name,staffinfo_cell order by staffinfo_id,purchase_datetime");
            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        /// <summary>
        /// ��ȡ�ɹ���ϸ��Ϣ
        /// </summary>
        /// <param name="staffinfo_id">ְ��ID</param>
        /// <param name="supplier_id">��Ӧ��ID</param>
        /// <returns></returns>
        public DataTable GetDetails(int staffinfo_id, int supplier_id)
        {
            StringBuilder commandText = new StringBuilder();
        
            commandText.Append("select staff.staffinfo_id staffinfo_id, staff.staffinfo_name staffinfo_name," + 
                "staff.staffinfo_cell, supplier.supplier_id supplier_id , " +
                "('S' + right('000000' + convert(varchar(8), supplier.supplier_id), 7)) supplier_bh, " + 
                "supplier.supplier_name supplier_name from t_staff staff, t_supplier supplier " +
                "where staff.staffinfo_id=@staffinfo_id and supplier.supplier_id=@supplier_id ");
            IList parameters = new ArrayList();

            DataParameter parmStaffinfoId = new DataParameter();
            parmStaffinfoId.ParameterName = "@staffinfo_id";
            parmStaffinfoId.DbType = DbType.Int32;
            parmStaffinfoId.Value = staffinfo_id;
            parameters.Add(parmStaffinfoId);

            DataParameter parmSupplierId = new DataParameter();
            parmSupplierId.ParameterName = "@supplier_id";
            parmSupplierId.DbType = DbType.Int32;
            parmSupplierId.Value = supplier_id;
            parameters.Add(parmSupplierId);

            return this.handler.Query(commandText.ToString(), parameters);
        }
        #endregion

        #region --- GetAll���� ---

        /// <summary>
        /// ��ȡ���е��û���Ϣ��¼
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT purchase_id,good_id,purchase_price,purchase_num, " +
                "convert(int,purchase_price) * convert(int,purchase_num) purchase_total, purchase_datetime," +
                " supplier_id FROM t_purchase ";
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
            string commandText = "SELECT purchase_id,good_id,purchase_price,purchase_num, " +
                "convert(int,purchase_price) * convert(int,purchase_num) purchase_total, convert(int,substring(purchase_datetime,0,7)) purchase_datetime," +
                " supplier_id FROM t_purchase union all select '0',good_id,'0','0'," +
                " SUM(convert(int,purchase_num) * convert(int,purchase_price)) sum, year_month,'0' from t_purchase " +
                " group by good_id,year_month order by purchase_datetime,good_id,purchase_id";
            return this.handler.Query(commandText, start, max);
        }
        /// <summary>
        /// ���÷�ҳ���ƻ�ȡ���е��û���Ϣ��¼
        /// </summary>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable GetRecAll(int start, int max)
        {
            string commandText = "";
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
            string commandText = "SELECT Count(purchase_id) FROM t_purchase";
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
        /// <param name="purchase">�û���Ϣ</param>
        /// <returns></returns>
        public int GetSize(Purchase purchase)
        {
            string commandText = "SELECT Count(purchase_id) FROM t_purchase WHERE good_id=@good_id";

            DataParameter parmGoodId = new DataParameter();
            parmGoodId.ParameterName = "@good_id";
            parmGoodId.DbType = DbType.String;
            parmGoodId.Value = purchase.Good_Id;

            IList parameters = new ArrayList();
            parameters.Add(parmGoodId);

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
        public bool Delete(Purchase purchase)
        {
            if (purchase.Purchase_Id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_purchase WHERE purchase_id=@purchase_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@purchase_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = purchase.Purchase_Id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 

    }
}
