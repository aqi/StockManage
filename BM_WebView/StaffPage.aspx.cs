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
    public partial class StaffPage : PageBase
    {

        private string id;

        #region --- ҳ���߼� ---
        private void BindText()
        {
            Staff staff = new Staff();
            staff.Staffinfo_id = Convert.ToInt32(id);
            StaffProvider provider = new StaffProvider();
            DataTable table = new DataTable();
            table = provider.Select(staff);

            this.txt_staffinfo_name.Text = table.Rows[0]["staffinfo_name"].ToString();
            this.txt_staffinfo_cell.Text = table.Rows[0]["staffinfo_cell"].ToString();
            this.ddl_sex.SelectedValue = table.Rows[0]["staffinfo_sex"].ToString();
            this.txt_NewPass.Text = "";
            this.txt_NewPassConfirm.Text = "";
            this.txt_OldPass.Text = "";
        }
/*
        private int IsSame()
        {
            Staff staff = new Staff();
            StaffProvider provider = new StaffProvider();
            staff.Staffinfo_num = this.txt_staffinfo_num.Text;
            DataTable table = new DataTable();
            table = provider.Select(staff);
            if (table.Rows.Count != 0)
            {
                this.Alert("��Ա�����Ѿ����ڣ����������룡����");
                return 1;
            }
            else
            {
                return 0;
            }
        }
*/
        private int IsSame()
        {
            return 0;
        }
        private Staff AddStaff()
        {
            Staff staff = new Staff();
            if (Request.QueryString["id"] != null)
            {
                staff.Staffinfo_id = Convert.ToInt32(id);
            }
            staff.Role_id = Convert.ToInt32(Session["ROLEID"].ToString());
            staff.Staffinfo_Name = this.txt_staffinfo_name.Text;
            staff.Staffinfo_sex = this.ddl_sex.SelectedValue.ToString();
            staff.Staffinfo_cell = this.txt_staffinfo_cell.Text;
            return staff;
        }

        private void TextCancel()
        {
            this.txt_staffinfo_name.Text = "";
            this.ddl_sex.SelectedValue = "��";
            this.txt_staffinfo_cell.Text = "";
            this.txt_NewPass.Text = "";
            this.txt_NewPassConfirm.Text = "";
            this.txt_OldPass.Text = "";
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
                this.account.Text = GetAccout();//Session["LOGINED"].ToString();
                this.datetime.Text = this.BindDayWeek();
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.TextCancel();
        }

        protected void btn_staff_manager_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaffManager.aspx");
        }

        private bool check_pass()
        {
            if (this.txt_OldPass.Text == "" && (this.txt_NewPass.Text != "" || this.txt_NewPassConfirm.Text != ""))
            {
                return false;
            }
            else if (this.txt_OldPass.Text == "")
            {
                return true;
            }

            if (this.txt_OldPass.Text.ToString() != Session["PASSWORD"].ToString())
            {
                return false;
            }

            if (this.txt_NewPass.Text == "")
            {
                return false;
            }

            if (this.txt_NewPass.Text.ToString() != this.txt_NewPassConfirm.Text.ToString())
            {
                return false;
            }

            return true;
        }

        protected void btn_sure_Click(object sender, EventArgs e)
        {
            Staff staff = this.AddStaff();

            StaffProvider provider = new StaffProvider();
            switch (this.OperationFlag)
            {
                case Operation.Add:
                    if (this.IsSame() == 1)
                    {
                        break;
                    }
                    if (provider.Insert(staff))
                    {
                        this.Alert("��ӳɹ�!!!");
                        this.TextCancel();
                    }
                    break;
                case Operation.Update:
                    if (!check_pass())
                    {
                        this.Alert("�����޸ĸ�ʽ������");
                        break;
                    }

                    if (provider.Update(staff))
                    {
                        if (this.txt_NewPassConfirm.Text != "")
                        {
                            UserProvider provider1 = new UserProvider();
                            if (provider1.UpdatePassWord(Convert.ToInt32(Session["USERID"].ToString()), this.txt_NewPassConfirm.Text.ToString()))
                            {
                                Session["PASSWORD"] = this.txt_NewPassConfirm.Text.ToString();
                                this.Alert("�޸ĳɹ�!!!");
                                this.BindText();
                                break;
                            }
                        }
                        else
                        {
                            this.Alert("�޸ĳɹ�!!!");
                            this.BindText();
                            break;
                        }
                    }
                    this.Alert("�޸�ʧ��!!!!");
                    this.BindText();
                    break;
            }
        }
    }
}
