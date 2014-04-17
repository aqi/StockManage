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

            this.txt_staffinfo_position.Text = table.Rows[0]["staffinfo_position"].ToString();
            this.txt_staffinfo_num.Text = table.Rows[0]["staffinfo_num"].ToString();
            this.txt_staffinfo_cell.Text = table.Rows[0]["staffinfo_cell"].ToString();
            this.txt_staffinfo_exp.Text = table.Rows[0]["staffinfo_exp"].ToString();
            this.ddl_sex.SelectedValue = table.Rows[0]["staffinfo_sex"].ToString();
        }

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

        private Staff AddStaff()
        {
            Staff staff = new Staff();
            if (Request.QueryString["id"] != null)
            {
                staff.Staffinfo_id = Convert.ToInt32(id);
            }
            staff.Staffionfo_position = this.txt_staffinfo_position.Text;
            staff.Staffinfo_num = this.txt_staffinfo_num.Text;
            staff.Staffinfo_sex = this.ddl_sex.SelectedValue.ToString();
            staff.Staffinfo_cell = this.txt_staffinfo_cell.Text;
            staff.Staffinfo_exp = this.txt_staffinfo_exp.Text;

            return staff;
        }

        private void TextCancel()
        {
            this.txt_staffinfo_position.Text = "";
            this.txt_staffinfo_num.Text = "";
            this.ddl_sex.SelectedValue = "��";
            this.txt_staffinfo_cell.Text = "";
            this.txt_staffinfo_exp.Text = "";
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

        protected void btn_staff_manager_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaffManager.aspx");
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
                    if (provider.Update(staff))
                    {
                        this.Alert("�޸ĳɹ�!!!");
                        this.BindText();
                    }
                    break;
            }
        }
    }
}
