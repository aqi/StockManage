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
    public partial class UsersPage : PageBase
    {

        private string id;

        #region --- ҳ���߼� ---

        private void BindText()
        {
            Users user = new Users();
            user.User_id = Convert.ToInt32(id);
            user.User_Login = 1;
            UserProvider provider = new UserProvider();
            DataTable table = new DataTable();
            table = provider.Select(user);

            this.txt_account.Text = table.Rows[0]["user_account"].ToString();
            this.txt_email.Text = table.Rows[0]["user_email"].ToString();
            this.txt_fax.Text = table.Rows[0]["user_fax"].ToString();
            this.txt_name.Text = table.Rows[0]["user_name"].ToString();
            this.txt_pass.Text = table.Rows[0]["user_pass"].ToString();
            this.txt_phone.Text = table.Rows[0]["user_phone"].ToString();
            this.ddl_roleName.SelectedValue = table.Rows[0]["role_name"].ToString();
        }

        private int IsSame()
        {
            Users user = new Users();
            UserProvider provider = new UserProvider();
            user.User_account = this.txt_account.Text;
            DataTable table = new DataTable();
            table = provider.Select(user);
            if (table.Rows.Count != 0)
            {
                this.Alert("���˺��Ѿ����ڣ����������룡����");
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private Users AddUsers()
        {
            Users user = new Users();           
            if (Request.QueryString["id"] != null)
            {
                user.User_id = Convert.ToInt32(id);
            }
            user.User_account = this.txt_account.Text;
            user.User_datetime = Convert.ToDateTime( DateTime.Now.ToString("HH:mm:ss"));
            user.User_email = this.txt_email.Text;
            user.User_fax = this.txt_fax.Text;
            user.User_name = this.txt_name.Text;
            user.User_pass = this.txt_pass.Text;
            user.User_phone = this.txt_phone.Text;
            int prvResponse = Convert.ToInt32(Session["PRVRESPONSE"].ToString());
            if (prvResponse == 9)
            {
                user.User_Manage = 0;
                user.Role_id = Convert.ToInt32(this.ddl_roleName.SelectedValue);
            }
            else
            {
                user.User_Manage = 1;
                user.Role_id = prvResponse - 20;
            }
            return user;
        }

        private void TextCancel()
        {
            this.txt_account.Text = "";
            this.txt_email.Text = "";
            this.txt_fax.Text = "";
            this.txt_name.Text = "";
            this.txt_pass.Text = "";
            this.txt_phone.Text = "";
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
            int prvResponse = Convert.ToInt32(Session["PRVRESPONSE"].ToString());
            if (prvResponse == 9)
            {
                this.ddl_roleName.Enabled = true;
            }
            else
            {
                this.ddl_roleName.SelectedIndex = (prvResponse - 21) <= 5 ? (prvResponse - 21) : 1;
                this.ddl_roleName.Enabled = false;
            }
            
        }

      

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.TextCancel();
        }

        protected void btn_manager_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsersManager.aspx");
        }

        protected void btn_sure_Click(object sender, EventArgs e)
        {
            Users users = this.AddUsers();
            UserProvider provider = new UserProvider();
            switch (this.OperationFlag)
            {
                case Operation.Add:
                    if (users.User_account == "")
                    {
                        this.Alert("���������޸�ʧ��!!!");
                        break;
                    }
                    if (this.IsSame() == 1)
                    {
                        break;
                    }
                    if (provider.Insert(users))
                    {
                        this.Alert("��ӳɹ�!!!");
                        this.TextCancel();
                    }
                    break;
                case Operation.Update:
                    if (users.User_account == "")
                    {
                        this.Alert("���������޸�ʧ��!!!");
                        break;
                    }
                    if (provider.Update(users))
                    {
                        this.Alert("�޸ĳɹ�!!!");
                        this.BindText();
                    }
                    break;
            }
        }
    }
}
