using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

    /// <summary>
    /// ��Ʒʵ����
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
        /// ���û򷵻ز�Ʒ����ID
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
        /// ���û򷵻ز�ƷͼƬ
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
        /// ���û򷵻ز�Ʒ����
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
        /// ���û򷵻ز�Ʒ���
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
        /// ���û򷵻ز�Ʒ�ɹ��۸�Χ���ͣ�
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
        /// ���û򷵻ز�Ʒ�ɹ��۸�Χ���ߣ�
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
