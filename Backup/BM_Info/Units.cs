using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

   /// <summary>
   /// 单位实体类
   /// </summary>
    public class Units
    {
        private int unit_id;

        private string unit_name;

        /// <summary>
        /// 设置或返回主键单位ID
        /// </summary>
        public int Unit_id
        {
            set
            {
                this.unit_id = value;
            }
            get
            {
                return this.unit_id;
            }
        }

        /// <summary>
        /// 设置或返回单位名称
        /// </summary>
        public string Unit_name
        {
            set
            {
                this.unit_name = value;
            }
            get
            {
                return this.unit_name;
            }
        }
    }
}
