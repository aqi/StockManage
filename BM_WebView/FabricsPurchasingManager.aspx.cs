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
    public partial class FabricsPurchasingManager : PageBase
    {

        #region --- ҳ���߼� ---

        /// <summary>
        ///  ��Contract��Ϣ������Դ
        /// </summary>
        private void BindSource(int start, string name)
        {
            if (name != null)
            {
                Contract contract = new Contract();
                contract.Contrac__num = name;
                ContractProvider provider = new ContractProvider();
                DataTable table = provider.Select(contract, start, this.ListPager1.PageSize);
                this.GridView1.DataSource = table.DefaultView;
                this.GridView1.DataBind();
            }
            else
            {
                Contract contract = new Contract();
                contract.Contrac__num = "%M%";
                ContractProvider provider = new ContractProvider();
                DataTable table = provider.Select(contract, start, this.ListPager1.PageSize);
                this.GridView1.DataSource = table.DefaultView;
                this.GridView1.DataBind();
            }
        }

        private void BindSource(string name)
        {
            this.BindSource(this.ListPager1.CurrentPageIndex * this.ListPager1.PageSize, name);
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Contract contract = new Contract();
                contract.Contrac__num = "%M%";
                ContractProvider provider = new ContractProvider();
                this.ListPager1.RecordCount = provider.GetSize(contract);
                this.BindSource(0, "%M%");
            }
            this.account.Text = Session["LOGINED"].ToString();
            this.datetime.Text = this.BindDayWeek();
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }

        void ListPager1_PageChange(object sender, PageEventArgs e)
        {
            if (this.txt_Name.Text == "")
            {
                this.BindSource(e.StartRecord, "%M%");
            }
            else
            {
                this.BindSource(e.StartRecord, "%" + this.txt_Name.Text + "%");
            }
        }

        protected void btn_Result_Click(object sender, EventArgs e)
        {
            Contract contract = new Contract();
            contract.Contrac__num = "%" + this.txt_Name.Text + "%";
            ContractProvider provider = new ContractProvider();
            this.ListPager1.RecordCount = provider.GetSize(contract);
            this.BindSource(0, "%" + this.txt_Name.Text + "%");
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("receiving"))
            {
                ContractProvider provider = new ContractProvider();
                provider.Update(this.GridView1.DataKeys[rowIndex].Value.ToString(), "���ύ");
                this.BindSource(0, "%M%");
            }
            if (e.CommandName.Equals("shop"))
            {
                Response.Redirect("ContractShopManager.aspx?id=" + this.GridView1.DataKeys[rowIndex].Value.ToString());
            }
            if (e.CommandName.Equals("add"))
            {
                Contract contract = new Contract();
                contract.Contrac_id = Convert.ToInt32(this.GridView1.DataKeys[rowIndex].Value);
                contract.Contrac_state = "���ύ";
                ContractProvider provider = new ContractProvider();
                DataTable table = provider.Select(contract);
                if (table.Rows.Count != 0)
                {
                    this.Alert("���������Ʒ�ˣ��Ѿ�ȷ�϶����ˣ�����");
                    return;
                }
                Response.Redirect("FabricsPurchasing.aspx?id=" + this.GridView1.DataKeys[rowIndex].Value.ToString());
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal
                   || e.Row.RowState == DataControlRowState.Alternate)
                {
                    //�����ͣ��ʱ���ı���ɫ
                    e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#00A9FF'");
                    //������ƿ�ʱ��ԭ����ɫ
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");

                    ((LinkButton)e.Row.Cells[9].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('��ȷ��Ҫɾ����ͬ:" + e.Row.Cells[0].Text + " ����Ϣ��?')");
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;

            Contract contract = new Contract();
            contract.Contrac_id = Convert.ToInt32(this.GridView1.DataKeys[rowIndex].Value);

            ContractProvider provider = new ContractProvider();
            if (provider.Delete(contract))
            {
                this.Alert("ɾ���ɹ�!!!");

                if (this.txt_Name.Text == "")
                {
                    this.ListPager1.RecordCount = this.ListPager1.RecordCount - 1;
                    this.BindSource("%M%");
                }
                else
                {
                    this.ListPager1.RecordCount = this.ListPager1.RecordCount - 1;
                    this.BindSource(this.txt_Name.Text);
                }

            }
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("FabricsPurchasingPage.aspx");
        }
    }
}
