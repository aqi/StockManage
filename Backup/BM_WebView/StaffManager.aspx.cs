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
    public partial class StaffManager : PageBase
    {

        #region --- 页面逻辑 ---

        /// <summary>
        ///  绑定Staff信息的数据源
        /// </summary>
        private void BindSource(int start, string position)
        {
            if (position != null)
            {
                Staff staff = new Staff();
                staff.Staffionfo_position = position;
                StaffProvider provider = new StaffProvider();
                DataTable table = provider.Select(staff, start, this.ListPager1.PageSize);
                this.GridView1.DataSource = table.DefaultView;
                this.GridView1.DataBind();
            }
            else
            {
                StaffProvider provider = new StaffProvider();
                DataTable table = provider.GetAll(start, this.ListPager1.PageSize);
                this.GridView1.DataSource = table.DefaultView;
                this.GridView1.DataBind();
            }
        }

        private void BindSource(string position)
        {
            this.BindSource(this.ListPager1.CurrentPageIndex * this.ListPager1.PageSize,position);
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StaffProvider provider = new StaffProvider();
                this.ListPager1.RecordCount = provider.GetSize();
                this.BindSource(0,null);
            }
            this.account.Text = Session["LOGINED"].ToString();
            this.datetime.Text = this.BindDayWeek();
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }

        void ListPager1_PageChange(object sender, PageEventArgs e)
        {
            if (this.txt_Position.Text == "")
            {
                this.BindSource(e.StartRecord, null);
            }
            else
            {
                this.BindSource(e.StartRecord, "%" + this.txt_Position.Text + "%");               
            }
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaffPage.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName.Equals("details"))
            {
                Response.Redirect("StaffPage.aspx?id=" + this.GridView1.DataKeys[rowIndex].Value.ToString());
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

                    ((LinkButton)e.Row.Cells[6].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('您确定要删除员工:" + e.Row.Cells[1].Text + " 的信息吗?')");
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;

            Staff staff = new Staff();
            staff.Staffinfo_id = Convert.ToInt32(this.GridView1.DataKeys[rowIndex].Value);

            StaffProvider provider = new StaffProvider();
            if (provider.Delete(staff))
            {
                this.Alert("删除成功!!!");
                
                if (this.txt_Position.Text == "")
                {
                    this.ListPager1.RecordCount = this.ListPager1.RecordCount - 1;
                    this.BindSource(null);
                }
                else
                {
                    this.ListPager1.RecordCount = this.ListPager1.RecordCount - 1;
                    this.BindSource("%" + this.txt_Position.Text + "%");
                }
            }
        }

        protected void btn_Result_Click(object sender, EventArgs e)
        {
            Staff staff=new Staff();
            staff.Staffionfo_position="%"+this.txt_Position.Text+"%";
            StaffProvider provider = new StaffProvider();
            this.ListPager1.RecordCount = provider.GetSize(staff);
            this.BindSource(0, "%" + this.txt_Position.Text + "%");
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }
    }
}
