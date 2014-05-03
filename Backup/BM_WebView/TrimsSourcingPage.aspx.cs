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
    public partial class TrimsSourcingPage : PageBase
    {

        #region --- Ò³ÃæÂß¼­ ---

        private void BindSource()
        {
            CompanyProvider provider = new CompanyProvider();
            this.ddl_company.DataSource = provider.GetAll();
            this.ddl_company.DataBind();
        }

        private Contract AddContract()
        {
            Contract contract = new Contract();
            contract.Contrac__num = this.txt_num.Text;
            contract.Company_id = Convert.ToInt32(this.ddl_company.SelectedValue);
            contract.Contrac_purpose = this.txt_purpose.Text;
            contract.Contrac_time = Convert.ToDateTime(this.txt_time.Text);
            contract.Contrac_mark = this.txt_mark.Text;
            contract.Contrac_state = "ÉÐÎ´¶©»õ";
            return contract;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Contract contract = new Contract();
            contract.Contrac__num = "%F%";
            ContractProvider provider = new ContractProvider();
            string size = provider.GetSize(contract).ToString();

            switch (size.Length)
            {
                case 1:
                    this.txt_num.Text = "11F000" + Convert.ToString(Convert.ToInt32(size) + 1);
                    break;
                case 2:
                    this.txt_num.Text = "11F00" + Convert.ToString(Convert.ToInt32(size) + 1);
                    break;
                case 3:
                    this.txt_num.Text = "11F0" + Convert.ToString(Convert.ToInt32(size) + 1);
                    break;
                case 4:
                    this.txt_num.Text = "11F" + Convert.ToString(Convert.ToInt32(size) + 1);
                    break;
            }
            if (!IsPostBack)
            {
                this.BindSource();
            }

            this.txt_time.Text = DateTime.Now.Date.ToString();
            this.account.Text = Session["LOGINED"].ToString();
            this.datetime.Text = this.BindDayWeek();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            this.txt_time.Text = this.Calendar1.SelectedDate.ToString();
        }

        protected void btn_result_Click(object sender, EventArgs e)
        {
            Contract contract = this.AddContract();
            ContractProvider provider = new ContractProvider();
            if (provider.Insert(contract))
            {
                string id = provider.GetSize().ToString();
                Response.Redirect("TrimsSourcing.aspx?id=" + id);
            }
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("TrimsSourcingManager.aspx");
        }
    }
}
