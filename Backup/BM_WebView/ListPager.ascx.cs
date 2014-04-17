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

namespace Web0204.BM.WebView
{

    public delegate void PagerEventHandler(object sender, PageEventArgs e);

    public partial class ListPager : System.Web.UI.UserControl
    {
        #region ---  ��ҳ�¼� ---

        /// <summary>
        /// ҳ�������ŷ����ı�ʱ���������¼�
        /// </summary>
        public event PagerEventHandler PageChange;

        /// <summary>
        /// ҳ�������ŷ����ı䴥��һ��PageChange�¼�
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPageChange(PageEventArgs e)
        {

            if (this.PageChange != null)
            {
                PageChange(this, e);
            }
        }

        #endregion

        #region --- ÿҳ��С ---

        /// <summary>
        /// ���û��ȡ��ҳ��ҳ���С
        /// </summary>
        public int PageSize
        {
            get
            {
                if (this.ViewState["PageSize"] == null)
                {
                    this.ViewState["PageSize"] = 8;
                }
                return Convert.ToInt32(this.ViewState["PageSize"]);
            }
            set
            {
                this.ViewState["PageSize"] = value;
            }

        }

        #endregion

        #region --- �ܼ�¼�� ---

        /// <summary>
        /// ���û��ȡ��¼������
        /// </summary>
        public int RecordCount
        {
            get
            {
                if (this.ViewState["RecordCount"] == null)
                {
                    this.ViewState["RecordCount"] = 0;
                }
                return Convert.ToInt32(this.ViewState["RecordCount"]);
            }
            set
            {
                this.ViewState["RecordCount"] = value;
                this.CurrentPageIndex = 0;
                this.DisplayControl();

            }
        }

        #endregion

        #region --- ��ҳ�� ---

        /// <summary>
        /// ��ȡ��ҳ��
        /// </summary>
        public int TotalPages
        {
            get
            {
                if (this.ViewState["TotalPages"] == null)
                {
                    this.ViewState["TotalPages"] = 0;
                }

                if (this.RecordCount != 0)
                {
                    this.ViewState["TotalPages"] = (RecordCount - 1) / PageSize + 1;
                }

                return Convert.ToInt32(this.ViewState["TotalPages"]);
            }
        }



        #endregion

        #region --- ��ǰҳ�������� ---

        /// <summary>
        /// ���û��ȡ��ǰҳ������
        /// </summary>
        public int CurrentPageIndex
        {
            get
            {
                if (this.ViewState["CurrentPageIndex"] == null)
                {
                    this.ViewState["CurrentPageIndex"] = 0;
                }

                if (Convert.ToInt32(this.ViewState["CurrentPageIndex"]) >= this.TotalPages)
                {
                    this.ViewState["CurrentPageIndex"] = this.TotalPages - 1;

                }

                if (Convert.ToInt32(this.ViewState["CurrentPageIndex"]) < 0)
                {
                    this.ViewState["CurrentPageIndex"] = 0;
                }

                return Convert.ToInt32(this.ViewState["CurrentPageIndex"]);
            }
            set
            {
                if (value >= this.TotalPages)
                {
                    if (this.TotalPages == 0)
                    {
                        this.ViewState["CurrentPageIndex"] = 0; 
                    }
                    else
                    {
                        this.ViewState["CurrentPageIndex"] = this.TotalPages - 1;
                    }
                }
                else if (value < 0)
                {
                    this.ViewState["CurrentPageIndex"] = 0;
                }
                else
                {
                    this.ViewState["CurrentPageIndex"] = value;
                }

            }
        }

        #endregion

        #region --- ��ť��ʾ���� ---

        /// <summary>
        /// ���ݵ�ǰ��ҳ��״̬������ť�Ƿ�ɼ���
        /// </summary>
        private void DisplayControl()
        {
            if (this.TotalPages == 1 || this.TotalPages == 0)
            {
                this.Visible = false;
                return;
            }

            this.Visible = true;

            if (this.CurrentPageIndex == this.TotalPages - 1) //���һҳ
            {
                this.btnFirst.Enabled = true;
                this.btnPrevious.Enabled = true;
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;

            }
            else if (this.CurrentPageIndex == 0)
            {
                this.btnFirst.Enabled = false;
                this.btnPrevious.Enabled = false;
                this.btnNext.Enabled = true;
                this.btnLast.Enabled = true;
            }
            else
            {
                this.btnFirst.Enabled = true;
                this.btnPrevious.Enabled = true;
                this.btnNext.Enabled = true;
                this.btnLast.Enabled = true;
            }

            this.lblTotal.Text = this.TotalPages.ToString();
            this.lblCurrent.Text = Convert.ToString(this.CurrentPageIndex + 1);

        }

        #endregion

        private void ClickCommon()
        {
            this.DisplayControl();
            PageEventArgs arg = new PageEventArgs();
            arg.CurrentPageIndex = this.CurrentPageIndex;
            arg.StartRecord = this.CurrentPageIndex * this.PageSize;
            this.OnPageChange(arg);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.DisplayControl();
            }
        }

        /// <summary>
        /// �����ҳ��ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFirst_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex = 0;
            this.ClickCommon();
        }

        /// <summary>
        /// �����һҳ��ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex = this.CurrentPageIndex - 1;
            this.ClickCommon();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex = this.CurrentPageIndex + 1;
            this.ClickCommon();
        }

        protected void btnLast_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex = this.TotalPages - 1;
            this.ClickCommon();
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            int result = 0;

            try
            {
                result = Convert.ToInt32(this.txtIndex.Text);
            }
            catch
            {

            }

            if (result == 0)
            {
                result = 1;
            }
            this.CurrentPageIndex = result - 1;
            this.ClickCommon();
        }
    }





    /// <summary>
    /// PageEventArgs���ʾ��ҳ�¼�����Ϣ��
    /// </summary>
    public class PageEventArgs : EventArgs
    {
        private int currentPageIndex;
        private int startRecord;

        /// <summary>
        /// ��ȡ�����õ�ǰҳ��������
        /// </summary>
        public int CurrentPageIndex
        {
            get { return currentPageIndex; }
            set { currentPageIndex = value; }
        }

        /// <summary>
        /// ��ȡ�����õ�ǰҳ����ʼ��������
        /// </summary>
        public int StartRecord
        {
            get { return startRecord; }
            set { startRecord = value; }
        }
    
    }
}