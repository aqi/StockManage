using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

   /// <summary>
   /// 品牌实体类
   /// </summary>
   public class Brand
    {
        private int brand_id;

        private string brand_name;

        /// <summary>
        /// 设置或返回主键品牌ID
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
        /// 设置或返回品牌名称
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
