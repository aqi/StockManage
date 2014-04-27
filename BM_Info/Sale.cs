using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

    /// <summary>
    /// ���۵�ʵ����
    /// </summary>
    public class Sale
    {
        private int sale_id;

        private string good_id;

        private string good_name;

        private string sale_price;

        private string purchase_price;

        private string sale_num;

        private string sale_datetime;

        private int staffinfo_id;

        private int buyer_id;

        private int year_month;

        /// <summary>
        /// ���û򷵻زɹ������
        /// </summary>
        public int Sale_Id 
        {
            set 
            {
                this.sale_id = value;
            }
            get 
            {
                return this.sale_id;
            }
        }

        /// <summary>
        /// ���û򷵻���Ʒ���
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
        /// ���û򷵻���Ʒ����
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
        /// ���û򷵻���Ʒ�ۼ�
        /// </summary>
        public string Sale_Price
        {
            set
            {
                this.sale_price = value;
            }
            get
            {
                return this.sale_price;
            }
        }


        /// <summary>
        /// ���û򷵻���Ʒ����
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
        /// ���û򷵻���Ʒ����
        /// </summary>
        public string Sale_Num
        {
            set
            {
                this.sale_num = value;
            }
            get
            {
                return this.sale_num;
            }
        }

        /// <summary>
        /// ���û򷵻زɹ�ʱ��
        /// </summary>
        public string Sale_Datetime
        {
            set
            {
                this.sale_datetime = value;
            }
            get
            {
                return this.sale_datetime;
            }
        }

        /// <summary>
        /// ���û򷵻زɹ���Ա
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
        /// ���û򷵻ع�Ӧ�̱��
        /// </summary>
        public int Buyer_Id
        {
            set 
            {
                this.buyer_id = value;
            }
            get 
            {
                return this.buyer_id;
            }
        }

        /// <summary>
        /// ���û򷵻ؼ�¼�·�
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
