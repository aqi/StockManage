using System;
using System.Collections.Generic;
using System.Text;

namespace Web0204.BM.Info
{
    
    /// <summary>
    /// �ļ���ʽʵ����
    /// </summary>
    public class Send
    {
        private int send_id;

        private string send_name;

        /// <summary>
        /// ���û򷵻ؼļ���ʽID
        /// </summary>
        public int Send_id
        {
            set
            {
                this.send_id = value;
            }
            get
            {
                return this.send_id;
            }
        }

        /// <summary>
        /// ���û򷵻ؼļ���ʽ����
        /// </summary>
        public string Send_name
        {
            set
            {
                this.send_name = value;
            }
            get
            {
                return this.send_name;
            }
        }
    }
}
