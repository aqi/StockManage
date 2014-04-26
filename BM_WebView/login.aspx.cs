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
                Session["PASSWORD"] = user.User_pass;

                Users user1 = new Users();
                user1.User_account = Session["LOGINED"].ToString();
                user1.User_Login = 1;

                UserProvider userProvider = new UserProvider();
                DataTable table1 = userProvider.Select(user1);
                string account = table1.Rows[0]["role_name"].ToString();

                if (account.Equals("管理员"))
                {
                    Session["PRVRESPONSE"] = "9";
                    Response.Redirect("UsersManager.aspx");
                }
                else if (account.Equals("采购员"))
                {
                    Session["USERMANAGE"] = table1.Rows[0]["user_manage"].ToString();
                    Session["USERID"] = table1.Rows[0]["user_id"].ToString();
                    Session["ROLEID"] = table1.Rows[0]["role_id"].ToString();
                    Response.Redirect("StaffManager.aspx");
                }
                else if (account.Equals("销售员"))
                {
                    Session["USERMANAGE"] = table1.Rows[0]["user_manage"].ToString();
                    Session["USERID"] = table1.Rows[0]["user_id"].ToString();
                    Session["ROLEID"] = table1.Rows[0]["role_id"].ToString();
                    Response.Redirect("StaffManager.aspx");
                }
                else if (account.Equals("仓库员"))
                {
                    Session["USERMANAGE"] = table1.Rows[0]["user_manage"].ToString();
                    Session["USERID"] = table1.Rows[0]["user_id"].ToString();
                    Session["ROLEID"] = table1.Rows[0]["role_id"].ToString();
                    Response.Redirect("StaffManager.aspx");
                }
                //else if (account.Equals("采购商"))
                //{
                //    Session["USERID"] = table1.Rows[0]["user_id"].ToString();
                //    Response.Redirect("GoodManager.aspx");
                //}
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
