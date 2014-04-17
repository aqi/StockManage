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

        #region --- ҳ���߼� ---

        private void BindText()
        {
            Good good = new Good();
            good.Good_id = Convert.ToInt32(id);
            GoodProvider provider = new GoodProvider();
            DataTable table = new DataTable();
            table = provider.Select(good);

            this.Image1.ImageUrl= table.Rows[0]["good_img"].ToString();
            this.txt_Name.Text = table.Rows[0]["good_name"].ToString();
            this.txt_Num.Text = table.Rows[0]["good_num"].ToString();

        }

        private Good AddGood()
        {
            Good good = new Good();
            if (Request.QueryString["id"] != null)
            {
                good.Good_id = Convert.ToInt32(id);
            }
            good.Good_img = this.Image1.ImageUrl;
            good.Good_name = this.txt_Name.Text;
            good.Good_Num = this.txt_Num.Text;
            good.Purchase_PriceMin = 0;
            good.Purchase_PriceMax = 0;

            return good;
        }

        private void TextCancel()
        {
            this.txt_Name.Text = "";
            this.txt_Num.Text = "";
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

        protected void btn_Up_Click(object sender, EventArgs e)
        {
            string fileleixing = null;
            fileleixing = System.IO.Path.GetExtension(FileUpload1.FileName).ToString();
            if (FileUpload1.PostedFile.ContentLength > 204800)
            {
                this.Alert("�ļ�ֻ����200k����!!!");
                return; 

            } 
            if (fileleixing == ".jpg" | fileleixing == ".gif")
            { 
                Random rmd = new Random();
                string filepath = null;
                filepath = System.DateTime.Now.ToString() + rmd.Next(1, 65535);
                filepath = filepath.Replace(":", "").Replace(" ", "").Replace("-", "") + fileleixing; //�����ļ��� 
                FileUpload1.SaveAs(Server.MapPath("images/" + filepath)); 
                if (System.IO.File.Exists(Server.MapPath("images/") + filepath))
                {
                    this.Image1.ImageUrl = "images/" + filepath;
                }
            }
            else
            {
                this.Alert("ֻ���ϴ�jpg��gif��ʽ!!!");
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
                    if (good.Good_name == "")
                    {
                        this.Alert("���棺����Ĳ�Ʒ����������");
                        break;
                    }

                    if (good.Good_Num == "")
                    {
                        this.Alert("����:����Ĳ�Ʒ��ţ�������");
                        break;
                    }

                    Good newgood = new Good();
                    newgood.Good_Num = this.txt_Num.Text;
                    //newgood.Good_name = this.txt_Name.Text;
                    GoodProvider goodProvider = new GoodProvider();
                    DataTable table = new DataTable();
                    table = goodProvider.Select(newgood);
                    if (table.Rows.Count == 0)
                    {
                        if (provider.Insert(good))
                        {
                            this.Alert("��ӳɹ�!!!");
                            this.TextCancel();
                        }
                    }
                    else
                    {
                        this.Alert("����������Ѿ����ڣ�����");
                    }
                    break;
                case Operation.Update:
                    if (provider.UpdateInfo(good))
                    {
                        this.Alert("�޸ĳɹ�!!!");
                        this.BindText();
                    }

                    break;
            }
        }
    }
}
