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
        /// ���û򷵻ز�Ʒ��ɫ
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
        /// ���û򷵻ز�Ʒ����
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
        /// ���û򷵻ز�Ʒ����
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
        /// ���û򷵻ز�ƷƷ��ID
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
        /// ���û򷵻ز�Ʒ���
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
        /// ���û򷵻ز�Ʒ���
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
        /// ���û򷵻ز�Ʒ����
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
        /// ���û򷵻ز�Ʒ��λID
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
        /// ���û򷵻ز�Ʒ���
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
