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
    public partial class CustomersPage : PageBase
    {

        private string id;

        #region --- 页面逻辑 ---
        private void BindText()
        {
            Customers customer = new Customers();
            customer.Customers_id = Convert.ToInt32(id);
            CustomersProvider provider = new CustomersProvider();
            DataTable table = new DataTable();
            table = provider.Select(customer);

            this.txt_address.Text = table.Rows[0]["customers_address"].ToString();
            this.txt_code.Text = table.Rows[0]["customers_code"].ToString();
            this.txt_fax.Text = table.Rows[0]["customers_fax"].ToString();
            this.txt_name.Text = table.Rows[0]["customers_name"].ToString();
            this.txt_network_address.Text = table.Rows[0]["customers_network_address"].ToString();
            this.txt_one_cell.Text = table.Rows[0]["customers_person_one_cell"].ToString();
            this.txt_one_email.Text = table.Rows[0]["customers_person_one_email"].ToString();
            this.txt_person_one.Text = table.Rows[0]["customers_person_one"].ToString();
            this.txt_person_two.Text = table.Rows[0]["customers_person_two"].ToString();
            this.txt_phone.Text = table.Rows[0]["customers_phone"].ToString();
            this.txt_region.Text = table.Rows[0]["customers_region"].ToString();
            this.txt_telephone.Text = table.Rows[0]["customers_telephone"].ToString();
            this.txt_two_cell.Text = table.Rows[0]["customers_person_two_cell"].ToString();
            this.txt_two_email.Text = table.Rows[0]["customers_person_two_email"].ToString();
            this.txt_type.Text = table.Rows[0]["customers_type"].ToString();
        }

        private Customers AddCustomers()
        {
            Customers customer = new Customers();
            if (Request.QueryString["id"] != null)
            {
                customer.Customers_id = Convert.ToInt32(id);
            }
            customer.Customers_address = this.txt_address.Text;
            customer.Customers_code = this.txt_code.Text;
            customer.Customers_fax = this.txt_fax.Text;
            customer.Customers_name = this.txt_name.Text;
            customer.Customers_network_address = this.txt_network_address.Text;
            customer.Customers_person_one_cell = this.txt_one_cell.Text;
            customer.Customers_person_one_email = this.txt_one_email.Text;
            customer.Customers_person_one = this.txt_person_one.Text;
            customer.Customers_person_two = this.txt_person_two.Text;
            customer.Customers_phone = this.txt_phone.Text;
            customer.Customers_region = this.txt_region.Text;
            customer.Customers_telephone = this.txt_telephone.Text;
            customer.Customers_person_two_cell = this.txt_two_cell.Text;
            customer.Customers_person_two_email = this.txt_two_email.Text;
            customer.Customers_type = this.txt_type.Text;
            return customer;
        }

        private void TextCancel()
        {
            this.txt_address.Text = "";
            this.txt_code.Text = "";
            this.txt_fax.Text = "";
            this.txt_name.Text = "";
            this.txt_network_address.Text = "";
            this.txt_one_cell.Text = "";
            this.txt_one_email.Text = "";
            this.txt_person_one.Text = "";
            this.txt_person_two.Text = "";
            this.txt_phone.Text = "";
            this.txt_region.Text = "";
            this.txt_telephone.Text = "";
            this.txt_two_cell.Text = "";
            this.txt_two_email.Text = "";
            this.txt_type.Text = "";
        }

        private int IsSame()
        {
            Customers customer = this.AddCustomers();
            CustomersProvider provider = new CustomersProvider();
            customer.Customers_code = this.txt_code.Text;
            DataTable table = new DataTable();
            table = provider.Select(customer);
            if (table.Rows.Count != 0)
            {
                this.Alert("该客户代码已经存在，请重新输入！！！");
                return 1;
            }
            else
            {
                return 0;
            }
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
            Response.Redirect("CustomersManager.aspx");
        }

        protected void btn_sure_Click(object sender, EventArgs e)
        {
            Customers customer = this.AddCustomers();
            CustomersProvider provider = new CustomersProvider();
            switch (this.OperationFlag)
            {
                case Operation.Add:
                    if (this.IsSame() == 1)
                    {
                        break;
                    }
                    if (provider.Insert(customer))
                    {
                        this.Alert("添加成功!!!");
                    }
                    break;
                case Operation.Update:
                    if (provider.Update(customer))
                    {
                        this.Alert("修改成功!!!");
                        this.BindText();
                    }
                    break;
            }
        }
    }
}
