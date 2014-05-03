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
    public partial class SupplierPage : PageBase
    {

        private string id;

        #region --- 页面逻辑 ---

        private void BindText()
        {
           Supplier supplier= new Supplier();
            supplier.Supplier_Id = Convert.ToInt32(id);
            SupplierProvider provider = new SupplierProvider();
            DataTable table = new DataTable();
            table = provider.Select(supplier);

            this.txt_name.Text = table.Rows[0]["supplier_name"].ToString();
            this.txt_address.Text = table.Rows[0]["Supplier_address"].ToString();
            this.txt_postcode.Text = table.Rows[0]["Supplier_postcode"].ToString();
            this.txt_cell.Text = table.Rows[0]["Supplier_cell"].ToString();
            this.txt_phone.Text = table.Rows[0]["Supplier_phone"].ToString();
            this.txt_fax.Text = table.Rows[0]["Supplier_fax"].ToString();
            this.txt_email.Text = table.Rows[0]["Supplier_email"].ToString();
            this.txt_liaison.Text = table.Rows[0]["Supplier_liaison"].ToString();
        }

        private int IsSame()
        {
            return 0;
        }

        private Supplier AddSupplier()
        {
           Supplier supplier= new Supplier();           
            if (Request.QueryString["id"] != null)
            {
                supplier.Supplier_Id = Convert.ToInt32(id);
            }
            supplier.Supplier_Name = this.txt_name.Text;
            supplier.Supplier_Address = this.txt_address.Text;
            supplier.Supplier_Postcode = this.txt_postcode.Text;
            supplier.Supplier_Cell = this.txt_cell.Text;
            supplier.Supplier_Phone = this.txt_phone.Text;
            supplier.Supplier_Fax = this.txt_fax.Text;
            supplier.Supplier_Email = this.txt_email.Text;
            supplier.Supplier_Liaison = this.txt_liaison.Text;

            return supplier;
        }

        private void TextCancel()
        {
            this.txt_name.Text = "";
            this.txt_address.Text = "";
            this.txt_postcode.Text = "";
            this.txt_cell.Text = "";
            this.txt_phone.Text = "";
            this.txt_fax.Text = "";
            this.txt_email.Text = "";
            this.txt_liaison.Text = "";
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
            Response.Redirect("SupplierManager.aspx");
        }

        protected void btn_sure_Click(object sender, EventArgs e)
        {
           Supplier supplier = this.AddSupplier();
            SupplierProvider provider = new SupplierProvider();
            switch (this.OperationFlag)
            {
                case Operation.Add:
                    if (supplier.Supplier_Name == "" || supplier.Supplier_Liaison == "")
                    {
                        this.Alert("供应商名或联系人不能为空，修改失败!!!");
                        break;
                    }
                    if (this.IsSame() == 1)
                    {
                        break;
                    }
                    if (provider.Insert(supplier))
                    {
                        this.Alert("添加成功!!!");
                        this.TextCancel();
                    }
                    break;
                case Operation.Update:
                    if (supplier.Supplier_Name == "" || supplier.Supplier_Liaison == "")
                    {
                        this.Alert("供应商名或联系人不能为空，修改失败!!!");
                        break;
                    }
                    if (provider.Update(supplier))
                    {
                        this.Alert("修改成功!!!");
                        this.BindText();
                    }
                    break;
            }
        }
    }
}
