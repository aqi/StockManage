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
    /// GoodProvider类表示产品信息模块操作的管理者
    /// </summary>
    public class GoodProvider : ActionBase
    {
        #region --- Insert方法 ---

        /// <summary>
        /// 添加一条新的产品信息
        /// </summary>
        /// <param unit="good">新的产品信息</param>
        /// <returns>添加成功返回true,否则返回false</returns>
        public bool Insert(Good good)
        {
            if (String.IsNullOrEmpty(good.Good_name))
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_good VALUES(@good_img,@good_name,@good_num,@purchase_priceMin,@purchase_priceMax)";

                DataParameter parmImg = new DataParameter();
                parmImg.ParameterName = "@good_img";
                parmImg.DbType = DbType.String;
                parmImg.Value = good.Good_img;

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@good_name";
                parmName.DbType = DbType.String;
                parmName.Value = good.Good_name;

                DataParameter parmNum = new DataParameter();
                parmNum.ParameterName = "@good_num";
                parmNum.DbType = DbType.String;
                parmNum.Value = good.Good_Num;

                DataParameter parmPriceMin = new DataParameter();
                parmPriceMin.ParameterName = "@purchase_priceMin";
                parmPriceMin.DbType = DbType.Int32;
                parmPriceMin.Value = good.Purchase_PriceMin;

                DataParameter parmPriceMax = new DataParameter();
                parmPriceMax.ParameterName = "@purchase_priceMax";
                parmPriceMax.DbType = DbType.Int32;
                parmPriceMax.Value = good.Purchase_PriceMax;

                IList parameters = new ArrayList();
                parameters.Add(parmImg);
                parameters.Add(parmName);
                parameters.Add(parmNum);
                parameters.Add(parmPriceMin);
                parameters.Add(parmPriceMax);

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
        /// 修改产品信息的内容
        /// </summary>
        /// <param name="good">新的产品信息</param>
        /// <returns>修改成功返回true,否则返回false</returns>
        public bool Update(Good good)
        {
            if (good.Good_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_good " +
                                  " SET good_img=@good_img,good_name=@good_name,good_num=@good_num," +
            "purchase_priceMin=@purchase_priceMin,purchase_priceMax=@purchase_priceMax " +
                                     " WHERE good_id=@good_id ";

            DataParameter parmId = new DataParameter();
            parmId.ParameterName = "@good_id";
            parmId.DbType = DbType.Int32;
            parmId.Value = good.Good_id;

            DataParameter parmImg = new DataParameter();
            parmImg.ParameterName = "@good_img";
            parmImg.DbType = DbType.String;
            parmImg.Value = good.Good_img;

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@good_name";
            parmName.DbType = DbType.String;
            parmName.Value = good.Good_name;

            DataParameter parmNum = new DataParameter();
            parmNum.ParameterName = "@good_num";
            parmNum.DbType = DbType.String;
            parmNum.Value = good.Good_Num;

            DataParameter parmPriceMin = new DataParameter();
            parmPriceMin.ParameterName = "@purchase_priceMin";
            parmPriceMin.DbType = DbType.Int32;
            parmPriceMin.Value = good.Purchase_PriceMax;

            DataParameter parmPriceMax = new DataParameter();
            parmPriceMax.ParameterName = "@purchase_priceMax";
            parmPriceMax.DbType = DbType.Int32;
            parmPriceMin.Value = good.Purchase_PriceMin;

            IList parameters = new ArrayList();
            parameters.Add(parmId);
            parameters.Add(parmImg);
            parameters.Add(parmName);
            parameters.Add(parmNum);
            parameters.Add(parmPriceMin);
            parameters.Add(parmPriceMax);
     
            return this.handler.ExecuteCommand(commandText, parameters);
        }

        /// <summary>
        /// 修改产品信息的内容
        /// </summary>
        /// <param name="good">新的产品信息</param>
        /// <returns>修改成功返回true,否则返回false</returns>
        public bool UpdateInfo(Good good)
        {
            if (good.Good_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_good " +
                                  " SET good_img=@good_img,good_name=@good_name,good_num=@good_num" +
                                     " WHERE good_id=@good_id ";

            DataParameter parmId = new DataParameter();
            parmId.ParameterName = "@good_id";
            parmId.DbType = DbType.Int32;
            parmId.Value = good.Good_id;

            DataParameter parmImg = new DataParameter();
            parmImg.ParameterName = "@good_img";
            parmImg.DbType = DbType.String;
            parmImg.Value = good.Good_img;

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@good_name";
            parmName.DbType = DbType.String;
            parmName.Value = good.Good_name;

            DataParameter parmNum = new DataParameter();
            parmNum.ParameterName = "@good_num";
            parmNum.DbType = DbType.String;
            parmNum.Value = good.Good_Num;

            IList parameters = new ArrayList();
            parameters.Add(parmId);
            parameters.Add(parmImg);
            parameters.Add(parmName);
            parameters.Add(parmNum);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        /// <summary>
        /// 修改产品限价的内容
        /// </summary>
        /// <param name="good">新的产品信息</param>
        /// <returns>修改成功返回true,否则返回false</returns>
        public bool UpdatePrice(Good good)
        {
            if (good.Good_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE t_good " +
                                  " SET purchase_priceMin=@purchase_priceMin,purchase_priceMax=@purchase_priceMax " +
                                     " WHERE good_id=@good_id ";

            DataParameter parmId = new DataParameter();
            parmId.ParameterName = "@good_id";
            parmId.DbType = DbType.Int32;
            parmId.Value = good.Good_id;


            DataParameter parmPriceMin = new DataParameter();
            parmPriceMin.ParameterName = "@purchase_priceMin";
            parmPriceMin.DbType = DbType.Int32;
            parmPriceMin.Value = good.Purchase_PriceMin;

            DataParameter parmPriceMax = new DataParameter();
            parmPriceMax.ParameterName = "@purchase_priceMax";
            parmPriceMax.DbType = DbType.Int32;
            parmPriceMax.Value = good.Purchase_PriceMax;

            IList parameters = new ArrayList();
            parameters.Add(parmId);
            parameters.Add(parmPriceMin);
            parameters.Add(parmPriceMax);

            return this.handler.ExecuteCommand(commandText, parameters);
        }
       
        #endregion

        #region --- Select方法 ---

        /// <summary>
        /// 根据指定的过滤条件查询产品信息
        /// </summary>
        /// <param name="good">过滤条件</param>
        /// <returns></returns>
        public DataTable Select(Good good)
        {
            return this.Select(good, 0, 0);
        }

        /// <summary>
        /// 利用分页机制,根据指定的过滤条件查询产品信息
        /// </summary>
        /// <param name="good">过滤条件</param>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable Select(Good good, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT * FROM t_good good WHERE 1=1 ");
            IList parameters = new ArrayList();

            if ( false == String.IsNullOrEmpty(good.Good_Num))
            {
                commandText.Append(" AND good_num=@good_num ");

                DataParameter parmNum = new DataParameter();
                parmNum.ParameterName = "@good_num";
                parmNum.DbType = DbType.String;
                parmNum.Value = good.Good_Num;
                parameters.Add(parmNum);
            }

            if (good.Good_id != 0)
            {
                commandText.Append(" AND good_id=@good_id ");
                DataParameter parmID = new DataParameter();
                parmID.ParameterName = "@good_id";
                parmID.DbType = DbType.Int32;
                parmID.Value = good.Good_id;
                parameters.Add(parmID);

            }

            if ( false == String.IsNullOrEmpty(good.Good_img))
            {
                commandText.Append(" AND good_img=@good_img ");

                DataParameter parmImg = new DataParameter();
                parmImg.ParameterName = "@good_img";
                parmImg.DbType = DbType.String;
                parmImg.Value = good.Good_img;
                parameters.Add(parmImg);
            }

            if ( false == String.IsNullOrEmpty(good.Good_name))
            {
                commandText.Append(" AND good_name like @good_name ");

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@good_name";
                parmName.DbType = DbType.String;
                parmName.Value = good.Good_name;
                parameters.Add(parmName);
            }

            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        #endregion

        #region --- GetAll方法 ---

        /// <summary>
        /// 获取所有的产品信息记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_good good";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// 利用分页机制获取所有的产品信息记录
        /// </summary>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT * FROM t_good good ";
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
            string commandText = "SELECT Count(good_id) FROM t_good";
            DataTable table = this.handler.Query(commandText);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        /// <summary>
        /// 获取产品信息记录名称总行数
        /// </summary>
        /// <param name="good">产品信息</param>
        /// <returns></returns>
        public int GetSize(Good good)
        {

            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT Count(good_id) FROM t_good WHERE 1=1 ");
            IList parameters = new ArrayList();

            if ( false == String.IsNullOrEmpty(good.Good_name))
            {
                commandText.Append(" AND good_name like @good_name ");

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@good_name";
                parmName.DbType = DbType.String;
                parmName.Value = good.Good_name;
                parameters.Add(parmName);
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
        /// 删除指定的产品信息
        /// </summary>
        /// <param name="good">将要被删除的产品信息</param>
        /// <returns>删除成功返回true,否则返回false</returns>
        public bool Delete(Good good)
        {
            if (good.Good_id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_good WHERE good_id=@good_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@good_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = good.Good_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 
    }
}
