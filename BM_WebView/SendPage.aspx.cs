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
    public partial class SendPage : PageBase
    {

        private string id;

        #region --- 页面逻辑 ---
        private void BindText()
        {
            Send send = new Send();
            send.Send_id = Convert.ToInt32(id);
            SendProvider provider = new SendProvider();
            DataTable table = new DataTable();
            table = provider.Select(send);

            this.txt_name.Text = table.Rows[0]["send_name"].ToString();
        }

        private int IsSame()
        {
            Send send = new Send();
            SendProvider provider = new SendProvider();
            send.Send_name = this.txt_name.Text;
            DataTable table = new DataTable();
            table = provider.Select(send);
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

        private Send AddSend()
        {
            Send send = new Send();
            if (Request.QueryString["id"] != null)
            {
                send.Send_id = Convert.ToInt32(id);
            }
            send.Send_name = this.txt_name.Text;
            return send;
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
            Response.Redirect("SendManager.aspx");
        }

        protected void btn_sure_Click(object sender, EventArgs e)
        {
            Send send = this.AddSend();
            SendProvider provider = new SendProvider();
            switch (this.OperationFlag)
            {
                case Operation.Add:
                    if (this.IsSame() == 1)
                    {
                        break;
                    }
                    if (provider.Insert(send))
                    {
                        this.Alert("添加成功!!!");
                        this.TextCancel();
                    }
                    break;
                case Operation.Update:
                    if (provider.Update(send))
                    {
                        this.Alert("修改成功!!!");
                        this.BindText();
                    }
                    break;
            }
        }
    }
}
