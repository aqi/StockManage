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
    public partial class CompanyManager : PageBase
    {

        #region --- 页面逻辑 ---

        /// <summary>
        ///  绑定Company信息的数据源
        /// </summary>
        private void BindSource(int start, string name)
        {
            if (name != null)
            {
                Company company = new Company();
                company.Company_name = name;
                CompanyProvider provider = new CompanyProvider();
                DataTable table = provider.Select(company, start, this.ListPager1.PageSize);
                this.GridView1.DataSource = table.DefaultView;
                this.GridView1.DataBind();
            }
            else
            {
                CompanyProvider provider = new CompanyProvider();
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
                CompanyProvider provider = new CompanyProvider();
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
            Company company = new Company();
            company.Company_name = "%" + this.txt_Name.Text + "%";
            CompanyProvider provider = new CompanyProvider();
            this.ListPager1.RecordCount = provider.GetSize(company);
            this.BindSource(0, "%" + this.txt_Name.Text + "%");
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompanyPage.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName.Equals("details"))
            {
                Response.Redirect("CompanyPage.aspx?id=" + this.GridView1.DataKeys[rowIndex].Value.ToString());
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

                    ((LinkButton)e.Row.Cells[9].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('您确定要删除厂商:" + e.Row.Cells[1].Text + " 的信息吗?')");
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;

            Company company = new Company();
            company.Company_id = Convert.ToInt32(this.GridView1.DataKeys[rowIndex].Value);

            CompanyProvider provider = new CompanyProvider();
            if (provider.Delete(company))
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
    }
}
