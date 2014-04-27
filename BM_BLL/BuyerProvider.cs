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
    /// UserProvider表示登录用户信息操作的管理者
    /// </summary>
    public class BuyerProvider : ActionBase
    {
        #region --- Insert方法 ---

        /// <summary>
        /// 添加一条新的用户信息
        /// </summary>
        /// <param unit="buyer">新的用户信息</param>
        /// <returns>添加成功返回true,否则返回false</returns>
        public bool Insert(Buyer buyer)
        {
            if (String.IsNullOrEmpty(buyer.Buyer_Name))
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_buyer VALUES(@buyer_name,@buyer_address,@buyer_postcode,@buyer_cell,@buyer_phone,@buyer_fax,@buyer_email,@buyer_liaison)";

                DataParameter parmBuyerName = new DataParameter();
                parmBuyerName.ParameterName = "@buyer_name";
                parmBuyerName.DbType = DbType.String;
                parmBuyerName.Value = buyer.Buyer_Name;

                DataParameter parmBuyerAddress = new DataParameter();
                parmBuyerAddress.ParameterName = "@buyer_address";
                parmBuyerAddress.DbType = DbType.String;
                parmBuyerAddress.Value = buyer.Buyer_Address;

                DataParameter parmBuyerPostcode = new DataParameter();
                parmBuyerPostcode.ParameterName = "@buyer_postcode";
                parmBuyerPostcode.DbType = DbType.String;
                parmBuyerPostcode.Value = buyer.Buyer_Postcode;

                DataParameter parmBuyerCell = new DataParameter();
                parmBuyerCell.ParameterName = "@buyer_cell";
                parmBuyerCell.DbType = DbType.String;
                parmBuyerCell.Value = buyer.Buyer_Cell;

                DataParameter parmBuyerPhone = new DataParameter();
                parmBuyerPhone.ParameterName = "@buyer_phone";
                parmBuyerPhone.DbType = DbType.String;
                parmBuyerPhone.Value = buyer.Buyer_Phone;

                DataParameter parmBuyerFax = new DataParameter();
                parmBuyerFax.ParameterName = "@buyer_fax";
                parmBuyerFax.DbType = DbType.String;
                parmBuyerFax.Value = buyer.Buyer_Fax;

                DataParameter parmBuyerEmail = new DataParameter();
                parmBuyerEmail.ParameterName = "@buyer_email";
                parmBuyerEmail.DbType = DbType.String;
                parmBuyerEmail.Value = buyer.Buyer_Email;

                DataParameter parmBuyerLiaison = new DataParameter();
                parmBuyerLiaison.ParameterName = "@buyer_liaison";
                parmBuyerLiaison.DbType = DbType.String;
                parmBuyerLiaison.Value = buyer.Buyer_Liaison;

                IList parameters = new ArrayList();
                parameters.Add(parmBuyerName);
                parameters.Add(parmBuyerAddress);
                parameters.Add(parmBuyerPostcode);
                parameters.Add(parmBuyerCell);
                parameters.Add(parmBuyerPhone);
                parameters.Add(parmBuyerFax);
                parameters.Add(parmBuyerEmail);
                parameters.Add(parmBuyerLiaison);

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
        /// 修改用户信息的内容
        /// </summary>
        /// <param name="buyer">新的用户信息</param>
        /// <returns>修改成功返回true,否则返回false</returns>
        public bool Update(Buyer buyer)
        {
            if (buyer.Buyer_Id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_buyer " +
                                  " SET buyer_name=@buyer_name," + 
                                    " buyer_address=@buyer_address, buyer_postcode=@buyer_postcode,"+
                                    " buyer_cell=@buyer_cell, buyer_phone=@buyer_phone," +
                                    " buyer_fax=@buyer_fax, buyer_email=@buyer_email," + 
                                    " buyer_liaison=@buyer_liaison" +
                                     " WHERE buyer_id=@buyer_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@buyer_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = buyer.Buyer_Id;

            DataParameter parmBuyerName = new DataParameter();
            parmBuyerName.ParameterName = "@buyer_name";
            parmBuyerName.DbType = DbType.String;
            parmBuyerName.Value = buyer.Buyer_Name;

            DataParameter parmBuyerAddress = new DataParameter();
            parmBuyerAddress.ParameterName = "@buyer_address";
            parmBuyerAddress.DbType = DbType.String;
            parmBuyerAddress.Value = buyer.Buyer_Address;

            DataParameter parmBuyerPostcode = new DataParameter();
            parmBuyerPostcode.ParameterName = "@buyer_postcode";
            parmBuyerPostcode.DbType = DbType.String;
            parmBuyerPostcode.Value = buyer.Buyer_Postcode;

            DataParameter parmBuyerCell = new DataParameter();
            parmBuyerCell.ParameterName = "@buyer_cell";
            parmBuyerCell.DbType = DbType.String;
            parmBuyerCell.Value = buyer.Buyer_Cell;

            DataParameter parmBuyerPhone = new DataParameter();
            parmBuyerPhone.ParameterName = "@buyer_phone";
            parmBuyerPhone.DbType = DbType.String;
            parmBuyerPhone.Value = buyer.Buyer_Phone;

            DataParameter parmBuyerFax = new DataParameter();
            parmBuyerFax.ParameterName = "@buyer_fax";
            parmBuyerFax.DbType = DbType.String;
            parmBuyerFax.Value = buyer.Buyer_Fax;

            DataParameter parmBuyerEmail = new DataParameter();
            parmBuyerEmail.ParameterName = "@buyer_email";
            parmBuyerEmail.DbType = DbType.String;
            parmBuyerEmail.Value = buyer.Buyer_Email;

            DataParameter parmBuyerLiaison = new DataParameter();
            parmBuyerLiaison.ParameterName = "@buyer_liaison";
            parmBuyerLiaison.DbType = DbType.String;
            parmBuyerLiaison.Value = buyer.Buyer_Liaison;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmBuyerName);
            parameters.Add(parmBuyerAddress);
            parameters.Add(parmBuyerPostcode);
            parameters.Add(parmBuyerCell);
            parameters.Add(parmBuyerPhone);
            parameters.Add(parmBuyerFax);
            parameters.Add(parmBuyerEmail);
            parameters.Add(parmBuyerLiaison);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion

        #region --- Select方法 ---

        /// <summary>
        /// 根据指定的过滤条件查询用户信息
        /// </summary>
        /// <param name="buyer">过滤条件</param>
        /// <returns></returns>
        public DataTable Select(Buyer buyer)
        {
            return this.Select(buyer, 0, 0);
        }

        /// <summary>
        /// 利用分页机制,根据指定的过滤条件查询用户信息
        /// </summary>
        /// <param name="product">过滤条件</param>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable Select(Buyer buyer, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT *,('P' + right('000000' + convert(varchar(8), buyer_id), 7)) buyer_bh FROM t_Buyer buyers WHERE 1 = 1");
            IList parameters = new ArrayList();

            if (buyer.Buyer_Id != 0)
            {
                commandText.Append(" And buyer_id=@buyer_id ");

                DataParameter parmID = new DataParameter();
                parmID.ParameterName = "@buyer_id";
                parmID.DbType = DbType.Int32;
                parmID.Value = buyer.Buyer_Id;
                parameters.Add(parmID);
            }

            if ( false == String.IsNullOrEmpty(buyer.Buyer_Name))
            {
                commandText.Append(" And buyer_name like @buyer_name ");

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@buyer_name";
                parmName.DbType = DbType.String;
                parmName.Value = buyer.Buyer_Name;
                parameters.Add(parmName);
            }

            if ( false == String.IsNullOrEmpty(buyer.Buyer_Phone))
            {
                commandText.Append(" AND buyer_phone=@buyer_phone ");

                DataParameter parmPhone = new DataParameter();
                parmPhone.ParameterName = "@buyer_phone";
                parmPhone.DbType = DbType.String;
                parmPhone.Value = buyer.Buyer_Phone;
                parameters.Add(parmPhone);
            }

            if ( false == String.IsNullOrEmpty(buyer.Buyer_Fax))
            {
                commandText.Append(" AND buyer_fax=@buyer_fax ");

                DataParameter parmFax = new DataParameter();
                parmFax.ParameterName = "@buyer_fax";
                parmFax.DbType = DbType.String;
                parmFax.Value = buyer.Buyer_Fax;
                parameters.Add(parmFax);
            }

            if ( false == String.IsNullOrEmpty(buyer.Buyer_Email))
            {
                commandText.Append(" AND buyer_email=@buyer_email ");

                DataParameter parmEmail = new DataParameter();
                parmEmail.ParameterName = "@buyer_email";
                parmEmail.DbType = DbType.String;
                parmEmail.Value = buyer.Buyer_Email;
                parameters.Add(parmEmail);
            }

            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        #endregion

        #region --- GetAll方法 ---

        /// <summary>
        /// 获取所有的用户信息记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT *,('P' + right('000000' + convert(varchar(8), buyer_id), 7)) buyer_bh FROM t_buyer";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// 利用分页机制获取所有的用户信息记录
        /// </summary>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT *,('P' + right('000000' + convert(varchar(8), buyer_id), 7)) buyer_bh FROM t_buyer ";
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
            string commandText = "SELECT Count(buyer_id) FROM t_buyer";
            DataTable table = this.handler.Query(commandText);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        /// <summary>
        /// 获取用户名称总行数
        /// </summary>
        /// <param name="buyer">用户信息</param>
        /// <returns></returns>
        public int GetSize(Buyer buyer)
        {
            string commandText = "SELECT Count(buyer_id) FROM t_buyer WHERE buyer_name like @buyer_name";

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@buyer_name";
            parmName.DbType = DbType.String;
            parmName.Value = buyer.Buyer_Name;

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
        /// 删除指定的用户信息
        /// </summary>
        /// <param name="user">将要被删除的用户信息</param>
        /// <returns>删除成功返回true,否则返回false</returns>
        public bool Delete(Buyer buyer)
        {
            if (buyer.Buyer_Id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_buyer WHERE buyer_id=@buyer_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@buyer_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = buyer.Buyer_Id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 

        #region --- GetBuyerId方法 ---
/*
        /// <summary>
        /// 获取供应商ID
        /// </summary>
        /// <param name="user">将要被删除的用户id</param>
        /// <returns>返回供应商ID</returns>
        public int GetBuyerId(int userId)
        {
            if (userId == 0)
            {
                return 0;
            }
            string commandText = "select * from t_buyer WHERE user_id=@user_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@user_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = userId;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            DataTable table = this.handler.Query(commandText, parameters);
            if (table != null && table.Rows.Count == 1)
            {
                return Convert.ToInt32(table.Rows[0]["buyer_id"].ToString());
            }
            else
            {
                return 0;
            }
        }
*/
        #endregion 
        
    }
}
