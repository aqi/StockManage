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
    public partial class SaleRecordManager : PageBase
    {

        #region --- 页面逻辑 ---
        int user_manage = 0;
        int user_id = 0;
        int staffinfo_id = 0;

        /// <summary>
        ///  绑定Staff信息的数据源
        /// </summary>
        private void BindSource(Staff staff, int start)
        {
            DataTable table;

            SaleProvider provider = new SaleProvider();
            table = provider.SelectRec(staff, start, this.ListPager1.PageSize);

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
            if (user_id == 0)
            {
                user_id = Convert.ToInt32(Session["USERID"].ToString());
            }

            if (user_manage == 0)
            {
                user_manage = Convert.ToInt32(Session["USERMANAGE"].ToString());
            }

            if (staffinfo_id == 0)
            {
                StaffProvider provider = new StaffProvider();

                staffinfo_id = provider.GetStaffinfoId(user_id);
            }

            if (!IsPostBack)
            {
                PurchaseProvider provider = new PurchaseProvider();

                Staff staff = new Staff();

                staff.User_id = user_id;
                staff.Role_Manage = user_manage;

                this.GridView1.Columns[11].Visible = false;
                
                this.ListPager1.RecordCount = provider.GetSize();
                this.BindSource(staff, 0);


            }
            this.account.Text = Session["LOGINED"].ToString();
            this.datetime.Text = this.BindDayWeek();
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);

        }

        void ListPager1_PageChange(object sender, PageEventArgs e)
        {
            Staff staff = new Staff();

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
            Response.Redirect("SalePage.aspx?staffid=" + staffinfo_id.ToString());
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName.Equals("details"))
            {
                Response.Redirect("SalePage.aspx?id=" + this.GridView1.DataKeys[rowIndex].Value.ToString());
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

                    ((LinkButton)e.Row.Cells[10].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('您确定要删除员工:" + e.Row.Cells[1].Text + " 的这条销售数据吗?')");
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;

            Purchase purchase = new Purchase();
            purchase.Purchase_Id = Convert.ToInt32(this.GridView1.DataKeys[rowIndex].Value);

            PurchaseProvider provider = new PurchaseProvider();
            if (provider.Delete(purchase))
            {
                this.Alert("删除成功!!!");

                Staff staff = new Staff();
                staff.Role_Manage = user_manage;
                staff.User_id = user_id;
 
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
            staff.Role_Manage = user_manage;
            if (this.txt_Position.Text != "")
            {
                staff.Staffinfo_Name = "%" + this.txt_Position.Text + "%";
            }
            PurchaseProvider provider = new PurchaseProvider();
            this.ListPager1.RecordCount = provider.GetSize();
            this.BindSource(staff,0);
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }
    }
}
