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
    public partial class GoodPricePage : PageBase
    {
        private string id;

        #region --- 页面逻辑 ---

        private void BindText()
        {
            Good good = new Good();
            good.Good_id = Convert.ToInt32(id);
            GoodProvider provider = new GoodProvider();
            DataTable table = new DataTable();
            table = provider.Select(good);

            this.text_Min.Text = table.Rows[0]["purchase_priceMin"].ToString();
            this.text_Max.Text = table.Rows[0]["purchase_priceMax"].ToString();
            this.txt_Name.Text = table.Rows[0]["good_name"].ToString();
            this.txt_Num.Text = table.Rows[0]["good_num"].ToString();

        }

        private Good AddGood()
        {
            Good good = new Good();
            if (Request.QueryString["id"] != null)
            {
                good.Good_id = Convert.ToInt32(id);
            }
            good.Good_name = this.txt_Name.Text;
            good.Good_Num = this.txt_Num.Text;

            if (this.text_Min.Text == "")
                good.Purchase_PriceMin = 0;
            else
                good.Purchase_PriceMin = Convert.ToInt32(this.text_Min.Text);

            if (this.text_Max.Text == "")
                good.Purchase_PriceMax = 0;
            else
                good.Purchase_PriceMax = Convert.ToInt32(this.text_Max.Text);

            return good;
        }

        private void TextCancel()
        {
            this.txt_Name.Text = "";
            this.txt_Num.Text = "";
            this.text_Min.Text = "";
            this.text_Max.Text = "";
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            this.txt_Name.Enabled = false;
            this.txt_Num.Enabled = false;

            if (Request.QueryString["id"] != null)
            {
                id = Request.QueryString["id"].ToString();
                if (!IsPostBack)
                {
                    this.BindText();
                }
                this.OperationFlag = Operation.Update;
            }

            this.account.Text = GetAccout(); //Session["LOGINED"].ToString();
            this.datetime.Text = this.BindDayWeek();
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.TextCancel();
        }

        protected void btn_manager_Click(object sender, EventArgs e)
        {
            Response.Redirect("GoodPriceManager.aspx");
        }

        protected void btn_sure_Click(object sender, EventArgs e)
        {
            Good good = this.AddGood();
            GoodProvider provider = new GoodProvider();
            switch (this.OperationFlag)
            {
                case Operation.Update:
                    if (good.Purchase_PriceMin > good.Purchase_PriceMax)
                    {
                        this.Alert("下限大于上限，请重新输入!!!!!!!!");
                        this.BindText();
                        break;
                    }
                    if (provider.UpdatePrice(good))
                    {
                        this.Alert("修改成功!!!");
                        this.BindText();
                    }

                    break;
            }
        }
    }
}
