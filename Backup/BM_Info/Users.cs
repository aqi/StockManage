using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

    /// <summary>
    /// �û�ʵ����
    /// </summary>
    public class Users
    {
        private int user_id;

        private int role_id;

        private string user_name;

        private string user_phone;

        private string user_fax;

        private string user_email;

        private DateTime user_datetime;

        private string user_account;

        private string user_pass;

        /// <summary>
        /// ���û򷵻��û�����ID
        /// </summary>
        public int User_id 
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
        /// ���û򷵻ؽ�ɫID
        /// </summary>
        public int Role_id
        {
            set
            {
                this.role_id = value;
            }
            get 
            {
                return this.role_id;
            }
        }

        /// <summary>
        /// ���û򷵻��û�����
        /// </summary>
        public string User_name
        {
            set
            {
                this.user_name = value;
            }
            get
            {
                return this.user_name;
            }
        }

        /// <summary>
        /// ���û򷵻��û��绰
        /// </summary>
        public string User_phone
        {
            set
            {
                this.user_phone = value;
            }
            get
            {
                return this.user_phone;
            }
        }

        /// <summary>
        /// ���û򷵻��û�����
        /// </summary>
        public string User_fax
        {
            set
            {
                this.user_fax = value;
            }
            get
            {
                return this.user_fax;
            }
        }

        /// <summary>
        /// ���û򷵻��û��ʼ�
        /// </summary>
        public string User_email
        {
            set
            {
                this.user_email = value;
            }
            get
            {
                return this.user_email;
            }
        }

        /// <summary>
        /// ���û򷵻��û������¼ʱ��
        /// </summary>
        public DateTime User_datetime
        {
            set
            {
                this.user_datetime = value;
            }
            get
            {
                return this.user_datetime;
            }
        }

        /// <summary>
        /// ���û򷵻ص����ʺ�
        /// </summary>
        public string User_account
        {
            set 
            {
                this.user_account = value;
            }
            get 
            {
                return this.user_account;
            }
        }

        /// <summary>
        /// ���û򷵻ص�������
        /// </summary>
        public string User_pass
        {
            set
            {
                this.user_pass = value;
            }
            get
            {
                return this.user_pass;
            }
        }
    }
}
