using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Web0204.BM.BLL;
using Web0204.BM.Info;

namespace Web0204.BM.WebView
{
    public partial class PurchaseRecordDetails : PageBase
    {

        #region --- ҳ���߼� ---

        /// <summary>
        ///  ��Staff��Ϣ������Դ
        /// </summary>
        private void BindSource(int staffinfo_id, int supplier_id)
        {
            DataTable table;

            PurchaseProvider provider = new PurchaseProvider();

            table = provider.GetDetails(staffinfo_id, supplier_id);

            this.GridView1.DataSource = table.DefaultView;
            this.GridView1.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int staffinfo_id = 0;
                int supplier_id = 0;

                if (Request.QueryString["id"] != null)
                {
                    staffinfo_id = Convert.ToInt32(Request.QueryString["id"].ToString());
                }
                if (Request.QueryString["supplier_id"] != null)
                {
                    supplier_id = Convert.ToInt32(Request.QueryString["supplier_id"].ToString());
                }
                this.BindSource(staffinfo_id, supplier_id);
            }
            this.account.Text = GetAccout();
            this.datetime.Text = this.BindDayWeek();
        }
    }
}
