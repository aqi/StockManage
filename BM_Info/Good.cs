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

        private string good_img;

        private string good_name;

        private string good_num;

        private int purchase_priceMin;
        
        private int purchase_priceMax;

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
        /// 设置或返回产品编号
        /// </summary>
        public string Good_Num
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
        /// 设置或返回产品采购价格范围（低）
        /// </summary>
        public int Purchase_PriceMin
        {
            set
            {
                this.purchase_priceMin = value;
            }
            get
            {
                return this.purchase_priceMin;
            }
        }

        /// <summary>
        /// 设置或返回产品采购价格范围（高）
        /// </summary>
        public int Purchase_PriceMax
        {
            set
            {
                this.purchase_priceMax = value;
            }
            get
            {
                return this.purchase_priceMax;
            }
        }
    }
}
