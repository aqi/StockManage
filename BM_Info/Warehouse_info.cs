using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{
    /// <summary>
    /// 库位明细信息类
    /// </summary>
    public class Warehouse_info
    {
        private int warehouse_info_id;

        private int good_id;

        private int warehouse_id;

        private int warehouse_info_number;

        private int place_id;

        /// <summary>
        /// 设置或返回主键记录ID
        /// </summary>
        public int Warehouse_info_id
        {
            set
            {
                this.warehouse_info_id = value;
            }
            get
            {
                return this.warehouse_info_id;
            }
        }

        /// <summary>
        /// 设置或返回商品ID
        /// </summary>
        public int Good_id
        {
            set
            {
                this.good_id = value;
            }
            get
            {
                return this.good_id;
            }
        }

        /// <summary>
        /// 设置或返回库存明细ID
        /// </summary>
        public int Warehouse_id
        {
            set
            {
                this.warehouse_id = value;
            }
            get
            {
                return this.warehouse_id;
            }
        }

        /// <summary>
        /// 设置或返回数量
        /// </summary>
        public int Warehouse_info_number
        {
            set
            {
                this.warehouse_info_number = value;
            }
            get
            {
                return this.warehouse_info_number;
            }
        }

        /// <summary>
        /// 设置或返回库位
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
    }
}
