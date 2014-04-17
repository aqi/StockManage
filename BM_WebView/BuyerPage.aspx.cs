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
    public partial class BuyerPage : PageBase
    {

        private string id;

        #region --- 页面逻辑 ---

        private void BindText()
        {
           Buyer buyer= new Buyer();
            buyer.Buyer_Id = Convert.ToInt32(id);
            BuyerProvider provider = new BuyerProvider();
            DataTable table = new DataTable();
            table = provider.Select(buyer);

            this.txt_name.Text = table.Rows[0]["buyer_name"].ToString();
            this.txt_address.Text = table.Rows[0]["Buyer_address"].ToString();
            this.txt_postcode.Text = table.Rows[0]["Buyer_postcode"].ToString();
            this.txt_cell.Text = table.Rows[0]["Buyer_cell"].ToString();
            this.txt_phone.Text = table.Rows[0]["Buyer_phone"].ToString();
            this.txt_fax.Text = table.Rows[0]["Buyer_fax"].ToString();
            this.txt_email.Text = table.Rows[0]["Buyer_email"].ToString();
            this.txt_liaison.Text = table.Rows[0]["Buyer_liaison"].ToString();
        }

        private int IsSame()
        {
            return 0;
        }

        private Buyer AddBuyer()
        {
           Buyer buyer= new Buyer();           
            if (Request.QueryString["id"] != null)
            {
                buyer.Buyer_Id = Convert.ToInt32(id);
            }

            buyer.Buyer_Name = this.txt_name.Text;
            buyer.Buyer_Address = this.txt_address.Text;
            buyer.Buyer_Postcode = this.txt_postcode.Text;
            buyer.Buyer_Cell = this.txt_cell.Text;
            buyer.Buyer_Phone = this.txt_phone.Text;
            buyer.Buyer_Fax = this.txt_fax.Text;
            buyer.Buyer_Email = this.txt_email.Text;
            buyer.Buyer_Liaison = this.txt_liaison.Text;

            return buyer;
        }

        private void TextCancel()
        {
            this.txt_name.Text = "";
            this.txt_address.Text = "";
            this.txt_postcode.Text = "";
            this.txt_cell.Text = "";
            this.txt_phone.Text = "";
            this.txt_fax.Text = "";
            this.txt_email.Text = "";
            this.txt_liaison.Text = "";
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
            this.account.Text = Session["LOGINED"].ToString();
            this.datetime.Text = this.BindDayWeek();
        }

      

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.TextCancel();
        }

        protected void btn_manager_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuyerManager.aspx");
        }

        protected void btn_sure_Click(object sender, EventArgs e)
        {
            Buyer buyer = this.AddBuyer();
            BuyerProvider provider = new BuyerProvider();
            switch (this.OperationFlag)
            {
                case Operation.Add:
                    if (buyer.Buyer_Name == "" || buyer.Buyer_Liaison == "")
                    {
                        this.Alert("采购商名或联系人不能为空，添加失败!!!");
                        break;
                    }
                    if (this.IsSame() == 1)
                    {
                        break;
                    }
                    if (provider.Insert(buyer))
                    {
                        this.Alert("添加成功!!!");
                        this.TextCancel();
                    }
                    break;
                case Operation.Update:
                    if (buyer.Buyer_Name == "" || buyer.Buyer_Liaison == "")
                    {
                        this.Alert("采购商商名或联系人不能为空，修改失败!!!");
                        break;
                    }
                    if (provider.Update(buyer))
                    {
                        this.Alert("修改成功!!!");
                        this.BindText();
                    }
                    break;
            }
        }
    }
}
