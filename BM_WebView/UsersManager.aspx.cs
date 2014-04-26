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
    public partial class UsersManager : PageBase
    {

        #region --- 页面逻辑 ---

        /// <summary>
        ///  绑定Users信息的数据源
        /// </summary>
        private void BindSource(int start, string name)
        {
            //int prvResponse = Convert.ToInt32(Session["PRVRESPONSE"].ToString());

            if (name != null)
            {
                Users user = new Users();
                user.User_name = name;
                user.User_Login = 1;
                //if (prvResponse == 9)
                //    user.User_Manage = 0;
                //else
                //{
                //    user.User_Manage = 1;
                //    user.Role_id = prvResponse - 20;
                //}
                UserProvider provider = new UserProvider();
                DataTable table = provider.SelectStaff(user, start, this.ListPager1.PageSize);
                this.GridView1.DataSource = table.DefaultView;
                this.GridView1.DataBind();
            }
            else
            {
                UserProvider provider = new UserProvider();
                DataTable table;

                //if (9 == prvResponse)
                //{
                //    table = provider.GetAll(start, this.ListPager1.PageSize);
                //}
                //else
                //{
                //    Users user = new Users();
                 //   user.Role_id = prvResponse - 20;
                //    user.User_Manage = 1;
                //    table = provider.Select(user, start, this.ListPager1.PageSize);
                //}
                table = provider.GetAll(start, this.ListPager1.PageSize);
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
            UserProvider provider = new UserProvider();
            if (!IsPostBack)
            {
                this.ListPager1.RecordCount = provider.GetSize();
                this.BindSource(0, null);
            }
            /*
            string manage = provider.GetUserManage(Session["LOGINED"].ToString()) == 1 ? "经理" : "普通员工";
            */

          string manage = "";
            this.account.Text = Session["LOGINED"].ToString() + manage;
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

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsersPage.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName.Equals("details"))
            {
                Response.Redirect("UsersPage.aspx?id=" + this.GridView1.DataKeys[rowIndex].Value.ToString());
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

                    ((LinkButton)e.Row.Cells[10].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('您确定要删除用户:" + e.Row.Cells[1].Text + " 的信息吗?')");
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;

            Users user = new Users();
            user.User_id = Convert.ToInt32(this.GridView1.DataKeys[rowIndex].Value);

            if (user.User_id == 1)
            {
                this.Alert("管理员账号不能删除！！！");
                return;
            }

            UserProvider provider = new UserProvider();
            if (provider.Delete(user))
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

        protected void btn_Result_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            user.User_name = "%" + this.txt_Name.Text + "%";
            UserProvider provider = new UserProvider();
            this.ListPager1.RecordCount = provider.GetSize(user);
            this.BindSource(0, "%" + this.txt_Name.Text + "%");
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }
    }
}
