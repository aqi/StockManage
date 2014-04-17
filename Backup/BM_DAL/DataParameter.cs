using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Web0204.BM.DAL
{
    /// <summary>
    /// DataParameter类表示命令文本的参数。
    /// </summary>
    public class DataParameter
    {

        private string parameterName;

        /// <summary>
        /// 获取或设置参数名称
        /// </summary>
        public string ParameterName
        {
            get { return parameterName; }
            set { parameterName = value; }
        }

        private DbType dbType;

        /// <summary>
        /// 获取或设置参数类型
        /// </summary>
        public DbType DbType
        {
            get { return dbType; }
            set { dbType = value; }
        }

        private object _value;

        /// <summary>
        /// 获取或设置参数的值
        /// </summary>
        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
