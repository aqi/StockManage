using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{
    /// <summary>
    /// ���ﳵʵ����
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
        /// ���û򷵻ع����¼
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
        /// ���û򷵻ؼ���ʱ��
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
        /// ���û򷵻���Ʒ����
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
        /// ���û򷵻���Ʒ��Ϣ
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
        /// ���û򷵻ض�����Ϣ
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
        /// ���û򷵻غ�ͬ��Ϣ
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
