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
    /// ProductProvider类表示产品类别模块操作的管理者
    /// </summary>
    public class ProductProvider : ActionBase
    {
        #region --- Insert方法 ---

        /// <summary>
        /// 添加一条新的产品类别
        /// </summary>
        /// <param unit="product">新的产品类别</param>
        /// <returns>添加成功返回true,否则返回false</returns>
        public bool Insert(Product product)
        {
            if (String.IsNullOrEmpty(product.Product_name))
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_product VALUES (@product_name)";

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@product_name";
                parmName.DbType = DbType.String;
                parmName.Value = product.Product_name;

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
        /// 修改产品类别的内容
        /// </summary>
        /// <param name="product">新的产品类别</param>
        /// <returns>修改成功返回true,否则返回false</returns>
        public bool Update(Product product)
        {
            if (product.Product_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_product " +
                                  " SET product_name=@product_name " +
                                     " WHERE product_id=@product_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@product_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = product.Product_id;

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@product_name";
            parmName.DbType = DbType.String;
            parmName.Value = product.Product_name;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmName);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion

        #region --- Select方法 ---

        /// <summary>
        /// 根据指定的过滤条件查询产品类别
        /// </summary>
        /// <param name="product">过滤条件</param>
        /// <returns></returns>
        public DataTable Select(Product product)
        {
            return this.Select(product, 0, 0);
        }

        /// <summary>
        /// 利用分页机制,根据指定的过滤条件查询产品类别
        /// </summary>
        /// <param name="product">过滤条件</param>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable Select(Product product, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT * FROM t_product WHERE 1=1 ");
            IList parameters = new ArrayList();

            if (product.Product_id != 0)
            {
                commandText.Append(" AND product_id=@product_id ");
                DataParameter parmID = new DataParameter();
                parmID.ParameterName = "@product_id";
                parmID.DbType = DbType.Int32;
                parmID.Value = product.Product_id;
                parameters.Add(parmID);

            }

            if (!String.IsNullOrEmpty(product.Product_name))
            {
                commandText.Append(" AND product_name like  @product_name ");

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@product_name";
                parmName.DbType = DbType.String;
                parmName.Value = product.Product_name;
                parameters.Add(parmName);
            }



            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        #endregion

        #region --- GetAll方法 ---

        /// <summary>
        /// 获取所有的产品类别记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_product";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// 利用分页机制获取所有的产品类别记录
        /// </summary>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT * FROM t_product";
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
            string commandText = "SELECT Count(product_id) FROM t_product";
            DataTable table = this.handler.Query(commandText);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        /// <summary>
        /// 获取产品类别名称总行数
        /// </summary>
        /// <param name="product">产品类别</param>
        /// <returns></returns>
        public int GetSize(Product product)
        {
            string commandText = "SELECT Count(product_id) FROM t_product WHERE product_name like @product_name";

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@product_name";
            parmName.DbType = DbType.String;
            parmName.Value = product.Product_name;

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
        /// 删除指定的产品类别
        /// </summary>
        /// <param name="unit">将要被删除的产品类别</param>
        /// <returns>删除成功返回true,否则返回false</returns>
        public bool Delete(Product product)
        {
            if (product.Product_id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_product WHERE product_id=@product_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@product_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = product.Product_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 
    }
}
