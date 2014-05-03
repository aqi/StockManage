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
    public partial class AccessoriesSalesPage : PageBase
    {

        #region --- Ò³ÃæÂß¼­ ---

        private void BindSource()
        {
            FreightProvider freight = new FreightProvider();
            this.ddl_freight.DataSource = freight.GetAll();
            this.ddl_freight.DataBind();
            SendProvider send = new SendProvider();
            this.ddl_send.DataSource = send.GetAll();
            this.ddl_send.DataBind();
            CustomersProvider customers = new CustomersProvider();
            this.ddl_customers.DataSource = customers.GetAll();
            this.ddl_customers.DataBind();
        }

        private Order AddOrder()
        {
            Order order = new Order();
            order.Customers_id = Convert.ToInt32(this.ddl_customers.SelectedValue);
            order.Order_num = this.txt_num.Text;
            order.Order_purpose = this.txt_purpose.Text;
            order.Freight_id = Convert.ToInt32(this.ddl_freight.SelectedValue);
            order.Send_id = Convert.ToInt32(this.ddl_send.SelectedValue);
            order.Order_acceptadd = this.txt_acceptadd.Text;
            order.Order_whether_charges = this.ddl_whether_charges.SelectedValue.ToString();
            order.Order_mark = this.txt_mark.Text;
            order.Order_state = "Î´·¢»õ";
            return order;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindSource();
            }
            Order order = new Order();
            order.Order_num = "%F%";
            OrderProvider customers = new OrderProvider();
            string size = customers.GetSize(order).ToString();
            switch (size.Length)
            {
                case 1:
                    this.txt_num.Text = "F11000" + Convert.ToString(Convert.ToInt32(size) + 1);
                    break;
                case 2:
                    this.txt_num.Text = "F1100" + Convert.ToString(Convert.ToInt32(size) + 1);
                    break;
                case 3:
                    this.txt_num.Text = "F110" + Convert.ToString(Convert.ToInt32(size) + 1);
                    break;
                case 4:
                    this.txt_num.Text = "F11" + Convert.ToString(Convert.ToInt32(size) + 1);
                    break;
            }
            this.account.Text = Session["LOGINED"].ToString();
            this.datetime.Text = this.BindDayWeek();
        }

        protected void btn_result_Click(object sender, EventArgs e)
        {
            Order order = this.AddOrder();
            OrderProvider provider = new OrderProvider();
            if (provider.Insert(order))
            {
                string id = provider.GetSize().ToString();
                Response.Redirect("AccessoriesSales .aspx?id=" + id);
            }
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccessoriesSalesManager.aspx");
        }
    }
}
