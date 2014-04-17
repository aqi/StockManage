using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

    /// <summary>
    /// ��Ӧ��ʵ����
    /// </summary>
    public class Purchase
    {
        private int purchase_id;

        private int good_id;

        private string good_name;

        private string purchase_price;

        private string purchase_num;

        private string purchase_datetime;

        private int staffinfo_id;

        private int supplier_id;

        private int year_month;


        /// <summary>
        /// ���û򷵻زɹ������
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
        /// ���û򷵻���Ʒ���
        /// </summary>
        public int Good_Id
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
        /// ���û򷵻زɹ�ʱ��
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
        /// ���û򷵻��޸��·�
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
