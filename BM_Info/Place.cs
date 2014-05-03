using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

    /// <summary>
    /// 库位实体类
    /// </summary>
    public class Place
    {
        private int place_id;

        private string place_num;

        private string place_state;

        /// <summary>
        /// 设置或返回住键库位ID
        /// </summary>
        public int Place_id
        {
            set
            {
                this.place_id = value;
            }
            get
            {
                return this.place_id;
            }
        }

        /// <summary>
        /// 设置或返回库位编号
        /// </summary>
        public string Place_num
        {
            set
            {
                this.place_num = value;
            }
            get
            {
                return this.place_num;
            }
        }

        /// <summary>
        /// 设置或返回状态
        /// </summary>
        public string Place_state
        {
            set
            {
                this.place_state = value;
            }
            get
            {
                return this.place_state;
            }
        }
    }
}
