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
    public partial class FreightPage : PageBase
    {

        private string id;

        #region --- 页面逻辑 ---
        private void BindText()
        {
            Freight freight = new Freight();
            freight.Freight_id = Convert.ToInt32(id);
            FreightProvider provider = new FreightProvider();
            DataTable table = new DataTable();
            table = provider.Select(freight);

            this.txt_name.Text = table.Rows[0]["freight_name"].ToString();
        }

        private int IsSame()
        {
            Freight freight = new Freight();
            FreightProvider provider = new FreightProvider();
            freight.Freight_name = this.txt_name.Text;
            DataTable table = new DataTable();
            table = provider.Select(freight);
            if (table.Rows.Count != 0)
            {
                this.Alert("该方式已经存在，请重新输入！！！");
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private Freight AddFreight()
        {
            Freight freight = new Freight();
            if (Request.QueryString["id"] != null)
            {
                freight.Freight_id = Convert.ToInt32(id);
            }
            freight.Freight_name = this.txt_name.Text;
            return freight;
        }

        private void TextCancel()
        {
            this.txt_name.Text = "";
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
            Response.Redirect("FreightManager.aspx");
        }

        protected void btn_sure_Click(object sender, EventArgs e)
        {
            Freight freight = this.AddFreight();
            FreightProvider provider = new FreightProvider();
            switch (this.OperationFlag)
            {
                case Operation.Add:
                    if (this.IsSame() == 1)
                    {
                        break;
                    }
                    if (provider.Insert(freight))
                    {
                        this.Alert("添加成功!!!");
                        this.TextCancel();
                    }
                    break;
                case Operation.Update:
                    if (provider.Update(freight))
                    {
                        this.Alert("修改成功!!!");
                        this.BindText();
                    }
                    break;
            }
        }
    }
}
