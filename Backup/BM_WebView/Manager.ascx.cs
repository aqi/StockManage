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
                UserProvider userProvider = new UserProvider();
                DataTable table1 = userProvider.Select(user);
                string account=table1.Rows[0]["role_name"].ToString();
                if (account.Equals("管理员"))
                {
                    //加入根节点
                    foreach (DataRowView drv in dv)
                    {
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
                        if (j == 1)
                        {                            
                            continue;
                        }
                        if (j == 3)
                        {
                            continue;
                        }
                        if (j == 4)
                        {
                            continue;
                        }
                        if (j == 5)
                        {
                            continue;
                        }
                        if (j == 6)
                        {
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
                        if (j == 1)
                        {
                            continue;
                        }
                        if (j == 2)
                        {
                            continue;
                        }
                        if (j == 4)
                        {
                            continue;
                        }
                        if (j == 5)
                        {
                            continue;
                        }
                        if (j == 6)
                        {
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
                else if (account.Equals("仓库员"))
                {
                    int j = 0;
                    //加入根节点
                    foreach (DataRowView drv in dv)
                    {
                        j++;
                        if (j == 1)
                        {
                            continue;
                        }
                        if (j == 3)
                        {
                            continue;
                        }
                        if (j == 2)
                        {
                            continue;
                        }
                        if (j == 5)
                        {
                            continue;
                        }
                        if (j == 6)
                        {
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
            if (this.treeView.SelectedValue.ToString().Equals("7"))
            {
                Response.Redirect("login.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("8"))
            {
                Response.Redirect("SendManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("9"))
            {
                Response.Redirect("FreightManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("10"))
            {
                Response.Redirect("CompanyManager.aspx");
            }
            else if (this.treeView.SelectedValue.ToString().Equals("11"))
            {
                Response.Redirect("StaffManager.aspx");
            }
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
        }
    }
}