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
    public partial class BrandPage : PageBase
    {

        private string id;

        #region --- 页面逻辑 ---
        private void BindText()
        {
            Brand brand = new Brand();
            brand.Brand_id = Convert.ToInt32(id);
            BrandProvider provider = new BrandProvider();
            DataTable table = new DataTable();
            table = provider.Select(brand);

            this.txt_name.Text = table.Rows[0]["brand_name"].ToString();
        }

        private int IsSame()
        {
            Brand brand = new Brand();
            BrandProvider provider = new BrandProvider();
            brand.Brand_name = this.txt_name.Text;
            DataTable table = new DataTable();
            table = provider.Select(brand);
            if (table.Rows.Count != 0)
            {
                this.Alert("该品牌已经存在，请重新输入！！！");
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private Brand AddBrand()
        {
            Brand brand = new Brand();
            if (Request.QueryString["id"] != null)
            {
                brand.Brand_id = Convert.ToInt32(id);
            }
            brand.Brand_name = this.txt_name.Text;
            return brand;
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
            Response.Redirect("BrandManager.aspx");
        }

        protected void btn_sure_Click(object sender, EventArgs e)
        {
            Brand brand = this.AddBrand();
            BrandProvider provider = new BrandProvider();
            switch (this.OperationFlag)
            {
                case Operation.Add:
                    if (this.IsSame() == 1)
                    {
                        break;
                    }
                    if (provider.Insert(brand))
                    {
                        this.Alert("添加成功!!!");
                        this.TextCancel();
                    }
                    break;
                case Operation.Update:
                    if (provider.Update(brand))
                    {
                        this.Alert("修改成功!!!");
                        this.BindText();
                    }
                    break;
            }
        }
    }
}
