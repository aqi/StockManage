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
    /// BrandProvider类表示产品品牌模块操作的管理者
    /// </summary>
    public class BrandProvider : ActionBase
    {

        #region --- Insert方法 ---

        /// <summary>
        /// 添加一条新的产品品牌
        /// </summary>
        /// <param unit="brand">新的产品品牌</param>
        /// <returns>添加成功返回true,否则返回false</returns>
        public bool Insert(Brand brand)
        {
            if (String.IsNullOrEmpty(brand.Brand_name))
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_brand VALUES (@brand_name)";

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@brand_name";
                parmName.DbType = DbType.String;
                parmName.Value = brand.Brand_name;

                IList parameters = new ArrayList();
                parameters.Add(parmName);

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
        /// 修改产品品牌的内容
        /// </summary>
        /// <param name="brand">新的产品品牌</param>
        /// <returns>修改成功返回true,否则返回false</returns>
        public bool Update(Brand brand)
        {
            if (brand.Brand_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_brand " +
                                  " SET brand_name=@brand_name " +
                                     " WHERE brand_id=@brand_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@brand_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = brand.Brand_id;

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@brand_name";
            parmName.DbType = DbType.String;
            parmName.Value = brand.Brand_name;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmName);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion

        #region --- Select方法 ---

        /// <summary>
        /// 根据指定的过滤条件查询产品品牌
        /// </summary>
        /// <param name="brand">过滤条件</param>
        /// <returns></returns>
        public DataTable Select(Brand brand)
        {
            return this.Select(brand, 0, 0);
        }

        /// <summary>
        /// 利用分页机制,根据指定的过滤条件查询产品品牌
        /// </summary>
        /// <param name="brand">过滤条件</param>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable Select(Brand brand, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT * FROM t_brand WHERE 1=1 ");
            IList parameters = new ArrayList();

            if (brand.Brand_id != 0)
            {
                commandText.Append(" AND brand_id=@brand_id ");
                DataParameter parmID = new DataParameter();
                parmID.ParameterName = "@brand_id";
                parmID.DbType = DbType.Int32;
                parmID.Value = brand.Brand_id;
                parameters.Add(parmID);

            }

            if (!String.IsNullOrEmpty(brand.Brand_name))
            {
                commandText.Append(" AND brand_name like @brand_name ");

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@brand_name";
                parmName.DbType = DbType.String;
                parmName.Value = brand.Brand_name;
                parameters.Add(parmName);
            }



            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        #endregion

        #region --- GetAll方法 ---

        /// <summary>
        /// 获取所有的产品品牌记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_brand";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// 利用分页机制获取所有的产品品牌记录
        /// </summary>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT * FROM t_brand";
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
            string commandText = "SELECT Count(brand_id) FROM t_brand";
            DataTable table = this.handler.Query(commandText);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        /// <summary>
        /// 获取产品品牌名称总行数
        /// </summary>
        /// <param name="brand">产品品牌</param>
        /// <returns></returns>
        public int GetSize(Brand brand)
        {
            string commandText = "SELECT Count(brand_id) FROM t_brand WHERE brand_name like @brand_name";

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@brand_name";
            parmName.DbType = DbType.String;
            parmName.Value = brand.Brand_name;

            IList parameters = new ArrayList();
            parameters.Add(parmName);

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
        /// 删除指定的产品品牌
        /// </summary>
        /// <param name="brand">将要被删除的产品品牌</param>
        /// <returns>删除成功返回true,否则返回false</returns>
        public bool Delete(Brand brand)
        {
            if (brand.Brand_id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_brand WHERE brand_id=@brand_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@brand_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = brand.Brand_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 

    }
}
