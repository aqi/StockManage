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
using System.Drawing.Imaging;

namespace Web0204.BM.WebView
{
    public partial class ChartManager : PageBase
    {

        #region --- 页面逻辑 ---

        /// <summary>
        ///  绑定Users信息的数据源
        /// </summary>
        private void BindSource(int start, string name)
        {
            //int prvResponse = Convert.ToInt32(Session["PRVRESPONSE"].ToString());

            if (name != null)
            {
                Users user = new Users();
                user.User_name = name;
                user.User_Login = 1;
                //if (prvResponse == 9)
                //    user.User_Manage = 0;
                //else
                //{
                //    user.User_Manage = 1;
                //    user.Role_id = prvResponse - 20;
                //}
                UserProvider provider = new UserProvider();
                DataTable table = provider.Select(user, start, this.ListPager1.PageSize);

            }
            else
            {
                UserProvider provider = new UserProvider();
                DataTable table;

                table = provider.GetAll(start, this.ListPager1.PageSize);

            }
        }
        private void DrawChart()
        {
            int height = 400, width = 700;

        }

        private void BindSource(string name)
        {
            this.BindSource(this.ListPager1.CurrentPageIndex * this.ListPager1.PageSize, name);
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            UserProvider provider = new UserProvider();
            if (!IsPostBack)
            {
                this.ListPager1.RecordCount = provider.GetSize();
                this.BindSource(0, null);
            }
            DrawChart();
            /*
            string manage = provider.GetUserManage(Session["LOGINED"].ToString()) == 1 ? "经理" : "普通员工";
            */

            string manage = "";
            this.account.Text = Session["LOGINED"].ToString() + manage;
            this.datetime.Text = this.BindDayWeek();
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }

        void ListPager1_PageChange(object sender, PageEventArgs e)
        {
            if (this.txt_Name.Text == "")
            {
                this.BindSource(e.StartRecord, null);
            }
            else
            {
                this.BindSource(e.StartRecord, "%" + this.txt_Name.Text + "%");
            }
        }

        protected void btn_Result_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            user.User_name = "%" + this.txt_Name.Text + "%";
            UserProvider provider = new UserProvider();
            this.ListPager1.RecordCount = provider.GetSize(user);
            this.BindSource(0, "%" + this.txt_Name.Text + "%");
            this.ListPager1.PageChange += new PagerEventHandler(ListPager1_PageChange);
        }
    }
}
