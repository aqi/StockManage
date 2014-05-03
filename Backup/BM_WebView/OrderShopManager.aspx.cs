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
    public partial class OrderShopManager : PageBase
    {

        private string id;

        #region --- 页面逻辑 ---

        /// <summary>
        ///  绑定Units信息的数据源
        /// </summary>
        private void BindSource(int start)
        {
            Shop shop = new Shop();
            shop.Order_id = Convert.ToInt32(id);
            ShopProvider provider = new ShopProvider();
            DataTable table = provider.Select(shop, start, this.ListPager1.PageSize);
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
            if (Request.QueryString["id"] != null)
            {
                id = Request.QueryString["id"].ToString();
            }
            if (!IsPostBack)
            {
                Shop shop = new Shop();
                shop.Order_id = Convert.ToInt32(id);
                ShopProvider provider = new ShopProvider();
                this.ListPager1.RecordCount = provider.GetSize(shop);
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

                    ((LinkButton)e.Row.Cells[7].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('您确定要删除商品:" + e.Row.Cells[1].Text + " 的信息吗?')");
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;

            Shop shop = new Shop();
            shop.Shop_id = Convert.ToInt32(this.GridView1.DataKeys[rowIndex].Value);

            ShopProvider provider = new ShopProvider();
            if (provider.Delete(shop))
            {
                this.Alert("删除成功!!!");

                this.ListPager1.RecordCount = this.ListPager1.RecordCount - 1;
                this.BindSource();


            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName.Equals("info"))
            {
                Shop shop = new Shop();
                shop.Shop_id = Convert.ToInt32(this.GridView1.DataKeys[rowIndex].Value);
                ContractShopProvider provider = new ContractShopProvider();
                DataTable table = provider.Select(shop);
                Warehouse warehouse = new Warehouse();
                warehouse.Warehouse_number = Convert.ToInt32(table.Rows[0]["shop_num"]);
                warehouse.Good_id = Convert.ToInt32(table.Rows[0]["good_id"]);
                warehouse.Warehouse_type = "出库";
                warehouse.Warehouse_time = DateTime.Now.Date;
                warehouse.Warehouse_operators = Session["LOGINED"].ToString();
                WarehouseProvider warehouseProvider = new WarehouseProvider();
                warehouseProvider.Insert(warehouse);
                if (provider.Delete(shop))
                {
                    this.Alert("出库成功!!!");
                }
            }
        }
    }
}
