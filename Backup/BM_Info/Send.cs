using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{
    
    /// <summary>
    /// 寄件方式实体类
    /// </summary>
    public class Send
    {
        private int send_id;

        private string send_name;

        /// <summary>
        /// 设置或返回寄件方式ID
        /// </summary>
        public int Send_id
        {
            set
            {
                this.send_id = value;
            }
            get
            {
                return this.send_id;
            }
        }

        /// <summary>
        /// 设置或返回寄件方式名称
        /// </summary>
        public string Send_name
        {
            set
            {
                this.send_name = value;
            }
            get
            {
                return this.send_name;
            }
        }
    }
}
