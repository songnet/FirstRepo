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
    public partial class WebForm1 : System.Web.UI.Page
    {
        private ISession isession = new NHibernateHelper().GetSession();

        protected void Page_Load(object sender, EventArgs e)
        {
            GvDemoBind();
        }

        protected void GvDemoBind()
        {
            var query = isession.CreateCriteria(typeof(SchoolModel)).Add(Restrictions.Eq("SchoolName", "qinghua"));

            var list1 = query.List<SchoolModel>();


            int itemStart = (PagingHelper1.PageIndex - 1) * PagingHelper1.PageSize;
            IList<SchoolModel> list44 = null;
            list44 = isession.CreateCriteria(typeof(SchoolModel))
               .Add(Restrictions.Eq("SchoolName", "qinghua"))
               .SetFirstResult(itemStart)
               .SetMaxResults(PagingHelper1.PageSize)
               .List<SchoolModel>();


            gvDemo.DataSource = list44;
            gvDemo.DataBind();
            PagingHelper1.TotalItemCount = list1.Count();

        }

        private static ICriteria CreateQuery<T>(ISession session, SearchRequest searchRequest)
        {
            return CreateQuery<T>(session, searchRequest, false);
        }
        private static ICriteria CreateQuery<T>(ISession session, SearchRequest searchRequest, bool compareFirstCopyPercent)
        {
            var query = session.CreateCriteria(typeof(T));

            if (searchRequest.ID != 0)
                query.Add(Restrictions.Ge("ID", searchRequest.ID));

            if (string.IsNullOrEmpty(searchRequest.SchoolName))
                query.Add(Restrictions.Le("SchoolName", searchRequest.SchoolName));

            return query;
        }


        protected void PagingHelper1_OnPageIndexChanged(object sender, EventArgs e)
        {
            GvDemoBind();
        }
    }
}