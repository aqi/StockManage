using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{
    /// <summary>
    /// ����ģ��ʵ����
    /// </summary>
    public class Manage
    {
        private int manage_id;

        private int parent_id;

        private string manage_name;

        /// <summary>
        /// ���û򷵻���������ģ��ID
        /// </summary>
        public int Manage_id
        {
            set
            {
                this.manage_id = value;
            }
            get
            {
                return this.manage_id;
            }
        }

        /// <summary>
        /// ���û򷵻ظ��ӽڵ�
        /// </summary>
        public int Parent_id
        {
            set
            {
                this.parent_id = value;
            }
            get
            {
                return this.parent_id;
            }
        }

        /// <summary>
        /// ���û򷵻ع���ģ������
        /// </summary>
        public string Manage_name
        {
            set
            {
                this.manage_name = value;
            }
            get
            {
                return this.manage_name;
            }
        }

    }
}
