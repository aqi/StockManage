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
    public partial class ProductPage : PageBase
    {

        private string id;

        #region --- 页面逻辑 ---
        private void BindText()
        {
            Product product = new Product();
            product.Product_id = Convert.ToInt32(id);
            ProductProvider provider = new ProductProvider();
            DataTable table = new DataTable();
            table = provider.Select(product);

            this.txt_name.Text = table.Rows[0]["product_name"].ToString();
        }

        private int IsSame()
        {
            Product product = new Product();
            ProductProvider provider = new ProductProvider();
            product.Product_name = this.txt_name.Text;
            DataTable table = new DataTable();
            table = provider.Select(product);
            if (table.Rows.Count != 0)
            {
                this.Alert("该类别已经存在，请重新输入！！！");
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private Product AddProduct()
        {
            Product product = new Product();
            if (Request.QueryString["id"] != null)
            {
                product.Product_id = Convert.ToInt32(id);
            }
            product.Product_name = this.txt_name.Text;
            return product;
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
            Response.Redirect("ProductManager.aspx");
        }

        protected void btn_sure_Click(object sender, EventArgs e)
        {
            Product product = this.AddProduct();
            ProductProvider provider = new ProductProvider();
            switch (this.OperationFlag)
            {
                case Operation.Add:
                    if (this.IsSame() == 1)
                    {
                        break;
                    }
                    if (provider.Insert(product))
                    {
                        this.Alert("添加成功!!!");
                        this.TextCancel();
                    }
                    break;
                case Operation.Update:
                    if (provider.Update(product))
                    {
                        this.Alert("修改成功!!!");
                        this.BindText();
                    }
                    break;
            }
        }
    }
}
