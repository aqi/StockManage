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
    /// PlaceProvider类表示库位模块操作的管理者
    /// </summary>
    public class PlaceProvider : ActionBase
    {
        #region --- Insert方法 ---

        /// <summary>
        /// 添加一条新的库位
        /// </summary>
        /// <param unit="place">新的库位</param>
        /// <returns>添加成功返回true,否则返回false</returns>
        public bool Insert(Place place)
        {
            if (String.IsNullOrEmpty(place.Place_num))
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_place VALUES (@place_num,@place_state)";

                DataParameter parmNum = new DataParameter();
                parmNum.ParameterName = "@place_num";
                parmNum.DbType = DbType.String;
                parmNum.Value = place.Place_num;

                DataParameter parmState = new DataParameter();
                parmState.ParameterName = "@place_state";
                parmState.DbType = DbType.String;
                parmState.Value = place.Place_state;

                IList parameters = new ArrayList();
                parameters.Add(parmNum);
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
        /// 修改库位的内容
        /// </summary>
        /// <param name="place">新的库位</param>
        /// <returns>修改成功返回true,否则返回false</returns>
        public bool Update(Place place)
        {
            if (place.Place_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_place " +
                                  " SET place_num=@place_num,place_state=@place_state " +
                                     " WHERE place_id=@place_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@place_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = place.Place_id;

            DataParameter parmNum = new DataParameter();
            parmNum.ParameterName = "@place_num";
            parmNum.DbType = DbType.String;
            parmNum.Value = place.Place_num;

            DataParameter parmState = new DataParameter();
            parmState.ParameterName = "@place_state";
            parmState.DbType = DbType.String;
            parmState.Value = place.Place_state;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmNum);
            parameters.Add(parmState);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion

        #region --- Select方法 ---

        /// <summary>
        /// 根据指定的过滤条件查询库位
        /// </summary>
        /// <param name="place">过滤条件</param>
        /// <returns></returns>
        public DataTable Select(Place place)
        {
            return this.Select(place, 0, 0);
        }

        /// <summary>
        /// 利用分页机制,根据指定的过滤条件查询库位
        /// </summary>
        /// <param name="product">过滤条件</param>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable Select(Place place, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT * FROM t_place WHERE 1=1 ");
            IList parameters = new ArrayList();

            if (place.Place_id != 0)
            {
                commandText.Append(" AND place_id=@place_id ");
                DataParameter parmID = new DataParameter();
                parmID.ParameterName = "@place_id";
                parmID.DbType = DbType.Int32;
                parmID.Value = place.Place_id;
                parameters.Add(parmID);

            }

            if ( false == String.IsNullOrEmpty(place.Place_num))
            {
                commandText.Append(" AND place_num like  @place_num ");

                DataParameter parmNum = new DataParameter();
                parmNum.ParameterName = "@place_num";
                parmNum.DbType = DbType.String;
                parmNum.Value = place.Place_num;
                parameters.Add(parmNum);
            }

            if ( false == String.IsNullOrEmpty(place.Place_state))
            {
                commandText.Append(" AND place_state like  @place_state ");

                DataParameter parmState = new DataParameter();
                parmState.ParameterName = "@place_state";
                parmState.DbType = DbType.String;
                parmState.Value = place.Place_state;
                parameters.Add(parmState);
            }

            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        #endregion

        #region --- GetAll方法 ---

        /// <summary>
        /// 获取所有的库位记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_place";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// 利用分页机制获取所有的库位别记录
        /// </summary>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT * FROM t_place";
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
            string commandText = "SELECT Count(place_id) FROM t_place";
            DataTable table = this.handler.Query(commandText);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        /// <summary>
        /// 获取库位编号总行数
        /// </summary>
        /// <param name="place">库位编号</param>
        /// <returns></returns>
        public int GetSize(Place place)
        {
            string commandText = "SELECT Count(place_id) FROM t_place WHERE place_num like @place_num";

            DataParameter parmNum = new DataParameter();
            parmNum.ParameterName = "@place_num";
            parmNum.DbType = DbType.String;
            parmNum.Value = place.Place_num;

            IList parameters = new ArrayList();
            parameters.Add(parmNum);

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
        /// 删除指定的库位
        /// </summary>
        /// <param name="place">将要被删除的库位</param>
        /// <returns>删除成功返回true,否则返回false</returns>
        public bool Delete(Place place)
        {
            if (place.Place_id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_place WHERE place_id=@place_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@place_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = place.Place_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 
    }
}
