using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{
    /// <summary>
    /// Ӧ���ѷ�ʽʵ����
    /// </summary>
    public class Freight
    {
        private int freight_id;

        private string freight_name;

        /// <summary>
        /// ���û򷵻�����Ӧ���ѷ�ʽID
        /// </summary>
        public int Freight_id
        {
            set
            {
                this.freight_id = value;
            }
            get
            {
                return this.freight_id;
            }
        }

        /// <summary>
        /// ���û򷵻�Ӧ���ѷ�ʽ����
        /// </summary>
        public string Freight_name
        {
            set
            {
                this.freight_name = value;
            }
            get
            {
                return this.freight_name;
            }
        }
    }
}
