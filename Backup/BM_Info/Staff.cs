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

        private string staffinfo_position;

        private string staffinfo_num;

        private string staffinfo_cell;

        private string staffinfo_sex;

        private string staffinfo_exp;

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
        /// 设置或返回所在公司职位
        /// </summary>
        public string Staffionfo_position
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
        /// 设置或返回员工号
        /// </summary>
        public string Staffinfo_num
        {
            set
            {
                this.staffinfo_num = value;
            }
            get
            {
                return this.staffinfo_num;            
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

        /// <summary>
        /// 设置或返回员工备注
        /// </summary>
        public string Staffinfo_exp
        {
            set 
            {
                this.staffinfo_exp = value;
            }
            get 
            {
                return this.staffinfo_exp;
            }
        }
    }
}
