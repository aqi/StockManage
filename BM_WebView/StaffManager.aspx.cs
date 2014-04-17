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
        int user_manage = 0;
        int role_id = 0;
        int user_id = 0;

        /// <summary>
        ///  绑定Staff信息的数据源
        /// </summary>
        private void BindSource(Staff staff, int start)
        {
            DataTable table;

            StaffProvider provider = new StaffProvider();
            table = provider.GetRoleAll(staff, start, this.ListPager1.PageSize);

            this.GridView1.DataSource = table.DefaultView;
            this.GridView1.DataBind();
        }

        private void BindSource(Staff staff)
        {
            this.BindSource(staff, this.ListPager1.CurrentPageIndex * this.ListPager1.PageSize);
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            role_id = Convert.ToInt32(Session["ROLEID"].ToString());
            if (!IsPostBack)
            {
                user_manage = Convert.ToInt32(Session["USERMANAGE"].ToString());
                user_id = Convert.ToInt32(Session["USERID"].ToString());

                Staff staff = new Staff();

                if (user_manage == 0)
                {
                    this.btn_Result.Enabled = false;
                }

                staff.User_id = user_id;
                staff.Role_id = role_id;
                staff.Role_Manage = user_manage;

                BoundField sumField = new BoundField();
                sumField.DataField = "sum";
                if (role_id == 2)
                {
                    sumField.HeaderText = "采购金额";
                }
                else if (role_id == 3)
                {
                    sumField.HeaderText = "销售金额";
                }
                else if (role_id == 4)
                {
                    sumField.HeaderText = "库存总额";
                }
                this.GridView1.Columns.Insert(6, sumField);
/*
                if (role_id == 4)
                {
                    this.GridView1.Columns.RemoveAt(6);
                }
                */
                //this.GridView1.Columns[7].Visible = false;
                //this.GridView1.Columns[9].Visible = false;
                StaffProvider provider = new StaffProvider();
                this.ListPager1.RecordCount = provider.GetSize();
                this.BindSource(staff, 0);

                if (this.GridView1.Rows.Count > 0)
                {
                    for (int i = 0; i < this.GridView1.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(this.GridView1.Rows[i].Cells[8].Text.ToString()) != user_id) 
                            this.GridView1.Rows[i].Cells[7].Enabled = false;
                    }
                }
                //this.GridView1.Rows[1].Cells[7].Enabled = false;
               this.GridView1.Columns[8].Visible = false;
            }
            this.account.Text = GetAccout();//Session["LOGINED"].ToString();
            this.datetime.Text = this.BindDayWeek();
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);

        }

        void ListPager1_PageChange(object sender, PageEventArgs e)
        {
            Staff staff = new Staff();

            staff.User_id = user_id;
            staff.Role_id = role_id;
            staff.Role_Manage = user_manage;

            if (this.txt_Position.Text == "")
            {
                this.BindSource(staff, e.StartRecord);
            }
            else
            {
                staff.Staffinfo_Name = "%" + this.txt_Position.Text + "%";
                this.BindSource(staff, e.StartRecord);               
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

                    //((LinkButton)e.Row.Cells[index].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('您确定要删除员工:" + e.Row.Cells[3].Text + " 的信息吗?')");
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
                staff.User_id = user_id;
                staff.Role_id = role_id;
                staff.Role_Manage = user_manage;
                staff.Staffinfo_id = 0;
              
                if (this.txt_Position.Text != "")
                {
                    staff.Staffinfo_Name = "%" + this.txt_Position.Text + "%";
                }
                this.ListPager1.RecordCount = this.ListPager1.RecordCount - 1;
                this.BindSource(staff);
            }
        }

        protected void btn_Result_Click(object sender, EventArgs e)
        {
            Staff staff=new Staff();
            staff.User_id = user_id;
            staff.Role_id = role_id;
            staff.Role_Manage = user_manage;
            if (this.txt_Position.Text != "")
            {
                staff.Staffinfo_Name = "%" + this.txt_Position.Text + "%";
            }
            staff.Role_id = Convert.ToInt32(Session["ROLEID"].ToString());
            StaffProvider provider = new StaffProvider();
            this.ListPager1.RecordCount = provider.GetSize(staff);
            this.BindSource(staff,0);
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }
    }
}
