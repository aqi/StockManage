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
    /// OrderProvider类表示订单模块操作的管理者
    /// </summary>
    public class OrderProvider : ActionBase
    {
        #region --- Insert方法 ---

        /// <summary>
        /// 添加一条新的订单信息
        /// </summary>
        /// <param unit="order">新的订单信息</param>
        /// <returns>添加成功返回true,否则返回false</returns>
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

        #region --- Update方法 ---

        /// <summary>
        /// 修改订单信息的内容
        /// </summary>
        /// <param name="order">新的订单信息</param>
        /// <returns>修改成功返回true,否则返回false</returns>
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

        #region --- Select方法 ---

        /// <summary>
        /// 根据指定的过滤条件查询订单信息
        /// </summary>
        /// <param name="order">过滤条件</param>
        /// <returns></returns>
        public DataTable Select(Order order)
        {
            return this.Select(order, 0, 0);
        }

        /// <summary>
        /// 利用分页机制,根据指定的过滤条件查询订单信息
        /// </summary>
        /// <param name="order">过滤条件</param>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
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

        #region --- GetAll方法 ---

        /// <summary>
        /// 获取所有的订单信息记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_order orders ";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// 利用分页机制获取所有的订单信息记录
        /// </summary>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT * FROM t_order orders ";
            return this.handler.Query(commandText, start, max);
        }

        #endregion

        #region --- GetSize方法 ---

        /// <summary>
        /// 获取总行数
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
        /// 获取订单号总行数
        /// </summary>
        /// <param name="order">新的订单信息</param>
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

        #region --- Delete方法 ---

        /// <summary>
        /// 删除指定的订单信息
        /// </summary>
        /// <param name="unit">将要被删除的订单信息</param>
        /// <returns>删除成功返回true,否则返回false</returns>
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
