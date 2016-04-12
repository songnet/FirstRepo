using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Repeater_NHibernate
{
    public partial class UCPagingHelper : System.Web.UI.UserControl
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
                //if (m_PageSize.Equals(0))
                //{
                //    m_PageSize = 10;
                //}
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

        public string BindDataMethodName    //绑定数据的方法名
        {
            set;
            private get;
        }
        #endregion

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
            ReBindData(lbtn.CommandArgument);
        }

        #region 公共方法

        #endregion

        #region 私有方法
        private void BindPagingHelperControl()
        {
            int totalPages = (TotalItemCount % PageSize) == 0 ? TotalItemCount / PageSize : TotalItemCount / PageSize + 1;
            //显示
            lbPageIndex.Text = PageIndex.ToString();
            lbTotalPages.Text = totalPages.ToString();
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
        private void ReBindData(string pageIndex)
        {
            PageIndex = int.Parse(pageIndex);
            Object obj = null;  //空间所在的容器
            if (base.Parent is HtmlForm)
            {
                obj = this.Page;
            }
            else if (base.Parent is ContentPlaceHolder)
            {
                obj = this.Page.Master.Page;
            }
            else
            {
                obj = base.Parent;
            }
            MethodInfo methodInfo = obj.GetType().GetMethod(BindDataMethodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            methodInfo.Invoke(obj, null);
            BindPagingHelperControl();
        }
        #endregion

    }
}