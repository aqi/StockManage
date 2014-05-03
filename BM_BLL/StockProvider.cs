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
    public class StockProvider : ActionBase
    {
        #region --- Insert���� ---

        /// <summary>
        /// ���һ���µ����۱���Ϣ
        /// </summary>
        /// <param unit="stock">�µ����۱�</param>
        /// <returns>��ӳɹ�����true,���򷵻�false</returns>
        public bool Insert(Stock stock)
        {
            if (String.IsNullOrEmpty(stock.Good_Id) == true)
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_stock (good_id,stock_num,stock_oper," + 
                    "staffinfo_id,purchase_price, purchase_datetime) VALUES (@good_id,@stock_num,"+
                    "@stock_oper,@staffinfo_id,@purchase_price,@purchase_datetime)";

                DataParameter parmGoodId = new DataParameter();
                parmGoodId.ParameterName = "@good_id";
                parmGoodId.DbType = DbType.String;
                parmGoodId.Value = stock.Good_Id;

                DataParameter parmStockNum = new DataParameter();
                parmStockNum.ParameterName = "@stock_num";
                parmStockNum.DbType = DbType.String;
                parmStockNum.Value = stock.Stock_Num;

                DataParameter parmStockOper = new DataParameter();
                parmStockOper.ParameterName = "@stock_oper";
                parmStockOper.DbType = DbType.Int32;
                parmStockOper.Value = stock.Stock_Oper;

                DataParameter parmStaffinfoId = new DataParameter();
                parmStaffinfoId.ParameterName = "@staffinfo_id";
                parmStaffinfoId.DbType = DbType.Int32;
                parmStaffinfoId.Value = stock.Staffinfo_Id;

                DataParameter parmPurchasePrice = new DataParameter();
                parmPurchasePrice.ParameterName = "@purchase_price";
                parmPurchasePrice.DbType = DbType.String;
                parmPurchasePrice.Value = stock.Purchase_Price;

                DataParameter parmPurchaseDatetime = new DataParameter();
                parmPurchaseDatetime.ParameterName = "@purchase_datetime";
                parmPurchaseDatetime.DbType = DbType.String;
                parmPurchaseDatetime.Value = stock.Purchase_Datetime;

                IList parameters = new ArrayList();
                parameters.Add(parmGoodId);
                parameters.Add(parmStockNum);
                parameters.Add(parmStockOper);
                parameters.Add(parmStaffinfoId);
                parameters.Add(parmPurchasePrice);
                parameters.Add(parmPurchaseDatetime);

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
        /// �޸Ŀ���������
        /// </summary>
        /// <param name="stock">�µı���Ϣ</param>
        /// <returns>�޸ĳɹ�����true,���򷵻�false</returns>
        public bool Update(Stock stock)
        {
            if (stock.Stock_Id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_stock " +
                                  " SET good_id=@good_id," +
                                    " stock_num=@stock_num,purchase_price=@purchase_price," +
                                    " purchase_datetime=@purchase_datetime" +
                                     " WHERE stock_id=@stock_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@stock_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = stock.Stock_Id;

            DataParameter parmGoodId = new DataParameter();
            parmGoodId.ParameterName = "@good_id";
            parmGoodId.DbType = DbType.String;
            parmGoodId.Value = stock.Good_Id;

            DataParameter parmStockNum = new DataParameter();
            parmStockNum.ParameterName = "@stock_num";
            parmStockNum.DbType = DbType.String;
            parmStockNum.Value = stock.Stock_Num;

            DataParameter parmPurchasePrice = new DataParameter();
            parmPurchasePrice.ParameterName = "@purchase_price";
            parmPurchasePrice.DbType = DbType.String;
            parmPurchasePrice.Value = stock.Purchase_Price;


            DataParameter parmPurchaseDatetime = new DataParameter();
            parmPurchaseDatetime.ParameterName = "@purchase_datetime";
            parmPurchaseDatetime.DbType = DbType.String;
            parmPurchaseDatetime.Value = stock.Purchase_Datetime;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmGoodId);
            parameters.Add(parmStockNum);
            parameters.Add(parmPurchasePrice);
            parameters.Add(parmPurchaseDatetime);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        /// <summary>
        /// �޸Ŀ���������
        /// </summary>
        /// <param name="stock">�µı���Ϣ</param>
        /// <returns>�޸ĳɹ�����true,���򷵻�false</returns>
        public bool UpdateNum(Stock stock)
        {
            string commandText = " UPDATE  t_stock " +
                                  " SET " +
                                    " stock_num=convert(char,convert(int,stock_num) - convert(int,@stock_num)), purchase_datetime=@purchase_datetime" +
                                    " where purchase_price=@purchase_price and good_id=@good_id";

            DataParameter parmGoodId = new DataParameter();
            parmGoodId.ParameterName = "@good_id";
            parmGoodId.DbType = DbType.Int32;
            parmGoodId.Value = stock.Good_Id;

            DataParameter parmStockNum = new DataParameter();
            parmStockNum.ParameterName = "@stock_num";
            parmStockNum.DbType = DbType.String;
            parmStockNum.Value = stock.Stock_Num;

            DataParameter parmPurchasePrice = new DataParameter();
            parmPurchasePrice.ParameterName = "@purchase_price";
            parmPurchasePrice.DbType = DbType.String;
            parmPurchasePrice.Value = stock.Purchase_Price;


            DataParameter parmPurchaseDatetime = new DataParameter();
            parmPurchaseDatetime.ParameterName = "@purchase_datetime";
            parmPurchaseDatetime.DbType = DbType.String;
            parmPurchaseDatetime.Value = stock.Purchase_Datetime;

            IList parameters = new ArrayList();
            parameters.Add(parmGoodId);
            parameters.Add(parmStockNum);
            parameters.Add(parmPurchasePrice);
            parameters.Add(parmPurchaseDatetime);

            return this.handler.ExecuteCommand(commandText, parameters);
        }


        #endregion

        #region --- Select���� ---

        /// <summary>
        /// ����ָ���Ĺ���������ѯ������Ϣ
        /// </summary>
        /// <param name="stock">��������</param>
        /// <returns></returns>
        public DataTable Select(Stock stock)
        {
            return this.Select(stock, 0, 0);
        }

        /// <summary>
        /// ���÷�ҳ����,����ָ���Ĺ���������ѯ������Ϣ
        /// </summary>
        /// <param name="product">��������</param>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable Select(Stock stock, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT good_id,purchase_price,stock_num, " +
    "convert(int,purchase_price) * convert(int,stock_num) stock_total, purchase_datetime" +
    " FROM t_Stock stocks WHERE 1 = 1");
            IList parameters = new ArrayList();

            if ( false == String.IsNullOrEmpty(stock.Good_Id))
            {
                commandText.Append(" And good_id=@good_id");

                DataParameter parmGoodId = new DataParameter();
                parmGoodId.ParameterName = "@good_id";
                parmGoodId.DbType = DbType.String;
                parmGoodId.Value = stock.Good_Id;
                parameters.Add(parmGoodId);
            }

            if (stock.Stock_Id != 0)
            {
                commandText.Append(" And stock_id=@stock_id");

                DataParameter parmId = new DataParameter();
                parmId.ParameterName = "@stock_id";
                parmId.DbType = DbType.Int32;
                parmId.Value = stock.Stock_Id;
                parameters.Add(parmId);
            }
            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        /// <summary>
        /// ���÷�ҳ����,����ָ���Ĺ���������ѯ����¼
        /// </summary>
        /// <param name="product">��������</param>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable SelectRec(Stock stock, int start, int max)
        {

            StringBuilder commandText = new StringBuilder();

            commandText.Append("select 0 purchase_staff, 0 sale_staff, stocks.good_id good_id, stocks.purchase_price purchase_price, " +
                "SUM(CONVERT(int, stocks.stock_num) * stocks.stock_oper) stock_num, " +
                "SUM(CONVERT(int, stocks.stock_num) * stocks.stock_oper) * CONVERT(int,stocks.purchase_price) sum, " +
                "convert(int,a.date) date,a.good_name good_name from t_stock stocks " +
                "left join (select t_good.good_name,t_stock.good_id, purchase_price, max(purchase_datetime) date " +
                "from t_stock,t_good where t_good.good_num=t_stock.good_id " +
                "group by t_stock.good_id, t_stock.purchase_price, t_good.good_name) a " +
                "on (a.good_id = stocks.good_id and a.purchase_price = stocks.purchase_price) " +
                "where 1=1 ");
/*
            "select isnull(stocks.stock_id, 0) stock_id, " +
    " isnull(stocks.good_id, 0) good_id, " +
    " isnull(stocks.stock_num, 0) stock_num, " +
    " isnull(stocks.purchase_price, 0) purchase_price, " +
    "  convert(int,stocks.purchase_price) * convert(int,stocks.stock_num) sum, " + 
    //" isnull(stocks1.sum, 0) sum," +
    " isnull(stocks.purchase_datetime, '0') purchase_datetime " +
    " from t_stock stocks " +
    //" from t_stock stocks left join (select SUM(convert(int,t_stock.purchase_price) * convert(int,t_stock.stock_num)) sum from t_stock) stocks1 on 1=1 " +
    " where 1=1 ");
 */
            IList parameters = new ArrayList();

            if ( false == String.IsNullOrEmpty(stock.Good_Id))
            {
                commandText.Append(" And stocks.good_id=@good_id ");

                DataParameter parmGoodId = new DataParameter();
                parmGoodId.ParameterName = "@good_id";
                parmGoodId.DbType = DbType.String;
                parmGoodId.Value = stock.Good_Id;
                parameters.Add(parmGoodId);
            }
            commandText.Append("group by stocks.good_id, stocks.purchase_price,good_name, date " + 
                "having SUM(CONVERT(int, stock_num) * stock_oper) > 0");
            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        /// <summary>
        /// ���÷�ҳ����,����ָ���Ĺ���������ѯ����¼
        /// </summary>
        /// <param name="product">��������</param>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable SelectRecPurchase(Stock stock, int start, int max)
        {

            StringBuilder commandText = new StringBuilder();

            commandText.Append("select 0 purchase_price, 0 sum, 0 date, " + 
                "t_stock.good_id, t_stock.stock_num stock_num, t_good.good_name," + 
                "t_staff.staffinfo_name purchase_staff, 0 sale_staff " + 
                "from t_stock,t_good,t_staff where t_stock.stock_oper=1 and " + 
                "t_staff.staffinfo_id=t_stock.staffinfo_id and t_stock.good_id=t_good.good_num ");

            IList parameters = new ArrayList();

            if ( false == String.IsNullOrEmpty(stock.Good_Id))
            {
                commandText.Append(" and t_stock.good_id=@good_id ");

                DataParameter parmGoodId = new DataParameter();
                parmGoodId.ParameterName = "@good_id";
                parmGoodId.DbType = DbType.String;
                parmGoodId.Value = stock.Good_Id;
                parameters.Add(parmGoodId);
            }
            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        /// <summary>
        /// ���÷�ҳ����,����ָ���Ĺ���������ѯ����¼
        /// </summary>
        /// <param name="product">��������</param>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable SelectRecSale(Stock stock, int start, int max)
        {

            StringBuilder commandText = new StringBuilder();

            commandText.Append("select 0 purchase_price, 0 sum, 0 date, " +
              "t_stock.good_id, t_stock.stock_num stock_num, t_good.good_name," +
              "t_staff.staffinfo_name sale_staff, 0 purchase_staff " +
              "from t_stock,t_good,t_staff where t_stock.stock_oper=-1 and " +
              "t_staff.staffinfo_id=t_stock.staffinfo_id and t_stock.good_id=t_good.good_num ");

            IList parameters = new ArrayList();

            if ( false == String.IsNullOrEmpty(stock.Good_Id))
            {
                commandText.Append(" and t_stock.good_id=@good_id ");

                DataParameter parmGoodId = new DataParameter();
                parmGoodId.ParameterName = "@good_id";
                parmGoodId.DbType = DbType.String;
                parmGoodId.Value = stock.Good_Id;
                parameters.Add(parmGoodId);
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
            string commandText = "SELECT stock_id,good_id,stock_num, purchase_price, " +
                "convert(int,purchase_price) * convert(int,stock_num) stock_total, purchase_datetime" +
                " FROM t_stock ";
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
            string commandText = "SELECT stock_id,good_id,stock_num, purchase_price " +
                "convert(int,purchase_price) * convert(int,stock_num) stock_total, purchase_datetime" +
                " FROM t_stock ";
            return this.handler.Query(commandText, start, max);
        }

        /// <summary>
        /// ��ȡ��Ʒ����¼
        /// </summary>
        /// <param name="goodid">��ƷID</param>
        /// <returns></returns>
        public DataTable GetStocks(string goodid)
        {
            //string commandText = "SELECT stock_num,purchase_price from t_stock where" +
            //    " good_id = @good_id order by purchase_price ASC";
            StringBuilder commandText = new StringBuilder();
            commandText.Append("select SUM(convert(int,stock_num) * stock_oper)stock_num, purchase_price " + 
                "from t_stock where good_id=@good_id group by good_id,purchase_price order by purchase_price ASC");
            IList parameters = new ArrayList();

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@good_id";
            parmID.DbType = DbType.String;
            parmID.Value = goodid;
            parameters.Add(parmID);

            return this.handler.Query(commandText.ToString(), parameters);
        }

        #endregion

        #region --- GetSize���� ---

        /// <summary>
        /// ��ȡ������
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            string commandText = "SELECT Count(stock_id) FROM t_stock";
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
        /// <param name="stock">�û���Ϣ</param>
        /// <returns></returns>
        public int GetSize(Stock stock)
        {
            string commandText = "SELECT Count(stock_id) FROM t_stock WHERE good_id=@good_id";

            DataParameter parmGoodId = new DataParameter();
            parmGoodId.ParameterName = "@good_id";
            parmGoodId.DbType = DbType.String;
            parmGoodId.Value = stock.Good_Id;

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
        public bool Delete(Stock stock)
        {
            if (stock.Stock_Id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_stock WHERE stock_id=@stock_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@stock_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = stock.Stock_Id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 
    }
}
