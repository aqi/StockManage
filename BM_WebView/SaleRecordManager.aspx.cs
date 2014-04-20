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
        private void BindSource(Sale sale, int start)
        {
            DataTable table;

            SaleProvider provider = new SaleProvider();
            table = provider.SelectRec(sale, start, this.ListPager1.PageSize);

            this.GridView1.DataSource = table.DefaultView;
            this.GridView1.DataBind();

            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                if (this.GridView1.Rows[i].Cells[3].Text.ToString() == "&nbsp;")
                {
                    this.GridView1.Rows[i].Cells[8].Enabled = false;
                    this.GridView1.Rows[i].Cells[9].Enabled = false;
                }
                else if (Convert.ToInt32(this.GridView1.Rows[i].Cells[3].Text.ToString()) == 0)
                {
                    this.GridView1.Rows[i].Cells[8].Enabled = false;
                    this.GridView1.Rows[i].Cells[9].Enabled = false;
                }
            }
        }

        private void BindSource(Sale sale)
        {
            this.BindSource(sale, this.ListPager1.CurrentPageIndex * this.ListPager1.PageSize);
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
                SaleProvider provider = new SaleProvider();
                Sale sale = new Sale();

                this.GridView1.DataKeyNames = new string[] { "sale_id", "staffinfo_id", "buyer_id" };
                
                if (user_manage == 0)
                    sale.Staffinfo_Id = staffinfo_id;
                
                this.ListPager1.RecordCount = provider.GetSize();
                this.BindSource(sale, 0);

            }
            this.account.Text = GetAccout();//Session["LOGINED"].ToString();
            this.datetime.Text = this.BindDayWeek();
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }

        void ListPager1_PageChange(object sender, PageEventArgs e)
        {
            Sale sale = new Sale();

            if (user_manage == 0)
                sale.Staffinfo_Id = staffinfo_id;
            sale.Sale_Id = 0;
            sale.Year_Month = 0;

            if (this.txt_Position.Text != "")
                sale.Sale_Id = Convert.ToInt32(this.txt_Position.Text);
            if (this.txt_Yearmonth.Text != "")
                sale.Year_Month = Convert.ToInt32(this.txt_Yearmonth.Text);
            this.BindSource(sale, e.StartRecord);
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
                Response.Redirect("SaleRecordDetails.aspx?id=" + this.GridView1.DataKeys[rowIndex]["sale_id"].ToString());
                //Response.Redirect("SaleRecordDetails.aspx?id=" + this.GridView1.DataKeys[rowIndex]["staffinfo_id"].ToString() + "&buyer_id=" + this.GridView1.DataKeys[rowIndex]["buyer_id"].ToString());
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

                    ((LinkButton)e.Row.Cells[9].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('您确定要删除销售单号:" + e.Row.Cells[0].Text + " 的数据吗?')");
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;

            Sale sale = new Sale();
            sale.Sale_Id = Convert.ToInt32(this.GridView1.DataKeys[rowIndex].Value);

            SaleProvider provider = new SaleProvider();
            if (provider.Delete(sale))
            {
                this.Alert("删除成功!!!");

                if (user_manage == 0)
                    sale.Staffinfo_Id = staffinfo_id;
                sale.Sale_Id = 0;
                sale.Year_Month = 0;

                if (this.txt_Position.Text != "")
                    sale.Sale_Id = Convert.ToInt32(this.txt_Position.Text);
                if (this.txt_Yearmonth.Text != "")
                    sale.Year_Month = Convert.ToInt32(this.txt_Yearmonth.Text);

                this.ListPager1.RecordCount = this.ListPager1.RecordCount - 1;
                this.BindSource(sale);
            }
        }

        protected void btn_Result_Click(object sender, EventArgs e)
        {
            Sale sale = new Sale();
            if (user_manage == 0)
                sale.Staffinfo_Id = staffinfo_id;
            sale.Sale_Id = 0;
            sale.Year_Month = 0;

            if (this.txt_Position.Text != "")
                sale.Sale_Id = Convert.ToInt32(this.txt_Position.Text);
            if (this.txt_Yearmonth.Text != "")
                sale.Year_Month = Convert.ToInt32(this.txt_Yearmonth.Text);

            SaleProvider provider = new SaleProvider();
            this.ListPager1.RecordCount = provider.GetSize();
            this.BindSource(sale, 0);
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }
    }
}
