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
                parmStaffinfoId.ParameterName = "@staffinfo_id";
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
        /// ���÷�ҳ����,����ָ���Ĺ���������ѯ�û���Ϣ
        /// </summary>
        /// <param name="product">��������</param>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable Select1(Sale sale, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT convert(char,sale_id) sale_id,good_id,sale_price, " +
                " purchase_price, convert(int,purchase_price) * convert(int,sale_num) purchase_total, sale_num, " +
                "convert(int,sale_price) * convert(int,sale_num) sale_total, sale_datetime, " +
                "((convert(int,sale_price) - convert(int,purchase_price)) * convert(int,sale_num)) sale_profit, buyer_id FROM t_Sale sales WHERE 1 = 1");
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
                parmStaffinfoId.ParameterName = "@staffinfo_id";
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

            if (sale.Year_Month != 0)
            {
                commandText.Append(" AND year_month=@year_month ");

                DataParameter parmYearMonth = new DataParameter();
                parmYearMonth.ParameterName = "@year_month";
                parmYearMonth.DbType = DbType.String;
                parmYearMonth.Value = sale.Year_Month;
                parameters.Add(parmYearMonth);
            }

            commandText.Append(" union all select ");
            if (sale.Good_Id != 0 && sale.Year_Month != 0)
            {
                commandText.Append("'���±���źϼ�', ");
            }
            else if (sale.Good_Id != 0)
            {
                commandText.Append("'����źϼ�', ");
            }
            else if (sale.Year_Month != 0)
            {
                commandText.Append("'���ºϼ�', ");
            }
            else
            {
                commandText.Append("'�ϼ�', ");
            }

            if (sale.Good_Id != 0)
                commandText.Append("@good_id1, ");
            else
                commandText.Append("'', ");

            commandText.Append("'', '', SUM(convert(int,purchase_price) * convert(int,sale_num)) purchase_total, '', SUM(convert(int,sale_price) * convert(int,sale_num)) sale_total, ");

            if (sale.Year_Month != 0)
                commandText.Append("@year_month1, ");
            else
                commandText.Append("'', ");

            commandText.Append("SUM((convert(int,sale_price) - convert(int,purchase_price)) * convert(int,sale_num)) sale_profit, '' FROM t_sale sales WHERE 1 = 1 ");

            if (sale.Good_Id != 0)
            {
                commandText.Append(" And good_id=@good_id1 ");

                DataParameter parmGoodId1 = new DataParameter();
                parmGoodId1.ParameterName = "@good_id1";
                parmGoodId1.DbType = DbType.Int32;
                parmGoodId1.Value = sale.Good_Id;
                parameters.Add(parmGoodId1);
            }

            if (sale.Year_Month != 0)
            {
                commandText.Append(" AND year_month=@year_month1 ");

                DataParameter parmYearMonth1 = new DataParameter();
                parmYearMonth1.ParameterName = "@year_month1";
                parmYearMonth1.DbType = DbType.String;
                parmYearMonth1.Value = sale.Year_Month;
                parameters.Add(parmYearMonth1);
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
        public DataTable SelectRec(Sale sale, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
/*           commandText.Append("select isnull(sales.sale_id, 0) sale_id, staffs.staffinfo_id staffinfo_id, staffs.staffinfo_name staffinfo_name, " +
    "staffs.staffinfo_cell staffinfo_cell, isnull(sales.good_id, 0) good_id, " +
    " isnull(sales.sale_num, 0) sale_num, " +
    " isnull(sales.sale_price, 0) sale_price, " +
    " isnull(sales.purchase_price, 0) purchase_price," +
    " isnull(convert(int,sales.sale_price) * convert(int,sales.sale_num), 0) sum, isnull(sales.sale_datetime, '0') sale_datetime," +
    " isnull(sales.buyer_id, '0') buyer_id from t_staff staffs, t_Sale sales " +
    " where sales.staffinfo_id = staffs.staffinfo_id ");
 */

            commandText.Append("select convert(char,sale_id) sale_id, good_id, good_name, purchase_price, sale_price, " + 
                "sale_num," +
    " staffinfo_id, buyer_id, sale_datetime , convert(int,sale_price) * convert(int,sale_num) sum" +
    " from t_sale where 1 = 1 ");

            IList parameters = new ArrayList();

            if (sale.Staffinfo_Id != 0)
            {
                commandText.Append(" AND staffinfo_id=@staffinfo_id ");

                DataParameter parmStaffinfoId = new DataParameter();
                parmStaffinfoId.ParameterName = "@staffinfo_id";
                parmStaffinfoId.DbType = DbType.Int32;
                parmStaffinfoId.Value = sale.Staffinfo_Id;
                parameters.Add(parmStaffinfoId);
            }

            if (sale.Sale_Id != 0)
            {
                commandText.Append(" AND sale_id=@sale_id ");

                DataParameter parmPurchaseId = new DataParameter();
                parmPurchaseId.ParameterName = "@sale_id";
                parmPurchaseId.DbType = DbType.Int32;
                parmPurchaseId.Value = sale.Sale_Id;
                parameters.Add(parmPurchaseId);
            }

            if (sale.Year_Month != 0)
            {
                commandText.Append(" AND year_month=@year_month ");
                DataParameter parmYearMonth = new DataParameter();
                parmYearMonth.ParameterName = "@year_month";
                parmYearMonth.DbType = DbType.String;
                parmYearMonth.Value = sale.Year_Month;
                parameters.Add(parmYearMonth);
            }
            commandText.Append(" union all select ");

            if (sale.Sale_Id != 0 && sale.Year_Month != 0)
            {
                commandText.Append("'���±����ϼ�', ");
            }
            else if (sale.Sale_Id != 0)
            {
                commandText.Append("'�����ϼ�', ");
            }
            else if (sale.Year_Month != 0)
            {
                commandText.Append("'���ºϼ�', ");
            }
            else
            {
                commandText.Append("'�ϼ�', ");
            }

            commandText.Append(" NULL, NULL, NULL, NULL, NULL, NULL,NULL, ");

            if (sale.Year_Month != 0)
            {
                commandText.Append("convert(char, @year_month1) sale_datetime, ");
            }
            else
            {
                commandText.Append("convert(char, year_month) sale_datetime, ");
            }

            commandText.Append(" SUM(convert(int,sales.sale_price) * convert(int,sales.sale_num)) sum ");
            commandText.Append("  from t_sale sales where 1 = 1 ");

            if (sale.Staffinfo_Id != 0)
            {
                commandText.Append(" AND sales.staffinfo_id=@staffinfo_id1 ");

                DataParameter parmStaffinfoId1 = new DataParameter();
                parmStaffinfoId1.ParameterName = "@staffinfo_id1";
                parmStaffinfoId1.DbType = DbType.Int32;
                parmStaffinfoId1.Value = sale.Staffinfo_Id;
                parameters.Add(parmStaffinfoId1);
            }

            if (sale.Sale_Id != 0)
            {
                commandText.Append(" AND sales.sale_id=@sale_id1 ");

                DataParameter parmSaleId1 = new DataParameter();
                parmSaleId1.ParameterName = "@sale_id1";
                parmSaleId1.DbType = DbType.Int32;
                parmSaleId1.Value = sale.Sale_Id;
                parameters.Add(parmSaleId1);
            }

            if (sale.Year_Month != 0)
            {
                commandText.Append(" AND sales.year_month=@year_month1 ");
                DataParameter parmYearMonth1 = new DataParameter();
                parmYearMonth1.ParameterName = "@year_month1";
                parmYearMonth1.DbType = DbType.Int32;
                parmYearMonth1.Value = sale.Year_Month;
                parameters.Add(parmYearMonth1);
            }

            commandText.Append(" group by year_month order by sale_datetime DESC"); 
            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }
        /// <summary>
        /// ��ȡ������ϸ��Ϣ
        /// </summary>
        /// <param name="staffinfo_id">ְ��ID</param>
        /// <param name="supplier_id">��Ӧ��ID</param>
        /// <returns></returns>
        public DataTable GetDetails(int sale_id)
        {
            StringBuilder commandText = new StringBuilder();

            commandText.Append("select sales.sale_id sale_id,staff.staffinfo_id staffinfo_id, staff.staffinfo_name staffinfo_name," +
                "staff.staffinfo_cell, buyer.buyer_id buyer_id , " +
                "buyer.buyer_name buyer_name from t_staff staff, t_buyer buyer, t_sale sales " +
                "where sales.sale_id=@sale_id and staff.staffinfo_id=sales.staffinfo_id and buyer.buyer_id=sales.buyer_id ");
            IList parameters = new ArrayList();

            DataParameter parmSaleId = new DataParameter();
            parmSaleId.ParameterName = "@sale_id";
            parmSaleId.DbType = DbType.Int32;
            parmSaleId.Value = sale_id;
            parameters.Add(parmSaleId);


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
