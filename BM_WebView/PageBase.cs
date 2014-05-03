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
    /// PageBase���ʾ����ҵ�����ҳ��Ļ���
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
        /// ��ȡ��ǰ��¼ϵͳ���û���Ϣ
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

            return CurrentUser + (provider.GetUserManage(Session["LOGINED"].ToString()) == 1 ? "����" : "��ͨԱ��");
        }
        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="message">��������</param>
        public void Alert(string message)
        {
            Response.Write("<script>");
            Response.Write("alert('" + message + "');");
            Response.Write("</script>");
        }

        public string BindDayWeek()
        {
            string dt = DateTime.Today.DayOfWeek.ToString();
            string day = DateTime.Today.ToString("yyyy��M��d�� ");
            //����ȡ�õ�����Ӣ�ĵ��ʷ��غ���
            switch (dt)
            {
                case "Monday":
                    day = day+ "����һ";
                    break;
                case "Tuesday":
                    day = day + "���ڶ�";
                    break;
                case "Wednesday":
                    day = day + "������";
                    break;
                case "Thursday":
                    day = day + "������";
                    break;
                case "Friday":
                    day = day + "������";
                    break;
                case "Saturday":
                    day = day + "������";
                    break;
                case "Sunday":
                    day = day + "������";
                    break;
            }
            return day;

        }

        /// <summary>
        /// ��ȡ��Ʒ��¼
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
        /// ��ȡ��Ӧ�̼�¼
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
        /// ��ȡ�ɹ��̼�¼
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
        /// ��ȡ�����ò������͵ı�־λ
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
        /// Operationö�ٱ�ʾ����������
        /// </summary>
        public enum Operation
        {
            /// <summary>
            /// ���
            /// </summary>
            Add,

            /// <summary>
            /// ����
            /// </summary>
            Update,

            /// <summary>
            /// ɾ��
            /// </summary>
            Delete
        }
    }
}
