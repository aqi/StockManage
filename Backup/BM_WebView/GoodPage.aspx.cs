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
    public partial class GoodPage : PageBase
    {
        private string id;

        #region --- 页面逻辑 ---

        private void BindSource()
        {
            UnitProvider unit = new UnitProvider();
            this.ddl_Unit.DataSource = unit.GetAll();
            this.ddl_Unit.DataBind();
            ProductProvider product = new ProductProvider();
            this.ddl_Product.DataSource = product.GetAll();
            this.ddl_Product.DataBind();
            BrandProvider brand = new BrandProvider();
            this.ddl_BrandName.DataSource = brand.GetAll();
            this.ddl_BrandName.DataBind();
        }

        private void BindText()
        {
            Good good = new Good();
            good.Good_id = Convert.ToInt32(id);
            GoodProvider provider = new GoodProvider();
            DataTable table = new DataTable();
            table = provider.Select(good);

            this.txt_Color.Text = table.Rows[0]["good_color"].ToString();
            this.txt_Code.Text = table.Rows[0]["good_code"].ToString();
            this.txt_Description.Text = table.Rows[0]["good_description"].ToString();
            this.Image1.ImageUrl= table.Rows[0]["good_img"].ToString();
            this.txt_Name.Text = table.Rows[0]["good_name"].ToString();
            this.txt_Num.Text = table.Rows[0]["good_num"].ToString();
            this.txt_Price.Text = table.Rows[0]["good_price"].ToString();
            this.txt_SellingPrice.Text = table.Rows[0]["good_selling_price"].ToString();
        }

        private Good AddGood()
        {
            Good good = new Good();
            if (Request.QueryString["id"] != null)
            {
                good.Good_id = Convert.ToInt32(id);
            }
            good.Good_color = this.txt_Color.Text;
            good.Good_code = this.txt_Code.Text;
            good.Good_description = this.txt_Description.Text;
            good.Good_img = this.Image1.ImageUrl;
            good.Good_name = this.txt_Name.Text;
            good.Brand_id = Convert.ToInt32( this.ddl_BrandName.SelectedValue);
            good.Good_num = Convert.ToInt32( this.txt_Num.Text);
            good.Good_price = Convert.ToDecimal( this.txt_Price.Text);
            good.Good_selling_price = Convert.ToDecimal( this.txt_SellingPrice.Text);
            good.Unit_id = Convert.ToInt32(this.ddl_Unit.SelectedValue);
            good.Product_id = Convert.ToInt32(this.ddl_Product.SelectedValue);
            return good;
        }

        private void TextCancel()
        {
            this.txt_Color.Text = "";
            this.txt_Code.Text = "";
            this.txt_Description.Text = "";
            this.txt_Name.Text = "";
            this.txt_Num.Text = "";
            this.txt_Price.Text = "";
            this.txt_SellingPrice.Text = "";
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
            if (!IsPostBack)
            {
                this.BindSource();
            }
            this.account.Text = Session["LOGINED"].ToString();
            this.datetime.Text = this.BindDayWeek();
        }

        protected void btn_Up_Click(object sender, EventArgs e)
        {
            string fileleixing = null;
            fileleixing = System.IO.Path.GetExtension(FileUpload1.FileName).ToString();
            if (FileUpload1.PostedFile.ContentLength > 204800)
            {
                this.Alert("文件只能在200k以内!!!");
                return; 

            } 
            if (fileleixing == ".jpg" | fileleixing == ".gif")
            { 
                Random rmd = new Random();
                string filepath = null;
                filepath = System.DateTime.Now.ToString() + rmd.Next(1, 65535);
                filepath = filepath.Replace(":", "").Replace(" ", "").Replace("-", "") + fileleixing; //生成文件名 
                FileUpload1.SaveAs(Server.MapPath("images/" + filepath)); 
                if (System.IO.File.Exists(Server.MapPath("images/") + filepath))
                {
                    this.Image1.ImageUrl = "images/" + filepath;
                }
            }
            else
            {
                this.Alert("只能上传jpg和gif格式!!!");
            } 
        }

       

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.TextCancel();
        }

        protected void btn_manager_Click(object sender, EventArgs e)
        {
            Response.Redirect("GoodManager.aspx");
        }

        protected void btn_sure_Click(object sender, EventArgs e)
        {
            Good good = this.AddGood();
            GoodProvider provider = new GoodProvider();
            switch (this.OperationFlag)
            {
                case Operation.Add:
                    Good newgood = new Good();
                    newgood.Good_code = this.txt_Code.Text;
                    newgood.Good_name = this.txt_Name.Text;
                    GoodProvider goodProvider = new GoodProvider();
                    DataTable table = new DataTable();
                    table = goodProvider.Select(newgood);
                    if (table.Rows.Count == 0)
                    {
                        if (provider.Insert(good))
                        {
                            this.Alert("添加成功!!!");
                            this.TextCancel();
                        }
                    }
                    else
                    {
                        this.Alert("代码和名称已经存在！！！");
                    }
                    break;
                case Operation.Update:
                    if (provider.Update(good))
                    {
                        this.Alert("修改成功!!!");
                        this.BindText();
                    }
                    break;
            }
        }
    }
}
