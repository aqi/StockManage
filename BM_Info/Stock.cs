using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

    /// <summary>
    /// 销售单实体类
    /// </summary>
    public class Stock
    {
        private int stock_id;

        private string good_id;

        private int stock_oper;

        private int staffinfo_id;

        private string stock_num;

        private string purchase_price;

        private string purchase_datetime;


        /// <summary>
        /// 设置或返回库存货物编号
        /// </summary>
        public int Stock_Id 
        {
            set 
            {
                this.stock_id = value;
            }
            get 
            {
                return this.stock_id;
            }
        }

        /// <summary>
        /// 设置或返回商品编号
        /// </summary>
        public string Good_Id
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
        /// 设置或返回操作类型
        /// </summary>
        public int Stock_Oper
        {
            set
            {
                this.stock_oper = value;
            }
            get
            {
                return this.stock_oper;
            }
        }

        /// <summary>
        /// 设置或返回员工ID
        /// </summary>
        public int Staffinfo_Id
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
        /// 设置或返回库存商品数量
        /// </summary>
        public string Stock_Num
        {
            set
            {
                this.stock_num = value;
            }
            get
            {
                return this.stock_num;
            }
        }

        /// <summary>
        /// 设置或返回商品进价
        /// </summary>
        public string Purchase_Price
        {
            set
            {
                this.purchase_price = value;
            }
            get
            {
                return this.purchase_price;
            }
        }

        /// <summary>
        /// 设置或返回采购时间
        /// </summary>
        public string Purchase_Datetime
        {
            set
            {
                this.purchase_datetime = value;
            }
            get
            {
                return this.purchase_datetime;
            }
        }
    }
}
