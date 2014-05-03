using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

    /// <summary>
    /// Ա����Ϣʵ����
    /// </summary>
    public class Staff
    {
        private int staffinfo_id;

        private int user_id;

        private int role_id;

        private int role_manage;

        private string staffinfo_position;

        private string staffinfo_name;

        private string staffinfo_cell;

        private string staffinfo_sex;

        /// <summary>
        /// ���û򷵻�Ա������ID
        /// </summary>
        public int Staffinfo_id
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
        /// ���û򷵻�Ա���û�ID
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
        /// ���û򷵻�Ա������ID
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
        /// ���û򷵻ز��־����־
        /// </summary>
        public int Role_Manage
        {
            set
            {
                this.role_manage = value;
            }
            get
            {
                return this.role_manage;
            }

        }
        /// <summary>
        /// ���û򷵻����ڹ�˾ְλ
        /// </summary>
        public string Staffinfo_position
        {
            set 
            {
                this.staffinfo_position = value;            
            }
            get {
                return this.staffinfo_position;
            }
        }

        /// <summary>
        /// ���û򷵻�Ա������
        /// </summary>
        public string Staffinfo_Name
        {
            set
            {
                this.staffinfo_name = value;
            }
            get
            {
                return this.staffinfo_name;
            }
        }


        /// <summary>
        /// ���û򷵻�Ա���ֻ���
        /// </summary>
        public string Staffinfo_cell
        {
            set
            {
                this.staffinfo_cell = value;
            }
            get
            {
                return this.staffinfo_cell;
            }
        }

        /// <summary>
        /// ���û򷵻�Ա���Ա�
        /// </summary>
        public string Staffinfo_sex
        {
            set 
            {
                this.staffinfo_sex = value;
            }
            get
            {
                return this.staffinfo_sex;
            }
        }
    }
}
