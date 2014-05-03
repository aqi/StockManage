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
    public partial class FabricSales : PageBase
    {

        private string id;

        #region --- 页面逻辑 ---

        private void BindDDL()
        {
            UnitProvider unit = new UnitProvider();
            this.ddl_Unit.DataSource = unit.GetAll();
            this.ddl_Unit.DataBind();
            BrandProvider brand = new BrandProvider();
            this.ddl_BrandName.DataSource = brand.GetAll();
            this.ddl_BrandName.DataBind();
        }

        private void BindSelect()
        {
            Good good = new Good();
            good.Unit_id = Convert.ToInt32(this.ddl_Unit.SelectedValue);
            good.Brand_id = Convert.ToInt32(this.ddl_BrandName.SelectedValue);
            good.Good_name = "%" + this.txt_Name.Text + "%";
            good.Product_id = 1;
            GoodProvider provider = new GoodProvider();
            this.ListPager1.RecordCount = provider.GetSize(good);
            DataTable table = provider.Select(good, 0, this.ListPager1.RecordCount);
            this.GridView1.DataSource = table.DefaultView;
            this.GridView1.DataBind();
        }

        /// <summary>
        ///  绑定Units信息的数据源
        /// </summary>
        private void BindSource(int start)
        {
                Good good = new Good();
                good.Product_id = 1;
                GoodProvider provider = new GoodProvider();
                DataTable table = provider.Select(good, start, this.ListPager1.PageSize);
                this.GridView1.DataSource = table.DefaultView;
                this.GridView1.DataBind();
        }

        private void BindSource()
        {
            this.BindSource(this.ListPager1.CurrentPageIndex * this.ListPager1.PageSize);
        }

        /// <summary>
        ///  绑定Shop信息的数据源
        /// </summary>
        private void BindSourceShop(int start)
        {
            Shop shop = new Shop();
            shop.Order_id = Convert.ToInt32(id);
            ShopProvider provider = new ShopProvider();
            DataTable table = provider.Select(shop, start, this.ListPager2.PageSize);
            this.GridView2.DataSource = table.DefaultView;
            this.GridView2.DataBind();
        }

        private void BindSourceShop()
        {
            this.BindSourceShop(this.ListPager1.CurrentPageIndex * this.ListPager2.PageSize);
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
                this.BindDDL();
                GoodProvider provider = new GoodProvider();
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

        protected void btn_Result_Click(object sender, EventArgs e)
        {
            if (this.txt_Name.Text == "")
            {
                GoodProvider provider = new GoodProvider();
                this.ListPager1.RecordCount = provider.GetSize();
                this.BindSource(0);
                return;
            }
            this.BindSelect();
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            int i=0;
            for (int index = 0; index < this.GridView1.Rows.Count; index++)
            {
                if (this.GridView1.Rows[index].RowType == DataControlRowType.DataRow)
                {
                    TextBox control = (TextBox)this.GridView1.Rows[index].Cells[9].FindControl("txt_number");
                    if (control.Text != "")
                    {
                        int number = Convert.ToInt32(control.Text);
                        if (number < 0)
                        {
                            this.Alert("数量不能为负数!");
                            return;
                        }
                        int num = number % 10;
                        if (num > 0)
                        {
                            number = number / 10;
                            number = number * 10 + 10;
                        }
                        Shop shop = new Shop();
                        shop.Good_id = Convert.ToInt32(this.GridView1.DataKeys[index].Value);
                        shop.Shop_num = number;
                        shop.Shop_jointime = Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss"));
                        shop.Order_id = Convert.ToInt32(id);
                        shop.Contrac_id = 0;
                        ShopProvider provider = new ShopProvider();
                        provider.Insert(shop);
                        i = 1;
                        ((TextBox)this.GridView1.Rows[index].Cells[9].FindControl("txt_number")).Text = "";
                    }
                }
            }
            if (i == 1)
            {
                Shop shop = new Shop();
                shop.Order_id = Convert.ToInt32(id);
                ShopProvider provider = new ShopProvider();
                this.ListPager2.RecordCount = provider.GetSize(shop);
                this.BindSourceShop(0);
                this.ListPager2.PageChange += new PagerEventHandler(ListPager2_PageChange);
            }
            else
            {
                this.Alert("请输入数量!!!");
            }
        }

        void ListPager2_PageChange(object sender, PageEventArgs e)
        {
            this.BindSourceShop(e.StartRecord);
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

                    ((LinkButton)e.Row.Cells[6].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('您确定要删除商品:" + e.Row.Cells[1].Text + " 的信息吗?')");
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;

            Shop shop = new Shop();
            shop.Shop_id = Convert.ToInt32(this.GridView2.DataKeys[rowIndex].Value);

            ContractShopProvider provider = new ContractShopProvider();
            if (provider.Delete(shop))
            {
                this.Alert("删除成功!!!");

                this.ListPager2.RecordCount = this.ListPager2.RecordCount - 1;
                this.BindSourceShop();


            }
        }

        protected void ddl_Unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindSelect();
        }

        protected void ddl_BrandName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindSelect();
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("FabricSalesManager.aspx");
        }
    }
}
