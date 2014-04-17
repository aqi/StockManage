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
    public partial class StockPage : PageBase
    {

        private string id;

        #region --- 页面逻辑 ---

        private void BindText()
        {
            Stock stock = new Stock();
            stock.Stock_Id = Convert.ToInt32(id);
            StockProvider provider = new StockProvider();
            DataTable table = new DataTable();
            table = provider.Select(stock);

            this.txt_goodid.Text = table.Rows[0]["good_id"].ToString();
            this.txt_price.Text = table.Rows[0]["purchase_price"].ToString();
            this.txt_num.Text = table.Rows[0]["stock_num"].ToString();
            this.txt_datetime.Text = table.Rows[0]["purchase_datetime"].ToString();
        }

        private int IsSame()
        {
            return 0;
        }

        private Stock AddStock()
        {
            Stock stock = new Stock();           
            if (Request.QueryString["id"] != null)
            {
                stock.Stock_Id = Convert.ToInt32(id);
            }

            if (this.txt_goodid.Text == "")
                stock.Good_Id = 0;
            else
                stock.Good_Id = Convert.ToInt32(this.txt_goodid.Text);
            stock.Purchase_Datetime = DateTime.Now.ToString(); ;//Convert.ToDateTime( DateTime.Now.ToString("HH:mm:ss"));
            stock.Purchase_Price= this.txt_price.Text;
            stock.Stock_Num = this.txt_num.Text;

            return stock;
        }

        private void TextCancel()
        {
            this.txt_goodid.Text = "";
            this.txt_datetime.Text = DateTime.Now.ToString();
            this.txt_price.Text = "";
            this.txt_num.Text = "";
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                id = Request.QueryString["id"].ToString();
                if (!IsPostBack)
                {
                    this.BindText();
                }
                this.OperationFlag = Operation.Update;
            }
            else
            {
                this.txt_datetime.Text = DateTime.Now.ToString();
            }

            this.txt_datetime.Enabled = false;
            this.account.Text = Session["LOGINED"].ToString();
            this.datetime.Text = this.BindDayWeek();
        }

      

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.TextCancel();
        }

        protected void btn_manager_Click(object sender, EventArgs e)
        {
            Response.Redirect("StockRecordManager.aspx");
        }

        protected void btn_sure_Click(object sender, EventArgs e)
        {
            Stock stocks = this.AddStock();
            StockProvider provider = new StockProvider();
            switch (this.OperationFlag)
            {
                case Operation.Add:
                    if (stocks.Good_Id == 0)
                    {
                        this.Alert("商品编号没设置，添加失败!!!");
                        break;
                    }
                    if (this.IsSame() == 1)
                    {
                        break;
                    }
                    if (provider.Insert(stocks))
                    {
                        this.Alert("添加成功!!!");
                        this.TextCancel();
                    }
                    break;
                case Operation.Update:
                    if (stocks.Good_Id == 0)
                    {
                        this.Alert("参数错误，修改失败!!!");
                        break;
                    }
                    if (provider.Update(stocks))
                    {
                        this.Alert("修改成功!!!");
                        this.BindText();
                    }
                    break;
            }
        }
    }
}
