using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{

    /// <summary>
    /// ��λʵ����
    /// </summary>
    public class Place
    {
        private int place_id;

        private string place_num;

        private string place_state;

        /// <summary>
        /// ���û򷵻�ס����λID
        /// </summary>
        public int Place_id
        {
            set
            {
                this.place_id = value;
            }
            get
            {
                return this.place_id;
            }
        }

        /// <summary>
        /// ���û򷵻ؿ�λ���
        /// </summary>
        public string Place_num
        {
            set
            {
                this.place_num = value;
            }
            get
            {
                return this.place_num;
            }
        }

        /// <summary>
        /// ���û򷵻�״̬
        /// </summary>
        public string Place_state
        {
            set
            {
                this.place_state = value;
            }
            get
            {
                return this.place_state;
            }
        }
    }
}
