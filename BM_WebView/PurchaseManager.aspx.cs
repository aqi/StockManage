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
    public partial class PurchaseManager : PageBase
    {

        #region --- 页面逻辑 ---

        /// <summary>
        ///  绑定Users信息的数据源
        /// </summary>
        private void BindSource(int start, int goodId)
        {
            if (goodId != 0)
            {
                Purchase purchase = new Purchase();
                purchase.Good_Id = goodId;
  
                PurchaseProvider provider = new PurchaseProvider();
                DataTable table = provider.Select(purchase, start, this.ListPager1.PageSize);
                this.GridView1.DataSource = table.DefaultView;
                this.GridView1.DataBind();
            }
            else
            {
                PurchaseProvider provider = new PurchaseProvider();
                DataTable table = provider.GetAll(start, this.ListPager1.PageSize);
                this.GridView1.DataSource = table.DefaultView;
                this.GridView1.DataBind();
            }
        }

        private void BindSource(int goodId)
        {
            this.BindSource(this.ListPager1.CurrentPageIndex * this.ListPager1.PageSize, goodId);
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PurchaseProvider provider = new PurchaseProvider();
                this.ListPager1.RecordCount = provider.GetSize();
                this.BindSource(0, 0);
                this.btn_add.Enabled = false;
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
            Response.Redirect("PurchasePage.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName.Equals("details"))
            {
                Response.Redirect("PurchasePage.aspx?id=" + this.GridView1.DataKeys[rowIndex].Value.ToString());
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

                   // ((LinkButton)e.Row.Cells[8].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('您确定要删除采购编号:" + e.Row.Cells[1].Text + " 的信息吗?')");
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;

            Purchase purchase = new Purchase();
            purchase.Purchase_Id = Convert.ToInt32(this.GridView1.DataKeys[rowIndex].Value);

            PurchaseProvider provider = new PurchaseProvider();
            if (provider.Delete(purchase))
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
            Purchase purchase = new Purchase();
            if (this.txt_Name.Text == "")
                purchase.Good_Id = 0;
            else
                purchase.Good_Id = Convert.ToInt32(this.txt_Name.Text);
            PurchaseProvider provider = new PurchaseProvider();
            this.ListPager1.RecordCount = provider.GetSize(purchase);
            this.BindSource(0, purchase.Good_Id);
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }
    }
}
