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
    public partial class CompanyPage : PageBase
    {

        private string id;

        #region --- 页面逻辑 ---
        private void BindText()
        {
            Company company = new Company();
            company.Company_id = Convert.ToInt32(id);
            CompanyProvider provider = new CompanyProvider();
            DataTable table = new DataTable();
            table = provider.Select(company);

            this.txt_company_address.Text = table.Rows[0]["company_address"].ToString();
            this.txt_company_cell.Text = table.Rows[0]["company_cell"].ToString();
            this.txt_company_city.Text = table.Rows[0]["company_city"].ToString();
            this.txt_company_email.Text = table.Rows[0]["company_email"].ToString();
            this.txt_company_fax.Text = table.Rows[0]["company_fax"].ToString();
            this.txt_company_manager.Text = table.Rows[0]["company_manager"].ToString();
            this.txt_company_name.Text = table.Rows[0]["company_name"].ToString();
            this.txt_company_nation.Text = table.Rows[0]["company_nation"].ToString();
            this.txt_company_num.Text = table.Rows[0]["company_num"].ToString();
            this.txt_company_phone.Text = table.Rows[0]["company_phone"].ToString();
            this.txt_company_postcode.Text = table.Rows[0]["company_postcode"].ToString();
            this.txt_company_pro.Text = table.Rows[0]["company_pro"].ToString();
        }

        private Company AddCompany()
        {
            Company company = new Company();
            if (Request.QueryString["id"] != null)
            {
                company.Company_id = Convert.ToInt32(id);
            }
            company.Company_address = this.txt_company_address.Text;
            company.Company_cell = this.txt_company_cell.Text;
            company.Company_city = this.txt_company_city.Text;
            company.Company_email = this.txt_company_email.Text;
            company.Company_fax = this.txt_company_fax.Text;
            company.Company_manager = this.txt_company_manager.Text;
            company.Company_name = this.txt_company_name.Text;
            company.Company_nation = this.txt_company_nation.Text;
            company.Company_num = Convert.ToInt32(this.txt_company_num.Text);
            company.Company_phone = this.txt_company_phone.Text;
            company.Company_postcode = this.txt_company_postcode.Text;
            company.Company_pro = this.txt_company_pro.Text;
            return company;
        }

        private int IsSame()
        {
            Company company = new Company();
            CompanyProvider provider = new CompanyProvider();
            company.Company_num = Convert.ToInt32( this.txt_company_num.Text);
            DataTable table = new DataTable();
            table = provider.Select(company);
            if (table.Rows.Count != 0)
            {
                this.Alert("该编号已经存在，请重新输入！！！");
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private void TextCancel()
        {
            this.txt_company_address.Text = "";
            this.txt_company_cell.Text = "";
            this.txt_company_city.Text = "";
            this.txt_company_email.Text = "";
            this.txt_company_fax.Text = "";
            this.txt_company_manager.Text = "";
            this.txt_company_name.Text = "";
            this.txt_company_nation.Text = "";
            this.txt_company_num.Text = "";
            this.txt_company_phone.Text = "";
            this.txt_company_postcode.Text = "";
            this.txt_company_pro.Text = "";
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
            Response.Redirect("CompanyManager.aspx");
        }

        protected void btn_sure_Click(object sender, EventArgs e)
        {
            Company company = this.AddCompany();
            CompanyProvider provider = new CompanyProvider();
            switch (this.OperationFlag)
            {
                case Operation.Add:
                    if (this.IsSame() == 1)
                    {
                        break;
                    }
                    if (provider.Insert(company))
                    {
                        this.Alert("添加成功!!!");
                        this.TextCancel();
                    }
                    break;
                case Operation.Update:
                    if (provider.Update(company))
                    {
                        this.Alert("修改成功!!!");
                        this.BindText();
                    }
                    break;
            }
        }
    }
}
