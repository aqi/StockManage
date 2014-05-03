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
    public partial class SalePage : PageBase
    {
        //private int stock_sum;
        private string id;
        private int staffinfo_id;
        private int purchase_price;

        #region --- 页面逻辑 ---

        private void BindText()
        {
            Sale sale = new Sale();
            sale.Sale_Id = Convert.ToInt32(id);
            SaleProvider provider = new SaleProvider();
            DataTable table = new DataTable();
            table = provider.Select(sale);

            purchase_price = Convert.ToInt32(table.Rows[0]["purchase_price"].ToString());
            Session["PURCHASEPRICE"] = purchase_price.ToString();
            this.ddl_GoodId.SelectedIndex = this.ddl_GoodId.Items.IndexOf(this.ddl_GoodId.Items.FindByValue(table.Rows[0]["good_id"].ToString()));
            this.txt_goodname.Text = table.Rows[0]["good_name"].ToString();
            this.txt_price.Text = table.Rows[0]["sale_price"].ToString();
            this.txt_num.Text = table.Rows[0]["sale_num"].ToString();
            this.txt_datetime.Text = table.Rows[0]["sale_datetime"].ToString();
            this.ddl_buyerid.SelectedIndex = this.ddl_buyerid.Items.IndexOf(this.ddl_buyerid.Items.FindByValue(table.Rows[0]["buyer_id"].ToString()));           
        }

        private int IsSame()
        {
            return 0;
        }

        private bool IsRecValid()
        {
            StockProvider provider = new StockProvider();

            DataTable table = provider.GetStocks(this.ddl_GoodId.SelectedValue.ToString());
            int price = 0;
            int num = 0;
            if (this.txt_price.Text != "")
                price = Convert.ToInt32(this.txt_price.Text);
            if (this.txt_num.Text != "")
                num = Convert.ToInt32(this.txt_num.Text);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (price > Convert.ToInt32(table.Rows[i]["purchase_price"]))
                {
                    if (num <= Convert.ToInt32(table.Rows[i]["stock_num"]))
                    {
                        purchase_price = Convert.ToInt32(table.Rows[i]["purchase_price"]);
                        return true;
                    }
                    else
                        num -= Convert.ToInt32(table.Rows[i]["stock_num"]);
                }
            }
            
            string WarningMessage = "销售价不能小于采购价且数量不能大于库存:" + "!!!!!!";
            this.Alert(WarningMessage);
    
            return false;
        }

        private Sale AddSale()
        {
            Sale sale = new Sale();           
            if (Request.QueryString["id"] != null)
            {
                sale.Sale_Id = Convert.ToInt32(id);
            }
            if (Request.QueryString["staffid"] != null)
            {
                sale.Staffinfo_Id = staffinfo_id;
            } 

            sale.Good_Id = this.ddl_GoodId.SelectedValue.ToString();

            sale.Sale_Datetime = DateTime.Now.ToString("yyyyMMdd"); ;//Convert.ToDateTime( DateTime.Now.ToString("HH:mm:ss"));
            sale.Sale_Price= this.txt_price.Text;
            //sale.Purchase_Price = Session["PURCHASEPRICE"].ToString();//purchase_price.ToString();
            sale.Sale_Num = this.txt_num.Text;

            if (this.ddl_buyerid.SelectedValue.ToString() == "")
            {
                sale.Buyer_Id = 0;
            }
            else
            {
                string value = this.ddl_buyerid.SelectedValue.ToString();
                value = value.Substring(1);
                sale.Buyer_Id = Convert.ToInt32(value);//this.ddl_buyerid.SelectedValue.ToString());
            }

            sale.Good_Name = this.txt_goodname.Text;
            sale.Year_Month = Convert.ToInt32(sale.Sale_Datetime.Substring(0, 6));

            return sale;
        }

        private void TextCancel()
        {
            //this.ddl_GoodId.SelectedIndex = -1;
            this.txt_datetime.Text = DateTime.Now.ToString("yyyyMMdd");
            this.txt_price.Text = "";
            this.txt_num.Text = "";
            //this.txt_goodname.Text = Good_Record.Rows[0]["good_name"].ToString();
            //this.ddl_buyerid.SelectedIndex = -1;
            
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
            else
            {
                this.txt_datetime.Text = DateTime.Now.ToString("yyyyMMdd");
            }
            if (!IsPostBack)
            {
                this.ddl_GoodId.DataSource = Good_Record;
                this.ddl_GoodId.Width = 100;
                this.ddl_GoodId.DataValueField = "good_num";
                this.ddl_GoodId.DataBind();
                this.ddl_buyerid.DataSource = Buyer_Record;
                this.ddl_buyerid.Width = 100;
                this.ddl_buyerid.DataValueField = "buyer_bh";
                this.ddl_buyerid.DataBind();

                StockProvider provider = new StockProvider();

                DataTable table = provider.GetStocks(this.ddl_GoodId.SelectedValue.ToString());

                int min = 0;
                int max = 0;
                int sum = 0;
                int price = 0;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    sum += Convert.ToInt32(table.Rows[i]["stock_num"]);
                    price = Convert.ToInt32(table.Rows[i]["purchase_price"]);
                    if (i == 0)
                    {
                        min = max = price;
                        continue;
                    }
                    
                    if (price < min)
                    {
                        min = price;
                    }
                    else if (price > max)
                    {
                        max = price;
                    }
                }

                this.lbl_PriceRange.Text = " 采购价格最低为：" + min.ToString() + " 最高为:" + max.ToString();
                this.lbl_StockNum.Text = "库存还剩：" + sum.ToString();
                //stock_sum = sum;
                Session["STOCKSUM"] = sum.ToString();

                Good good = new Good();
                GoodProvider provider1 = new GoodProvider();
                String good_name = "";
                good.Good_Num = this.ddl_GoodId.SelectedValue.ToString();

                DataTable table1 = provider1.Select(good);

                if (table1 != null && table1.Rows.Count == 1)
                {
                    good_name = table1.Rows[0]["good_name"].ToString();
                }
                this.txt_goodname.Text = good_name;
            }
            if (Request.QueryString["staffid"] != null)
            {
                staffinfo_id = Convert.ToInt32(Request.QueryString["staffid"].ToString());
            }
            this.txt_datetime.Enabled = false;
            this.txt_goodname.Enabled = false;
            this.account.Text = GetAccout(); //Session["LOGINED"].ToString();
            this.datetime.Text = this.BindDayWeek();
        }

      

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.TextCancel();
        }

        protected void btn_manager_Click(object sender, EventArgs e)
        {
            Response.Redirect("SaleRecordManager.aspx");
        }

        protected void btn_sure_Click(object sender, EventArgs e)
        {
            Sale sales = this.AddSale();
            SaleProvider provider = new SaleProvider();
            switch (this.OperationFlag)
            {
                case Operation.Add:
                    if (true == String.IsNullOrEmpty(sales.Good_Id))
                    {
                        this.Alert("商品编号没设置，添加失败!!!");
                        break;
                    }
                    if (sales.Staffinfo_Id == 0)
                    {
                        this.Alert("员工编号为0，添加失败!!!");
                        break;
                    }
                    if (this.IsSame() == 1)
                    {
                        break;
                    }

                    if (this.IsRecValid() == false)
                    {
                        break;
                    }
                    sales.Purchase_Price = purchase_price.ToString();
                    if (provider.Insert(sales))
                    {
                        StockProvider stockProvider = new StockProvider();
                        Stock stock = new Stock();

                        stock.Stock_Num = sales.Sale_Num;
                        stock.Good_Id = sales.Good_Id;
                        stock.Stock_Oper = -1;
                        stock.Staffinfo_Id = sales.Staffinfo_Id;
                        stock.Purchase_Price = sales.Purchase_Price;
                        stock.Purchase_Datetime = DateTime.Now.ToString("yyyyMMdd");

                        if (stockProvider.Insert(stock))
                        {
                            this.Alert("添加成功!!!");
                            this.TextCancel();
                            int sum = Convert.ToInt32(Session["STOCKSUM"].ToString());
                            sum -= Convert.ToInt32(sales.Sale_Num);
                            Session["STOCKSUM"] = sum.ToString();
                            this.lbl_StockNum.Text = "库存还剩：" + sum.ToString();
                        }
                    }
                    break;
                case Operation.Update:
                    if ( false == String.IsNullOrEmpty(sales.Good_Id))
                    {
                        this.Alert("参数错误，修改失败!!!");
                        break;
                    }
                    sales.Purchase_Price = Session["PURCHASEPRICE"].ToString();
                    if (provider.Update(sales))
                    {
                        this.Alert("修改成功!!!");
                        this.BindText();
                    }
                    break;
            }
        }
         protected void ddl_GoodId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Good good = new Good();
            GoodProvider provider = new GoodProvider();
            String good_name = "";
            good.Good_Num = this.ddl_GoodId.SelectedValue.ToString();

            DataTable table = provider.Select(good);

            if (table != null && table.Rows.Count == 1)
            {
                good_name = table.Rows[0]["good_name"].ToString();
            }

            StockProvider provider1 = new StockProvider();

            table = provider1.GetStocks(this.ddl_GoodId.SelectedValue.ToString());

            int min = 0;
            int max = 0;
            int sum = 0;
            int price = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                sum += Convert.ToInt32(table.Rows[i]["stock_num"]);
                price = Convert.ToInt32(table.Rows[i]["purchase_price"]);
                if (i == 0)
                {
                    min = max = price;
                    continue;
                }

                if (price < min)
                {
                    min = price;
                }
                else if (price > max)
                {
                    max = price;
                }
            }
            this.lbl_PriceRange.Text = " 采购价格最低为：" + min.ToString() + " 最高为:" + max.ToString();
            this.lbl_StockNum.Text = "库存还剩：" + sum.ToString();
            Session["STOCKSUM"] = sum.ToString();

            this.txt_goodname.Text = good_name;
            this.txt_goodname.Enabled = false;
        }
    }
}
