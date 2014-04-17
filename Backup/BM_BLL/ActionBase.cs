using System;
using System.Collections.Generic;
using System.Text;
using Web0204.BM.DAL;

namespace Web0204.BM.BLL
{
    /// <summary>
    /// ActionBase���ʾ����ҵ���߼���Ļ���
    /// </summary>
    public abstract class ActionBase
    {
        protected IDataHandler handler;

        public ActionBase()
        {
            this.handler = DataHandler.CreateHandler();
        }

    }
}
