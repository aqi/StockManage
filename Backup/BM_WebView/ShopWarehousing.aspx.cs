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
    public partial class ShopWarehousing : PageBase
    {

        private string id;

        #region --- 页面逻辑 ---

        /// <summary>
        ///  绑定Units信息的数据源
        /// </summary>
        private void BindSource(int start)
        {
            Shop shop = new Shop();
            shop.Contrac_id = Convert.ToInt32(id);
            ContractShopProvider provider = new ContractShopProvider();
            DataTable table = provider.Select(shop, start, this.ListPager1.PageSize);
            this.GridView1.DataSource = table.DefaultView;
            this.GridView1.DataBind();
        }

        private void BindSource()
        {
            this.BindSource(this.ListPager1.CurrentPageIndex * this.ListPager1.PageSize);
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                id = Request.QueryString["id"].ToString();
            }
            if (!IsPostBack)
            {
                Shop shop = new Shop();
                shop.Contrac_id = Convert.ToInt32(id);
                ContractShopProvider provider = new ContractShopProvider();
                this.ListPager1.RecordCount = provider.GetSize(shop);
                this.BindSource(0);
            }
            this.account.Text = Session["LOGINED"].ToString();
            this.datetime.Text = this.BindDayWeek();
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }

        void ListPager1_PageChange(object sender, PageEventArgs e)
        {
            this.BindSource(e.StartRecord);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("warehousing"))
            {
                Good good = new Good();
                good.Good_name = this.GridView1.Rows[rowIndex].Cells[0].Text;
                good.Good_code = this.GridView1.Rows[rowIndex].Cells[3].Text;
                GoodProvider goodProvider = new GoodProvider();
                DataTable table= goodProvider.Select(good);
                if (table.Rows.Count != 0)
                {
                    Warehouse warehouse = new Warehouse();
                    Warehouse_info warehouse_info = new Warehouse_info();
                    warehouse.Good_id = Convert.ToInt32(table.Rows[0]["good_id"]);
                    warehouse.Warehouse_type = "入库";
                    warehouse_info.Good_id = Convert.ToInt32(table.Rows[0]["good_id"]);
                    WarehouseInfoProvider warehouseInfoProvider = new WarehouseInfoProvider();
                    table = warehouseInfoProvider.Select(warehouse_info);
                    WarehouseProvider warehouseProvider = new WarehouseProvider();
                    Shop shop=new Shop();
                    shop.Shop_id=Convert.ToInt32(this.GridView1.DataKeys[rowIndex].Value);
                    ShopProvider shopProvider = new ShopProvider();
                    if (table.Rows.Count != 0)
                    {
                        warehouse_info.Warehouse_info_number = Convert.ToInt32(this.GridView1.Rows[rowIndex].Cells[5].Text);
                        warehouse.Warehouse_number = Convert.ToInt32(this.GridView1.Rows[rowIndex].Cells[5].Text);
                        warehouse.Order_id = Convert.ToInt32(id);
                        warehouse.Warehouse_operators = Session["LOGINED"].ToString();
                        warehouse.Warehouse_time = Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss"));
                        warehouse_info.Warehouse_info_id = Convert.ToInt32(table.Rows[0]["warehouse_info_id"]);
                        if (warehouseInfoProvider.Update(warehouse_info.Warehouse_info_number, warehouse_info.Warehouse_info_id))
                        {
                            if (shopProvider.Delete(shop))
                            {
                                if (warehouseProvider.Insert(warehouse))
                                {
                                    this.Alert("入库成功！");
                                    Shop shop1 = new Shop();
                                    shop.Contrac_id = Convert.ToInt32(id);
                                    ContractShopProvider provider = new ContractShopProvider();
                                    this.ListPager1.RecordCount = provider.GetSize(shop1);
                                    this.BindSource(0);
                                    if (this.ListPager1.RecordCount > 0)
                                    {
                                        ContractProvider contractProvider = new ContractProvider();
                                        contractProvider.Update(id, "已部分收货");
                                    }
                                    else
                                    {
                                        ContractProvider contractProvider = new ContractProvider();
                                        contractProvider.Update(id, "已全部收货");
                                    }
                                    
                                }
                            }
                        }
                    }
                    else
                    {
                        warehouse_info.Warehouse_id = warehouseProvider.GetSize() + 1;
                        warehouse_info.Warehouse_info_number = Convert.ToInt32(this.GridView1.Rows[rowIndex].Cells[5].Text);
                        warehouse.Warehouse_number = Convert.ToInt32(this.GridView1.Rows[rowIndex].Cells[5].Text);
                        warehouse.Order_id = Convert.ToInt32(id);
                        warehouse.Warehouse_operators = Session["LOGINED"].ToString();
                        warehouse.Warehouse_time = Convert.ToDateTime( DateTime.Now.Date);
                        Place place = new Place();
                        place.Place_state = "空闲";
                        PlaceProvider placeProvider = new PlaceProvider();
                        table=placeProvider.Select(place);
                        warehouse_info.Place_id = Convert.ToInt32(table.Rows[0]["place_id"]);
                        if (warehouseInfoProvider.Insert(warehouse_info))
                        {
                            if (shopProvider.Delete(shop))
                            {
                                if (warehouseProvider.Insert(warehouse))
                                {
                                    this.Alert("入库成功！");
                                    Shop shop1 = new Shop();
                                    shop.Contrac_id = Convert.ToInt32(id);
                                    ContractShopProvider provider = new ContractShopProvider();
                                    this.ListPager1.RecordCount = provider.GetSize(shop1);
                                    this.BindSource(0);
                                    Contract contract = new Contract();
                                    if (this.ListPager1.RecordCount > 0)
                                    {
                                        ContractProvider contractProvider = new ContractProvider();
                                        contractProvider.Update(id, "已部分收货");
                                    }
                                    else
                                    {
                                        ContractProvider contractProvider = new ContractProvider();
                                        contractProvider.Update(id, "已全部收货");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
