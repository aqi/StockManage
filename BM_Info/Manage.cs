using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{
    /// <summary>
    /// 管理模块实体类
    /// </summary>
    public class Manage
    {
        private int manage_id;

        private int parent_id;

        private string manage_name;

        /// <summary>
        /// 设置或返回主键管理模块ID
        /// </summary>
        public int Manage_id
        {
            set
            {
                this.manage_id = value;
            }
            get
            {
                return this.manage_id;
            }
        }

        /// <summary>
        /// 设置或返回根子节点
        /// </summary>
        public int Parent_id
        {
            set
            {
                this.parent_id = value;
            }
            get
            {
                return this.parent_id;
            }
        }

        /// <summary>
        /// 设置或返回管理模块名称
        /// </summary>
        public string Manage_name
        {
            set
            {
                this.manage_name = value;
            }
            get
            {
                return this.manage_name;
            }
        }

    }
}
