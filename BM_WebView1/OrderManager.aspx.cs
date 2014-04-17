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
    public partial class OrderManager : PageBase
    {

        #region --- 页面逻辑 ---

        private int buyer_id = 0;
        private int user_id = 0;
        /// <summary>
        ///  绑定Users信息的数据源
        /// </summary>
        private void BindSource(int start, int orderId)
        {
            Order order = new Order();
            order.Buyer_Id = buyer_id;
            if (orderId != 0)
            {
                order.Order_id = orderId;
            }
            OrderProvider provider = new OrderProvider();
            DataTable table = provider.Select(order, start, this.ListPager1.PageSize);
            this.GridView1.DataSource = table.DefaultView;
            this.GridView1.DataBind();
        }

        private void BindSource(int orderId)
        {
            this.BindSource(this.ListPager1.CurrentPageIndex * this.ListPager1.PageSize, orderId);
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            user_id = Convert.ToInt32(Session["USERID"].ToString());

            BuyerProvider buyerProvider = new BuyerProvider();

            buyer_id = buyerProvider.GetBuyerId(user_id);

            if (!IsPostBack)
            {
                OrderProvider provider = new OrderProvider();
                this.ListPager1.RecordCount = provider.GetSize();
                this.BindSource(0, 0);
            }
            this.account.Text = Session["LOGINED"].ToString();
            this.datetime.Text = this.BindDayWeek();
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }

        void ListPager1_PageChange(object sender, PageEventArgs e)
        {
            if (this.txt_Name.Text == "")
            {
                this.BindSource(e.StartRecord, 0);
            }
            else
            {
                this.BindSource(e.StartRecord, Convert.ToInt32(this.txt_Name.Text));
            }
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderPage.aspx?buyerid=" + buyer_id.ToString());
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName.Equals("details"))
            {
                Response.Redirect("OrderPage.aspx?id=" + this.GridView1.DataKeys[rowIndex].Value.ToString());
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal
                   || e.Row.RowState == DataControlRowState.Alternate)
                {
                    //当鼠标停留时更改背景色
                    e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#00A9FF'");
                    //当鼠标移开时还原背景色
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");

                    ((LinkButton)e.Row.Cells[11].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('您确定要删除订单号:" + e.Row.Cells[0].Text + " 的记录吗?')");
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;

            Order order = new Order();
            order.Order_id = Convert.ToInt32(this.GridView1.DataKeys[rowIndex].Value);

            OrderProvider provider = new OrderProvider();
            if (provider.Delete(order))
            {
                this.Alert("删除成功!!!");

                if (this.txt_Name.Text == "")
                {
                    this.ListPager1.RecordCount = this.ListPager1.RecordCount - 1;
                    this.BindSource(0);
                }
                else
                {
                    this.ListPager1.RecordCount = this.ListPager1.RecordCount - 1;
                    this.BindSource(Convert.ToInt32(this.txt_Name.Text));
                }

            }
        }

        protected void btn_Result_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            if (this.txt_Name.Text != "")
            {
                order.Order_id = Convert.ToInt32(this.txt_Name.Text);
            }
            OrderProvider provider = new OrderProvider();
            this.ListPager1.RecordCount = provider.GetSize(order);
            this.BindSource(0, order.Order_id);
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }
    }
}
