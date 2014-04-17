using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Web0204.BM.DAL
{
    /// <summary>
    /// DataParameter���ʾ�����ı��Ĳ�����
    /// </summary>
    public class DataParameter
    {

        private string parameterName;

        /// <summary>
        /// ��ȡ�����ò�������
        /// </summary>
        public string ParameterName
        {
            get { return parameterName; }
            set { parameterName = value; }
        }

        private DbType dbType;

        /// <summary>
        /// ��ȡ�����ò�������
        /// </summary>
        public DbType DbType
        {
            get { return dbType; }
            set { dbType = value; }
        }

        private object _value;

        /// <summary>
        /// ��ȡ�����ò�����ֵ
        /// </summary>
        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
