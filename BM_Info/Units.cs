using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

   /// <summary>
   /// ��λʵ����
   /// </summary>
    public class Units
    {
        private int unit_id;

        private string unit_name;

        /// <summary>
        /// ���û򷵻�������λID
        /// </summary>
        public int Unit_id
        {
            set
            {
                this.unit_id = value;
            }
            get
            {
                return this.unit_id;
            }
        }

        /// <summary>
        /// ���û򷵻ص�λ����
        /// </summary>
        public string Unit_name
        {
            set
            {
                this.unit_name = value;
            }
            get
            {
                return this.unit_name;
            }
        }
    }
}
