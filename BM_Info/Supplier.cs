using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

    /// <summary>
    /// ��Ӧ��ʵ����
    /// </summary>
    public class Supplier
    {
        private int supplier_id;

        private string supplier_name;

        private string supplier_address;

        private string supplier_postcode;

        private string supplier_cell;

        private string supplier_phone;

        private string supplier_fax;

        private string supplier_email;

        private string supplier_liaison;


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
        /// ���û򷵻ع�Ӧ������
        /// </summary>
        public string Supplier_Name
        {
            set
            {
                this.supplier_name = value;
            }
            get 
            {
                return this.supplier_name;
            }
        }

        /// <summary>
        /// ���û򷵻ع�Ӧ�̵�ַ
        /// </summary>
        public string Supplier_Address
        {
            set
            {
                this.supplier_address = value;
            }
            get
            {
                return this.supplier_address;
            }
        }

        /// <summary>
        /// ���û򷵻��ʱ�
        /// </summary>
        public string Supplier_Postcode
        {
            set
            {
                this.supplier_postcode = value;
            }
            get
            {
                return this.supplier_postcode;
            }
        }

        /// <summary>
        /// ���û򷵻ع�Ӧ���ֻ�
        /// </summary>
        public string Supplier_Cell
        {
            set
            {
                this.supplier_cell = value;
            }
            get
            {
                return this.supplier_cell;
            }
        }

        /// <summary>
        /// ���û򷵻ع�Ӧ�̵绰
        /// </summary>
        public string Supplier_Phone
        {
            set
            {
                this.supplier_phone = value;
            }
            get
            {
                return this.supplier_phone;
            }
        }

        /// <summary>
        /// ���û򷵻ع�Ӧ�̴���
        /// </summary>
        public string Supplier_Fax
        {
            set
            {
                this.supplier_fax = value;
            }
            get
            {
                return this.supplier_fax;
            }
        }

        /// <summary>
        /// ���û򷵻ع�Ӧ������
        /// </summary>
        public string Supplier_Email
        {
            set 
            {
                this.supplier_email = value;
            }
            get 
            {
                return this.supplier_email;
            }
        }

        /// <summary>
        /// ���û򷵻ع�Ӧ����ϵ��
        /// </summary>
        public string Supplier_Liaison
        {
            set
            {
                this.supplier_liaison = value;
            }
            get
            {
                return this.supplier_liaison;
            }
        }
    }
}
