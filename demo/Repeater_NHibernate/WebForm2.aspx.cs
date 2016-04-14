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
                num.Text = "1";
                repdatabind();
            }
        }

        public void repdatabind()
        {
            PagedDataSource pds = new PagedDataSource();

            pds.AllowPaging = true;//允许分页
            pds.PageSize = 1;//单页显示项数

            int curpage = Convert.ToInt32(num.Text);
            this.BtnDown.Enabled = true;
            this.BtnUp.Enabled = true;
            pds.CurrentPageIndex = curpage - 1;
            if (curpage == 1)
            {
                this.BtnUp.Enabled = false;
            }
            if (curpage == pds.PageCount)
            {
                this.BtnDown.Enabled = false;
            }

            int itemStart = (curpage - 1) * pds.PageSize;


            IList<SchoolModel> list44 = null;
            list44 = isession.CreateCriteria(typeof(SchoolModel))
               .SetFirstResult(itemStart)
               .SetMaxResults(pds.PageSize)
               .List<SchoolModel>();


            pds.DataSource = list44;

            this.Repeater1.DataSource = list44;
            this.Repeater1.DataBind();
        }

        protected void BtnUp_Click(object sender, EventArgs e)
        {
            this.num.Text = Convert.ToString(Convert.ToInt32(num.Text) - 1);
            repdatabind();
        }
        protected void BtnDown_Click(object sender, EventArgs e)
        {
            this.num.Text = Convert.ToString(Convert.ToInt32(num.Text) + 1);
            repdatabind();
        }
    }
}