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

        private string staffinfo_position;

        private string staffinfo_num;

        private string staffinfo_cell;

        private string staffinfo_sex;

        private string staffinfo_exp;

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
        /// ���û򷵻����ڹ�˾ְλ
        /// </summary>
        public string Staffionfo_position
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
        /// ���û򷵻�Ա����
        /// </summary>
        public string Staffinfo_num
        {
            set
            {
                this.staffinfo_num = value;
            }
            get
            {
                return this.staffinfo_num;            
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

        /// <summary>
        /// ���û򷵻�Ա����ע
        /// </summary>
        public string Staffinfo_exp
        {
            set 
            {
                this.staffinfo_exp = value;
            }
            get 
            {
                return this.staffinfo_exp;
            }
        }
    }
}
