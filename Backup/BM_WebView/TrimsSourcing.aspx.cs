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
    public partial class TrimsSourcing : PageBase
    {

        private string id;

        #region --- 页面逻辑 ---

        private void BindDDL()
        {
            BrandProvider brand = new BrandProvider();
            this.ddl_BrandName.DataSource = brand.GetAll();
            this.ddl_BrandName.DataBind();
            this.ddl_BrandName.Items.Add("所有");
            this.ddl_BrandName.SelectedIndex = this.ddl_BrandName.Items.Count - 1;
        }

        private void BindSelect()
        {
            Good good = new Good();
            if (this.ddl_BrandName.SelectedValue.ToString() != "所有")
            {
                good.Brand_id = Convert.ToInt32(this.ddl_BrandName.SelectedValue);
            }
            good.Product_id = 2;
            good.Good_code = this.txt_code.Text;
            good.Good_name = "%" + this.txt_Name.Text + "%";
            GoodProvider provider = new GoodProvider();
            this.ListPager1.RecordCount = provider.GetSize(good);
            DataTable table = provider.Select(good, 0, this.ListPager1.RecordCount);
            this.GridView1.DataSource = table.DefaultView;
            this.GridView1.DataBind();
        }

        /// <summary>
        ///  绑定good信息的数据源
        /// </summary>
        private void BindSource(int start, string name)
        {
            if (name != null)
            {
                Good good = new Good();
                good.Good_name = name;
                good.Product_id = 2;
                GoodProvider provider = new GoodProvider();
                DataTable table = provider.Select(good, start, this.ListPager1.PageSize);
                this.GridView1.DataSource = table.DefaultView;
                this.GridView1.DataBind();
            }
            else
            {
                Good good = new Good();
                good.Product_id = 2;
                GoodProvider provider = new GoodProvider();
                DataTable table = provider.Select(good, start, this.ListPager1.PageSize);
                this.GridView1.DataSource = table.DefaultView;
                this.GridView1.DataBind();
            }
        }

        private void BindSource(string name)
        {
            this.BindSource(this.ListPager1.CurrentPageIndex * this.ListPager1.PageSize, name);
        }
        /// <summary>
        ///  绑定Shop信息的数据源
        /// </summary>
        private void BindSourceShop(int start)
        {
            Shop shop = new Shop();
            shop.Contrac_id = Convert.ToInt32(id);
            ContractShopProvider provider = new ContractShopProvider();
            DataTable table = provider.Select(shop, start, this.ListPager2.PageSize);
            this.GridView2.DataSource = table.DefaultView;
            this.GridView2.DataBind();
        }

        private void BindSourceShop()
        {
            this.BindSourceShop(this.ListPager2.CurrentPageIndex * this.ListPager2.PageSize);
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
                this.BindSource(0, null);
            }
            this.account.Text = Session["LOGINED"].ToString();
            this.datetime.Text = this.BindDayWeek();
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }

        void ListPager1_PageChange(object sender, PageEventArgs e)
        {
            if (this.txt_Name.Text == "")
            {
                this.BindSource(e.StartRecord, null);
            }
            else
            {
                this.BindSource(e.StartRecord, "%" + this.txt_Name.Text + "%");
            }
        }

        protected void btn_Result_Click(object sender, EventArgs e)
        {
            Good good = new Good();
            GoodProvider provider = new GoodProvider();
            if (this.txt_Name.Text == "")
            {
                if (this.txt_code.Text == "")
                {
                    GoodProvider providers = new GoodProvider();
                    this.ListPager1.RecordCount = providers.GetSize();
                    this.BindSource(0, null);
                }
                else
                {
                    good.Product_id = 2;
                    good.Good_code = "%" + this.txt_code.Text + "%";
                    DataTable table = provider.Select(good, 0, this.ListPager1.RecordCount);
                    this.GridView1.DataSource = table.DefaultView;
                    this.GridView1.DataBind();
                }
            }
            else
            {
                if (this.txt_code.Text == "")
                {
                    good.Product_id = 2;
                    good.Good_name = "%" + this.txt_Name.Text + "%";
                    this.ListPager1.RecordCount = provider.GetSize(good);
                    this.BindSource(0, "%" + this.txt_Name.Text + "%");
                }
                else
                {
                    good.Product_id = 2;
                    good.Good_name = "%" + this.txt_Name.Text + "%";
                    good.Good_code = "%" + this.txt_code.Text + "%";
                    DataTable table = provider.Select(good, 0, this.ListPager1.RecordCount);
                    this.GridView1.DataSource = table.DefaultView;
                    this.GridView1.DataBind();
                }
            }
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            int i = 0;
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
                        shop.Order_id = 0;
                        shop.Contrac_id = Convert.ToInt32(id);
                        ContractShopProvider provider = new ContractShopProvider();
                        provider.Insert(shop);
                        i = 1;
                        ((TextBox)this.GridView1.Rows[index].Cells[9].FindControl("txt_number")).Text = "";
                    }
                }
            }
            if (i == 1)
            {
                Shop shop = new Shop();
                shop.Contrac_id = Convert.ToInt32(id);
                ContractShopProvider provider = new ContractShopProvider();
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

        protected void ddl_BrandName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddl_BrandName.SelectedValue.ToString() == "所有")
            {
                Good good = new Good();
                good.Product_id = 2;
                GoodProvider provider = new GoodProvider();
                DataTable table = provider.Select(good, 0, this.ListPager1.PageSize);
                this.GridView1.DataSource = table.DefaultView;
                this.GridView1.DataBind();
                return;
            }
            this.BindSelect();
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("TrimsSourcingManager.aspx");
        }

        
    }
}
