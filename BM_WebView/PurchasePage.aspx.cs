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
    public partial class PurchasePage : PageBase
    {
        private string good_name;
        private int max;
        private int min;
        private string id;
        private int staffinfo_id = 0;

        #region --- ҳ���߼� ---

        private void BindText()
        {
            Purchase purchase = new Purchase();
            purchase.Purchase_Id = Convert.ToInt32(id);
            PurchaseProvider provider = new PurchaseProvider();
            DataTable table = new DataTable();
            table = provider.Select(purchase);

            this.ddl_GoodId.SelectedIndex = this.ddl_GoodId.Items.IndexOf(this.ddl_GoodId.Items.FindByValue(table.Rows[0]["good_id"].ToString()));
            this.txt_price.Text = table.Rows[0]["purchase_price"].ToString();
            this.txt_num.Text = table.Rows[0]["purchase_num"].ToString();
            this.txt_datetime.Text = table.Rows[0]["purchase_datetime"].ToString();//DateTime.Now.ToString();//table.Rows[0]["purchase_datetime"].ToString();
            this.ddl_supplierid.SelectedIndex = this.ddl_supplierid.Items.IndexOf(this.ddl_supplierid.Items.FindByValue(table.Rows[0]["supplier_id"].ToString()));
            this.txt_goodname.Text = table.Rows[0]["good_name"].ToString();
        }

        private int IsSame()
        {
            return 0;
        }

        private bool IsRang()
        {
            int min = Convert.ToInt32(Good_Record.Rows[this.ddl_GoodId.SelectedIndex]["purchase_priceMin"].ToString());
            int max = Convert.ToInt32(Good_Record.Rows[this.ddl_GoodId.SelectedIndex]["purchase_priceMax"].ToString());
            
            int value = 0;
            if (this.txt_price.Text != "")
            {
                value = Convert.ToInt32(this.txt_price.Text);
            }
            if (value < min || value > max)
            {
                string WarningMessage = "�ɹ�ֵ��ΧΪ:(" + min.ToString() + " - " + max.ToString() + ")!!!!!!";
                this.Alert(WarningMessage);
                return false;
            }
            return true;
        }
        private Purchase AddPurchase()
        {
            Purchase purchase = new Purchase();           
            if (Request.QueryString["id"] != null)
            {
                purchase.Purchase_Id = Convert.ToInt32(id);
            }
            if (Request.QueryString["staffid"] != null)
            {
                purchase.Staffinfo_Id = staffinfo_id;
            }
            
            if (this.ddl_GoodId.SelectedValue.ToString() == "")
            {
                purchase.Good_Id = 0;
            }
            else
            {
                purchase.Good_Id = Convert.ToInt32(this.ddl_GoodId.SelectedValue.ToString());
            }
            purchase.Purchase_Datetime = DateTime.Now.ToString("yyyyMMdd");//Convert.ToDateTime( DateTime.Now.ToString("HH:mm:ss"));
            purchase.Purchase_Price= this.txt_price.Text;
            purchase.Purchase_Num = this.txt_num.Text;
            purchase.Good_Name = this.txt_goodname.Text;
            if (this.ddl_supplierid.SelectedValue.ToString() == "")
            {
                purchase.Supplier_Id = 0;
            }
            else
            {
                purchase.Supplier_Id = Convert.ToInt32(this.ddl_supplierid.SelectedValue.ToString());
            }
            purchase.Year_Month = Convert.ToInt32(purchase.Purchase_Datetime.Substring(0, 6));

            return purchase;
        }

        private void TextCancel()
        {
            this.ddl_GoodId.SelectedIndex = -1;
            this.txt_datetime.Text = DateTime.Now.ToString("yyyyMMdd"); ;
            this.txt_price.Text = "";
            this.txt_goodname.Text = Good_Record.Rows[0]["good_name"].ToString();
            this.txt_num.Text = "";
            this.ddl_GoodId.SelectedIndex = -1;
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
                this.txt_datetime.Text = DateTime.Now.ToString("yyyyMMdd");
            }

            if (!IsPostBack)
            {
                this.ddl_GoodId.DataSource = Good_Record;
                this.ddl_GoodId.Width = 100;
                this.ddl_GoodId.DataValueField = "good_num";
                this.ddl_GoodId.DataBind();
                this.ddl_supplierid.DataSource = Supplier_Record;
                this.ddl_supplierid.Width = 100;
                this.ddl_supplierid.DataValueField = "supplier_id";
                this.ddl_supplierid.DataBind();

                this.lbl_PriceRange.Text ="�ɹ���Χ��" +  Good_Record.Rows[0]["purchase_priceMin"].ToString() + " - " + Good_Record.Rows[0]["purchase_priceMax"].ToString();
                this.txt_goodname.Text = Good_Record.Rows[0]["good_name"].ToString();
            }
            if (Request.QueryString["staffid"] != null)
            {
                staffinfo_id = Convert.ToInt32(Request.QueryString["staffid"].ToString());
            }
            this.txt_datetime.Enabled = false;
            this.txt_goodname.Enabled = false;
            this.account.Text = GetAccout();
            this.datetime.Text = this.BindDayWeek();                     
        }

      

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.TextCancel();
        }

        protected void btn_manager_Click(object sender, EventArgs e)
        {
            Response.Redirect("PurchaseRecordManager.aspx");
        }

        protected void btn_sure_Click(object sender, EventArgs e)
        {
            Purchase purchases = this.AddPurchase();
            PurchaseProvider provider = new PurchaseProvider();
            switch (this.OperationFlag)
            {
                case Operation.Add:
                    if (purchases.Good_Id == 0)
                    {
                        this.Alert("��Ʒ���û���ã����ʧ��!!!");
                        break;
                    }
                    if (purchases.Staffinfo_Id == 0)
                    {
                        this.Alert("Ա�����Ϊ0�����ʧ��!!!");
                        break;
                    }
                    if (this.IsSame() == 1)
                    {
                        break;
                    }
                    if (this.IsRang() == false)
                    {
                        break;
                    }

                    if (provider.Insert(purchases))
                    {
                        StockProvider stockProvider = new StockProvider();
                        Stock stock = new Stock();

                        stock.Stock_Num = purchases.Purchase_Num;
                        stock.Good_Id = purchases.Good_Id;
                        stock.Stock_Oper = 1;
                        stock.Staffinfo_Id = purchases.Staffinfo_Id;
                        stock.Purchase_Price = purchases.Purchase_Price;
                        stock.Purchase_Datetime = DateTime.Now.ToString("yyyyMMdd");

                        if (stockProvider.Insert(stock))
                        {
                            this.Alert("��ӳɹ�!!!");
                            this.TextCancel();
                        }
                    }
                    break;
                case Operation.Update:
                    if (purchases.Good_Id == 0)
                    {
                        this.Alert("���������޸�ʧ��!!!");
                        break;
                    }
                    if (this.IsRang() == false)
                    {
                        break;
                    }
                    if (provider.Update(purchases))
                    {
                        this.Alert("�޸ĳɹ�!!!");
                        this.BindText();
                    }
                    break;
            }
        }

        protected void ddl_GoodId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Good good = new Good();
            GoodProvider provider = new GoodProvider();

            good.Good_Num = this.ddl_GoodId.SelectedValue.ToString();

            DataTable table = provider.Select(good);

            if (table != null && table.Rows.Count == 1)
            {
                good_name = table.Rows[0]["good_name"].ToString();
                max = Convert.ToInt32(table.Rows[0]["purchase_priceMax"].ToString());
                min = Convert.ToInt32(table.Rows[0]["purchase_priceMin"].ToString());
            }

            this.lbl_PriceRange.Text = "�ɹ���Χ��" +  min.ToString() + " - " + max.ToString();
            this.txt_goodname.Text = good_name;
            this.txt_goodname.Enabled = false;
        }
    }
}
