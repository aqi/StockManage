using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

    /// <summary>
    /// 库位明细实体类
    /// </summary>
    public class Warehouse
    {
        private int warehouse_id;

        private int good_id;

        private string warehouse_type;

        private int warehouse_number;

        private DateTime warehouse_time;

        private int order_id;

        private string warehouse_operators;

        /// <summary>
        /// 设置或返回主键记录ID
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
        /// 设置或返回类别
        /// </summary>
        public string Warehouse_type
        {
            set
            {
                this.warehouse_type = value;
            }
            get
            {
                return this.warehouse_type;
            }
        }

        /// <summary>
        /// 设置或返回数量
        /// </summary>
        public int Warehouse_number
        {
            set
            {
                this.warehouse_number = value;
            }
            get
            {
                return this.warehouse_number;
            }
        }

        /// <summary>
        /// 设置或返回时间
        /// </summary>
        public DateTime Warehouse_time
        {
            set
            {
                this.warehouse_time = value;
            }
            get
            {
                return this.warehouse_time;
            }
        }

        /// <summary>
        /// 设置或返回所属单号
        /// </summary>
        public int Order_id
        {
            set
            {
                this.order_id = value;
            }
            get
            {
                return this.order_id;
            }
        }

        /// <summary>
        /// 设置或返回操作人
        /// </summary>
        public string Warehouse_operators
        {
            set
            {
                this.warehouse_operators = value;
            }
            get
            {
                return this.warehouse_operators;
            }
        }
    }
}
