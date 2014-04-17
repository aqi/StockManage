using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

    /// <summary>
    /// 产品实体类
    /// </summary>
    public class Good
    {
        private int good_id;

        private string good_color;

        private string good_code;

        private string good_description;

        private string good_img;

        private string good_name;

        private int brand_id;

        private int good_num;

        private decimal good_price;

        private decimal good_selling_price;

        private int unit_id;

        private int product_id;

        /// <summary>
        /// 设置或返回产品主键ID
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
        /// 设置或返回产品颜色
        /// </summary>
        public string Good_color
        {
            set
            {
                this.good_color = value;
            }
            get
            {
                return this.good_color;
            }
        }

        /// <summary>
        /// 设置或返回产品代码
        /// </summary>
        public string Good_code
        {
            set
            {
                this.good_code = value;
            }
            get
            {
                return this.good_code;
            }
        }

        /// <summary>
        /// 设置或返回产品描述
        /// </summary>
        public string Good_description
        {
            set
            {
                this.good_description = value;
            }
            get
            {
                return this.good_description;
            }
        }

        /// <summary>
        /// 设置或返回产品图片
        /// </summary>
        public string Good_img
        {
            set
            {
                this.good_img = value;
            }
            get
            {
                return this.good_img;
            }
        }

        /// <summary>
        /// 设置或返回产品名称
        /// </summary>
        public string Good_name
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
        /// 设置或返回产品品牌ID
        /// </summary>
        public int Brand_id
        {
            set
            {
                this.brand_id = value;
            }
            get
            {
                return this.brand_id;
            }
        }

        /// <summary>
        /// 设置或返回产品编号
        /// </summary>
        public int Good_num
        {
            set
            {
                this.good_num = value;
            }
            get
            {
                return this.good_num;
            }
        }

        /// <summary>
        /// 设置或返回产品买价
        /// </summary>
        public decimal Good_price
        {
            set
            {
                this.good_price = value;
            }
            get
            {
                return this.good_price;
            }
        }

        /// <summary>
        /// 设置或返回产品卖价
        /// </summary>
        public decimal Good_selling_price
        {
            set
            {
                this.good_selling_price = value;
            }
            get
            {
                return this.good_selling_price;
            }
        }

        /// <summary>
        /// 设置或返回产品单位ID
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
        /// 设置或返回产品类别
        /// </summary>
        public int Product_id
        {
            set
            {
                this.product_id = value;
            }
            get
            {
                return this.product_id;
            }
        }
    }
}
