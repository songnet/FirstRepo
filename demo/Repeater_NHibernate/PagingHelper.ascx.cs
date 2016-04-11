using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Repeater_NHibernate
{
    public partial class PagingHelper : System.Web.UI.UserControl
    {
        #region 属性
        private int m_PageSize;
        public int PageSize         //每页显示记录数
        {
            set
            {
                m_PageSize = value;
            }
            get
            {
                if (m_PageSize.Equals(0))
                {
                    m_PageSize = 2;
                }
                return m_PageSize;
            }
        }

        private int m_PageIndex;
        public int PageIndex        //当前页页码
        {
            set
            {
                m_PageIndex = value;
            }
            get
            {
                if (m_PageIndex.Equals(0))
                {
                    m_PageIndex = 1;
                }
                return m_PageIndex;
            }
        }

        public int TotalItemCount   //记录总数
        {
            set;
            private get;
        }

        #endregion

        #region 受保护的方法
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPagingHelperControl();
            }
        }
        protected void lbtnPage_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            ReBindData(int.Parse(lbtn.CommandArgument));
        }
        protected void btnGoto_Click(object sender, EventArgs e)
        {
            int gotoPageIndex = PageIndex;
            if (int.TryParse(txtGoto.Text, out gotoPageIndex))
            {
                if (gotoPageIndex < 1 || gotoPageIndex > int.Parse(lbTotalPages.Text))
                {
                    Response.Write("<script>alert('此页面不存在！')</script>");
                }
                else
                {
                    if (!gotoPageIndex.Equals(int.Parse(lbPageIndex.Text)))
                    {
                        ReBindData(gotoPageIndex);
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('请输入正确的页码！')</script>");
            }

        }
        #endregion

        #region 公共方法

        #endregion

        #region 私有方法
        private void BindPagingHelperControl()
        {
            int totalPages = (TotalItemCount % PageSize) == 0 ? TotalItemCount / PageSize : TotalItemCount / PageSize + 1;
            //显示
            lbPageIndex.Text = PageIndex.ToString();
            lbTotalPages.Text = totalPages.ToString();
            txtGoto.Text = PageIndex.ToString();
            //使能
            lbtnFirstPage.Enabled = PageIndex > 1;
            lbtnPrevPage.Enabled = PageIndex > 1;
            lbtnLastPage.Enabled = PageIndex < totalPages;
            lbtnNextPage.Enabled = PageIndex < totalPages;
            //命令
            lbtnFirstPage.CommandArgument = "1";
            lbtnPrevPage.CommandArgument = (PageIndex - 1).ToString();
            lbtnNextPage.CommandArgument = (PageIndex + 1).ToString();
            lbtnLastPage.CommandArgument = totalPages.ToString();
        }
        private void ReBindData(int pageIndex)
        {
            PageIndex = pageIndex;
            OnPageIndexChanged(new EventArgs());
            BindPagingHelperControl();
        }
        #endregion

        #region 事件
        public delegate void PageIndexChangedEventHandler(object sender, EventArgs e);
        public event PageIndexChangedEventHandler PageIndexChanged;
        protected virtual void OnPageIndexChanged(EventArgs e)
        {
            PageIndexChangedEventHandler handler = PageIndexChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion


    }
}