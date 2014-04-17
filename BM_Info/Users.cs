using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

    /// <summary>
    /// 用户实体类
    /// </summary>
    public class Users
    {
        private int user_id;

        private int role_id;

        private string user_name;

        private string user_phone;

        private string user_fax;

        private string user_email;

        private DateTime user_datetime;

        private string user_account;

        private string user_pass;

        private int user_manage;

        private int user_login;

        /// <summary>
        /// 设置或返回用户主键ID
        /// </summary>
        public int User_id 
        {
            set 
            {
                this.user_id = value;
            }
            get 
            {
                return this.user_id;
            }
        }

        /// <summary>
        /// 设置或返回角色ID
        /// </summary>
        public int Role_id
        {
            set
            {
                this.role_id = value;
            }
            get 
            {
                return this.role_id;
            }
        }

        /// <summary>
        /// 设置或返回用户名称
        /// </summary>
        public string User_name
        {
            set
            {
                this.user_name = value;
            }
            get
            {
                return this.user_name;
            }
        }

        /// <summary>
        /// 设置或返回用户电话
        /// </summary>
        public string User_phone
        {
            set
            {
                this.user_phone = value;
            }
            get
            {
                return this.user_phone;
            }
        }

        /// <summary>
        /// 设置或返回用户传真
        /// </summary>
        public string User_fax
        {
            set
            {
                this.user_fax = value;
            }
            get
            {
                return this.user_fax;
            }
        }

        /// <summary>
        /// 设置或返回用户邮件
        /// </summary>
        public string User_email
        {
            set
            {
                this.user_email = value;
            }
            get
            {
                return this.user_email;
            }
        }

        /// <summary>
        /// 设置或返回用户最近登录时间
        /// </summary>
        public DateTime User_datetime
        {
            set
            {
                this.user_datetime = value;
            }
            get
            {
                return this.user_datetime;
            }
        }

        /// <summary>
        /// 设置或返回登入帐号
        /// </summary>
        public string User_account
        {
            set 
            {
                this.user_account = value;
            }
            get 
            {
                return this.user_account;
            }
        }

        /// <summary>
        /// 设置或返回登入密码
        /// </summary>
        public string User_pass
        {
            set
            {
                this.user_pass = value;
            }
            get
            {
                return this.user_pass;
            }
        }

        /// <summary>
        /// 设置或返回用户经理标志
        /// </summary>
        public int User_Manage
        {
            set
            {
                this.user_manage = value;
            }
            get
            {
                return this.user_manage;
            }
        }

        /// <summary>
        /// 设置或返回登录标志，查询忽略user_manage标志
        /// </summary>
        public int User_Login
        {
            set
            {
                this.user_login = value;
            }
            get
            {
                return this.user_login;
            }
        }
    }
}
