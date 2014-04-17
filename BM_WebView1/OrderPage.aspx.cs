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
    public partial class OrderPage : PageBase
    {

        private string id;
        private string buyer_id;

        #region --- 页面逻辑 ---

        private void BindText()
        {
            Order order = new Order();
            order.Order_id = Convert.ToInt32(id);
            OrderProvider provider = new OrderProvider();
            DataTable table = new DataTable();
            table = provider.Select(order);

            this.txt_goodid.Text = table.Rows[0]["good_id"].ToString();
            this.txt_goodname.Text = table.Rows[0]["good_name"].ToString();
            this.txt_price.Text = table.Rows[0]["sale_price"].ToString();
            this.txt_num.Text = table.Rows[0]["good_num"].ToString();
            this.txt_buyeraddress.Text = table.Rows[0]["buyer_address"].ToString();
            this.txt_buyerpostcode.Text = table.Rows[0]["buyer_postcode"].ToString();
            this.txt_buyerliason.Text = table.Rows[0]["buyer_liaison"].ToString();
            this.txt_buyercell.Text = table.Rows[0]["buyer_cell"].ToString();
            this.txt_sum.Text = table.Rows[0]["order_price"].ToString();
        }

        private int IsSame()
        {
            return 0;
        }

        private Order AddOrder()
        {
            Order order = new Order();           
            if (Request.QueryString["id"] != null)
            {
                order.Order_id = Convert.ToInt32(id);
            }

            if (this.txt_goodid.Text == "")
                order.Good_Id = 0;
            else
                order.Good_Id = Convert.ToInt32(this.txt_goodid.Text);
            if (Request.QueryString["buyerid"] != null)
            {
                order.Buyer_Id = Convert.ToInt32(buyer_id);
            }
            order.Good_Name = this.txt_goodname.Text;
            order.Sale_Price = this.txt_price.Text;
            order.Good_Num = this.txt_num.Text;
            order.Buyer_Address = this.txt_num.Text;
            order.Buyer_Postcode = this.txt_buyerpostcode.Text;
            order.Buyer_Liaison = this.txt_buyerliason.Text;
            order.Buyer_Cell = this.txt_buyercell.Text;
            order.Order_Price = this.txt_sum.Text;
            return order;
        }

        private void TextCancel()
        {
            this.txt_goodid.Text = "";
            this.txt_goodname.Text = "";
            this.txt_price.Text = "";
            this.txt_num.Text = "";
            this.txt_buyeraddress.Text = "";
            this.txt_buyerpostcode.Text = "";
            this.txt_buyerliason.Text = "";
            this.txt_buyercell.Text = "";
            this.txt_sum.Text = "";
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

            if (Request.QueryString["buyerid"] != null)
            {
                buyer_id = Request.QueryString["buyerid"].ToString();
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
            Response.Redirect("OrderManager.aspx");
        }

        protected void btn_sure_Click(object sender, EventArgs e)
        {
            Order orders = this.AddOrder();
            OrderProvider provider = new OrderProvider();
            switch (this.OperationFlag)
            {
                case Operation.Add:
                    if (orders.Good_Id == 0)
                    {
                        this.Alert("商品编号没设置，添加失败!!!");
                        break;
                    }
                    if (this.IsSame() == 1)
                    {
                        break;
                    }
                    if (provider.Insert(orders))
                    {
                        this.Alert("添加成功!!!");
                        this.TextCancel();
                    }
                    break;
                case Operation.Update:
                    if (orders.Good_Id == 0)
                    {
                        this.Alert("参数错误，修改失败!!!");
                        break;
                    }
                    if (provider.Update(orders))
                    {
                        this.Alert("修改成功!!!");
                        this.BindText();
                    }
                    break;
            }
        }
    }
}
