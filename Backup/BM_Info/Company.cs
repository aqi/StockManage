using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

    /// <summary>
    /// 销售商信息实体类
    /// </summary>
   public class Company
    {
        private int company_id;

        private int company_num;

        private string company_nation;

        private string company_pro;

        private string company_city;

        private string company_name;

        private string company_address;

        private string company_postcode;

        private string company_cell;

        private string company_phone;

        private string company_fax;

        private string company_email;

        private string company_manager;

        /// <summary>
        /// 设置或返回销售商主键ID
        /// </summary>
        public int Company_id
        {
            set
            {
                this.company_id = value;
            }
            get 
            {
                return this.company_id;
            }
        }

        /// <summary>
        /// 设置或返回客户编号
        /// </summary>
        public int Company_num
        {
            set
            {
                this.company_num = value;
            }
            get 
            {
                return this.company_num;
            }
        }

        /// <summary>
        /// 设置或返回国家名称
        /// </summary>
        public string Company_nation
        {
            set 
            {
                this.company_nation = value;
            }
            get
            {
                return this.company_nation;
            }
        }

        /// <summary>
        /// 设置或返回销售商的省份
        /// </summary>
        public string Company_pro
        {
            set 
            {
                this.company_pro = value;
            }
            get 
            {
                return this.company_pro;
            }
        }

        /// <summary>
        /// 设置或返回销售商的市
        /// </summary>
        public string Company_city
        {
            set 
            {
                this.company_city = value;
            }
            get
            {
                return this.company_city;
            }
        }

        /// <summary>
        /// 设置或返回销售商的公司名称
        /// </summary>
        public string Company_name
        {
            set
            {
                this.company_name = value;
            }
            get
            {
                return this.company_name;
            }
        }

        /// <summary>
        /// 设置或返回销售商的公司地址
        /// </summary>
        public string Company_address
        {
            set
            {
                this.company_address = value;
            }
            get
            {
                return this.company_address;
            }
        }

        /// <summary>
        /// 设置或返回销售商的邮编
        /// </summary>
        public string Company_postcode
        {
            set 
            {
                this.company_postcode = value;
            }
            get
            {
                return this.company_postcode;
            }
        }

        /// <summary>
        /// 设置或返回销售商的手机
        /// </summary>
        public string Company_cell
        {
            set 
            {
                this.company_cell = value;
            }
            get
            {
                return this.company_cell;
            }
        }

        /// <summary>
        /// 设置或返回销售商的固定电话
        /// </summary>
        public string Company_phone
        {
            set
            {
                this.company_phone = value;
            }
            get
            {
                return this.company_phone;
            }
        }

        /// <summary>
        /// 设置或返回销售商的传真地址
        /// </summary>
        public string Company_fax
        {
            set
            {
                this.company_fax = value;
            }
            get
            {
                 return this.company_fax;
            }
        }

        /// <summary>
        /// 设置或返回销售商的电子邮件
        /// </summary>
        public string Company_email
        {
            set
            {
                this.company_email = value;
            }
            get
            {
                return this.company_email;
            }
        }

        /// <summary>
        /// 设置或返回销售商的业务经理
        /// </summary>
        public string Company_manager
        {
            set
            {
                this.company_manager = value;
            }
            get 
            {
                return this.company_manager;
            }
        }
    }
}
