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
    /// OrderProvider���ʾ����ģ������Ĺ�����
    /// </summary>
    public class OrderProvider : ActionBase
    {
        #region --- Insert���� ---

        /// <summary>
        /// ���һ���µĶ�����Ϣ
        /// </summary>
        /// <param unit="order">�µĶ�����Ϣ</param>
        /// <returns>��ӳɹ�����true,���򷵻�false</returns>
        public bool Insert(Order order)
        {
            if (order.Buyer_Id == 0)
            {
                return false;
            }
            if (String.IsNullOrEmpty(order.Good_Name))
            {
                return false;
            }

            if (String.IsNullOrEmpty(order.Good_Num))
            {
                return false;
            }

            try
            {
                IList parameters = new ArrayList();
                string commandText = "INSERT INTO t_order VALUES(@buyer_id,@good_id,@good_name,@sale_price,@good_num," +
                    "@buyer_address,@buyer_postcode,@buyer_liaison,@buyer_cell,@order_price)";

                DataParameter parmBuyerId = new DataParameter();
                parmBuyerId.ParameterName = "@buyer_id";
                parmBuyerId.DbType = DbType.Int32;
                parmBuyerId.Value = order.Buyer_Id;
                parameters.Add(parmBuyerId);

                DataParameter parmGoodId = new DataParameter();
                parmGoodId.ParameterName = "@good_id";
                parmGoodId.DbType = DbType.Int32;
                parmGoodId.Value = order.Good_Id;
                parameters.Add(parmGoodId);

                DataParameter parmGoodName = new DataParameter();
                parmGoodName.ParameterName = "@good_name";
                parmGoodName.DbType = DbType.String;
                parmGoodName.Value = order.Sale_Price;
                parameters.Add(parmGoodName);

                DataParameter parmSalePrice = new DataParameter();
                parmSalePrice.ParameterName = "@sale_price";
                parmSalePrice.DbType = DbType.String;
                parmSalePrice.Value = order.Sale_Price;
                parameters.Add(parmSalePrice);

                DataParameter parmGoodNum = new DataParameter();
                parmGoodNum.ParameterName = "@good_num";
                parmGoodNum.DbType = DbType.String;
                parmGoodNum.Value = order.Good_Num;
                parameters.Add(parmGoodNum);

                DataParameter parmBuyerAddress = new DataParameter();
                parmBuyerAddress.ParameterName = "@buyer_address";
                parmBuyerAddress.DbType = DbType.String;
                parmBuyerAddress.Value = order.Buyer_Address;
                parameters.Add(parmBuyerAddress);

                DataParameter parmBuyerPostcode = new DataParameter();
                parmBuyerPostcode.ParameterName = "@buyer_postcode";
                parmBuyerPostcode.DbType = DbType.String;
                parmBuyerPostcode.Value = order.Buyer_Postcode;
                parameters.Add(parmBuyerPostcode);

                DataParameter parmBuyerLiaison = new DataParameter();
                parmBuyerLiaison.ParameterName = "@buyer_liaison";
                parmBuyerLiaison.DbType = DbType.String;
                parmBuyerLiaison.Value = order.Buyer_Liaison;
                parameters.Add(parmBuyerLiaison);

                DataParameter parmBuyerCell = new DataParameter();
                parmBuyerCell.ParameterName = "@buyer_cell";
                parmBuyerCell.DbType = DbType.String;
                parmBuyerCell.Value = order.Buyer_Cell;
                parameters.Add(parmBuyerCell);

                DataParameter parmOrderPrice = new DataParameter();
                parmOrderPrice.ParameterName = "@order_price";
                parmOrderPrice.DbType = DbType.String;
                parmOrderPrice.Value = order.Buyer_Id;
                parameters.Add(parmOrderPrice);


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
        /// �޸Ķ�����Ϣ������
        /// </summary>
        /// <param name="order">�µĶ�����Ϣ</param>
        /// <returns>�޸ĳɹ�����true,���򷵻�false</returns>
        public bool Update(Order order)
        {
            if (order.Order_id == 0)
            {
                return false;
            }

            IList parameters = new ArrayList();
            string commandText = " UPDATE  t_order " +
                                  " SET buyer_id=@buyer_id,good_id=@good_id,good_name=@good_name,sale_price=@sale_price," +
                                  "good_num=@good_num,buyer_address=@buyer_address,buyer_postcode=@buyer_postcode," +
                                  "buyer_liaison=@buyer_liaison,buyer_cell=@buyer_cell,order_price=@order_price" +
                                     " WHERE order_id=@order_id ";

            DataParameter parmOrderId = new DataParameter();
            parmOrderId.ParameterName = "@order_id";
            parmOrderId.DbType = DbType.Int32;
            parmOrderId.Value = order.Order_id;
            parameters.Add(parmOrderId);

            DataParameter parmBuyerId = new DataParameter();
            parmBuyerId.ParameterName = "@buyer_id";
            parmBuyerId.DbType = DbType.Int32;
            parmBuyerId.Value = order.Buyer_Id;
            parameters.Add(parmBuyerId);

            DataParameter parmGoodId = new DataParameter();
            parmGoodId.ParameterName = "@good_id";
            parmGoodId.DbType = DbType.Int32;
            parmGoodId.Value = order.Good_Id;
            parameters.Add(parmGoodId);

            DataParameter parmGoodName = new DataParameter();
            parmGoodName.ParameterName = "@good_name";
            parmGoodName.DbType = DbType.String;
            parmGoodName.Value = order.Sale_Price;
            parameters.Add(parmGoodName);

            DataParameter parmSalePrice = new DataParameter();
            parmSalePrice.ParameterName = "@sale_price";
            parmSalePrice.DbType = DbType.String;
            parmSalePrice.Value = order.Sale_Price;
            parameters.Add(parmSalePrice);

            DataParameter parmGoodNum = new DataParameter();
            parmGoodNum.ParameterName = "@good_num";
            parmGoodNum.DbType = DbType.String;
            parmGoodNum.Value = order.Good_Num;
            parameters.Add(parmGoodNum);

            DataParameter parmBuyerAddress = new DataParameter();
            parmBuyerAddress.ParameterName = "@buyer_address";
            parmBuyerAddress.DbType = DbType.String;
            parmBuyerAddress.Value = order.Buyer_Address;
            parameters.Add(parmBuyerAddress);

            DataParameter parmBuyerPostcode = new DataParameter();
            parmBuyerPostcode.ParameterName = "@buyer_postcode";
            parmBuyerPostcode.DbType = DbType.String;
            parmBuyerPostcode.Value = order.Buyer_Postcode;
            parameters.Add(parmBuyerPostcode);

            DataParameter parmBuyerLiaison = new DataParameter();
            parmBuyerLiaison.ParameterName = "@buyer_liaison";
            parmBuyerLiaison.DbType = DbType.String;
            parmBuyerLiaison.Value = order.Buyer_Liaison;
            parameters.Add(parmBuyerLiaison);

            DataParameter parmBuyerCell = new DataParameter();
            parmBuyerCell.ParameterName = "@buyer_cell";
            parmBuyerCell.DbType = DbType.String;
            parmBuyerCell.Value = order.Buyer_Cell;
            parameters.Add(parmBuyerCell);

            DataParameter parmOrderPrice = new DataParameter();
            parmOrderPrice.ParameterName = "@order_price";
            parmOrderPrice.DbType = DbType.String;
            parmOrderPrice.Value = order.Order_Price;
            parameters.Add(parmOrderPrice);

            return this.handler.ExecuteCommand(commandText, parameters);
        }



        public bool Update(string order_id, string order_state)
        {
            if (Convert.ToInt32(order_id) == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_order " +
                                  " SET order_state=@order_state " +
                                     " WHERE order_id=@order_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@order_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = order_id;

            DataParameter parmState = new DataParameter();
            parmState.ParameterName = "@order_state";
            parmState.DbType = DbType.String;
            parmState.Value = order_state;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmState);

            return this.handler.ExecuteCommand(commandText, parameters);
        }
        #endregion

        #region --- Select���� ---

        /// <summary>
        /// ����ָ���Ĺ���������ѯ������Ϣ
        /// </summary>
        /// <param name="order">��������</param>
        /// <returns></returns>
        public DataTable Select(Order order)
        {
            return this.Select(order, 0, 0);
        }

        /// <summary>
        /// ���÷�ҳ����,����ָ���Ĺ���������ѯ������Ϣ
        /// </summary>
        /// <param name="order">��������</param>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable Select(Order order, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT * FROM t_order orders WHERE 1=1");
            IList parameters = new ArrayList();

            if (order.Order_id != 0)
            {
                commandText.Append(" AND order_id=@order_id ");
                DataParameter parmID = new DataParameter();
                parmID.ParameterName = "@order_id";
                parmID.DbType = DbType.Int32;
                parmID.Value = order.Order_id;
                parameters.Add(parmID);

            }

            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        #endregion

        #region --- GetAll���� ---

        /// <summary>
        /// ��ȡ���еĶ�����Ϣ��¼
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_order orders ";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// ���÷�ҳ���ƻ�ȡ���еĶ�����Ϣ��¼
        /// </summary>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT * FROM t_order orders ";
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
            string commandText = "SELECT Count(order_id) FROM t_order";
            DataTable table = this.handler.Query(commandText);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        /// <summary>
        /// ��ȡ������������
        /// </summary>
        /// <param name="order">�µĶ�����Ϣ</param>
        /// <returns></returns>
        public int GetSize(Order order)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT Count(order_id) FROM t_order WHERE 1=1 ");

            IList parameters = new ArrayList();

            if (order.Order_id != 0)
            {
                commandText.Append(" And order_id=@order_id");
                DataParameter parmOrderId = new DataParameter();
                parmOrderId.ParameterName = "@order_id";
                parmOrderId.DbType = DbType.String;
                parmOrderId.Value = order.Order_id;
                parameters.Add(parmOrderId);
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
        /// ɾ��ָ���Ķ�����Ϣ
        /// </summary>
        /// <param name="unit">��Ҫ��ɾ���Ķ�����Ϣ</param>
        /// <returns>ɾ���ɹ�����true,���򷵻�false</returns>
        public bool Delete(Order order)
        {
            if (order.Order_id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_order WHERE order_id=@order_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@order_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = order.Order_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 
    }
}
