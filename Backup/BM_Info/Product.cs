using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

    /// <summary>
    /// ��Ʒ���ʵ����
    /// </summary>
     public class Product
    {
        private int product_id;

        private string product_name;

         /// <summary>
         ///���û򷵻ز�Ʒ���ID
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
         /// ���û򷵻ز�Ʒ�������
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
