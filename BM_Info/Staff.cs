using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

    /// <summary>
    /// 员工信息实体类
    /// </summary>
    public class Staff
    {
        private int staffinfo_id;

        private int user_id;

        private int role_id;

        private int role_manage;

        private string staffinfo_position;

        private string staffinfo_name;

        private string staffinfo_cell;

        private string staffinfo_sex;

        /// <summary>
        /// 设置或返回员工主键ID
        /// </summary>
        public int Staffinfo_id
        {
            set
            {
                this.staffinfo_id = value;
            }
            get 
            {
                return this.staffinfo_id;           
            }
        }

        /// <summary>
        /// 设置或返回员工用户ID
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
        /// 设置或返回员工部门ID
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
        /// 设置或返回部分经理标志
        /// </summary>
        public int Role_Manage
        {
            set
            {
                this.role_manage = value;
            }
            get
            {
                return this.role_manage;
            }

        }
        /// <summary>
        /// 设置或返回所在公司职位
        /// </summary>
        public string Staffinfo_position
        {
            set 
            {
                this.staffinfo_position = value;            
            }
            get {
                return this.staffinfo_position;
            }
        }

        /// <summary>
        /// 设置或返回员工姓名
        /// </summary>
        public string Staffinfo_Name
        {
            set
            {
                this.staffinfo_name = value;
            }
            get
            {
                return this.staffinfo_name;
            }
        }


        /// <summary>
        /// 设置或返回员工手机号
        /// </summary>
        public string Staffinfo_cell
        {
            set
            {
                this.staffinfo_cell = value;
            }
            get
            {
                return this.staffinfo_cell;
            }
        }

        /// <summary>
        /// 设置或返回员工性别
        /// </summary>
        public string Staffinfo_sex
        {
            set 
            {
                this.staffinfo_sex = value;
            }
            get
            {
                return this.staffinfo_sex;
            }
        }
    }
}
