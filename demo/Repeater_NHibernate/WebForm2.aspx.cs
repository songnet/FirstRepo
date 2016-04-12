using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Transform;
using NHibernate.Criterion;

namespace Repeater_NHibernate
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        private ISession isession = new NHibernateHelper().GetSession();

        private void con()
        {
            PagedDataSource pds = new PagedDataSource();

            //pds.DataSource = list44;
            pds.AllowPaging = true;//允许分页
            pds.PageSize = 8;//单页显示项数
            int CurPage;
            if (Request.QueryString["Page"] != null)
                CurPage = Convert.ToInt32(Request.QueryString["Page"]);
            else
                CurPage = 1;
            pds.CurrentPageIndex = CurPage - 1;
            int Count = pds.PageCount;

            lblCurrentPage.Text = "当前页：" + CurPage.ToString();
            labPage.Text = Count.ToString();

            if (!pds.IsFirstPage)
            {
                this.first.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=1";
                this.last.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(Count - 1); ;
                up.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(CurPage - 1);
            }
            else
            {
                this.first.Visible = false;
                this.last.Visible = false;

            }

            if (!pds.IsLastPage)
            {

                next.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(CurPage + 1);
            }
            else
            {
                this.first.Visible = false;
                this.last.Visible = false;

            }


            var query = isession.CreateCriteria(typeof(SchoolModel)).Add(Restrictions.Eq("SchoolName", "qinghua"));

            var list1 = query.List<SchoolModel>();

            int itemStart = (CurPage - 1) * pds.PageSize;
            IList<SchoolModel> list44 = null;
            list44 = isession.CreateCriteria(typeof(SchoolModel))
               .SetFirstResult(itemStart)
               .SetMaxResults(pds.PageSize)
               .List<SchoolModel>();

            Repeater1.DataSource = pds;
            Repeater1.DataBind();

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                con();
                this.first.Visible = true;
                this.last.Visible = true;
                //this.Repeater1.DataSource = pds();
                //this.Repeater1.DataBind();

            }

        }
    }
}