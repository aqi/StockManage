using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{


    /// <summary>
    /// 角色实体类
    /// </summary>
    public class Role
    {
        private int role_id;

        private string role_name;

        private string role_exp;


        /// <summary>
        /// 设置或返回角色主键ID
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
        /// 设置或返回角色名称
        /// </summary>
        public string Role_name
        {
            set
            {
                this.role_name = value;
            }
            get
            {
                return this.role_name;
            }
        }

        /// <summary>
        /// 设置或返回角色备注
        /// </summary>
        public string Role_exp
        {
            set
            {
                this.role_exp = value;
            }
            get
            {
                return this.role_exp;
            }
        }
    }
}
