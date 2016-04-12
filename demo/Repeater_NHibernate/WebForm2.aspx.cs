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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GvDemoBind();
            }
        }

        protected void GvDemoBind()
        {
            var query = isession.CreateCriteria(typeof(SchoolModel));
                //.Add(Restrictions.Eq("SchoolName", "qinghua"));

            var list1 = query.List<SchoolModel>();


            int itemStart = (UCPagingHelper.PageIndex - 1) * UCPagingHelper.PageSize;
            IList<SchoolModel> list44 = null;
            list44 = isession.CreateCriteria(typeof(SchoolModel))
               .SetFirstResult(itemStart)
               .SetMaxResults(UCPagingHelper.PageSize)
               .List<SchoolModel>();

            gvDemo.DataSource = list44;
            gvDemo.DataBind();
            UCPagingHelper.TotalItemCount = list1.Count();

        }

    }
}