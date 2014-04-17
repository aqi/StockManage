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
    public partial class WarehouseMingxi : PageBase
    {

        private string id;

        #region --- 页面逻辑 ---

        /// <summary>
        ///  绑定Units信息的数据源
        /// </summary>
        private void BindSource(int start)
        {
            if (Request.QueryString["id"] != null)
            {
                id = Request.QueryString["id"].ToString();
                Warehouse warehouse = new Warehouse();
                warehouse.Good_id = Convert.ToInt32(id);
                WarehouseProvider provider = new WarehouseProvider();
                DataTable table = provider.Select(warehouse, start, this.ListPager1.PageSize);
                this.GridView1.DataSource = table.DefaultView;
                this.GridView1.DataBind();
            }
            else
            {
                WarehouseProvider provider = new WarehouseProvider();
                DataTable table = provider.GetAll(start, this.ListPager1.PageSize);
                this.GridView1.DataSource = table.DefaultView;
                this.GridView1.DataBind();
            }
        }

        private void BindSource()
        {
            this.BindSource(this.ListPager1.CurrentPageIndex * this.ListPager1.PageSize);
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                id = Request.QueryString["id"].ToString();
            }
            if (!IsPostBack)
            {
                Warehouse warehouse = new Warehouse();
                warehouse.Good_id = Convert.ToInt32(id);
                WarehouseProvider provider = new WarehouseProvider();
                this.ListPager1.RecordCount = provider.GetSize(warehouse);
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

                    ((LinkButton)e.Row.Cells[5].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('您确定要删除产品:" + e.Row.Cells[4].Text + " 的信息吗?')");
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;

            Warehouse warehouse = new Warehouse();
            warehouse.Warehouse_id = Convert.ToInt32(this.GridView1.DataKeys[rowIndex].Value);

            WarehouseProvider provider = new WarehouseProvider();
            if (provider.Delete(warehouse))
            {
                this.Alert("删除成功!!!");

                this.ListPager1.RecordCount = this.ListPager1.RecordCount - 1;
                this.BindSource();

            }
        }
    }
}
