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
    public partial class ContractPage : PageBase
    {
        private string id;

        #region --- 页面逻辑 ---

        private void BindSource()
        {
            CompanyProvider provider = new CompanyProvider();
            this.ddl_company.DataSource = provider.GetAll();
            this.ddl_company.DataBind();
        }

        private int IsSame()
        {
            Contract contract = new Contract();
            contract.Contrac__num = this.txt_num.Text;
            ContractProvider provider = new ContractProvider();
            DataTable table = new DataTable();
            table = provider.Select(contract);
            if (table.Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
            
        }

        private int IsTime()
        {
            DateTime time_start = new DateTime();
            DateTime time_end = new DateTime();
            time_start = Convert.ToDateTime(this.txt_start.Text);
            time_end = Convert.ToDateTime(this.txt_end.Text);
            if (time_end <= time_start)
            {
                return 1;
            }
            if (time_start < DateTime.Now.Date)
            {
                return 2;
            }
            return 0;
        }

        private void BindText()
        {
            Contract contract = new Contract();
            contract.Contrac_id = Convert.ToInt32(id);
            ContractProvider provider = new ContractProvider();
            DataTable table = new DataTable();
            table = provider.Select(contract);

            this.txt_start.Text = table.Rows[0]["contract_start"].ToString();
            this.ddl_company.SelectedValue = table.Rows[0]["company_id"].ToString();
            this.txt_end.Text = table.Rows[0]["contract_end"].ToString();
            this.txt_num.Text = table.Rows[0]["contrac_num"].ToString();
        }

        private Contract AddContract()
        {
            Contract contract = new Contract();
            if (Request.QueryString["id"] != null)
            {
                contract.Contrac_id = Convert.ToInt32(id);
            }
            contract.Contrac__num = this.txt_num.Text;
            contract.Company_id = Convert.ToInt32( this.ddl_company.SelectedValue);
            contract.Contract_start = Convert.ToDateTime( this.txt_start.Text);
            contract.Contract_end = Convert.ToDateTime( this.txt_end.Text);
            contract.Contrac_purpose = "";
            contract.Contrac_time = Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss"));
            contract.Contrac_mark = "";
            return contract;
        }

        private void TextCancel()
        {
            this.txt_start.Text = "";
            this.txt_end.Text = "";
            this.txt_num.Text = "";
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
            }
            if (!IsPostBack)
            {
                this.BindSource();
            }
            this.account.Text = Session["LOGINED"].ToString();
            this.datetime.Text = this.BindDayWeek();
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                this.Alert("不能修改，找不到相应记录！！！");
                return;
            }
            if (this.IsTime() == 1)
            {
                this.Alert("开始时间必须比结束时间前，请重新选择时间！");
                return ;
            }
            if (this.IsTime() == 2)
            {
                this.Alert("时间不符合逻辑！");
                return ;
            }
            Contract contract = this.AddContract();
            ContractProvider provider = new ContractProvider();
            if (provider.Update(contract))
            {
                this.Alert("修改成功!!!");
                this.BindText();
            }
        }

        protected void btn_Result_Click(object sender, EventArgs e)
        {
            Contract contract = this.AddContract();
            ContractProvider provider = new ContractProvider();
            if (this.IsSame() == 1)
            {
                this.Alert("合同号已经存在，请重新输入！");
                return ;
            }
            if (provider.Insert(contract))
            {
                this.Alert("添加成功!!!");
                this.TextCancel();
            }
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.TextCancel();
        }

        protected void btn_manager_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContractManager.aspx");
        }

        protected void Calendar_start_SelectionChanged(object sender, EventArgs e)
        {
            this.txt_start.Text = this.Calendar_start.SelectedDate.ToString();
        }

        protected void Calendar_end_SelectionChanged(object sender, EventArgs e)
        {
            this.txt_end.Text = this.Calendar_end.SelectedDate.ToString();
        }
    }
}
