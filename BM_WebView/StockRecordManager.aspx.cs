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
            DataTable table = new DataTable();
            int index = this.ddl_QueryCategory.SelectedIndex;
            this.GridView1.Columns[3].Visible = true;
            this.GridView1.Columns[4].Visible = true;
            this.GridView1.Columns[5].Visible = true;
            this.GridView1.Columns[6].Visible = true;
            this.GridView1.Columns[7].Visible = true;

            StockProvider provider = new StockProvider();

            switch (index)
            {
                case 0:
                    table = provider.SelectRec(stock, start, this.ListPager1.PageSize);
                    break;
                case 1:
                    table = provider.SelectRecPurchase(stock, start, this.ListPager1.PageSize);
                    break;
                case 2:
                    table = provider.SelectRecSale(stock, start, this.ListPager1.PageSize);
                    break;
            }
 

            this.GridView1.DataSource = table.DefaultView;
            this.GridView1.DataBind();

            switch (index)
            {
                case 0:
                    this.GridView1.Columns[3].Visible = true;
                    this.GridView1.Columns[4].Visible = true;
                    this.GridView1.Columns[5].Visible = true;
                    this.GridView1.Columns[7].Visible = false;
                    this.GridView1.Columns[6].Visible = false;
                    break;
                case 1:
                    this.GridView1.Columns[3].Visible = false;
                    this.GridView1.Columns[4].Visible = false;
                    this.GridView1.Columns[5].Visible = false;
                    this.GridView1.Columns[6].Visible = true;
                    this.GridView1.Columns[7].Visible = false;
                    break;
                case 2:
                    this.GridView1.Columns[3].Visible = false;
                    this.GridView1.Columns[4].Visible = false;
                    this.GridView1.Columns[5].Visible = false;
                    this.GridView1.Columns[6].Visible = false;
                    this.GridView1.Columns[7].Visible = true;
                    break;
            }
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
            if (!IsPostBack)
            {
                StockProvider provider = new StockProvider();
                
                this.ListPager1.RecordCount = provider.GetSize();
                this.BindSource(0);


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



        protected void btn_Result_Click(object sender, EventArgs e)
        {
            Stock stock = new Stock();
            int index = 0;

            stock.Good_Id = 0;
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
