using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

    /// <summary>
    /// ��������Ϣʵ����
    /// </summary>
   public class Company
    {
        private int company_id;

        private int company_num;

        private string company_nation;

        private string company_pro;

        private string company_city;

        private string company_name;

        private string company_address;

        private string company_postcode;

        private string company_cell;

        private string company_phone;

        private string company_fax;

        private string company_email;

        private string company_manager;

        /// <summary>
        /// ���û򷵻�����������ID
        /// </summary>
        public int Company_id
        {
            set
            {
                this.company_id = value;
            }
            get 
            {
                return this.company_id;
            }
        }

        /// <summary>
        /// ���û򷵻ؿͻ����
        /// </summary>
        public int Company_num
        {
            set
            {
                this.company_num = value;
            }
            get 
            {
                return this.company_num;
            }
        }

        /// <summary>
        /// ���û򷵻ع�������
        /// </summary>
        public string Company_nation
        {
            set 
            {
                this.company_nation = value;
            }
            get
            {
                return this.company_nation;
            }
        }

        /// <summary>
        /// ���û򷵻������̵�ʡ��
        /// </summary>
        public string Company_pro
        {
            set 
            {
                this.company_pro = value;
            }
            get 
            {
                return this.company_pro;
            }
        }

        /// <summary>
        /// ���û򷵻������̵���
        /// </summary>
        public string Company_city
        {
            set 
            {
                this.company_city = value;
            }
            get
            {
                return this.company_city;
            }
        }

        /// <summary>
        /// ���û򷵻������̵Ĺ�˾����
        /// </summary>
        public string Company_name
        {
            set
            {
                this.company_name = value;
            }
            get
            {
                return this.company_name;
            }
        }

        /// <summary>
        /// ���û򷵻������̵Ĺ�˾��ַ
        /// </summary>
        public string Company_address
        {
            set
            {
                this.company_address = value;
            }
            get
            {
                return this.company_address;
            }
        }

        /// <summary>
        /// ���û򷵻������̵��ʱ�
        /// </summary>
        public string Company_postcode
        {
            set 
            {
                this.company_postcode = value;
            }
            get
            {
                return this.company_postcode;
            }
        }

        /// <summary>
        /// ���û򷵻������̵��ֻ�
        /// </summary>
        public string Company_cell
        {
            set 
            {
                this.company_cell = value;
            }
            get
            {
                return this.company_cell;
            }
        }

        /// <summary>
        /// ���û򷵻������̵Ĺ̶��绰
        /// </summary>
        public string Company_phone
        {
            set
            {
                this.company_phone = value;
            }
            get
            {
                return this.company_phone;
            }
        }

        /// <summary>
        /// ���û򷵻������̵Ĵ����ַ
        /// </summary>
        public string Company_fax
        {
            set
            {
                this.company_fax = value;
            }
            get
            {
                 return this.company_fax;
            }
        }

        /// <summary>
        /// ���û򷵻������̵ĵ����ʼ�
        /// </summary>
        public string Company_email
        {
            set
            {
                this.company_email = value;
            }
            get
            {
                return this.company_email;
            }
        }

        /// <summary>
        /// ���û򷵻������̵�ҵ����
        /// </summary>
        public string Company_manager
        {
            set
            {
                this.company_manager = value;
            }
            get 
            {
                return this.company_manager;
            }
        }
    }
}
