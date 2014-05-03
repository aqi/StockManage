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
    public partial class GoodPriceManager : PageBase
    {

        #region --- ҳ���߼� ---
   
        /// <summary>
        ///  ��good��Ϣ������Դ
        /// </summary>
        private void BindSource(int start, string name)
        {
            if (name != null)
            {
                Good good = new Good();
                good.Good_name = name;
                GoodProvider provider = new GoodProvider();
                DataTable table = provider.Select(good, start, this.ListPager1.PageSize);
                this.GridView1.DataSource = table.DefaultView;
                this.GridView1.DataBind();
            }
            else
            {
                GoodProvider provider = new GoodProvider();
                DataTable table = provider.GetAll(start, this.ListPager1.PageSize);
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
                this.GridView1.Columns[5].Visible = false;
                GoodProvider provider = new GoodProvider();
                this.ListPager1.RecordCount = provider.GetSize();
                this.BindSource(0, null);
            }
            this.account.Text = GetAccout(); //Session["LOGINED"].ToString();
            this.datetime.Text = this.BindDayWeek();
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }

        void ListPager1_PageChange(object sender, PageEventArgs e)
        {
            if (this.txt_Position.Text == "")
            {
                this.BindSource(e.StartRecord, null);
            }
            else
            {
                this.BindSource(e.StartRecord, "%" + this.txt_Position.Text + "%");
            }
        }

        protected void btn_Result_Click(object sender, EventArgs e)
        {
            Good good = new Good();
            GoodProvider provider = new GoodProvider();
            if (this.txt_Position.Text == "")
            {
                GoodProvider providers = new GoodProvider();
                this.ListPager1.RecordCount = providers.GetSize();
                this.BindSource(0, null);
            }
            else
            {
                good.Good_name = "%" + this.txt_Position.Text + "%";
                DataTable table = provider.Select(good, 0, this.ListPager1.RecordCount);
                this.GridView1.DataSource = table.DefaultView;
                this.GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName.Equals("details"))
            {
                Response.Redirect("GoodPricePage.aspx?id=" + this.GridView1.DataKeys[rowIndex].Value.ToString());
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

                    //((LinkButton)e.Row.Cells[5].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('��ȷ��Ҫɾ����Ʒ:" + e.Row.Cells[0].Text + " ����Ϣ��?')");
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            int rowIndex = e.RowIndex;

            Good good = new Good();
            good.Good_id = Convert.ToInt32(this.GridView1.DataKeys[rowIndex].Value);

            GoodProvider provider = new GoodProvider();
            if (provider.Delete(good))
            {
                this.Alert("ɾ���ɹ�!!!");

                if (this.txt_Position.Text == "")
                {
                    this.ListPager1.RecordCount = this.ListPager1.RecordCount - 1;
                    this.BindSource(null);
                }
                else
                {
                    this.ListPager1.RecordCount = this.ListPager1.RecordCount - 1;
                    this.BindSource("%" + this.txt_Position.Text + "%");
                }

            }
             
        }

    }
 
}
