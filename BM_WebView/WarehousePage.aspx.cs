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
    public partial class WarehousePage : PageBase
    {

        private string id;

        #region --- 页面逻辑 ---

        private void BindSource()
        {
            GoodProvider good = new GoodProvider();
            this.ddl_good.DataSource = good.GetAll();
            this.ddl_good.DataBind();
            PlaceProvider place = new PlaceProvider();
            this.ddl_place.DataSource = place.GetAll();
            this.ddl_place.DataBind();
        }

        private void BindText()
        {
            Warehouse warehouse = new Warehouse();
            warehouse.Warehouse_id = Convert.ToInt32(id);
            WarehouseProvider provider = new WarehouseProvider();
            DataTable table = new DataTable();
            table = provider.Select(warehouse);

            this.txt_number.Text = table.Rows[0]["warehouse_number"].ToString();
            this.txt_time.Text = table.Rows[0]["warehouse_time"].ToString();
        }

        private Warehouse AddWarehouse()
        {
            Warehouse warehouse = new Warehouse();
            if (Request.QueryString["id"] != null)
            {
                warehouse.Warehouse_id = Convert.ToInt32(id);
            }
            warehouse.Warehouse_number = Convert.ToInt32( this.txt_number.Text);
            warehouse.Warehouse_time = Convert.ToDateTime(this.txt_time.Text);
            warehouse.Good_id = Convert.ToInt32(this.ddl_good.Text);
            warehouse.Warehouse_type = this.ddl_type.Text;
            warehouse.Warehouse_operators = Session["LOGINED"].ToString();
            return warehouse;
        }

        private void TextCancel()
        {
            this.txt_number.Text = "";
            this.txt_time.Text = "";
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

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            this.txt_time.Text = this.Calendar1.SelectedDate.ToString();
        }

        protected void btn_sure_Click(object sender, EventArgs e)
        {
            Warehouse warehouse = this.AddWarehouse();
            WarehouseProvider provider = new WarehouseProvider();
            switch (this.OperationFlag)
            {
                case Operation.Add:
                    if (provider.Insert(warehouse))
                    {
                        this.Alert("添加成功!!!");
                    }
                    break;
                case Operation.Update:
                    if (provider.Update(warehouse))
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
            Response.Redirect("WarehouseManager.aspx");
        }
    }
}
