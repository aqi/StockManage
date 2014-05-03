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
    public partial class Manager : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ManagerProvider provider = new ManagerProvider();
                DataTable table = provider.Select();
                this.treeView.Nodes.Clear();
                DataView dv = table.DefaultView;
                dv.RowFilter = "parent_id = 0";

                Users user = new Users();
                user.User_account = Session["LOGINED"].ToString();
                user.User_Login = 1;
                UserProvider userProvider = new UserProvider();
                DataTable table1 = userProvider.Select(user);
                string account=table1.Rows[0]["role_name"].ToString();
                if (account.Equals("管理员"))
                {
                    int j = 0;
                    //加入根节点
                    foreach (DataRowView drv in dv)
                    {
                        j++;
                        if (j != 1 && j != 2 && j != 6 && j != 8)
                            continue;
                        TreeNode root = new TreeNode(drv["manage_name"].ToString(), drv["manage_id"].ToString());
                        this.treeView.Nodes.Add(root);
                    }

                    for (int i = 0; i < this.treeView.Nodes.Count; i++)
                    {
                        this.AddChildNode(table, this.treeView.Nodes[i]);
                    }
                }
                else if (account.Equals("采购员"))
                {
                    int j = 0;
                    //加入根节点
                    foreach (DataRowView drv in dv)
                    {
                        j++;

                        if (j != 3 && j != 7 && j != 8)
                            continue;

                        if (j == 7)
                        {
                            if(Convert.ToInt32(Session["USERMANAGE"].ToString()) != 1)
                                continue;
                        }
                        TreeNode root = new TreeNode(drv["manage_name"].ToString(), drv["manage_id"].ToString());
                        this.treeView.Nodes.Add(root);


                    }

                    for (int i = 0; i < this.treeView.Nodes.Count; i++)
                    {
                        this.AddChildNode(table, this.treeView.Nodes[i]);
                    }
                }
                else if (account.Equals("销售员"))
                {
                    int j = 0;
                    //加入根节点
                    foreach (DataRowView drv in dv)
                    {
                        j++;
                        if (j != 4 && j != 8)
                            continue;
                        
                        TreeNode root = new TreeNode(drv["manage_name"].ToString(), drv["manage_id"].ToString());
                        this.treeView.Nodes.Add(root);
                    }

                    for (int i = 0; i < this.treeView.Nodes.Count; i++)
                    {
                        this.AddChildNode(table, this.treeView.Nodes[i]);
                    }
                }
                else if (account.Equals("仓库员"))
                {
                    int j = 0;
                    //加入根节点
                    foreach (DataRowView drv in dv)
                    {
                        j++;
                        if (j != 5 && j != 8)
                            continue;

                        TreeNode root = new TreeNode(drv["manage_name"].ToString(), drv["manage_id"].ToString());
                        this.treeView.Nodes.Add(root);
                    }

                    for (int i = 0; i < this.treeView.Nodes.Count; i++)
                    {
                        this.AddChildNode(table, this.treeView.Nodes[i]);
                    }
                }
                    /*
                else if (account.Equals("采购商"))
                {
                    int j = 0;
                    //加入根节点
                    foreach (DataRowView drv in dv)
                    {
                        j++;
                        if (j != 7 && j != 8)
                            continue;

                        TreeNode root = new TreeNode(drv["manage_name"].ToString(), drv["manage_id"].ToString());
                        this.treeView.Nodes.Add(root);
                    }

                    for (int i = 0; i < this.treeView.Nodes.Count; i++)
                    {
                        this.AddChildNode(table, this.treeView.Nodes[i]);
                    }
                }
                     */

                
            }
        }

        private void AddChildNode(DataTable dt, TreeNode node)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "parent_id=" + node.Value.Trim();

            foreach (DataRowView drv in dv)
            {
                TreeNode childNode = new TreeNode(drv["manage_name"].ToString(), drv["manage_id"].ToString());
                node.ChildNodes.Add(childNode);
            }
        }
        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (this.treeView.SelectedValue.ToString().Equals("8"))
            {
                Response.Redirect("login.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("9"))
            {
                Session["PRVRESPONSE"] = "9";
                Response.Redirect("UsersManager.aspx");
            }
            //else if (this.treeView.SelectedValue.ToString().Equals("8"))
            //{
            //    Response.Redirect("SendManager.aspx");
           // }
            //else if (this.treeView.SelectedValue.ToString().Equals("9"))
            //{
            //    Response.Redirect("FreightManager.aspx");
            //}
            else if (this.treeView.SelectedValue.ToString().Equals("10"))
            {
                //Response.Redirect("CompanyManager.aspx");
                Response.Redirect("SupplierManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("11"))
            {
                //Response.Redirect("StaffManager.aspx");
                Response.Redirect("BuyerManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("12"))
            {
                //Response.Redirect("StaffManager.aspx");
                Response.Redirect("GoodManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("13"))
            {
                Response.Redirect("StaffManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("14"))
            {
                Response.Redirect("PurchaseRecordManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("15"))
            {
                Response.Redirect("StaffManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("16"))
            {
                Response.Redirect("SaleRecordManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("17"))
            {
                Response.Redirect("StaffManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("18"))
            {
                Response.Redirect("StockRecordManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("19"))
            {
                //Response.Redirect("StaffManager.aspx");
                Response.Redirect("PurchaseManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("20"))
            {
                //Response.Redirect("StaffManager.aspx");
                Response.Redirect("SaleManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("21"))
            {
                //Response.Redirect("StaffManager.aspx");
                Response.Redirect("ChartManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("22"))
            {
                Response.Redirect("GoodPriceManager.aspx");
                //Session["PRVRESPONSE"] = "22";
                //Response.Redirect("UsersManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("23"))
            {
                Session["PRVRESPONSE"] = "23";
                Response.Redirect("UsersManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("24"))
            {
                Session["PRVRESPONSE"] = "24";
                Response.Redirect("UsersManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("25"))
            {
                Session["PRVRESPONSE"] = "25";
                Response.Redirect("UsersManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("26"))
            {
                Session["PRVRESPONSE"] = "26";
                Response.Redirect("UsersManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("27"))
            {
                Response.Redirect("GoodManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("28"))
            {
                Response.Redirect("OrderManager.aspx");
            }
/*
            else if (this.treeView.SelectedValue.ToString().Equals("12"))
            {
                Response.Redirect("BrandManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("13"))
            {
                Response.Redirect("UnitManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("14"))
            {
                Response.Redirect("ProductManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("15"))
            {
                Response.Redirect("GoodManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("16"))
            {
                Response.Redirect("CustomersManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("17"))
            {
                Response.Redirect("FabricsPurchasingManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("18"))
            {
                Response.Redirect("TrimsSourcingManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("19"))
            {
                Response.Redirect("FabricSalesManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("20"))
            {
                Response.Redirect("AccessoriesSalesManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("21"))
            {
                Response.Redirect("WarehouseManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("23"))
            {
                Response.Redirect("PlaceManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("28"))
            {
                Response.Redirect("UsersManager.aspx");
            }
 */
        }
    }
}