using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{
    /// <summary>
    /// 客户信息实体类
    /// </summary>
    public class Customers
    {
        private int customers_id;

        private string customers_code;

        private string customers_region;

        private string customers_name;

        private string customers_type;

        private string customers_address;

        private string customers_phone;

        private string customers_telephone;

        private string customers_fax;

        private string customers_network_address;

        private string customers_person_one;

        private string customers_person_one_cell;

        private string customers_person_one_email;

        private string customers_person_two;

        private string customers_person_two_cell;

        private string customers_person_two_email;

        /// <summary>
        /// 设置或返回客户主键ID
        /// </summary>
        public int Customers_id
        {
            set
            {
                this.customers_id = value;
            }
            get
            {
                return this.customers_id;
            }
        }

        /// <summary>
        /// 设置或返回客户代码
        /// </summary>
        public string Customers_code
        {
            set
            {
                this.customers_code = value;
            }
            get
            {
                return this.customers_code;
            }
        }

        /// <summary>
        /// 设置或返回国家区域
        /// </summary>
        public string Customers_region
        {
            set
            {
                this.customers_region = value;
            }
            get
            {
                return this.customers_region;
            }
        }

        /// <summary>
        /// 设置或返回客户公司名
        /// </summary>
        public string Customers_name
        {
            set
            {
                this.customers_name = value;
            }
            get
            {
                return this.customers_name;
            }
        }

        /// <summary>
        /// 设置或返回主要产品类型
        /// </summary>
        public string Customers_type
        {
            set
            {
                this.customers_type = value;
            }
            get
            {
                return this.customers_type;
            }
        }

        /// <summary>
        /// 设置或返回客户公司地址
        /// </summary>
        public string Customers_address
        {
            set
            {
                this.customers_address = value;
            }
            get
            {
                return this.customers_address;
            }
        }

        /// <summary>
        /// 设置或返回客户电话
        /// </summary>
        public string Customers_phone
        {
            set
            {
                this.customers_phone = value;
            }
            get
            {
                return this.customers_phone;
            }
        }

        /// <summary>
        /// 设置或返回客户固定电话
        /// </summary>
        public string Customers_telephone
        {
            set
            {
                this.customers_telephone = value;
            }
            get
            {
                return this.customers_telephone;
            }
        }

        /// <summary>
        /// 设置或返回客户传真
        /// </summary>
        public string Customers_fax
        {
            set
            {
                this.customers_fax = value;
            }
            get
            {
                return this.customers_fax;
            }
        }

        /// <summary>
        /// 设置或返回客户网址
        /// </summary>
        public string Customers_network_address
        {
            set
            {
                this.customers_network_address = value;
            }
            get
            {
                return this.customers_network_address;
            }
        }

        /// <summary>
        /// 设置或返回客户联系人1
        /// </summary>
        public string Customers_person_one
        {
            set
            {
                this.customers_person_one = value;
            }
            get
            {
                return this.customers_person_one;
            }
        }

        /// <summary>
        /// 设置或返回客户联系人1手机
        /// </summary>
        public string Customers_person_one_cell
        {
            set
            {
                this.customers_person_one_cell = value;
            }
            get
            {
                return this.customers_person_one_cell;
            }
        }

        /// <summary>
        /// 设置或返回客户联系人1邮箱
        /// </summary>
        public string Customers_person_one_email
        {
            set
            {
                this.customers_person_one_email = value;
            }
            get
            {
                return this.customers_person_one_email;
            }
        }

        /// <summary>
        /// 设置或返回客户联系人2
        /// </summary>
        public string Customers_person_two
        {
            set
            {
                this.customers_person_two = value;
            }
            get
            {
                return this.customers_person_two;
            }
        }

        /// <summary>
        /// 设置或返回客户联系人2手机
        /// </summary>
        public string Customers_person_two_cell
        {
            set
            {
                this.customers_person_two_cell = value;
            }
            get
            {
                return this.customers_person_two_cell;
            }
        }

        /// <summary>
        /// 设置或返回客户联系人2邮箱
        /// </summary>
        public string Customers_person_two_email
        {
            set
            {
                this.customers_person_two_email = value;
            }
            get
            {
                return this.customers_person_two_email;
            }
        }
    }
}
