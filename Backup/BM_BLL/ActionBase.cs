using System;
using System.Collections.Generic;
using System.Text;
using Web0204.BM.DAL;

namespace Web0204.BM.BLL
{
    /// <summary>
    /// ActionBase类表示所有业务逻辑类的基类
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
