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
    public partial class GoodManager : PageBase
    {

        #region --- 页面逻辑 ---

        private void BindDDL()
        {
            ProductProvider product = new ProductProvider();
            this.ddl_Product.DataSource = product.GetAll();
            this.ddl_Product.DataBind();
            this.ddl_Product.Items.Add("所有");
            this.ddl_Product.SelectedIndex = this.ddl_Product.Items.Count - 1;
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
            if (this.ddl_Product.SelectedValue.ToString() != "所有")
            {
                good.Product_id = Convert.ToInt32(this.ddl_Product.SelectedValue);
            }
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
                GoodProvider provider = new GoodProvider();
                DataTable table = provider.Select(good, start, this.ListPager1.PageSize);
                this.GridView1.DataSource = table.DefaultView;
                this.GridView1.DataBind();
            }
            else
            {
                GoodProvider provider = new GoodProvider();
                DataTable table = provider.GetAll(start, this.ListPager1.PageSize);
                this.GridView1.DataSource = table.DefaultView;
                this.GridView1.DataBind();
            }
        }

        private void BindSource(string name)
        {
            this.BindSource(this.ListPager1.CurrentPageIndex * this.ListPager1.PageSize, name);
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GoodProvider provider = new GoodProvider();
                this.ListPager1.RecordCount = provider.GetSize();
                this.BindSource(0, null);
                this.BindDDL();
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
                    good.Good_name = "%" + this.txt_Name.Text + "%";
                    this.ListPager1.RecordCount = provider.GetSize(good);
                    this.BindSource(0, "%" + this.txt_Name.Text + "%");
                }
                else
                {
                    good.Good_name = "%" + this.txt_Name.Text + "%";
                    good.Good_code = "%" + this.txt_code.Text + "%";
                    DataTable table = provider.Select(good, 0, this.ListPager1.RecordCount);
                    this.GridView1.DataSource = table.DefaultView;
                    this.GridView1.DataBind();
                }
            }
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("GoodPage.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName.Equals("details"))
            {
                Response.Redirect("GoodPage.aspx?id=" + this.GridView1.DataKeys[rowIndex].Value.ToString());
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

                    ((LinkButton)e.Row.Cells[12].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('您确定要删除产品:" + e.Row.Cells[4].Text + " 的信息吗?')");
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

                if (this.txt_Name.Text == "")
                {
                    this.ListPager1.RecordCount = this.ListPager1.RecordCount - 1;
                    this.BindSource(null);
                }
                else
                {
                    this.ListPager1.RecordCount = this.ListPager1.RecordCount - 1;
                    this.BindSource("%" + this.txt_Name.Text + "%");
                }

            }
        }

        protected void ddl_Product_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddl_Product.SelectedValue.ToString() == "所有")
            {
                GoodProvider providers = new GoodProvider();
                this.ListPager1.RecordCount = providers.GetSize();
                this.BindSource(0, null);
                return;
            }
            this.BindSelect();
        }

        protected void ddl_BrandName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddl_BrandName.SelectedValue.ToString() == "所有")
            {
                GoodProvider providers = new GoodProvider();
                this.ListPager1.RecordCount = providers.GetSize();
                this.BindSource(0, null);
                return;
            }
            this.BindSelect();
        }
    }
}
