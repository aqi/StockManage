using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{
    /// <summary>
    /// 应付费方式实体类
    /// </summary>
    public class Freight
    {
        private int freight_id;

        private string freight_name;

        /// <summary>
        /// 设置或返回主键应付费方式ID
        /// </summary>
        public int Freight_id
        {
            set
            {
                this.freight_id = value;
            }
            get
            {
                return this.freight_id;
            }
        }

        /// <summary>
        /// 设置或返回应付费方式名称
        /// </summary>
        public string Freight_name
        {
            set
            {
                this.freight_name = value;
            }
            get
            {
                return this.freight_name;
            }
        }
    }
}
