using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Transform;

namespace Repeater_NHibernate
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private ISession isession = new NHibernateHelper().GetSession();

        protected void Page_Load(object sender, EventArgs e)
        {
            GvDemoBind();
        }

        /// <summary>
        /// 分页测试
        /// </summary>
        /// <param name="pageStart">开始查找的记录条</param>
        /// <param name="pageLimit">显示数量</param>
        /// <param name="sql"></param>
        /// <returns></returns>

        protected void GvDemoBind()
        {
            IList<SchoolModel> list1 = isession.QueryOver<SchoolModel>().List();

            #region
            string sql = "SELECT * FROM T_School";
            int itemStart = (PagingHelper1.PageIndex - 1) * PagingHelper1.PageSize;
            //sql += string.Format(" LIMIT {0},{1}", itemStart, PagingHelper1.PageSize);
            IList<SchoolModel> list = isession.CreateSQLQuery(sql)
                .SetFirstResult(itemStart)
                .SetMaxResults(PagingHelper1.PageSize)
                .SetResultTransformer(Transformers.AliasToBean<SchoolModel>()).List<SchoolModel>();
            gvDemo.DataSource = list;
            gvDemo.DataBind();
            PagingHelper1.TotalItemCount = list1.Count();
            #endregion

        }


        public IList<SchoolModel> GetCustomerListTest(int pageStart, int pageLimit, string sql)
        {
            IList<SchoolModel> customerList = isession.CreateSQLQuery(sql)
                .SetFirstResult(pageStart)
                .SetMaxResults(pageLimit)
                .SetResultTransformer(Transformers.AliasToBean<SchoolModel>()).List<SchoolModel>();
            return customerList;
        }

        protected void PagingHelper1_OnPageIndexChanged(object sender, EventArgs e)
        {
            GvDemoBind();
        }
    }
}