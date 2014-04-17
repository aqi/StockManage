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

        private string id;
        private int staffinfo_id = 0;

        #region --- 页面逻辑 ---

        private void BindText()
        {
            Purchase purchase = new Purchase();
            purchase.Purchase_Id = Convert.ToInt32(id);
            PurchaseProvider provider = new PurchaseProvider();
            DataTable table = new DataTable();
            table = provider.Select(purchase);

            this.txt_goodid.Text = table.Rows[0]["good_id"].ToString();
            this.txt_price.Text = table.Rows[0]["purchase_price"].ToString();
            this.txt_num.Text = table.Rows[0]["purchase_num"].ToString();
            this.txt_datetime.Text = table.Rows[0]["purchase_datetime"].ToString();//DateTime.Now.ToString();//table.Rows[0]["purchase_datetime"].ToString();
            this.txt_supplierid.Text = table.Rows[0]["supplier_id"].ToString();
        }

        private int IsSame()
        {
            return 0;
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
            if (this.txt_goodid.Text == "")
                purchase.Good_Id = 0;
            else
                purchase.Good_Id = Convert.ToInt32(this.txt_goodid.Text);
            purchase.Purchase_Datetime = DateTime.Now.ToString();//Convert.ToDateTime( DateTime.Now.ToString("HH:mm:ss"));
            purchase.Purchase_Price= this.txt_price.Text;
            purchase.Purchase_Num = this.txt_num.Text;
            if (this.txt_supplierid.Text == "")
                purchase.Supplier_Id = 0;
            else
                purchase.Supplier_Id = Convert.ToInt32(this.txt_supplierid.Text);
            purchase.Good_Name = "";

            return purchase;
        }

        private void TextCancel()
        {
            this.txt_goodid.Text = "";
            this.txt_datetime.Text = DateTime.Now.ToString();
            this.txt_price.Text = "";
            this.txt_num.Text = "";
            this.txt_supplierid.Text = "";
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
                        this.Alert("商品编号没设置，添加失败!!!");
                        break;
                    }
                    if (purchases.Staffinfo_Id == 0)
                    {
                        this.Alert("员工编号为0，添加失败!!!");
                        break;
                    }
                    if (this.IsSame() == 1)
                    {
                        break;
                    }
                    if (provider.Insert(purchases))
                    {
                        this.Alert("添加成功!!!");
                        this.TextCancel();
                    }
                    break;
                case Operation.Update:
                    if (purchases.Good_Id == 0)
                    {
                        this.Alert("参数错误，修改失败!!!");
                        break;
                    }
                    if (provider.Update(purchases))
                    {
                        this.Alert("修改成功!!!");
                        this.BindText();
                    }
                    break;
            }
        }
    }
}
