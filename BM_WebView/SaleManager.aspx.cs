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
    public partial class SaleManager : PageBase
    {

        #region --- 页面逻辑 ---

        /// <summary>
        ///  绑定Users信息的数据源
        /// </summary>
        private void BindSource(int start, int goodId, int yearmonth)
        {
            Sale sale = new Sale();
            sale.Good_Id = goodId;
            sale.Year_Month = yearmonth;

            SaleProvider provider = new SaleProvider();
            DataTable table = provider.Select1(sale, start, this.ListPager1.PageSize);
            this.GridView1.DataSource = table.DefaultView;
            this.GridView1.DataBind();
        }

        private void BindSource(int goodId, int yearmonth)
        {
            this.BindSource(this.ListPager1.CurrentPageIndex * this.ListPager1.PageSize, goodId, yearmonth);
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SaleProvider provider = new SaleProvider();
                this.ListPager1.RecordCount = provider.GetSize();
                this.BindSource(0, 0, 0);
            }
            this.account.Text = Session["LOGINED"].ToString();
            this.datetime.Text = this.BindDayWeek();
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }

        void ListPager1_PageChange(object sender, PageEventArgs e)
        {

            int good_id = 0;
            int yearmonth = 0;

            if (this.txt_Name.Text != "")
                good_id = Convert.ToInt32(this.txt_Name.Text);
            if (this.txt_Yearmonth.Text != "")
                yearmonth = Convert.ToInt32(this.txt_Yearmonth.Text);

            this.BindSource(e.StartRecord, good_id, yearmonth);
        }

        protected void btn_Result_Click(object sender, EventArgs e)
        {
            Sale sale = new Sale();
            sale.Good_Id = 0;
            sale.Year_Month = 0;
            if (this.txt_Name.Text != "")
                sale.Good_Id = Convert.ToInt32(this.txt_Name.Text);
            if (this.txt_Yearmonth.Text != "")
                sale.Year_Month = Convert.ToInt32(this.txt_Yearmonth.Text);

            SaleProvider provider = new SaleProvider();
            this.ListPager1.RecordCount = provider.GetSize(sale);
            this.BindSource(0, sale.Good_Id, sale.Year_Month);
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }
    }
}
