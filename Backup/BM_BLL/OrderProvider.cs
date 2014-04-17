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
            if (String.IsNullOrEmpty(order.Order_num))
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_order VALUES(@order_num,@customers_id,@order_purpose,@freight_id,@send_id,@order_acceptadd,@order_whether_charges,@order_mark,@order_state)";

                DataParameter parmNum = new DataParameter();
                parmNum.ParameterName = "@order_num";
                parmNum.DbType = DbType.String;
                parmNum.Value = order.Order_num;

                DataParameter parmCompany = new DataParameter();
                parmCompany.ParameterName = "@customers_id";
                parmCompany.DbType = DbType.Int32;
                parmCompany.Value = order.Customers_id;

                DataParameter parmPurpose = new DataParameter();
                parmPurpose.ParameterName = "@order_purpose";
                parmPurpose.DbType = DbType.String;
                parmPurpose.Value = order.Order_purpose;

                DataParameter parmFreight = new DataParameter();
                parmFreight.ParameterName = "@freight_id";
                parmFreight.DbType = DbType.Int32;
                parmFreight.Value = order.Freight_id;

                DataParameter parmSend = new DataParameter();
                parmSend.ParameterName = "@send_id";
                parmSend.DbType = DbType.Int32;
                parmSend.Value = order.Send_id;

                DataParameter parmAcceptadd = new DataParameter();
                parmAcceptadd.ParameterName = "@order_acceptadd";
                parmAcceptadd.DbType = DbType.String;
                parmAcceptadd.Value = order.Order_acceptadd;

                DataParameter parmWhetherCharges = new DataParameter();
                parmWhetherCharges.ParameterName = "@order_whether_charges";
                parmWhetherCharges.DbType = DbType.String;
                parmWhetherCharges.Value = order.Order_whether_charges;

                DataParameter parmMark = new DataParameter();
                parmMark.ParameterName = "@order_mark";
                parmMark.DbType = DbType.String;
                parmMark.Value = order.Order_mark;

                DataParameter parmState = new DataParameter();
                parmState.ParameterName = "@order_state";
                parmState.DbType = DbType.String;
                parmState.Value = order.Order_state;

                IList parameters = new ArrayList();
                parameters.Add(parmNum);
                parameters.Add(parmCompany);
                parameters.Add(parmPurpose);
                parameters.Add(parmFreight);
                parameters.Add(parmSend);
                parameters.Add(parmAcceptadd);
                parameters.Add(parmWhetherCharges);
                parameters.Add(parmMark);
                parameters.Add(parmState);

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

            string commandText = " UPDATE  t_order " +
                                  " SET order_num=@order_num,customers_id=@customers_id,order_purpose=@order_purpose,freight_id=@freight_id,send_id=@send_id,order_acceptadd=@order_acceptadd,order_whether_charges=@order_whether_charges,order_mark=@order_mark,order_state=@order_state " +
                                     " WHERE order_id=@order_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@order_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = order.Order_id;

            DataParameter parmNum = new DataParameter();
            parmNum.ParameterName = "@order_num";
            parmNum.DbType = DbType.String;
            parmNum.Value = order.Order_num;

            DataParameter parmCompany = new DataParameter();
            parmCompany.ParameterName = "@customers_id";
            parmCompany.DbType = DbType.Int32;
            parmCompany.Value = order.Customers_id;

            DataParameter parmPurpose = new DataParameter();
            parmPurpose.ParameterName = "@order_purpose";
            parmPurpose.DbType = DbType.String;
            parmPurpose.Value = order.Order_purpose;

            DataParameter parmFreight = new DataParameter();
            parmFreight.ParameterName = "@freight_id";
            parmFreight.DbType = DbType.Int32;
            parmFreight.Value = order.Freight_id;

            DataParameter parmSend = new DataParameter();
            parmSend.ParameterName = "@send_id";
            parmSend.DbType = DbType.Int32;
            parmSend.Value = order.Send_id;

            DataParameter parmAcceptadd = new DataParameter();
            parmAcceptadd.ParameterName = "@order_acceptadd";
            parmAcceptadd.DbType = DbType.String;
            parmAcceptadd.Value = order.Order_acceptadd;

            DataParameter parmWhetherCharges = new DataParameter();
            parmWhetherCharges.ParameterName = "@order_whether_charges";
            parmWhetherCharges.DbType = DbType.String;
            parmWhetherCharges.Value = order.Order_whether_charges;

            DataParameter parmMark = new DataParameter();
            parmMark.ParameterName = "@order_mark";
            parmMark.DbType = DbType.String;
            parmMark.Value = order.Order_mark;

            DataParameter parmState = new DataParameter();
            parmState.ParameterName = "@order_state";
            parmState.DbType = DbType.String;
            parmState.Value = order.Order_state;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmNum);
            parameters.Add(parmCompany);
            parameters.Add(parmPurpose);
            parameters.Add(parmFreight);
            parameters.Add(parmSend);
            parameters.Add(parmAcceptadd);
            parameters.Add(parmWhetherCharges);
            parameters.Add(parmMark);
            parameters.Add(parmState);

            return this.handler.ExecuteCommand(commandText, parameters);
        }



        public bool Update(string order_id, string order_state)
        {
            if (Convert.ToInt32( order_id) == 0)
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
            commandText.Append("SELECT * FROM t_order orders,t_customers customers,t_freight freights,t_send sends WHERE orders.customers_id=customers.customers_id  AND orders.freight_id=freights.freight_id AND orders.send_id=sends.send_id ");
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

            if (!String.IsNullOrEmpty(order.Order_num))
            {
                commandText.Append(" AND orders.order_num like @order_num ");

                DataParameter parmNum = new DataParameter();
                parmNum.ParameterName = "@order_num";
                parmNum.DbType = DbType.String;
                parmNum.Value = order.Order_num;
                parameters.Add(parmNum);
            }

            if (order.Customers_id != 0)
            {
                commandText.Append(" AND orders.customers_id=@customers_id ");
                DataParameter parmCompany = new DataParameter();
                parmCompany.ParameterName = "@company_id";
                parmCompany.DbType = DbType.Int32;
                parmCompany.Value = order.Customers_id;
                parameters.Add(parmCompany);

            }

            if (!String.IsNullOrEmpty(order.Order_purpose))
            {
                commandText.Append(" AND order_purpose=@order_purpose ");

                DataParameter parmPurpose = new DataParameter();
                parmPurpose.ParameterName = "@order_purpose";
                parmPurpose.DbType = DbType.String;
                parmPurpose.Value = order.Order_purpose;
                parameters.Add(parmPurpose);
            }

            if (order.Freight_id != 0)
            {
                commandText.Append(" AND orders.freight_id=@freight_id ");
                DataParameter parmFreight = new DataParameter();
                parmFreight.ParameterName = "@freight_id";
                parmFreight.DbType = DbType.Int32;
                parmFreight.Value = order.Freight_id;
                parameters.Add(parmFreight);

            }

            if (order.Send_id != 0)
            {
                commandText.Append(" AND orders.send_id=@send_id ");
                DataParameter parmSend = new DataParameter();
                parmSend.ParameterName = "@send_id";
                parmSend.DbType = DbType.Int32;
                parmSend.Value = order.Send_id;
                parameters.Add(parmSend);

            }

            if (!String.IsNullOrEmpty(order.Order_acceptadd))
            {
                commandText.Append(" AND order_acceptadd=@order_acceptadd ");

                DataParameter parmAcceptadd = new DataParameter();
                parmAcceptadd.ParameterName = "@order_acceptadd";
                parmAcceptadd.DbType = DbType.String;
                parmAcceptadd.Value = order.Order_acceptadd;
                parameters.Add(parmAcceptadd);
            }

            if (!String.IsNullOrEmpty(order.Order_whether_charges))
            {
                commandText.Append(" AND order_whether_charges=@order_whether_charges ");

                DataParameter parmWhetherCharges = new DataParameter();
                parmWhetherCharges.ParameterName = "@order_whether_charges";
                parmWhetherCharges.DbType = DbType.String;
                parmWhetherCharges.Value = order.Order_whether_charges;
                parameters.Add(parmWhetherCharges);
            }

            if (!String.IsNullOrEmpty(order.Order_state))
            {
                commandText.Append(" AND order_state=@order_state ");

                DataParameter parmState = new DataParameter();
                parmState.ParameterName = "@order_state";
                parmState.DbType = DbType.String;
                parmState.Value = order.Order_state;
                parameters.Add(parmState);
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
            string commandText = "SELECT * FROM t_order orders,t_customers customers,t_freight freights,t_send sends WHERE orders.customers_id=customers.customers_id  AND orders.freight_id=freights.freight_id AND orders.send_id=sends.send_id ";
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
            string commandText = "SELECT * FROM t_order orders,t_customers customers,t_freight freights,t_send sends WHERE orders.customers_id=customers.customers_id  AND orders.freight_id=freights.freight_id AND orders.send_id=sends.send_id ";
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

            if (!String.IsNullOrEmpty(order.Order_num))
            {
                commandText.Append(" AND order_num like @order_num ");

                DataParameter parmNum = new DataParameter();
                parmNum.ParameterName = "@order_num";
                parmNum.DbType = DbType.String;
                parmNum.Value = order.Order_num;
                parameters.Add(parmNum);
            }

            if (!String.IsNullOrEmpty(order.Order_state))
            {
                commandText.Append(" AND order_state=@order_state ");

                DataParameter parmState = new DataParameter();
                parmState.ParameterName = "@order_state";
                parmState.DbType = DbType.String;
                parmState.Value = order.Order_state;
                parameters.Add(parmState);
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
