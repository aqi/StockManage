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
    /// CustomersProvider类表示客户信息模块操作的管理者
    /// </summary>
    public class CustomersProvider : ActionBase
    {
        #region --- Insert方法 ---

        /// <summary>
        /// 添加一条新的客户信息
        /// </summary>
        /// <param unit="customer">新的客户信息</param>
        /// <returns>添加成功返回true,否则返回false</returns>
        public bool Insert(Customers customer)
        {
            if (String.IsNullOrEmpty(customer.Customers_name))
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_customers VALUES(@customers_code,@customers_region,@customers_name,@customers_type,@customers_address,@customers_phone,@customers_telephone,@customers_fax,@customers_network_address,@customers_person_one,@customers_person_one_cell,@customers_person_one_email,@customers_person_two,@customers_person_two_cell,@customers_person_two_email)";

                DataParameter parmCode = new DataParameter();
                parmCode.ParameterName = "@customers_code";
                parmCode.DbType = DbType.String;
                parmCode.Value = customer.Customers_code;

                DataParameter parmRegion = new DataParameter();
                parmRegion.ParameterName = "@customers_region";
                parmRegion.DbType = DbType.String;
                parmRegion.Value = customer.Customers_region;

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@customers_name";
                parmName.DbType = DbType.String;
                parmName.Value = customer.Customers_name;

                DataParameter parmType = new DataParameter();
                parmType.ParameterName = "@customers_type";
                parmType.DbType = DbType.String;
                parmType.Value = customer.Customers_type;

                DataParameter parmAddress = new DataParameter();
                parmAddress.ParameterName = "@customers_address";
                parmAddress.DbType = DbType.String;
                parmAddress.Value = customer.Customers_address;

                DataParameter parmPhone = new DataParameter();
                parmPhone.ParameterName = "@customers_phone";
                parmPhone.DbType = DbType.String;
                parmPhone.Value = customer.Customers_phone;

                DataParameter parmTelephone = new DataParameter();
                parmTelephone.ParameterName = "@customers_telephone";
                parmTelephone.DbType = DbType.String;
                parmTelephone.Value = customer.Customers_telephone;

                DataParameter parmFax = new DataParameter();
                parmFax.ParameterName = "@customers_fax";
                parmFax.DbType = DbType.String;
                parmFax.Value = customer.Customers_fax;

                DataParameter parmNetWork = new DataParameter();
                parmNetWork.ParameterName = "@customers_network_address";
                parmNetWork.DbType = DbType.String;
                parmNetWork.Value = customer.Customers_network_address;

                DataParameter parmOne = new DataParameter();
                parmOne.ParameterName = "@customers_person_one";
                parmOne.DbType = DbType.String;
                parmOne.Value = customer.Customers_person_one;

                DataParameter parmOneCell = new DataParameter();
                parmOneCell.ParameterName = "@customers_person_one_cell";
                parmOneCell.DbType = DbType.String;
                parmOneCell.Value = customer.Customers_person_one_cell;

                DataParameter parmOneEmail = new DataParameter();
                parmOneEmail.ParameterName = "@customers_person_one_email";
                parmOneEmail.DbType = DbType.String;
                parmOneEmail.Value = customer.Customers_person_one_email;

                DataParameter parmTwo = new DataParameter();
                parmTwo.ParameterName = "@customers_person_two";
                parmTwo.DbType = DbType.String;
                parmTwo.Value = customer.Customers_person_two;

                DataParameter parmTwoCell = new DataParameter();
                parmTwoCell.ParameterName = "@customers_person_two_cell";
                parmTwoCell.DbType = DbType.String;
                parmTwoCell.Value = customer.Customers_person_two_cell;

                DataParameter parmTwoEmail = new DataParameter();
                parmTwoEmail.ParameterName = "@customers_person_two_email";
                parmTwoEmail.DbType = DbType.String;
                parmTwoEmail.Value = customer.Customers_person_two_email;

                IList parameters = new ArrayList();
                parameters.Add(parmCode);
                parameters.Add(parmRegion);
                parameters.Add(parmName);
                parameters.Add(parmType);
                parameters.Add(parmAddress);
                parameters.Add(parmPhone);
                parameters.Add(parmTelephone);
                parameters.Add(parmFax);
                parameters.Add(parmNetWork);
                parameters.Add(parmOne);
                parameters.Add(parmOneCell);
                parameters.Add(parmOneEmail);
                parameters.Add(parmTwo);
                parameters.Add(parmTwoCell);
                parameters.Add(parmTwoEmail);

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
        /// 修改客户信息的内容
        /// </summary>
        /// <param name="customer">新的客户信息</param>
        /// <returns>修改成功返回true,否则返回false</returns>
        public bool Update(Customers customer)
        {
            if (customer.Customers_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_customers " +
                                  " SET customers_code=@customers_code,customers_region=@customers_region,customers_name=@customers_name,customers_type=@customers_type,customers_address=@customers_address,customers_phone=@customers_phone,customers_telephone=@customers_telephone,customers_fax=@customers_fax,customers_network_address=@customers_network_address,customers_person_one=@customers_person_one,customers_person_one_cell=@customers_person_one_cell,customers_person_one_email=@customers_person_one_email,customers_person_two=@customers_person_two,customers_person_two_cell=@customers_person_two_cell,customers_person_two_email=@customers_person_two_email " +
                                     " WHERE customers_id=@customers_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@customers_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = customer.Customers_id;

            DataParameter parmCode = new DataParameter();
            parmCode.ParameterName = "@customers_code";
            parmCode.DbType = DbType.String;
            parmCode.Value = customer.Customers_code;

            DataParameter parmRegion = new DataParameter();
            parmRegion.ParameterName = "@customers_region";
            parmRegion.DbType = DbType.String;
            parmRegion.Value = customer.Customers_region;

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@customers_name";
            parmName.DbType = DbType.String;
            parmName.Value = customer.Customers_name;

            DataParameter parmType = new DataParameter();
            parmType.ParameterName = "@customers_type";
            parmType.DbType = DbType.String;
            parmType.Value = customer.Customers_type;

            DataParameter parmAddress = new DataParameter();
            parmAddress.ParameterName = "@customers_address";
            parmAddress.DbType = DbType.String;
            parmAddress.Value = customer.Customers_address;

            DataParameter parmPhone = new DataParameter();
            parmPhone.ParameterName = "@customers_phone";
            parmPhone.DbType = DbType.String;
            parmPhone.Value = customer.Customers_phone;

            DataParameter parmTelephone = new DataParameter();
            parmTelephone.ParameterName = "@customers_telephone";
            parmTelephone.DbType = DbType.String;
            parmTelephone.Value = customer.Customers_telephone;

            DataParameter parmFax = new DataParameter();
            parmFax.ParameterName = "@customers_fax";
            parmFax.DbType = DbType.String;
            parmFax.Value = customer.Customers_fax;

            DataParameter parmNetWork = new DataParameter();
            parmNetWork.ParameterName = "@customers_network_address";
            parmNetWork.DbType = DbType.String;
            parmNetWork.Value = customer.Customers_network_address;

            DataParameter parmOne = new DataParameter();
            parmOne.ParameterName = "@customers_person_one";
            parmOne.DbType = DbType.String;
            parmOne.Value = customer.Customers_person_one;

            DataParameter parmOneCell = new DataParameter();
            parmOneCell.ParameterName = "@customers_person_one_cell";
            parmOneCell.DbType = DbType.String;
            parmOneCell.Value = customer.Customers_person_one_cell;

            DataParameter parmOneEmail = new DataParameter();
            parmOneEmail.ParameterName = "@customers_person_one_email";
            parmOneEmail.DbType = DbType.String;
            parmOneEmail.Value = customer.Customers_person_one_email;

            DataParameter parmTwo = new DataParameter();
            parmTwo.ParameterName = "@customers_person_two";
            parmTwo.DbType = DbType.String;
            parmTwo.Value = customer.Customers_person_two;

            DataParameter parmTwoCell = new DataParameter();
            parmTwoCell.ParameterName = "@customers_person_two_cell";
            parmTwoCell.DbType = DbType.String;
            parmTwoCell.Value = customer.Customers_person_two_cell;

            DataParameter parmTwoEmail = new DataParameter();
            parmTwoEmail.ParameterName = "@customers_person_two_email";
            parmTwoEmail.DbType = DbType.String;
            parmTwoEmail.Value = customer.Customers_person_two_email;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmCode);
            parameters.Add(parmRegion);
            parameters.Add(parmName);
            parameters.Add(parmType);
            parameters.Add(parmAddress);
            parameters.Add(parmPhone);
            parameters.Add(parmTelephone);
            parameters.Add(parmFax);
            parameters.Add(parmNetWork);
            parameters.Add(parmOne);
            parameters.Add(parmOneCell);
            parameters.Add(parmOneEmail);
            parameters.Add(parmTwo);
            parameters.Add(parmTwoCell);
            parameters.Add(parmTwoEmail);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion

        #region --- Select方法 ---

        /// <summary>
        /// 根据指定的过滤条件查询客户信息
        /// </summary>
        /// <param name="customer">过滤条件</param>
        /// <returns></returns>
        public DataTable Select(Customers customer)
        {
            return this.Select(customer, 0, 0);
        }

        /// <summary>
        /// 利用分页机制,根据指定的过滤条件查询客户信息
        /// </summary>
        /// <param name="customer">过滤条件</param>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable Select(Customers customer, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT * FROM t_customers WHERE 1=1 ");
            IList parameters = new ArrayList();

            if (customer.Customers_id != 0)
            {
                commandText.Append(" AND customers_id=@customers_id ");
                DataParameter parmID = new DataParameter();
                parmID.ParameterName = "@customers_id";
                parmID.DbType = DbType.Int32;
                parmID.Value = customer.Customers_id;
                parameters.Add(parmID);

            }

            if (!String.IsNullOrEmpty(customer.Customers_code))
            {
                commandText.Append(" AND customers_code=@customers_code ");

                DataParameter parmCode = new DataParameter();
                parmCode.ParameterName = "@customers_code";
                parmCode.DbType = DbType.String;
                parmCode.Value = customer.Customers_code;
                parameters.Add(parmCode);
            }

            if (!String.IsNullOrEmpty(customer.Customers_region))
            {
                commandText.Append(" AND customers_region=@customers_region ");

                DataParameter parmRegion = new DataParameter();
                parmRegion.ParameterName = "@customers_region";
                parmRegion.DbType = DbType.String;
                parmRegion.Value = customer.Customers_region;
                parameters.Add(parmRegion);
            }

            if (!String.IsNullOrEmpty(customer.Customers_name))
            {
                commandText.Append(" AND customers_name like @customers_name ");

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@customers_name";
                parmName.DbType = DbType.String;
                parmName.Value = customer.Customers_name;
                parameters.Add(parmName);
            }

            if (!String.IsNullOrEmpty(customer.Customers_type))
            {
                commandText.Append(" AND customers_type=@customers_type ");

                DataParameter parmType = new DataParameter();
                parmType.ParameterName = "@customers_type";
                parmType.DbType = DbType.String;
                parmType.Value = customer.Customers_type;
                parameters.Add(parmType);
            }

            if (!String.IsNullOrEmpty(customer.Customers_address))
            {
                commandText.Append(" AND customers_address=@customers_address ");

                DataParameter parmAddress = new DataParameter();
                parmAddress.ParameterName = "@customers_address";
                parmAddress.DbType = DbType.String;
                parmAddress.Value = customer.Customers_address;
                parameters.Add(parmAddress);
            }

            if (!String.IsNullOrEmpty(customer.Customers_phone))
            {
                commandText.Append(" AND customers_phone=@customers_phone ");

                DataParameter parmPhone = new DataParameter();
                parmPhone.ParameterName = "@customers_phone";
                parmPhone.DbType = DbType.String;
                parmPhone.Value = customer.Customers_phone;
                parameters.Add(parmPhone);
            }

            if (!String.IsNullOrEmpty(customer.Customers_telephone))
            {
                commandText.Append(" AND customers_telephone=@customers_telephone ");

                DataParameter parmTelephone = new DataParameter();
                parmTelephone.ParameterName = "@customers_telephone";
                parmTelephone.DbType = DbType.String;
                parmTelephone.Value = customer.Customers_telephone;
                parameters.Add(parmTelephone);
            }

            if (!String.IsNullOrEmpty(customer.Customers_fax))
            {
                commandText.Append(" AND customers_fax=@customers_fax ");

                DataParameter parmFax = new DataParameter();
                parmFax.ParameterName = "@customers_fax";
                parmFax.DbType = DbType.String;
                parmFax.Value = customer.Customers_fax;
                parameters.Add(parmFax);
            }

            if (!String.IsNullOrEmpty(customer.Customers_network_address))
            {
                commandText.Append(" AND customers_network_address=@customers_network_address ");

                DataParameter parmNetWork = new DataParameter();
                parmNetWork.ParameterName = "@customers_network_address";
                parmNetWork.DbType = DbType.String;
                parmNetWork.Value = customer.Customers_network_address;
                parameters.Add(parmNetWork);
            }

            if (!String.IsNullOrEmpty(customer.Customers_person_one))
            {
                commandText.Append(" AND customers_person_one=@customers_person_one ");

                DataParameter parmOne = new DataParameter();
                parmOne.ParameterName = "@customers_person_one";
                parmOne.DbType = DbType.String;
                parmOne.Value = customer.Customers_person_one;
                parameters.Add(parmOne);
            }

            if (!String.IsNullOrEmpty(customer.Customers_person_one_cell))
            {
                commandText.Append(" AND customers_person_one_cell=@customers_person_one_cell ");

                DataParameter parmOneCell = new DataParameter();
                parmOneCell.ParameterName = "@customers_person_one_cell";
                parmOneCell.DbType = DbType.String;
                parmOneCell.Value = customer.Customers_person_one_cell;
                parameters.Add(parmOneCell);
            }

            if (!String.IsNullOrEmpty(customer.Customers_person_one_email))
            {
                commandText.Append(" AND customers_person_one_email=@customers_person_one_email ");

                DataParameter parmOneEmail = new DataParameter();
                parmOneEmail.ParameterName = "@customers_person_one_email";
                parmOneEmail.DbType = DbType.String;
                parmOneEmail.Value = customer.Customers_person_one_email;
                parameters.Add(parmOneEmail);
            }

            if (!String.IsNullOrEmpty(customer.Customers_person_two))
            {
                commandText.Append(" AND customers_person_two=@customers_person_two ");

                DataParameter parmTwo = new DataParameter();
                parmTwo.ParameterName = "@customers_person_two";
                parmTwo.DbType = DbType.String;
                parmTwo.Value = customer.Customers_person_two;
                parameters.Add(parmTwo);
            }

            if (!String.IsNullOrEmpty(customer.Customers_person_two_cell))
            {
                commandText.Append(" AND customers_person_two_cell=@customers_person_two_cell ");

                DataParameter parmTwoCell = new DataParameter();
                parmTwoCell.ParameterName = "@customers_person_two_cell";
                parmTwoCell.DbType = DbType.String;
                parmTwoCell.Value = customer.Customers_person_two_cell;
                parameters.Add(parmTwoCell);
            }

            if (!String.IsNullOrEmpty(customer.Customers_person_two_email))
            {
                commandText.Append(" AND customers_person_two_email=@customers_person_two_email ");

                DataParameter parmTwoEmail = new DataParameter();
                parmTwoEmail.ParameterName = "@customers_person_two_email";
                parmTwoEmail.DbType = DbType.String;
                parmTwoEmail.Value = customer.Customers_person_two_email;
                parameters.Add(parmTwoEmail);
            }


            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        #endregion

        #region --- GetAll方法 ---

        /// <summary>
        /// 获取所有的客户信息记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_customers";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// 利用分页机制获取所有的客户信息记录
        /// </summary>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT * FROM t_customers";
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
            string commandText = "SELECT Count(customers_id) FROM t_customers";
            DataTable table = this.handler.Query(commandText);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        /// <summary>
        /// 获取客户信息名称总行数
        /// </summary>
        /// <param name="customer">产品类别</param>
        /// <returns></returns>
        public int GetSize(Customers customer)
        {
            string commandText = "SELECT Count(customers_id) FROM t_customers WHERE customers_name like @customers_name";

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@customers_name";
            parmName.DbType = DbType.String;
            parmName.Value = customer.Customers_name;
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
        /// 删除指定的客户信息
        /// </summary>
        /// <param name="unit">将要被删除的客户信息</param>
        /// <returns>删除成功返回true,否则返回false</returns>
        public bool Delete(Customers customer)
        {
            if (customer.Customers_id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_customers WHERE customers_id=@customers_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@customers_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = customer.Customers_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion         
    }
}
