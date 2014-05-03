using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

    /// <summary>
    /// 产品类别实体类
    /// </summary>
     public class Product
    {
        private int product_id;

        private string product_name;

         /// <summary>
         ///设置或返回产品类别ID
         /// </summary>
         public int Product_id
         {
             set
             {
                 this.product_id = value;
             }
             get
             {
                 return this.product_id;
             }
         }

         /// <summary>
         /// 设置或返回产品类别名称
         /// </summary>
         public string Product_name
         {
             set
             {
                 this.product_name = value;
             }
             get
             {
                 return this.product_name;
             }
         }
    }
}
