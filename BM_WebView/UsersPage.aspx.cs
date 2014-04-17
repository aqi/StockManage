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

        #region --- 页面逻辑 ---

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
            this.cbox_manageFlag.Checked = table.Rows[0]["user_manage"].ToString() == "1" ? true : false;
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
                this.Alert("该账号已经存在，请重新输入！！！");
                return 1;
            }
            else
            {
                return 0;
            }
        }
        private Staff AddStaff(Users user)
        {
            Staff staff = new Staff();

            if (user.User_id == 0)
            {
                UserProvider provider = new UserProvider();
                user.User_id = provider.GetUserId(user.User_account);
            }
            staff.Role_id = user.Role_id;
            staff.User_id = user.User_id;
            staff.Staffinfo_position = user.User_Manage == 1 ? "经理" : "普通";
            staff.Staffinfo_Name = user.User_name;
            staff.Staffinfo_cell = "";
            staff.Staffinfo_sex = "男";
            
            return staff;
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
            user.User_Manage = Convert.ToInt32(this.cbox_manageFlag.Checked);
            //int prvResponse = Convert.ToInt32(Session["PRVRESPONSE"].ToString());
            user.Role_id = Convert.ToInt32(this.ddl_roleName.SelectedValue);

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
            this.cbox_manageFlag.Checked = false;
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
            //int prvResponse = Convert.ToInt32(Session["PRVRESPONSE"].ToString());
            //if (prvResponse == 9)
            //{
            //    this.ddl_roleName.Enabled = true;
            //}
            //else
            //{
            //    this.ddl_roleName.SelectedIndex = (prvResponse - 21) <= 5 ? (prvResponse - 21) : 1;
            //    this.ddl_roleName.Enabled = false;
            //}
            
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
                        this.Alert("参数错误，修改失败!!!");
                        break;
                    }
                    if (this.IsSame() == 1)
                    {
                        break;
                    }
                    if (provider.Insert(users))
                    {
                        Staff staff = new Staff();

                        staff = this.AddStaff(users);

                        if (staff.User_id == 0)
                        {
                            provider.Delete(users);
                            this.Alert("user_id为0，添加失败");
                        }

                        StaffProvider staffProvider = new StaffProvider();
                        if (staffProvider.Insert(staff))
                        {
                            this.Alert("添加成功!!!");
                            this.TextCancel();
                        }
                        else
                        {
                            provider.Delete(users);
                        }
                    }
                    break;
                case Operation.Update:
                    if (users.User_account == "")
                    {
                        this.Alert("参数错误，修改失败!!!");
                        break;
                    }
                    if (provider.Update(users))
                    {
                        Staff staff = new Staff();

                        staff = this.AddStaff(users);

                        if (staff.User_id == 0)
                        {
                            provider.Delete(users);
                            this.Alert("user_id为0，修改失败");
                        }

                        StaffProvider staffProvider = new StaffProvider();

                        int staffinfo_id = staffProvider.GetStaffinfoId(staff.User_id);
                        if (staffinfo_id == 0)
                        {
                            if (staffProvider.Insert(staff))
                            {
                                this.Alert("修改成功!!!");
                            }
                            else
                            {
                                this.Alert("修改失败!!!");
                            }
                        }
                        else
                        {
                            staff.Staffinfo_id = staffinfo_id;
                            if (staffProvider.Update(staff))
                            {
                                this.Alert("修改成功!!!");
                                this.BindText();
                            }
                            else
                            {
                                this.Alert("修改失败!!!");
                            }
                        }
                        this.BindText();
                    }
                    break;
            }
        }
    }
}
