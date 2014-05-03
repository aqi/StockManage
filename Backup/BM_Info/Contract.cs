using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

    /// <summary>
    /// 合同实体类
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
        /// 设置或返回主键合同ID
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
        /// 设置或返回合同号
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
        /// 设置或返回供应商
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
        /// 设置或返回采购用途
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
        /// 设置或返回发料时间
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
        /// 设置或返回备注
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
        /// 设置或返回状态
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
