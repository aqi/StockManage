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
    /// SaleProvider��ʾ���۱�
    /// </summary>
    public class SaleProvider : ActionBase
    {
        #region --- Insert���� ---

        /// <summary>
        /// ���һ���µ����۱���Ϣ
        /// </summary>
        /// <param unit="sale">�µ����۱�</param>
        /// <returns>��ӳɹ�����true,���򷵻�false</returns>
        public bool Insert(Sale sale)
        {
            if (sale.Good_Id == 0)
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_sale VALUES(@good_id,@good_name,"+
                                    "@sale_price,@purchase_price,@sale_num,@sale_datetime,@staffinfo_id,@buyer_id,@year_month)";
                DataParameter parmGoodId = new DataParameter();
                parmGoodId.ParameterName = "@good_id";
                parmGoodId.DbType = DbType.Int32;
                parmGoodId.Value = sale.Good_Id;

                DataParameter parmGoodName = new DataParameter();
                parmGoodName.ParameterName = "@good_name";
                parmGoodName.DbType = DbType.String;
                parmGoodName.Value = sale.Good_Name;

                DataParameter parmSalePrice = new DataParameter();
                parmSalePrice.ParameterName = "@sale_price";
                parmSalePrice.DbType = DbType.String;
                parmSalePrice.Value = sale.Sale_Price;

                DataParameter parmPurchasePrice = new DataParameter();
                parmPurchasePrice.ParameterName = "@purchase_price";
                parmPurchasePrice.DbType = DbType.String;
                parmPurchasePrice.Value = sale.Purchase_Price;

                DataParameter parmSaleNum = new DataParameter();
                parmSaleNum.ParameterName = "@sale_num";
                parmSaleNum.DbType = DbType.String;
                parmSaleNum.Value = sale.Sale_Num;

                DataParameter parmSaleDatetime = new DataParameter();
                parmSaleDatetime.ParameterName = "@sale_datetime";
                parmSaleDatetime.DbType = DbType.String;
                parmSaleDatetime.Value = sale.Sale_Datetime;

                DataParameter parmStaffinfoId = new DataParameter();
                parmStaffinfoId.ParameterName = "@staffinfo_id";
                parmStaffinfoId.DbType = DbType.Int32;
                parmStaffinfoId.Value = sale.Staffinfo_Id;

                DataParameter parmBuyerId = new DataParameter();
                parmBuyerId.ParameterName = "@buyer_id";
                parmBuyerId.DbType = DbType.Int32;
                parmBuyerId.Value = sale.Buyer_Id;

                DataParameter parmYearMonth = new DataParameter();
                parmYearMonth.ParameterName = "@year_month";
                parmYearMonth.DbType = DbType.Int32;
                parmYearMonth.Value = sale.Year_Month;

                parmBuyerId.Value = sale.Buyer_Id;
                IList parameters = new ArrayList();
                parameters.Add(parmGoodId);
                parameters.Add(parmGoodName);
                parameters.Add(parmSalePrice);
                parameters.Add(parmPurchasePrice);
                parameters.Add(parmSaleNum);
                parameters.Add(parmSaleDatetime);
                parameters.Add(parmStaffinfoId);
                parameters.Add(parmBuyerId);
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
        /// �޸����۱�������
        /// </summary>
        /// <param name="sale">�µı���Ϣ</param>
        /// <returns>�޸ĳɹ�����true,���򷵻�false</returns>
        public bool Update(Sale sale)
        {
            if (sale.Sale_Id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_sale " +
                                  " SET good_id=@good_id," +
                                    " sale_price=@sale_price," +
                                    " purchase_price=@purchase_price," +
                                    " sale_num=@sale_num, sale_datetime=@sale_datetime," +
                                    " buyer_id=@buyer_id, " + 
                                     " year_month=@year_month WHERE sale_id=@sale_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@sale_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = sale.Sale_Id;

            DataParameter parmGoodId = new DataParameter();
            parmGoodId.ParameterName = "@good_id";
            parmGoodId.DbType = DbType.Int32;
            parmGoodId.Value = sale.Good_Id;

            DataParameter parmSalePrice = new DataParameter();
            parmSalePrice.ParameterName = "@sale_price";
            parmSalePrice.DbType = DbType.String;
            parmSalePrice.Value = sale.Sale_Price;

            DataParameter parmPurchasePrice = new DataParameter();
            parmPurchasePrice.ParameterName = "@purchase_price";
            parmPurchasePrice.DbType = DbType.String;
            parmPurchasePrice.Value = sale.Purchase_Price;

            DataParameter parmSaleNum = new DataParameter();
            parmSaleNum.ParameterName = "@sale_num";
            parmSaleNum.DbType = DbType.String;
            parmSaleNum.Value = sale.Sale_Num;

            DataParameter parmSaleDatetime = new DataParameter();
            parmSaleDatetime.ParameterName = "@sale_datetime";
            parmSaleDatetime.DbType = DbType.String;
            parmSaleDatetime.Value = sale.Sale_Datetime;

            DataParameter parmBuyerId = new DataParameter();
            parmBuyerId.ParameterName = "@buyer_id";
            parmBuyerId.DbType = DbType.String;
            parmBuyerId.Value = sale.Buyer_Id;

            DataParameter parmYearMonth = new DataParameter();
            parmYearMonth.ParameterName = "@year_month";
            parmYearMonth.DbType = DbType.Int32;
            parmYearMonth.Value = sale.Year_Month;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmGoodId);
            parameters.Add(parmSalePrice);
            parameters.Add(parmPurchasePrice);
            parameters.Add(parmSaleNum);
            parameters.Add(parmSaleDatetime);
            parameters.Add(parmBuyerId);
            parameters.Add(parmYearMonth);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion

        #region --- Select���� ---

        /// <summary>
        /// ����ָ���Ĺ���������ѯ���۱����Ϣ
        /// </summary>
        /// <param name="sale">��������</param>
        /// <returns></returns>
        public DataTable Select(Sale sale)
        {
            return this.Select(sale, 0, 0);
        }

        /// <summary>
        /// ���÷�ҳ����,����ָ���Ĺ���������ѯ�û���Ϣ
        /// </summary>
        /// <param name="product">��������</param>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable Select(Sale sale, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT sale_id,good_id,sale_price,purchase_price,sale_num, " +
    "convert(int,sale_price) * convert(int,sale_num) sale_total, sale_datetime," +
    " buyer_id FROM t_Sale sales WHERE 1 = 1");
            IList parameters = new ArrayList();

            if (sale.Good_Id != 0)
            {
                commandText.Append(" And good_id=@good_id");

                DataParameter parmGoodId = new DataParameter();
                parmGoodId.ParameterName = "@good_id";
                parmGoodId.DbType = DbType.Int32;
                parmGoodId.Value = sale.Good_Id;
                parameters.Add(parmGoodId);
            }

            if (sale.Staffinfo_Id != 0)
            {
                commandText.Append(" AND staffinfo_id=@staffinfo_id ");

                DataParameter parmStaffinfoId = new DataParameter();
                parmStaffinfoId.ParameterName = "@sale_phone";
                parmStaffinfoId.DbType = DbType.Int32;
                parmStaffinfoId.Value = sale.Staffinfo_Id;
                parameters.Add(parmStaffinfoId);
            }


            if (sale.Buyer_Id != 0)
            {
                commandText.Append(" AND buyer_id=@buyer_id ");

                DataParameter parmBuyerId = new DataParameter();
                parmBuyerId.ParameterName = "@buyer_id";
                parmBuyerId.DbType = DbType.String;
                parmBuyerId.Value = sale.Buyer_Id;
                parameters.Add(parmBuyerId);
            }

            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        /// <summary>
        /// ���÷�ҳ����,����ָ���Ĺ���������ѯԱ�����ۼ�¼
        /// </summary>
        /// <param name="product">��������</param>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable SelectRec(Staff staff, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("select isnull(sales.sale_id, 0) sale_id, staffs.staffinfo_id staffinfo_id, staffs.staffinfo_name staffinfo_name, " +
    "staffs.staffinfo_cell staffinfo_cell, isnull(sales.good_id, 0) good_id, " +
    " isnull(sales.sale_num, 0) sale_num, " +
    " isnull(sales.sale_price, 0) sale_price, " +
    " isnull(sales.purchase_price, 0) purchase_price," +
    " isnull(convert(int,sales.sale_price) * convert(int,sales.sale_num), 0) sum, isnull(sales.sale_datetime, '0') sale_datetime," +
    " isnull(sales.buyer_id, '0') buyer_id from t_staff staffs, t_Sale sales " +
    " where sales.staffinfo_id = staffs.staffinfo_id ");
            IList parameters = new ArrayList();

            if (0 == staff.Role_Manage)
            {
                commandText.Append(" AND staffs.user_id=@user_id ");

                DataParameter parmStaffinfoId = new DataParameter();
                parmStaffinfoId.ParameterName = "@user_id";
                parmStaffinfoId.DbType = DbType.Int32;
                parmStaffinfoId.Value = staff.User_id;
                parameters.Add(parmStaffinfoId);
            }

            if (!String.IsNullOrEmpty(staff.Staffinfo_Name))
            {
                commandText.Append(" AND staffs.staffinfo_name like @staffinfo_name ");
                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@staffinfo_name";
                parmName.DbType = DbType.String;
                parmName.Value = staff.Staffinfo_Name;
                parameters.Add(parmName);
            }

            commandText.Append(" union all select '0',staffs.staffinfo_id staffinfo_id, " +
                " staffs.staffinfo_name staffinfo_name,staffs.staffinfo_cell staffinfo_cell,'0','0','0','0'," +
                " SUM(convert(int,sales.sale_num) * convert(int,sales.sale_price)) sum," +
                " sales.year_month,'0' from t_staff staffs, t_sale sales where sales.staffinfo_id = staffs.staffinfo_id ");

            if (0 == staff.Role_Manage)
            {
                commandText.Append(" AND staffs.user_id=@user_id1 ");

                DataParameter parmStaffinfoId1 = new DataParameter();
                parmStaffinfoId1.ParameterName = "@user_id1";
                parmStaffinfoId1.DbType = DbType.Int32;
                parmStaffinfoId1.Value = staff.User_id;
                parameters.Add(parmStaffinfoId1);
            }

            if (!String.IsNullOrEmpty(staff.Staffinfo_Name))
            {
                commandText.Append(" AND staffs.staffinfo_name like @staffinfo_name1 ");
                DataParameter parmName1 = new DataParameter();
                parmName1.ParameterName = "@staffinfo_name1";
                parmName1.DbType = DbType.String;
                parmName1.Value = staff.Staffinfo_Name;
                parameters.Add(parmName1);
            }

            commandText.Append(" group by staffs.staffinfo_id,sales.year_month,staffinfo_name,staffinfo_cell order by staffinfo_id,sale_datetime");

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
            string commandText = "SELECT sale_id,good_id,sale_price,sale_num, " +
                "convert(int,sale_price) * convert(int,sale_num) sale_total, sale_datetime," +
                " buyer_id FROM t_sale ";
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
            string commandText = "SELECT sale_id,good_id,sale_price,purchase_price,sale_num, " +
                "convert(int,sale_price) * convert(int,sale_num) sale_total, convert(int,substring(sale_datetime,0,7)) sale_datetime," +
                " buyer_id FROM t_sale union all select '0',good_id,'0','0', '0'," +
                " SUM(convert(int,sale_num) * convert(int,sale_price)) sum, year_month,'0' from t_sale " +
                " group by good_id,year_month order by sale_datetime,good_id,sale_id";
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
            string commandText = "SELECT Count(sale_id) FROM t_sale";
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
        /// <param name="sale">�û���Ϣ</param>
        /// <returns></returns>
        public int GetSize(Sale sale)
        {
            string commandText = "SELECT Count(sale_id) FROM t_sale WHERE good_id=@good_id";

            DataParameter parmGoodId = new DataParameter();
            parmGoodId.ParameterName = "@good_id";
            parmGoodId.DbType = DbType.Int32;
            parmGoodId.Value = sale.Good_Id;

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
        public bool Delete(Sale sale)
        {
            if (sale.Sale_Id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_sale WHERE sale_id=@sale_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@sale_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = sale.Sale_Id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 
    }
}
