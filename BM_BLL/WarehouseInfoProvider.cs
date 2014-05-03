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
    /// WarehouseInfoProvider类表示库存模块操作的管理者
    /// </summary>
    public class WarehouseInfoProvider : ActionBase
    {
        #region --- Insert方法 ---

        /// <summary>
        /// 添加一条新的库存
        /// </summary>
        /// <param unit="warehouse">新的库存</param>
        /// <returns>添加成功返回true,否则返回false</returns>
        public bool Insert(Warehouse_info warehouse)
        {
            if (warehouse.Warehouse_info_number == 0)
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_warehouse_info VALUES (@good_id,@warehouse_id,@warehouse_info_number,@place_id)";

                DataParameter parmGood = new DataParameter();
                parmGood.ParameterName = "@good_id";
                parmGood.DbType = DbType.Int32;
                parmGood.Value = warehouse.Good_id;

                DataParameter parmWarehouse_id = new DataParameter();
                parmWarehouse_id.ParameterName = "@warehouse_id";
                parmWarehouse_id.DbType = DbType.Int32;
                parmWarehouse_id.Value = warehouse.Warehouse_id;

                DataParameter parmNumber = new DataParameter();
                parmNumber.ParameterName = "@warehouse_info_number";
                parmNumber.DbType = DbType.Int32;
                parmNumber.Value = warehouse.Warehouse_info_number;

                DataParameter parmPlaceID = new DataParameter();
                parmPlaceID.ParameterName = "@place_id";
                parmPlaceID.DbType = DbType.Int32;
                parmPlaceID.Value = warehouse.Place_id;

                IList parameters = new ArrayList();
                parameters.Add(parmGood);
                parameters.Add(parmWarehouse_id);
                parameters.Add(parmNumber);
                parameters.Add(parmPlaceID);

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
        public bool Update(Warehouse_info warehouse)
        {
            if (warehouse.Warehouse_info_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_warehouse_info " +
                                  " SET good_id=@good_id,warehouse_id=@warehouse_id,warehouse_info_number=@warehouse_info_number ,place_id=@place_id  " +
                                     " WHERE warehouse_info_id=@warehouse_info_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@warehouse_info_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = warehouse.Warehouse_info_id;

            DataParameter parmGood = new DataParameter();
            parmGood.ParameterName = "@good_id";
            parmGood.DbType = DbType.Int32;
            parmGood.Value = warehouse.Good_id;

            DataParameter parmWarehouse_id = new DataParameter();
            parmWarehouse_id.ParameterName = "@warehouse_id";
            parmWarehouse_id.DbType = DbType.Int32;
            parmWarehouse_id.Value = warehouse.Warehouse_id;

            DataParameter parmNumber = new DataParameter();
            parmNumber.ParameterName = "@warehouse_info_number";
            parmNumber.DbType = DbType.Int32;
            parmNumber.Value = warehouse.Warehouse_info_number;

            DataParameter parmPlaceID = new DataParameter();
            parmPlaceID.ParameterName = "@place_id";
            parmPlaceID.DbType = DbType.Int32;
            parmPlaceID.Value = warehouse.Place_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmGood);
            parameters.Add(parmWarehouse_id);
            parameters.Add(parmNumber);
            parameters.Add(parmPlaceID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        public bool Update(int warehouse_info_number, int warehouse_info_id)
        {
            if (warehouse_info_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_warehouse_info " +
                                  " SET warehouse_info_number=warehouse_info_number+@warehouse_info_number " +
                                     " WHERE warehouse_info_id=@warehouse_info_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@warehouse_info_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = warehouse_info_id;

            DataParameter parmNumber = new DataParameter();
            parmNumber.ParameterName = "@warehouse_info_number";
            parmNumber.DbType = DbType.Int32;
            parmNumber.Value = warehouse_info_number;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmNumber);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        public bool UpdateOut(int warehouse_info_number, int warehouse_info_id)
        {
            if (warehouse_info_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_warehouse_info " +
                                  " SET warehouse_info_number=warehouse_info_number-@warehouse_info_number " +
                                     " WHERE warehouse_info_id=@warehouse_info_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@warehouse_info_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = warehouse_info_id;

            DataParameter parmNumber = new DataParameter();
            parmNumber.ParameterName = "@warehouse_info_number";
            parmNumber.DbType = DbType.Int32;
            parmNumber.Value = warehouse_info_number;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmNumber);

            return this.handler.ExecuteCommand(commandText, parameters);
        }
        #endregion

        #region --- Select方法 ---

        /// <summary>
        /// 根据指定的过滤条件查询库存
        /// </summary>
        /// <param name="warehouse">过滤条件</param>
        /// <returns></returns>
        public DataTable Select(Warehouse_info warehouse)
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
        public DataTable Select(Warehouse_info warehouse, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT * FROM t_warehouse_info WHERE 1=1 ");
            IList parameters = new ArrayList();

            if (warehouse.Good_id != 0)
            {
                commandText.Append(" AND good_id=@good_id ");
                DataParameter parmID = new DataParameter();
                parmID.ParameterName = "@good_id";
                parmID.DbType = DbType.Int32;
                parmID.Value = warehouse.Good_id;
                parameters.Add(parmID);

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
            string commandText = "SELECT * FROM t_warehouse_info,t_good,t_place WHERE  t_warehouse_info.good_id=t_good.good_id AND t_warehouse_info.place_id=t_place.place_id";
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
            string commandText = "SELECT * FROM t_warehouse_info,t_good,t_place WHERE  t_warehouse_info.good_id=t_good.good_id AND t_warehouse_info.place_id=t_place.place_id ";
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
            string commandText = "SELECT Count(warehouse_info_id) FROM t_warehouse_info";
            DataTable table = this.handler.Query(commandText);
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
        public bool Delete(Warehouse_info warehouse)
        {
            if (warehouse.Warehouse_id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_warehouse_info WHERE warehouse_info_id=@warehouse_info_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@warehouse_info_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = warehouse.Warehouse_info_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 
    }
}
