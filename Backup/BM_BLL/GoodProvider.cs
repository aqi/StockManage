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
                string commandText = "INSERT INTO t_good VALUES(@good_color,@good_code,@good_description,@good_img,@good_name,@brand_id,@good_num,@good_price,@good_selling_price,@unit_id,@product_id)";

                DataParameter parmGood = new DataParameter();
                parmGood.ParameterName = "@good_color";
                parmGood.DbType = DbType.String;
                parmGood.Value = good.Good_color;

                DataParameter parmCode = new DataParameter();
                parmCode.ParameterName = "@good_code";
                parmCode.DbType = DbType.String;
                parmCode.Value = good.Good_code;

                DataParameter parmDescription = new DataParameter();
                parmDescription.ParameterName = "@good_description";
                parmDescription.DbType = DbType.String;
                parmDescription.Value = good.Good_description;

                DataParameter parmImg = new DataParameter();
                parmImg.ParameterName = "@good_img";
                parmImg.DbType = DbType.String;
                parmImg.Value = good.Good_img;

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@good_name";
                parmName.DbType = DbType.String;
                parmName.Value = good.Good_name;

                DataParameter parmBrandId = new DataParameter();
                parmBrandId.ParameterName = "@brand_id";
                parmBrandId.DbType = DbType.Int32;
                parmBrandId.Value = good.Brand_id;

                DataParameter parmNum = new DataParameter();
                parmNum.ParameterName = "@good_num";
                parmNum.DbType = DbType.Int32;
                parmNum.Value = good.Good_num;

                DataParameter parmPrice = new DataParameter();
                parmPrice.ParameterName = "@good_price";
                parmPrice.DbType = DbType.Decimal;
                parmPrice.Value = good.Good_price;

                DataParameter parmSellingPrice = new DataParameter();
                parmSellingPrice.ParameterName = "@good_selling_price";
                parmSellingPrice.DbType = DbType.Decimal;
                parmSellingPrice.Value = good.Good_selling_price;

                DataParameter parmUnitId = new DataParameter();
                parmUnitId.ParameterName = "@unit_id";
                parmUnitId.DbType = DbType.Int32;
                parmUnitId.Value = good.Unit_id;

                DataParameter parmProductId = new DataParameter();
                parmProductId.ParameterName = "@product_id";
                parmProductId.DbType = DbType.Int32;
                parmProductId.Value = good.Product_id;

                IList parameters = new ArrayList();
                parameters.Add(parmGood);
                parameters.Add(parmCode);
                parameters.Add(parmDescription);
                parameters.Add(parmImg);
                parameters.Add(parmName);
                parameters.Add(parmBrandId);
                parameters.Add(parmNum);
                parameters.Add(parmPrice);
                parameters.Add(parmSellingPrice);
                parameters.Add(parmUnitId);
                parameters.Add(parmProductId);

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
                                  " SET good_color=@good_color,good_code=@good_code,good_description=@good_description,good_img=@good_img,good_name=@good_name,brand_id=@brand_id,good_num=@good_num,good_price=@good_price,good_selling_price=@good_selling_price,unit_id=@unit_id,product_id=@product_id " +
                                     " WHERE good_id=@good_id ";

            DataParameter parmId = new DataParameter();
            parmId.ParameterName = "@good_id";
            parmId.DbType = DbType.String;
            parmId.Value = good.Good_id;

            DataParameter parmGood = new DataParameter();
            parmGood.ParameterName = "@good_color";
            parmGood.DbType = DbType.String;
            parmGood.Value = good.Good_color;

            DataParameter parmCode = new DataParameter();
            parmCode.ParameterName = "@good_code";
            parmCode.DbType = DbType.String;
            parmCode.Value = good.Good_code;

            DataParameter parmDescription = new DataParameter();
            parmDescription.ParameterName = "@good_description";
            parmDescription.DbType = DbType.String;
            parmDescription.Value = good.Good_description;

            DataParameter parmImg = new DataParameter();
            parmImg.ParameterName = "@good_img";
            parmImg.DbType = DbType.String;
            parmImg.Value = good.Good_img;

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@good_name";
            parmName.DbType = DbType.String;
            parmName.Value = good.Good_name;

            DataParameter parmBrandId = new DataParameter();
            parmBrandId.ParameterName = "@brand_id";
            parmBrandId.DbType = DbType.Int32;
            parmBrandId.Value = good.Brand_id;

            DataParameter parmNum = new DataParameter();
            parmNum.ParameterName = "@good_num";
            parmNum.DbType = DbType.Int32;
            parmNum.Value = good.Good_num;

            DataParameter parmPrice = new DataParameter();
            parmPrice.ParameterName = "@good_price";
            parmPrice.DbType = DbType.Decimal;
            parmPrice.Value = good.Good_price;

            DataParameter parmSellingPrice = new DataParameter();
            parmSellingPrice.ParameterName = "@good_selling_price";
            parmSellingPrice.DbType = DbType.Decimal;
            parmSellingPrice.Value = good.Good_selling_price;

            DataParameter parmUnitId = new DataParameter();
            parmUnitId.ParameterName = "@unit_id";
            parmUnitId.DbType = DbType.Int32;
            parmUnitId.Value = good.Unit_id;

            DataParameter parmProductId = new DataParameter();
            parmProductId.ParameterName = "@product_id";
            parmProductId.DbType = DbType.Int32;
            parmProductId.Value = good.Product_id;

            IList parameters = new ArrayList();
            parameters.Add(parmId);
            parameters.Add(parmGood);
            parameters.Add(parmCode);
            parameters.Add(parmDescription);
            parameters.Add(parmImg);
            parameters.Add(parmName);
            parameters.Add(parmBrandId);
            parameters.Add(parmNum);
            parameters.Add(parmPrice);
            parameters.Add(parmSellingPrice);
            parameters.Add(parmUnitId);
            parameters.Add(parmProductId);
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
            commandText.Append("SELECT * FROM t_good good,t_unit unit,t_product product,t_brand brand WHERE good.unit_id=unit.unit_id AND good.product_id=product.product_id AND good.brand_id=brand.brand_id ");
            IList parameters = new ArrayList();

            if (good.Good_id != 0)
            {
                commandText.Append(" AND good_id=@good_id ");
                DataParameter parmID = new DataParameter();
                parmID.ParameterName = "@good_id";
                parmID.DbType = DbType.Int32;
                parmID.Value = good.Good_id;
                parameters.Add(parmID);

            }

            if (!String.IsNullOrEmpty(good.Good_color))
            {
                commandText.Append(" AND good_color=@good_color ");

                DataParameter parmGood = new DataParameter();
                parmGood.ParameterName = "@good_color";
                parmGood.DbType = DbType.String;
                parmGood.Value = good.Good_color;
                parameters.Add(parmGood);
            }

            if (!String.IsNullOrEmpty(good.Good_code))
            {
                commandText.Append(" AND good_code like @good_code ");

                DataParameter parmCode = new DataParameter();
                parmCode.ParameterName = "@good_code";
                parmCode.DbType = DbType.String;
                parmCode.Value = good.Good_code;
                parameters.Add(parmCode);
            }

            if (!String.IsNullOrEmpty(good.Good_description))
            {
                commandText.Append(" AND good_description=@good_description ");

                DataParameter parmDescription = new DataParameter();
                parmDescription.ParameterName = "@good_description";
                parmDescription.DbType = DbType.String;
                parmDescription.Value = good.Good_description;
                parameters.Add(parmDescription);
            }

            if (!String.IsNullOrEmpty(good.Good_img))
            {
                commandText.Append(" AND good_img=@good_img ");

                DataParameter parmImg = new DataParameter();
                parmImg.ParameterName = "@good_img";
                parmImg.DbType = DbType.String;
                parmImg.Value = good.Good_img;
                parameters.Add(parmImg);
            }

            if (!String.IsNullOrEmpty(good.Good_name))
            {
                commandText.Append(" AND good_name like @good_name ");

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@good_name";
                parmName.DbType = DbType.String;
                parmName.Value = good.Good_name;
                parameters.Add(parmName);
            }

            if (good.Brand_id !=0)
            {
                commandText.Append(" AND good.brand_id=@brand_id ");

                DataParameter parmBrandId = new DataParameter();
                parmBrandId.ParameterName = "@brand_id";
                parmBrandId.DbType = DbType.Int32;
                parmBrandId.Value = good.Brand_id;
                parameters.Add(parmBrandId);
            }

            if (good.Good_num != 0)
            {
                commandText.Append(" AND good_num=@good_num ");

                DataParameter parmNum = new DataParameter();
                parmNum.ParameterName = "@good_num";
                parmNum.DbType = DbType.Int32;
                parmNum.Value = good.Good_num;
                parameters.Add(parmNum);
            }

            if (good.Good_price != 0)
            {
                commandText.Append(" AND good_price=@good_price ");

                DataParameter parmPrice = new DataParameter();
                parmPrice.ParameterName = "@good_price";
                parmPrice.DbType = DbType.Decimal;
                parmPrice.Value = good.Good_price;
                parameters.Add(parmPrice);
            }

            if (good.Good_selling_price != 0)
            {
                commandText.Append(" AND good_selling_price=@good_selling_price ");

                DataParameter parmSellingPrice = new DataParameter();
                parmSellingPrice.ParameterName = "@good_selling_price";
                parmSellingPrice.DbType = DbType.Decimal;
                parmSellingPrice.Value = good.Good_selling_price;
                parameters.Add(parmSellingPrice);
            }

            if (good.Unit_id != 0)
            {
                commandText.Append(" AND good.unit_id=@unit_id ");

                DataParameter parmUnitId = new DataParameter();
                parmUnitId.ParameterName = "@unit_id";
                parmUnitId.DbType = DbType.Int32;
                parmUnitId.Value = good.Unit_id;
                parameters.Add(parmUnitId);
            }

            if (good.Product_id != 0)
            {
                commandText.Append(" AND good.product_id=@product_id ");

                DataParameter parmProductId = new DataParameter();
                parmProductId.ParameterName = "@product_id";
                parmProductId.DbType = DbType.Int32;
                parmProductId.Value = good.Product_id;
                parameters.Add(parmProductId);
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
            string commandText = "SELECT * FROM t_good good,t_unit unit,t_product product,t_brand brand WHERE good.unit_id=unit.unit_id AND good.product_id=product.product_id AND good.brand_id=brand.brand_id ";
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
            string commandText = "SELECT * FROM t_good good,t_unit unit,t_product product,t_brand brand WHERE good.unit_id=unit.unit_id AND good.product_id=product.product_id AND good.brand_id=brand.brand_id ";
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

            if (!String.IsNullOrEmpty(good.Good_name))
            {
                commandText.Append(" AND good_name like @good_name ");

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@good_name";
                parmName.DbType = DbType.String;
                parmName.Value = good.Good_name;
                parameters.Add(parmName);
            }

            if (good.Brand_id != 0)
            {
                commandText.Append(" AND brand_id=@brand_id ");

                DataParameter parmBrandId = new DataParameter();
                parmBrandId.ParameterName = "@brand_id";
                parmBrandId.DbType = DbType.Int32;
                parmBrandId.Value = good.Brand_id;
                parameters.Add(parmBrandId);
            }

            if (good.Unit_id != 0)
            {
                commandText.Append(" AND unit_id=@unit_id ");

                DataParameter parmUnitId = new DataParameter();
                parmUnitId.ParameterName = "@unit_id";
                parmUnitId.DbType = DbType.Int32;
                parmUnitId.Value = good.Unit_id;
                parameters.Add(parmUnitId);
            }

            if (good.Product_id != 0)
            {
                commandText.Append(" AND product_id=@product_id ");

                DataParameter parmProductId = new DataParameter();
                parmProductId.ParameterName = "@product_id";
                parmProductId.DbType = DbType.Int32;
                parmProductId.Value = good.Product_id;
                parameters.Add(parmProductId);
            }

            if (!String.IsNullOrEmpty(good.Good_code))
            {
                commandText.Append(" AND good_code like @good_code ");

                DataParameter parmCode = new DataParameter();
                parmCode.ParameterName = "@good_code";
                parmCode.DbType = DbType.String;
                parmCode.Value = good.Good_code;
                parameters.Add(parmCode);
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
