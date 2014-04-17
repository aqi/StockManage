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
    public partial class StockRecordManager : PageBase
    {

        #region --- 页面逻辑 ---
        int user_manage = 0;
        int user_id = 0;
        int staffinfo_id = 0;

        /// <summary>
        ///  绑定Staff信息的数据源
        /// </summary>
        private void BindSource(Stock stock, int start)
        {
            DataTable table;

            StockProvider provider = new StockProvider();
            table = provider.SelectRec(stock, start, this.ListPager1.PageSize);

            this.GridView1.DataSource = table.DefaultView;
            this.GridView1.DataBind();
        }

        private void BindSource(Stock stock)
        {
            this.BindSource(stock, this.ListPager1.CurrentPageIndex * this.ListPager1.PageSize);
        }

        private void BindSource(int start)
        {
            Stock stock = new Stock();
            this.BindSource(stock, start);
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
                StockProvider provider = new StockProvider();
                
                this.ListPager1.RecordCount = provider.GetSize();
                this.BindSource(0);

                this.GridView1.Columns[7].Visible = false;


            }
            this.account.Text = GetAccout();//Session["LOGINED"].ToString();
            this.datetime.Text = this.BindDayWeek();
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);

        }

        void ListPager1_PageChange(object sender, PageEventArgs e)
        {
            Stock stock = new Stock();

            if (this.txt_Position.Text == "")
            {
                this.BindSource(stock, e.StartRecord);
            }
            else
            {
                stock.Good_Id = Convert.ToInt32(this.txt_Position.Text.ToString());
                this.BindSource(stock, e.StartRecord);               
            }
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("StockPage.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName.Equals("details"))
            {
                Response.Redirect("StockPage.aspx?id=" + this.GridView1.DataKeys[rowIndex].Value.ToString());
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

                    ((LinkButton)e.Row.Cells[6].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('您确定要删除员工:" + e.Row.Cells[1].Text + " 的这条库存数据吗?')");
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;

            Stock stock = new Stock();
            stock.Stock_Id = Convert.ToInt32(this.GridView1.DataKeys[rowIndex].Value);

            StockProvider provider = new StockProvider();
            if (provider.Delete(stock))
            {
                this.Alert("删除成功!!!");

                stock.Stock_Id = 0;
                if (this.txt_Position.Text != "")
                {
                    stock.Good_Id = Convert.ToInt32(this.txt_Position.Text.ToString());
                }
                this.ListPager1.RecordCount = this.ListPager1.RecordCount - 1;
                this.BindSource(stock);
            }
        }

        protected void btn_Result_Click(object sender, EventArgs e)
        {
            Stock stock = new Stock();

            if (this.txt_Position.Text != "")
            {
                stock.Good_Id = Convert.ToInt32(txt_Position.Text.ToString());
            }
            StockProvider provider = new StockProvider();
            this.ListPager1.RecordCount = provider.GetSize();
            this.BindSource(stock, 0);
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }
    }
}
