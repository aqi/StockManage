using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

    /// <summary>
    /// ��ͬʵ����
    /// </summary>
    public class Contract
    {
        private int contrac_id;

        private string contrac_num;

        private int company_id;

        private string contrac_purpose;

        private DateTime contrac_time;

        private string contrac_mark;

        private string contrac_state;

        /// <summary>
        /// ���û򷵻�������ͬID
        /// </summary>
        public int Contrac_id
        {
            set
            {
                this.contrac_id = value;
            }
            get
            {
                return this.contrac_id;
            }
        }

        /// <summary>
        /// ���û򷵻غ�ͬ��
        /// </summary>
        public string Contrac__num
        {
            set
            {
                this.contrac_num = value;
            }
            get
            {
                return this.contrac_num;
            }
        }

        /// <summary>
        /// ���û򷵻ع�Ӧ��
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
        /// ���û򷵻زɹ���;
        /// </summary>
        public string Contrac_purpose
        {
            set
            {
                this.contrac_purpose = value;
            }
            get
            {
                return this.contrac_purpose;
            }
        }

        /// <summary>
        /// ���û򷵻ط���ʱ��
        /// </summary>
        public DateTime Contrac_time
        {
            set
            {
                this.contrac_time = value;
            }
            get
            {
                return this.contrac_time;
            }
        }

        /// <summary>
        /// ���û򷵻ر�ע
        /// </summary>
        public string Contrac_mark
        {
            set
            {
                this.contrac_mark = value;
            }
            get
            {
                return this.contrac_mark;
            }
        }

        /// <summary>
        /// ���û򷵻�״̬
        /// </summary>
        public string Contrac_state
        {
            set
            {
                this.contrac_state = value;
            }
            get
            {
                return this.contrac_state;
            }
        }
    }
}
