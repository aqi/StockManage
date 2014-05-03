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

        protected void btn_Export_Click(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.GridView dg = new System.Web.UI.WebControls.GridView();
            /*
                        BoundField field1 = new BoundField();
                        field1.DataField = "sale_id";
                        field1.HeaderText = "销售单号";
                        dg.Columns.Add(field1);

                        BoundField field2 = new BoundField();
                        field2.DataField = "good_id";
                        field2.HeaderText = "商品编号";
                        dg.Columns.Add(field2);

                        BoundField field3 = new BoundField();
                        field3.DataField = "sale_price";
                        field3.HeaderText = "销售单价";
                        dg.Columns.Add(field3);

                        BoundField field4 = new BoundField();
                        field4.DataField = "purchase_price";
                        field4.HeaderText = "采购单价";
                        dg.Columns.Add(field4);

                        BoundField field5 = new BoundField();
                        field5.DataField = "purchase_total";
                        field5.HeaderText = "成本总价";
                        dg.Columns.Add(field5);

                        BoundField field6 = new BoundField();
                        field6.DataField = "sale_num";
                        field6.HeaderText = "销售数量";
                        dg.Columns.Add(field6);


                        BoundField field7 = new BoundField();
                        field7.DataField = "sale_total";
                        field7.HeaderText = "销售总价";
                        dg.Columns.Add(field7);

                        BoundField field8 = new BoundField();
                        field8.DataField = "sale_profit";
                        field8.HeaderText = "利润";
                        dg.Columns.Add(field8);

                        BoundField field9 = new BoundField();
                        field9.DataField = "sale_datetime";
                        field9.HeaderText = "销售时间";
                        dg.Columns.Add(field9);

                        BoundField field10 = new BoundField();
                        field10.DataField = "buyer_bh";
                        field10.HeaderText = "采购商编号";
                        dg.Columns.Add(field10);
            */
            Purchase purchase = new Purchase();
            purchase.Good_Id = "";
            purchase.Year_Month = 0;
            if (this.txt_Name.Text != "")
                purchase.Good_Id = this.txt_Name.Text.ToString();
            if (this.txt_Yearmonth.Text != "")
                purchase.Year_Month = Convert.ToInt32(this.txt_Yearmonth.Text);

            PurchaseProvider provider = new PurchaseProvider();
            DataTable table = provider.Select(purchase, 0, 0);

            dg.DataSource = table.DefaultView;
            dg.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("content-disposition", "attachment;filename=PurchaseRecords.xls");
            Response.Charset = "";
            this.EnableViewState = false;

            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);

            dg.RenderControl(htw);

            Response.Write(sw.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            // Confirms that an HtmlForm control is rendered for
        }
    }
}
