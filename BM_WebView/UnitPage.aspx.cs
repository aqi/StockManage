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
    public partial class UnitPage : PageBase
    {

        private string id;

        #region --- 页面逻辑 ---
        private void BindText()
        {
            Units unit = new Units();
            unit.Unit_id = Convert.ToInt32(id);
            UnitProvider provider = new UnitProvider();
            DataTable table = new DataTable();
            table = provider.Select(unit);

            this.txt_unit_name.Text = table.Rows[0]["unit_name"].ToString();
        }

        private int IsSame()
        {
            Units unit = new Units();
            UnitProvider provider = new UnitProvider();
            unit.Unit_name = this.txt_unit_name.Text;
            DataTable table = new DataTable();
            table = provider.Select(unit);
            if (table.Rows.Count != 0)
            {
                this.Alert("该单位已经存在，请重新输入！！！");
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private Units AddUnit()
        {
            Units unit = new Units();
            if (Request.QueryString["id"] != null)
            {
                unit.Unit_id = Convert.ToInt32(id);
            }
            unit.Unit_name = this.txt_unit_name.Text;
            return unit;
        }

        private void TextCancel()
        {
            this.txt_unit_name.Text = "";
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
            Response.Redirect("UnitManager.aspx");
        }

        
        protected void btn_sure_Click(object sender, EventArgs e)
        {
            Units units = this.AddUnit();
            UnitProvider provider = new UnitProvider();
            switch (this.OperationFlag)
            {
                case Operation.Add:
                    if (this.IsSame() == 1)
                    {
                        break;
                    }
                    if (provider.Insert(units))
                    {
                        this.Alert("添加成功!!!");
                        this.TextCancel();
                    }
                    break;
                case Operation.Update:
                    if (provider.Update(units))
                    {
                        this.Alert("修改成功!!!");
                        this.BindText();
                    }
                    break;
            }
        }
    }
}
