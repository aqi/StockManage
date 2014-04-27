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
    public partial class PurchaseManager : PageBase
    {

        #region --- 页面逻辑 ---

        /// <summary>
        ///  绑定Users信息的数据源
        /// </summary>
        private void BindSource(int start, string goodId, int yearmonth)
        {

                Purchase purchase = new Purchase();
                purchase.Good_Id = goodId;
                purchase.Year_Month = yearmonth;

                PurchaseProvider provider = new PurchaseProvider();
                DataTable table = provider.Select(purchase, start, this.ListPager1.PageSize);
                this.GridView1.DataSource = table.DefaultView;
                this.GridView1.DataBind();
        }

        private void BindSource(string goodId, int yearmonth)
        {
            this.BindSource(this.ListPager1.CurrentPageIndex * this.ListPager1.PageSize, goodId, yearmonth);
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PurchaseProvider provider = new PurchaseProvider();
                this.ListPager1.RecordCount = provider.GetSize();
                this.BindSource(0, "", 0);
            }
            this.account.Text = Session["LOGINED"].ToString();
            this.datetime.Text = this.BindDayWeek();
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }

        void ListPager1_PageChange(object sender, PageEventArgs e)
        {
            string good_id = "";
            int yearmonth = 0;

            if (this.txt_Name.Text != "")
                good_id = this.txt_Name.Text.ToString();
            if (this.txt_Yearmonth.Text != "")
                yearmonth = Convert.ToInt32(this.txt_Yearmonth.Text);
            this.BindSource(e.StartRecord, good_id, yearmonth);
    
        }

        protected void btn_Result_Click(object sender, EventArgs e)
        {
            Purchase purchase = new Purchase();
            purchase.Good_Id = "";
            purchase.Year_Month = 0;
            if (this.txt_Name.Text != "")
                purchase.Good_Id = this.txt_Name.Text.ToString();
            if (this.txt_Yearmonth.Text != "")
                purchase.Year_Month = Convert.ToInt32(this.txt_Yearmonth.Text);

            PurchaseProvider provider = new PurchaseProvider();
            this.ListPager1.RecordCount = provider.GetSize(purchase);
            this.BindSource(0, purchase.Good_Id, purchase.Year_Month);
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }
    }
}
