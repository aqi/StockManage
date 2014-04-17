using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

    /// <summary>
    /// ���۵�ʵ����
    /// </summary>
    public class Stock
    {
        private int stock_id;

        private int good_id;

        private string stock_num;

        private string purchase_price;

        private string purchase_datetime;


        /// <summary>
        /// ���û򷵻ؿ�������
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
        /// ���û򷵻ؿ����Ʒ����
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
    }
}
