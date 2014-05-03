using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Web0204.BM.Info;
using System.Text;
using System.IO;
using Web0204.BM.BLL;

namespace Web0204.BM.WebView
{
    /// <summary>
    /// PageBase类表示所有业务管理页面的基类
    /// </summary>
    public class PageBase : Page
    {

        protected override void OnLoad(EventArgs e)
        {
            if (Session["LOGINED"] == null)
            {
                Response.Redirect("login.aspx");
            }
            base.OnLoad(e);
        }

        /// <summary>
        /// 获取当前登录系统的用户信息
        /// </summary>
        public string CurrentUser
        {
            get
            {
                if (Session["LOGINED"] != null)
                {
                    return Session["LOGINED"].ToString();
                }
                return null;
            }
        }

        public string GetAccout()
        {
            UserProvider provider = new UserProvider();

            return CurrentUser + (provider.GetUserManage(Session["LOGINED"].ToString()) == 1 ? "经理" : "普通员工");
        }
        /// <summary>
        /// 弹出警告框
        /// </summary>
        /// <param name="message">警告内容</param>
        public void Alert(string message)
        {
            Response.Write("<script>");
            Response.Write("alert('" + message + "');");
            Response.Write("</script>");
        }

        public string BindDayWeek()
        {
            string dt = DateTime.Today.DayOfWeek.ToString();
            string day = DateTime.Today.ToString("yyyy年M月d日 ");
            //根据取得的星期英文单词返回汉字
            switch (dt)
            {
                case "Monday":
                    day = day+ "星期一";
                    break;
                case "Tuesday":
                    day = day + "星期二";
                    break;
                case "Wednesday":
                    day = day + "星期三";
                    break;
                case "Thursday":
                    day = day + "星期四";
                    break;
                case "Friday":
                    day = day + "星期五";
                    break;
                case "Saturday":
                    day = day + "星期六";
                    break;
                case "Sunday":
                    day = day + "星期日";
                    break;
            }
            return day;

        }

        /// <summary>
        /// 获取商品记录
        /// </summary>
        public DataTable Good_Record
        {
            get
            {
                GoodProvider goodProvider = new GoodProvider();
                DataTable table = goodProvider.GetAll();
                return table;
            }
        }

        /// <summary>
        /// 获取供应商记录
        /// </summary>
        public DataTable Supplier_Record
        {
            get
            {
  
                    SupplierProvider supplierProvider = new SupplierProvider();
                    DataTable table = supplierProvider.GetAll();
                    return  table;
            }
        }

        /// <summary>
        /// 获取采购商记录
        /// </summary>
        public DataTable Buyer_Record
        {
            get
            {
                if (Session["BRDT"] == null)
                {
                    BuyerProvider buyerProvider = new BuyerProvider();
                    DataTable table = buyerProvider.GetAll();
                    Session["BRDT"] = table;
                }
                return (DataTable)Session["BRDT"];
            }
        }

        /// <summary>
        /// 获取或设置操作类型的标志位
        /// </summary>
        public Operation OperationFlag
        {
            get
            {
                if (this.ViewState["FLAG"] == null)
                {
                    this.ViewState["FLAG"] = Operation.Add;
                }
                return (Operation)this.ViewState["FLAG"];
            }
            set
            {
                this.ViewState["FLAG"] = value;
            }
        }

        /// <summary>
        /// Operation枚举表示操作的类型
        /// </summary>
        public enum Operation
        {
            /// <summary>
            /// 添加
            /// </summary>
            Add,

            /// <summary>
            /// 更新
            /// </summary>
            Update,

            /// <summary>
            /// 删除
            /// </summary>
            Delete
        }
    }
}
