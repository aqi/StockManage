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

        private string order_num;

        private int customers_id;

        private string order_purpose;

        private int freight_id;

        private int send_id;

        private string order_acceptadd;

        private string order_whether_charges;

        private string order_mark;

        private string order_state;

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
        /// ���û򷵻ض�����
        /// </summary>
        public string Order_num
        {
            set
            {
                this.order_num = value;
            }
            get
            {
                return this.order_num;
            }
        }

        /// <summary>
        /// ���û򷵻ؿͻ�ID
        /// </summary>
        public int Customers_id
        {
            set 
            {
                this.customers_id = value;
            }
            get
            {
                return this.customers_id;
            }
        }

        /// <summary>
        /// ���û򷵻ط�����;
        /// </summary>
        public string Order_purpose
        {
            set
            {
                this.order_purpose = value;
            }
            get
            {
                return this.order_purpose;
            }
        }

        /// <summary>
        /// ���û򷵻��˷Ѹ��㷽ʽID
        /// </summary>
        public int Freight_id
        {
            set
            {
                this.freight_id = value;
            }
            get
            {
                return this.freight_id;
            }
        }

        /// <summary>
        /// ���û򷵻ؼļ���ʽID
        /// </summary>
        public int Send_id
        {
            set
            {
                this.send_id = value;
            }
            get
            {
                return this.send_id;
            }
        }

        /// <summary>
        /// ���û򷵻��ջ���ַ
        /// </summary>
        public string Order_acceptadd
        {
            set
            {
                this.order_acceptadd = value;
            }
            get
            {
                return this.order_acceptadd;
            }
        }

        /// <summary>
        /// ���û򷵻��ϼ��Ƿ�Ҫ�շ�
        /// </summary>
        public string Order_whether_charges
        {
            set
            {
                this.order_whether_charges = value;
            }
            get
            {
                return this.order_whether_charges;
            }
        }

        /// <summary>
        /// ���û򷵻ر�ע
        /// </summary>
        public string Order_mark
        {
            set
            {
                this.order_mark = value;
            }
            get
            {
                return this.order_mark;
            }
        }

        /// <summary>
        /// ���û򷵻�״̬
        /// </summary>
        public string Order_state
        {
            set
            {
                this.order_state = value;
            }
            get
            {
                return this.order_state;
            }
        }
    }
}
