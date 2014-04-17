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
    /// WarehouseProvider类表示库存模块操作的管理者
    /// </summary>
    public class WarehouseProvider : ActionBase
    {
        #region --- Insert方法 ---

        /// <summary>
        /// 添加一条新的库存
        /// </summary>
        /// <param unit="warehouse">新的库存</param>
        /// <returns>添加成功返回true,否则返回false</returns>
        public bool Insert(Warehouse warehouse)
        {
            if (warehouse.Warehouse_number == 0)
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_warehouse VALUES (@good_id,@warehouse_type,@warehouse_number,@warehouse_time,@order_id,@warehouse_operators)";

                DataParameter parmGood = new DataParameter();
                parmGood.ParameterName = "@good_id";
                parmGood.DbType = DbType.Int32;
                parmGood.Value = warehouse.Good_id;

                DataParameter parmType = new DataParameter();
                parmType.ParameterName = "@warehouse_type";
                parmType.DbType = DbType.String;
                parmType.Value = warehouse.Warehouse_type;

                DataParameter parmNumber = new DataParameter();
                parmNumber.ParameterName = "@warehouse_number";
                parmNumber.DbType = DbType.Int32;
                parmNumber.Value = warehouse.Warehouse_number;

                DataParameter parmTime = new DataParameter();
                parmTime.ParameterName = "@warehouse_time";
                parmTime.DbType = DbType.DateTime;
                parmTime.Value = warehouse.Warehouse_time;

                DataParameter parmOrderID = new DataParameter();
                parmOrderID.ParameterName = "@order_id";
                parmOrderID.DbType = DbType.Int32;
                parmOrderID.Value = warehouse.Order_id;

                DataParameter parmOperators = new DataParameter();
                parmOperators.ParameterName = "@warehouse_operators";
                parmOperators.DbType = DbType.String;
                parmOperators.Value = warehouse.Warehouse_operators;

                IList parameters = new ArrayList();
                parameters.Add(parmGood);
                parameters.Add(parmType);
                parameters.Add(parmNumber);
                parameters.Add(parmTime);
                parameters.Add(parmOrderID);
                parameters.Add(parmOperators);

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
        /// 修改库存的内容
        /// </summary>
        /// <param name="warehouse">新的库存</param>
        /// <returns>修改成功返回true,否则返回false</returns>
        public bool Update(Warehouse warehouse)
        {
            if (warehouse.Warehouse_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_warehouse " +
                                  " SET good_id=@good_id,warehouse_type=@warehouse_type,warehouse_number=@warehouse_number ,warehouse_time=@warehouse_time r,warehouse_operators=@warehouse_operators  " +
                                     " WHERE warehouse_id=@warehouse_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@warehouse_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = warehouse.Warehouse_id;

            DataParameter parmGood = new DataParameter();
            parmGood.ParameterName = "@good_id";
            parmGood.DbType = DbType.Int32;
            parmGood.Value = warehouse.Good_id;

            DataParameter parmType = new DataParameter();
            parmType.ParameterName = "@warehouse_type";
            parmType.DbType = DbType.String;
            parmType.Value = warehouse.Warehouse_type;

            DataParameter parmNumber = new DataParameter();
            parmNumber.ParameterName = "@warehouse_number";
            parmNumber.DbType = DbType.Int32;
            parmNumber.Value = warehouse.Warehouse_number;

            DataParameter parmTime = new DataParameter();
            parmTime.ParameterName = "@warehouse_time";
            parmTime.DbType = DbType.DateTime;
            parmTime.Value = warehouse.Warehouse_time;

            DataParameter parmOperators = new DataParameter();
            parmOperators.ParameterName = "@warehouse_operators";
            parmOperators.DbType = DbType.String;
            parmOperators.Value = warehouse.Warehouse_type;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmGood);
            parameters.Add(parmType);
            parameters.Add(parmNumber);
            parameters.Add(parmTime);
            parameters.Add(parmOperators);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion

        #region --- Select方法 ---

        /// <summary>
        /// 根据指定的过滤条件查询库存
        /// </summary>
        /// <param name="warehouse">过滤条件</param>
        /// <returns></returns>
        public DataTable Select(Warehouse warehouse)
        {
            return this.Select(warehouse, 0, 0);
        }

        /// <summary>
        /// 利用分页机制,根据指定的过滤条件查询库存
        /// </summary>
        /// <param name="warehouse">过滤条件</param>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable Select(Warehouse warehouse, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT * FROM t_warehouse warehouses,t_good goods WHERE warehouses.good_id=goods.good_id ");
            IList parameters = new ArrayList();

            if (warehouse.Warehouse_id != 0)
            {
                commandText.Append(" AND warehouse_id=@warehouse_id ");
                DataParameter parmID = new DataParameter();
                parmID.ParameterName = "@warehouse_id";
                parmID.DbType = DbType.Int32;
                parmID.Value = warehouse.Warehouse_id;
                parameters.Add(parmID);

            }

            if (warehouse.Good_id != 0)
            {
                commandText.Append(" AND warehouses.good_id=@good_id ");

                DataParameter parmGood = new DataParameter();
                parmGood.ParameterName = "@good_id";
                parmGood.DbType = DbType.Int32;
                parmGood.Value = warehouse.Good_id;
                parameters.Add(parmGood);
            }

            if (!String.IsNullOrEmpty(warehouse.Warehouse_type))
            {
                commandText.Append(" AND warehouse_type=@warehouse_type ");

                DataParameter parmType = new DataParameter();
                parmType.ParameterName = "@warehouse_type";
                parmType.DbType = DbType.String;
                parmType.Value = warehouse.Warehouse_type;
                parameters.Add(parmType);
            }

            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        #endregion

        #region --- GetAll方法 ---

        /// <summary>
        /// 获取所有的库存记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_warehouse warehouses,t_good goods WHERE warehouses.good_id=goods.good_id ";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// 利用分页机制获取所有的库存记录
        /// </summary>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT * FROM t_warehouse warehouses,t_good goods WHERE warehouses.good_id=goods.good_id ";
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
            string commandText = "SELECT Count(warehouse_id) FROM t_warehouse";
            DataTable table = this.handler.Query(commandText);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        /// <summary>
        /// 获取库存明细ID总行数
        /// </summary>
        /// <param name="warehouse">库存信息</param>
        /// <returns></returns>
        public int GetSize(Warehouse warehouse)
        {
            string commandText = "SELECT Count(warehouse_id) FROM t_warehouse WHERE good_id=@good_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@good_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = warehouse.Good_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

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
        /// 删除指定的库存记录
        /// </summary>
        /// <param name="warehouse">将要被删除的库存记录</param>
        /// <returns>删除成功返回true,否则返回false</returns>
        public bool Delete(Warehouse warehouse)
        {
            if (warehouse.Warehouse_id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_warehouse WHERE warehouse_id=@warehouse_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@warehouse_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = warehouse.Warehouse_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 
    }
}
