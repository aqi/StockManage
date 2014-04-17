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
    public partial class SalePage : PageBase
    {

        private string id;
        private int staffinfo_id;

        #region --- 页面逻辑 ---

        private void BindText()
        {
            Sale sale = new Sale();
            sale.Sale_Id = Convert.ToInt32(id);
            SaleProvider provider = new SaleProvider();
            DataTable table = new DataTable();
            table = provider.Select(sale);

            this.txt_goodid.Text = table.Rows[0]["good_id"].ToString();
            this.txt_price.Text = table.Rows[0]["sale_price"].ToString();
            this.txt_num.Text = table.Rows[0]["sale_num"].ToString();
            this.txt_datetime.Text = table.Rows[0]["sale_datetime"].ToString();
            this.txt_buyerid.Text = table.Rows[0]["buyer_id"].ToString();
        }

        private int IsSame()
        {
            return 0;
        }

        private Sale AddSale()
        {
            Sale sale = new Sale();           
            if (Request.QueryString["id"] != null)
            {
                sale.Sale_Id = Convert.ToInt32(id);
            }
            if (Request.QueryString["staffid"] != null)
            {
                sale.Staffinfo_Id = staffinfo_id;
            }
            if (this.txt_goodid.Text == "")
                sale.Good_Id = 0;
            else
                sale.Good_Id = Convert.ToInt32(this.txt_goodid.Text);
            sale.Sale_Datetime = DateTime.Now.ToString(); ;//Convert.ToDateTime( DateTime.Now.ToString("HH:mm:ss"));
            sale.Sale_Price= this.txt_price.Text;
            sale.Sale_Num = this.txt_num.Text;
            if (this.txt_buyerid.Text == "")
                sale.Buyer_Id = 0;
            else
                sale.Buyer_Id = Convert.ToInt32(this.txt_buyerid.Text);
            sale.Good_Name = "";

            return sale;
        }

        private void TextCancel()
        {
            this.txt_goodid.Text = "";
            this.txt_datetime.Text = DateTime.Now.ToString();
            this.txt_price.Text = "";
            this.txt_num.Text = "";
            this.txt_buyerid.Text = "";
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
            if (Request.QueryString["staffid"] != null)
            {
                staffinfo_id = Convert.ToInt32(Request.QueryString["staffid"].ToString());
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
            Response.Redirect("SaleRecordManager.aspx");
        }

        protected void btn_sure_Click(object sender, EventArgs e)
        {
            Sale sales = this.AddSale();
            SaleProvider provider = new SaleProvider();
            switch (this.OperationFlag)
            {
                case Operation.Add:
                    if (sales.Good_Id == 0)
                    {
                        this.Alert("商品编号没设置，添加失败!!!");
                        break;
                    }
                    if (sales.Staffinfo_Id == 0)
                    {
                        this.Alert("员工编号为0，添加失败!!!");
                        break;
                    }
                    if (this.IsSame() == 1)
                    {
                        break;
                    }
                    if (provider.Insert(sales))
                    {
                        this.Alert("添加成功!!!");
                        this.TextCancel();
                    }
                    break;
                case Operation.Update:
                    if (sales.Good_Id == 0)
                    {
                        this.Alert("参数错误，修改失败!!!");
                        break;
                    }
                    if (provider.Update(sales))
                    {
                        this.Alert("修改成功!!!");
                        this.BindText();
                    }
                    break;
            }
        }
    }
}
