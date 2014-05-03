using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

    /// <summary>
    /// ����ʵ����
    /// </summary>
    public class Order
    {
        private int order_id;

        private int buyer_id;

        private int good_id;

        private string good_name;

        private string sale_price;

        private string good_num;

        private string buyer_address;

        private string buyer_postcode;

        private string buyer_liaison;

        private string buyer_cell;

        private string order_price;


        /// <summary>
        /// ���û򷵻���������ID
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
        /// ���û򷵻زɹ���ID
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
        /// ���û򷵻���Ʒ����
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

        public string Buyer_Address
        {
            set
            {
                this.buyer_address = value;
            }
            get
            {
                return this.buyer_address;
            }
        }

        public string Buyer_Postcode
        {
            set
            {
                this.buyer_postcode = value;
            }
            get
            {
                return this.buyer_postcode;
            }
        }

        public string Buyer_Liaison
        {
            set
            {
                this.buyer_liaison = value;
            }
            get
            {
                return this.buyer_liaison;
            }
        }

        
        public string Buyer_Cell
        {
            set
            {
                this.buyer_cell = value;
            }
            get
            {
                return this.buyer_cell;
            }
        }

        
        public string Order_Price
        {
            set
            {
                this.order_price = value;
            }
            get
            {
                return this.order_price;
            }
        }
    }
}
