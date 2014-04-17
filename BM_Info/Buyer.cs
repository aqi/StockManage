using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

    /// <summary>
    /// ��Ӧ��ʵ����
    /// </summary>
    public class Buyer
    {
        private int buyer_id;

        private int user_id;

        private string buyer_name;

        private string buyer_address;

        private string buyer_postcode;

        private string buyer_cell;

        private string buyer_phone;

        private string buyer_fax;

        private string buyer_email;

        private string buyer_liaison;


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
        /// ���û򷵻ع�Ӧ���û���
        /// </summary>
        public int User_Id
        {
            set
            {
                this.user_id = value;
            }
            get
            {
                return this.user_id;
            }
        }

        /// <summary>
        /// ���û򷵻ع�Ӧ������
        /// </summary>
        public string Buyer_Name
        {
            set
            {
                this.buyer_name = value;
            }
            get 
            {
                return this.buyer_name;
            }
        }

        /// <summary>
        /// ���û򷵻ع�Ӧ�̵�ַ
        /// </summary>
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

        /// <summary>
        /// ���û򷵻��ʱ�
        /// </summary>
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

        /// <summary>
        /// ���û򷵻ع�Ӧ���ֻ�
        /// </summary>
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

        /// <summary>
        /// ���û򷵻ع�Ӧ�̵绰
        /// </summary>
        public string Buyer_Phone
        {
            set
            {
                this.buyer_phone = value;
            }
            get
            {
                return this.buyer_phone;
            }
        }

        /// <summary>
        /// ���û򷵻ع�Ӧ�̴���
        /// </summary>
        public string Buyer_Fax
        {
            set
            {
                this.buyer_fax = value;
            }
            get
            {
                return this.buyer_fax;
            }
        }

        /// <summary>
        /// ���û򷵻ع�Ӧ������
        /// </summary>
        public string Buyer_Email
        {
            set 
            {
                this.buyer_email = value;
            }
            get 
            {
                return this.buyer_email;
            }
        }

        /// <summary>
        /// ���û򷵻ع�Ӧ����ϵ��
        /// </summary>
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
    }
}
