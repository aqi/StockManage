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
    public partial class warehousing : PageBase
    {

        #region --- 页面逻辑 ---

        /// <summary>
        ///  绑定Contract信息的数据源
        /// </summary>
        private void BindSource(int start)
        {
            Contract contract = new Contract();
            contract.Contrac_state = "%已%";
            ContractProvider provider = new ContractProvider();
            DataTable table = provider.Select(contract, start, this.ListPager1.PageSize);
            this.GridView1.DataSource = table.DefaultView;
            this.GridView1.DataBind();
        }

        private void BindSource()
        {
            this.BindSource(this.ListPager1.CurrentPageIndex * this.ListPager1.PageSize);
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Contract contract = new Contract();
                contract.Contrac_state = "%已%";
                ContractProvider provider = new ContractProvider();
                this.ListPager1.RecordCount = provider.GetSize(contract);
                this.BindSource(0);
            }
            this.account.Text = Session["LOGINED"].ToString();
            this.datetime.Text = this.BindDayWeek();
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }

        void ListPager1_PageChange(object sender, PageEventArgs e)
        {
            this.BindSource(e.StartRecord);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("warehousing"))
            {
                Response.Redirect("ShopWarehousing.aspx?id=" + this.GridView1.DataKeys[rowIndex].Value.ToString());
            }
        }
    }
}
