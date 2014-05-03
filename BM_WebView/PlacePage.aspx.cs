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
    public partial class PlacePage : PageBase
    {

        private string id;

        #region --- 页面逻辑 ---
        private void BindText()
        {
            Place place = new Place();
            place.Place_id = Convert.ToInt32(id);
            PlaceProvider provider = new PlaceProvider();
            DataTable table = new DataTable();
            table = provider.Select(place);

            this.txt_name.Text = table.Rows[0]["place_num"].ToString();
            this.ddl_state.SelectedValue= table.Rows[0]["place_state"].ToString();
        }

        private int IsSame()
        {
            Place place = this.AddProduct();
            PlaceProvider provider = new PlaceProvider();
            place.Place_num = this.txt_name.Text;
            DataTable table = new DataTable();
            table = provider.Select(place);
            if (table.Rows.Count != 0)
            {
                this.Alert("该库位编号已经存在，请重新输入！！！");
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private Place AddProduct()
        {
            Place place = new Place();
            if (Request.QueryString["id"] != null)
            {
                place.Place_id = Convert.ToInt32(id);
            }
            place.Place_num = this.txt_name.Text;
            place.Place_state = this.ddl_state.SelectedValue.ToString();
            return place;
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

        protected void btn_sure_Click(object sender, EventArgs e)
        {
            Place place = this.AddProduct();
            PlaceProvider provider = new PlaceProvider();
            switch (this.OperationFlag)
            {
                case Operation.Add:
                    if (this.IsSame() == 1)
                    {
                        break;
                    }
                    if (provider.Insert(place))
                    {
                        this.Alert("添加成功!!!");
                        this.TextCancel();
                    }
                    break;
                case Operation.Update:
                    if (provider.Update(place))
                    {
                        this.Alert("修改成功!!!");
                        this.BindText();
                    }
                    break;
            }
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.TextCancel();
        }

        protected void btn_manager_Click(object sender, EventArgs e)
        {
            Response.Redirect("PlaceManager.aspx");
        }
    }
}
