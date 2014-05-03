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
    public partial class WarehouseManager : PageBase
    {

        #region --- 页面逻辑 ---

        /// <summary>
        ///  绑定Units信息的数据源
        /// </summary>
        private void BindSource(int start)
        {
            WarehouseInfoProvider provider = new WarehouseInfoProvider();
            DataTable table = provider.GetAll(start, this.ListPager1.PageSize);
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
                WarehouseInfoProvider provider = new WarehouseInfoProvider();
                this.ListPager1.RecordCount = provider.GetSize();
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

                    ((LinkButton)e.Row.Cells[5].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('您确定要删除产品:" + e.Row.Cells[0].Text + " 的信息吗?')");
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;

            Good good = new Good();
            good.Good_id = Convert.ToInt32(this.GridView1.DataKeys[rowIndex].Value);

            GoodProvider provider = new GoodProvider();
            if (provider.Delete(good))
            {
                this.Alert("删除成功!!!");

                this.ListPager1.RecordCount = this.ListPager1.RecordCount- 1;
                this.BindSource();

            }
        }

        protected void btn_chuku_Click(object sender, EventArgs e)
        {
            Response.Redirect("outbound.aspx");
        }

        protected void btn_add_Click1(object sender, EventArgs e)
        {
            Response.Redirect("warehousing.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName.Equals("warehouse"))
            {
                Response.Redirect("WarehouseMingxi.aspx?id=" + this.GridView1.DataKeys[rowIndex].Value.ToString());
            }
        }
    }
}
