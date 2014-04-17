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
    public partial class outbound : PageBase
    {

        #region --- 页面逻辑 ---

        /// <summary>
        ///  绑定Order信息的数据源
        /// </summary>
        private void BindSource(int start)
        {
            Order order = new Order();
            //order.Order_state = "已发货";
            OrderProvider provider = new OrderProvider();
            DataTable table = provider.Select(order, start, this.ListPager1.PageSize);
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
                Order order = new Order();
                //order.Order_state = "已发货";
                OrderProvider provider = new OrderProvider();
                this.ListPager1.RecordCount = provider.GetSize(order);
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
                Response.Redirect("ShopOutbound.aspx?id=" + this.GridView1.DataKeys[rowIndex].Value.ToString());
            }
        }
    }
}
