using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

   /// <summary>
   /// Ʒ��ʵ����
   /// </summary>
   public class Brand
    {
        private int brand_id;

        private string brand_name;

        /// <summary>
        /// ���û򷵻�����Ʒ��ID
        /// </summary>
        public int Brand_id
        {
            set
            {
                this.brand_id = value;
            }
            get
            {
                return this.brand_id;
            }
        }

        /// <summary>
        /// ���û򷵻�Ʒ������
        /// </summary>
        public string Brand_name
        {
            set
            {
                this.brand_name = value;
            }
            get
            {
                return this.brand_name;
            }
        }
    }
}
