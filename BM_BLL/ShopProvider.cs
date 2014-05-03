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
    /// ShopProvider类表示购物车模块操作的管理者
    /// </summary>
    public class ShopProvider : ActionBase
    {
        #region --- Insert方法 ---

        /// <summary>
        /// 添加一条新的购物车信息
        /// </summary>
        /// <param unit="shop">新的购物车信息</param>
        /// <returns>添加成功返回true,否则返回false</returns>
        public bool Insert(Shop shop)
        {
            if (shop.Shop_num == 0)
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_shop VALUES(@shop_jointime,@shop_num,@good_id,@order_id,@contrac_id)";

                DataParameter parmtime = new DataParameter();
                parmtime.ParameterName = "@shop_jointime";
                parmtime.DbType = DbType.DateTime;
                parmtime.Value = shop.Shop_jointime;

                DataParameter parmNum = new DataParameter();
                parmNum.ParameterName = "@shop_num";
                parmNum.DbType = DbType.Int32;
                parmNum.Value = shop.Shop_num;

                DataParameter parmGood = new DataParameter();
                parmGood.ParameterName = "@good_id";
                parmGood.DbType = DbType.Int32;
                parmGood.Value = shop.Good_id;

                DataParameter parmOrder = new DataParameter();
                parmOrder.ParameterName = "@order_id";
                parmOrder.DbType = DbType.Int32;
                parmOrder.Value = shop.Order_id;

                DataParameter parmContract = new DataParameter();
                parmContract.ParameterName = "@contrac_id";
                parmContract.DbType = DbType.Int32;
                parmContract.Value = shop.Contrac_id;


                IList parameters = new ArrayList();
                parameters.Add(parmtime);
                parameters.Add(parmNum);
                parameters.Add(parmGood);
                parameters.Add(parmOrder);
                parameters.Add(parmContract);

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
        /// 修改购物车信息的内容
        /// </summary>
        /// <param name="shop">新的购物车信息</param>
        /// <returns>修改成功返回true,否则返回false</returns>
        public bool Update(Shop shop)
        {
            if (shop.Shop_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_shop " +
                                  " SET shop_jointime=@shop_jointime,shop_num=@shop_num,good_id=@good_id,order_id=@order_id,contrac_id=@contrac_id " +
                                     " WHERE shop_id=@shop_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@shop_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = shop.Shop_id;

            DataParameter parmtime = new DataParameter();
            parmtime.ParameterName = "@shop_jointime";
            parmtime.DbType = DbType.DateTime;
            parmtime.Value = shop.Shop_jointime;

            DataParameter parmNum = new DataParameter();
            parmNum.ParameterName = "@shop_num";
            parmNum.DbType = DbType.Int32;
            parmNum.Value = shop.Shop_num;

            DataParameter parmGood = new DataParameter();
            parmGood.ParameterName = "@good_id";
            parmGood.DbType = DbType.Int32;
            parmGood.Value = shop.Good_id;

            DataParameter parmOrder = new DataParameter();
            parmOrder.ParameterName = "@order_id";
            parmOrder.DbType = DbType.Int32;
            parmOrder.Value = shop.Order_id;

            DataParameter parmContract = new DataParameter();
            parmContract.ParameterName = "@contrac_id";
            parmContract.DbType = DbType.Int32;
            parmContract.Value = shop.Contrac_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmtime);
            parameters.Add(parmNum);
            parameters.Add(parmGood);
            parameters.Add(parmOrder);
            parameters.Add(parmContract);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion

        #region --- Select方法 ---

        /// <summary>
        /// 根据指定的过滤条件查询购物车信息
        /// </summary>
        /// <param name="shop">过滤条件</param>
        /// <returns></returns>
        public DataTable Select(Shop shop)
        {
            return this.Select(shop, 0, 0);
        }

        /// <summary>
        /// 利用分页机制,根据指定的过滤条件查询购物车信息
        /// </summary>
        /// <param name="shop">过滤条件</param>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable Select(Shop shop, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT * FROM t_shop shops,t_good goods,t_order orders WHERE shops.good_id=goods.good_id AND shops.order_id=orders.order_id ");
            IList parameters = new ArrayList();

            if (shop.Shop_id != 0)
            {
                commandText.Append(" AND shop_id=@shop_id ");
                DataParameter parmID = new DataParameter();
                parmID.ParameterName = "@shop_id";
                parmID.DbType = DbType.Int32;
                parmID.Value = shop.Shop_id;
                parameters.Add(parmID);

            }

            if (shop.Shop_num != 0)
            {
                commandText.Append(" AND shop_num=@shop_num ");
                DataParameter parmNum = new DataParameter();
                parmNum.ParameterName = "@shop_num";
                parmNum.DbType = DbType.Int32;
                parmNum.Value = shop.Shop_num;
                parameters.Add(parmNum);

            }

            if (shop.Good_id != 0)
            {
                commandText.Append(" AND shops.good_id=@good_id ");
                DataParameter parmGood = new DataParameter();
                parmGood.ParameterName = "@good_id";
                parmGood.DbType = DbType.Int32;
                parmGood.Value = shop.Good_id;
                parameters.Add(parmGood);

            }

            if (shop.Order_id != 0)
            {
                commandText.Append(" AND shops.order_id=@order_id ");
                DataParameter parmOrder = new DataParameter();
                parmOrder.ParameterName = "@order_id";
                parmOrder.DbType = DbType.Int32;
                parmOrder.Value = shop.Order_id;
                parameters.Add(parmOrder);

            }

            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        #endregion

        #region --- GetAll方法 ---

        /// <summary>
        /// 获取所有的购物车信息记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_shop shops,t_good goods,t_order orders WHERE shops.good_id=goods.good_id AND shops.order_id=orders.order_id ";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// 利用分页机制获取所有的购物车信息记录
        /// </summary>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT * FROM t_shop shops,t_good goods,t_order orders WHERE shops.good_id=goods.good_id AND shops.order_id=orders.order_id ";
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
            string commandText = "SELECT Count(shop_id) FROM t_shop";
            DataTable table = this.handler.Query(commandText);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        /// <summary>
        /// 获取购物车订单总行数
        /// </summary>
        /// <param name="shop">购物车信息</param>
        /// <returns></returns>
        public int GetSize(Shop shop)
        {
            string commandText = "SELECT Count(shop_id) FROM t_shop WHERE order_id=@order_id";

            DataParameter parmOrder = new DataParameter();
            parmOrder.ParameterName = "@order_id";
            parmOrder.DbType = DbType.Int32;
            parmOrder.Value = shop.Order_id;

            IList parameters = new ArrayList();
            parameters.Add(parmOrder);

            DataTable table = this.handler.Query(commandText, parameters);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        #endregion

        #region --- Delete方法 ---

        /// <summary>
        /// 删除指定的购物车信息
        /// </summary>
        /// <param name="shop">将要被删除的购物车信息</param>
        /// <returns>删除成功返回true,否则返回false</returns>
        public bool Delete(Shop shop)
        {
            if (shop.Shop_id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_shop WHERE shop_id=@shop_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@shop_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = shop.Shop_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 
    }
}
