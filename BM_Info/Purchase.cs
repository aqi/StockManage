using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

    /// <summary>
    /// 供应商实体类
    /// </summary>
    public class Purchase
    {
        private int purchase_id;

        private string good_id;

        private string good_name;

        private string purchase_price;

        private string purchase_num;

        private string purchase_datetime;

        private int staffinfo_id;

        private int supplier_id;

        private int year_month;


        /// <summary>
        /// 设置或返回采购单编号
        /// </summary>
        public int Purchase_Id 
        {
            set 
            {
                this.purchase_id = value;
            }
            get 
            {
                return this.purchase_id;
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
        /// 设置或返回商品名称
        /// </summary>
        public string Good_Name
        {
            set
            {
                this.good_name = value;
            }
            get
            {
                return this.good_name;
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
        /// 设置或返回商品数量
        /// </summary>
        public string Purchase_Num
        {
            set
            {
                this.purchase_num = value;
            }
            get
            {
                return this.purchase_num;
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

        /// <summary>
        /// 设置或返回采购人员
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
        /// 设置或返回供应商编号
        /// </summary>
        public int Supplier_Id
        {
            set 
            {
                this.supplier_id = value;
            }
            get 
            {
                return this.supplier_id;
            }
        }

        /// <summary>
        /// 设置或返回修改月份
        /// </summary>
        public int Year_Month
        {
            set
            {
                this.year_month = value;
            }
            get
            {
                return this.year_month;
            }
        }
    }
}
