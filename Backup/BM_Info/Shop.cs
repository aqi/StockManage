using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{
    /// <summary>
    /// 购物车实体类
    /// </summary>
    public class Shop
    {
        private int shop_id;

        private DateTime shop_jointime;

        private int shop_num;

        private int good_id;

        private int order_id;

        private int contrac_id;

        /// <summary>
        /// 设置或返回购物记录
        /// </summary>
        public int Shop_id
        {
            set
            {
                this.shop_id = value;
            }
            get
            {
                return this.shop_id;
            }
        }

        /// <summary>
        /// 设置或返回加入时间
        /// </summary>
        public DateTime Shop_jointime
        {
            set
            {
                this.shop_jointime = value;
            }
            get
            {
                return this.shop_jointime;
            }
        }

        /// <summary>
        /// 设置或返回商品数量
        /// </summary>
        public int Shop_num
        {
            set
            {
                this.shop_num = value;
            }
            get
            {
                return this.shop_num;
            }
        }

        /// <summary>
        /// 设置或返回商品信息
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
        /// 设置或返回订单信息
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
        /// 设置或返回合同信息
        /// </summary>
        public int Contrac_id
        {
            set
            {
                this.contrac_id = value;
            }
            get
            {
                return this.contrac_id;
            }
        }
    }
}
