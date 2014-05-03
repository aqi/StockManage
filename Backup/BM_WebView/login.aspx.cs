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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ibt_login_Click(object sender, ImageClickEventArgs e)
        {
            if (this.txt_name.Text == "" || this.txt_passWord.Text == "")
            {
                Response.Write("<script>alert('帐号和密码不能为空!!')</script>");
                return;
            }

            Users user=new Users();
            user.User_account=this.txt_name.Text.ToLower();
            user.User_pass=this.txt_passWord.Text.ToLower();

            UserProvider provider = new UserProvider();
            bool result = provider.Login(user);
            if (result)
            {
                Session["LOGINED"] = this.txt_name.Text;
                
                Users user1 = new Users();
                user1.User_account = Session["LOGINED"].ToString();
                UserProvider userProvider = new UserProvider();
                DataTable table1 = userProvider.Select(user1);
                string account = table1.Rows[0]["role_name"].ToString();
                if (account.Equals("管理员"))
                {
                    Response.Redirect("SendManager.aspx");
                }
                else if (account.Equals("采购员"))
                {
                    Response.Redirect("FabricsPurchasingManager.aspx");
                }
                else if (account.Equals("销售员"))
                {
                    Response.Redirect("FabricSalesManager.aspx");
                }
                else if (account.Equals("仓库员"))
                {
                    Response.Redirect("SendManager.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('登陆失败!!')</script>");
            }
        }

        protected void ibt_cancel_Click(object sender, ImageClickEventArgs e)
        {
            this.txt_name.Text = "";
            this.txt_passWord.Text = "";
        }
    }
}
