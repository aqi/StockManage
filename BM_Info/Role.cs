using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{


    /// <summary>
    /// ��ɫʵ����
    /// </summary>
    public class Role
    {
        private int role_id;

        private string role_name;

        private string role_exp;


        /// <summary>
        /// ���û򷵻ؽ�ɫ����ID
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
        /// ���û򷵻ؽ�ɫ����
        /// </summary>
        public string Role_name
        {
            set
            {
                this.role_name = value;
            }
            get
            {
                return this.role_name;
            }
        }

        /// <summary>
        /// ���û򷵻ؽ�ɫ��ע
        /// </summary>
        public string Role_exp
        {
            set
            {
                this.role_exp = value;
            }
            get
            {
                return this.role_exp;
            }
        }
    }
}
