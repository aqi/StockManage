using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

    /// <summary>
    /// ��λ��ϸʵ����
    /// </summary>
    public class Warehouse
    {
        private int warehouse_id;

        private int good_id;

        private string warehouse_type;

        private int warehouse_number;

        private DateTime warehouse_time;

        private int order_id;

        private string warehouse_operators;

        /// <summary>
        /// ���û򷵻�������¼ID
        /// </summary>
        public int Warehouse_id
        {
            set
            {
                this.warehouse_id = value;
            }
            get
            {
                return this.warehouse_id;
            }
        }

        /// <summary>
        /// ���û򷵻���ƷID
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
        /// ���û򷵻����
        /// </summary>
        public string Warehouse_type
        {
            set
            {
                this.warehouse_type = value;
            }
            get
            {
                return this.warehouse_type;
            }
        }

        /// <summary>
        /// ���û򷵻�����
        /// </summary>
        public int Warehouse_number
        {
            set
            {
                this.warehouse_number = value;
            }
            get
            {
                return this.warehouse_number;
            }
        }

        /// <summary>
        /// ���û򷵻�ʱ��
        /// </summary>
        public DateTime Warehouse_time
        {
            set
            {
                this.warehouse_time = value;
            }
            get
            {
                return this.warehouse_time;
            }
        }

        /// <summary>
        /// ���û򷵻���������
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
        /// ���û򷵻ز�����
        /// </summary>
        public string Warehouse_operators
        {
            set
            {
                this.warehouse_operators = value;
            }
            get
            {
                return this.warehouse_operators;
            }
        }
    }
}
