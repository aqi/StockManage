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
    /// CompanyProvider类表示产品类别模块操作的管理者
    /// </summary>
    public class CompanyProvider : ActionBase
    {
        #region --- Insert方法 ---

        /// <summary>
        /// 添加一条新的厂商信息
        /// </summary>
        /// <param unit="company">新的厂商信息</param>
        /// <returns>添加成功返回true,否则返回false</returns>
        public bool Insert(Company company)
        {
            if (String.IsNullOrEmpty(company.Company_name))
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_company VALUES (@company_num,@company_nation,@company_pro,@company_city,@company_name,@company_address,@company_postcode,@company_cell,@company_phone,@company_fax,@company_email,@company_manager)";

                DataParameter parmNum = new DataParameter();
                parmNum.ParameterName = "@company_num";
                parmNum.DbType = DbType.Int32;
                parmNum.Value = company.Company_num;

                DataParameter parmNation = new DataParameter();
                parmNation.ParameterName = "@company_nation";
                parmNation.DbType = DbType.String;
                parmNation.Value = company.Company_nation;

                DataParameter parmPro = new DataParameter();
                parmPro.ParameterName = "@company_pro";
                parmPro.DbType = DbType.String;
                parmPro.Value = company.Company_pro;

                DataParameter parmCity = new DataParameter();
                parmCity.ParameterName = "@company_city";
                parmCity.DbType = DbType.String;
                parmCity.Value = company.Company_city;

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@company_name";
                parmName.DbType = DbType.String;
                parmName.Value = company.Company_name;

                DataParameter parmAddress = new DataParameter();
                parmAddress.ParameterName = "@company_address";
                parmAddress.DbType = DbType.String;
                parmAddress.Value = company.Company_address;

                DataParameter parmPostcode = new DataParameter();
                parmPostcode.ParameterName = "@company_postcode";
                parmPostcode.DbType = DbType.String;
                parmPostcode.Value = company.Company_postcode;

                DataParameter parmCell = new DataParameter();
                parmCell.ParameterName = "@company_cell";
                parmCell.DbType = DbType.String;
                parmCell.Value = company.Company_cell;

                DataParameter parmPhone = new DataParameter();
                parmPhone.ParameterName = "@company_phone";
                parmPhone.DbType = DbType.String;
                parmPhone.Value = company.Company_phone;

                DataParameter parmFax = new DataParameter();
                parmFax.ParameterName = "@company_fax";
                parmFax.DbType = DbType.String;
                parmFax.Value = company.Company_fax;

                DataParameter parmEmail = new DataParameter();
                parmEmail.ParameterName = "@company_email";
                parmEmail.DbType = DbType.String;
                parmEmail.Value = company.Company_email;

                DataParameter parmManager = new DataParameter();
                parmManager.ParameterName = "@company_manager";
                parmManager.DbType = DbType.String;
                parmManager.Value = company.Company_manager;

                IList parameters = new ArrayList();
                parameters.Add(parmNum);
                parameters.Add(parmNation);
                parameters.Add(parmPro);
                parameters.Add(parmCity);
                parameters.Add(parmName);
                parameters.Add(parmAddress);
                parameters.Add(parmPostcode);
                parameters.Add(parmCell);
                parameters.Add(parmPhone);
                parameters.Add(parmFax);
                parameters.Add(parmEmail);
                parameters.Add(parmManager);

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
        /// 修改厂商信息的内容
        /// </summary>
        /// <param name="company">新的厂商信息</param>
        /// <returns>修改成功返回true,否则返回false</returns>
        public bool Update(Company company)
        {
            if (company.Company_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_company " +
                                  " SET company_num=@company_num,company_nation=@company_nation,company_pro=@company_pro,company_city=@company_city,company_name=@company_name,company_address=@company_address,company_postcode=@company_postcode,company_cell=@company_cell,company_phone=@company_phone,company_fax=@company_fax,company_email=@company_email,company_manager=@company_manager " +
                                     " WHERE company_id=@company_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@company_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = company.Company_id;

            DataParameter parmNum = new DataParameter();
            parmNum.ParameterName = "@company_num";
            parmNum.DbType = DbType.Int32;
            parmNum.Value = company.Company_num;

            DataParameter parmNation = new DataParameter();
            parmNation.ParameterName = "@company_nation";
            parmNation.DbType = DbType.String;
            parmNation.Value = company.Company_nation;

            DataParameter parmPro = new DataParameter();
            parmPro.ParameterName = "@company_pro";
            parmPro.DbType = DbType.String;
            parmPro.Value = company.Company_pro;

            DataParameter parmCity = new DataParameter();
            parmCity.ParameterName = "@company_city";
            parmCity.DbType = DbType.String;
            parmCity.Value = company.Company_city;

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@company_name";
            parmName.DbType = DbType.String;
            parmName.Value = company.Company_name;

            DataParameter parmAddress = new DataParameter();
            parmAddress.ParameterName = "@company_address";
            parmAddress.DbType = DbType.String;
            parmAddress.Value = company.Company_address;

            DataParameter parmPostcode = new DataParameter();
            parmPostcode.ParameterName = "@company_postcode";
            parmPostcode.DbType = DbType.String;
            parmPostcode.Value = company.Company_postcode;

            DataParameter parmCell = new DataParameter();
            parmCell.ParameterName = "@company_cell";
            parmCell.DbType = DbType.String;
            parmCell.Value = company.Company_cell;

            DataParameter parmPhone = new DataParameter();
            parmPhone.ParameterName = "@company_phone";
            parmPhone.DbType = DbType.String;
            parmPhone.Value = company.Company_phone;

            DataParameter parmFax = new DataParameter();
            parmFax.ParameterName = "@company_fax";
            parmFax.DbType = DbType.String;
            parmFax.Value = company.Company_fax;

            DataParameter parmEmail = new DataParameter();
            parmEmail.ParameterName = "@company_email";
            parmEmail.DbType = DbType.String;
            parmEmail.Value = company.Company_email;

            DataParameter parmManager = new DataParameter();
            parmManager.ParameterName = "@company_manager";
            parmManager.DbType = DbType.String;
            parmManager.Value = company.Company_manager;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmNum);
            parameters.Add(parmNation);
            parameters.Add(parmPro);
            parameters.Add(parmCity);
            parameters.Add(parmName);
            parameters.Add(parmAddress);
            parameters.Add(parmPostcode);
            parameters.Add(parmCell);
            parameters.Add(parmPhone);
            parameters.Add(parmFax);
            parameters.Add(parmEmail);
            parameters.Add(parmManager);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion

        #region --- Select方法 ---

        /// <summary>
        /// 根据指定的过滤条件查询厂商信息
        /// </summary>
        /// <param name="company">过滤条件</param>
        /// <returns></returns>
        public DataTable Select(Company company)
        {
            return this.Select(company, 0, 0);
        }

        /// <summary>
        /// 利用分页机制,根据指定的过滤条件查询厂商信息
        /// </summary>
        /// <param name="company">过滤条件</param>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable Select(Company company, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT * FROM t_company WHERE 1=1 ");
            IList parameters = new ArrayList();

            if (company.Company_id != 0)
            {
                commandText.Append(" AND company_id=@company_id ");
                DataParameter parmID = new DataParameter();
                parmID.ParameterName = "@company_id";
                parmID.DbType = DbType.Int32;
                parmID.Value = company.Company_id;
                parameters.Add(parmID);

            }

            if (company.Company_num != 0)
            {
                commandText.Append(" AND company_num=@company_num ");
                DataParameter parmNum = new DataParameter();
                parmNum.ParameterName = "@company_num";
                parmNum.DbType = DbType.Int32;
                parmNum.Value = company.Company_num;
                parameters.Add(parmNum);

            }

            if ( false == String.IsNullOrEmpty(company.Company_nation))
            {
                commandText.Append(" AND company_nation=@company_nation ");

                DataParameter parmNation = new DataParameter();
                parmNation.ParameterName = "@company_nation";
                parmNation.DbType = DbType.String;
                parmNation.Value = company.Company_nation;
                parameters.Add(parmNation);
            }

            if ( false == String.IsNullOrEmpty(company.Company_pro))
            {
                commandText.Append(" AND company_pro=@company_pro ");

                DataParameter parmPro = new DataParameter();
                parmPro.ParameterName = "@company_pro";
                parmPro.DbType = DbType.String;
                parmPro.Value = company.Company_pro;
                parameters.Add(parmPro);
            }

            if ( false == String.IsNullOrEmpty(company.Company_city))
            {
                commandText.Append(" AND company_city=@company_city ");

                DataParameter parmCity = new DataParameter();
                parmCity.ParameterName = "@company_city";
                parmCity.DbType = DbType.String;
                parmCity.Value = company.Company_city;
                parameters.Add(parmCity);
            }

            if ( false == String.IsNullOrEmpty(company.Company_name))
            {
                commandText.Append(" AND company_name like @company_name ");

                DataParameter parmName = new DataParameter();
                parmName.ParameterName = "@company_name";
                parmName.DbType = DbType.String;
                parmName.Value = company.Company_name;
                parameters.Add(parmName);
            }

            if ( false == String.IsNullOrEmpty(company.Company_address))
            {
                commandText.Append(" AND company_address=@company_address ");

                DataParameter parmAddress = new DataParameter();
                parmAddress.ParameterName = "@company_address";
                parmAddress.DbType = DbType.String;
                parmAddress.Value = company.Company_address;
                parameters.Add(parmAddress);
            }

            if ( false == String.IsNullOrEmpty(company.Company_postcode))
            {
                commandText.Append(" AND company_postcode=@company_postcode ");

                DataParameter parmPostcode = new DataParameter();
                parmPostcode.ParameterName = "@company_postcode";
                parmPostcode.DbType = DbType.String;
                parmPostcode.Value = company.Company_postcode;
                parameters.Add(parmPostcode);
            }

            if ( false == String.IsNullOrEmpty(company.Company_cell))
            {
                commandText.Append(" AND company_cell=@company_cell ");

                DataParameter parmCell = new DataParameter();
                parmCell.ParameterName = "@company_cell";
                parmCell.DbType = DbType.String;
                parmCell.Value = company.Company_cell;
                parameters.Add(parmCell);
            }

            if ( false == String.IsNullOrEmpty(company.Company_phone))
            {
                commandText.Append(" AND company_phone=@company_phone ");

                DataParameter parmPhone = new DataParameter();
                parmPhone.ParameterName = "@company_phone";
                parmPhone.DbType = DbType.String;
                parmPhone.Value = company.Company_phone;
                parameters.Add(parmPhone);
            }

            if ( false == String.IsNullOrEmpty(company.Company_fax))
            {
                commandText.Append(" AND company_fax=@company_fax ");

                DataParameter parmFax = new DataParameter();
                parmFax.ParameterName = "@company_fax";
                parmFax.DbType = DbType.String;
                parmFax.Value = company.Company_fax;
                parameters.Add(parmFax);
            }

            if ( false == String.IsNullOrEmpty(company.Company_email))
            {
                commandText.Append(" AND company_email=@company_email ");

                DataParameter parmEmail = new DataParameter();
                parmEmail.ParameterName = "@company_email";
                parmEmail.DbType = DbType.String;
                parmEmail.Value = company.Company_email;
                parameters.Add(parmEmail);
            }

            if ( false == String.IsNullOrEmpty(company.Company_manager))
            {
                commandText.Append(" AND company_manager=@company_manager ");

                DataParameter parmManager = new DataParameter();
                parmManager.ParameterName = "@company_manager";
                parmManager.DbType = DbType.String;
                parmManager.Value = company.Company_manager;
                parameters.Add(parmManager);
            }

            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        #endregion

        #region --- GetAll方法 ---

        /// <summary>
        /// 获取所有的厂商信息记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_company";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// 利用分页机制获取所有的厂商信息记录
        /// </summary>
        /// <param name="start">起始行</param>
        /// <param name="max">获取记录行的总数</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT * FROM t_company";
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
            string commandText = "SELECT Count(company_id) FROM t_company";
            DataTable table = this.handler.Query(commandText);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        /// <summary>
        /// 获取厂商信息名称总行数
        /// </summary>
        /// <param name="company">产品类别</param>
        /// <returns></returns>
        public int GetSize(Company company)
        {
            string commandText = "SELECT Count(company_id) FROM t_company WHERE company_name like @company_name";

            DataParameter parmName = new DataParameter();
            parmName.ParameterName = "@company_name";
            parmName.DbType = DbType.String;
            parmName.Value = company.Company_name;

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
        /// 删除指定的厂商信息
        /// </summary>
        /// <param name="company">将要被删除的厂商信息</param>
        /// <returns>删除成功返回true,否则返回false</returns>
        public bool Delete(Company company)
        {
            if (company.Company_id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_company WHERE company_id=@company_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@company_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = company.Company_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 
    }
}
