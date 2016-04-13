using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    public partial class WebForm3 : System.Web.UI.Page
    {

        private ISession isession = new NHibernateHelper().GetSession();

        protected void Page_Load(object sender, EventArgs e)
        {

            ViewState["keyWord"] = "";
            ViewState["style"] = "";

            GetPager();
            AspNetPager1.CurrentPageIndex = 1;
            GetDepNews();
        }

        //绑定部门新闻到Repeater控件   
        private void GetDepNews()
        {

            //string sqlDataString = "declare @sqlString varchar(500);declare @whereString varchar(200);set @sqlString='select id,title,author,content from Mis_News where '; set @whereString=' checkone='+char(39)+'是'+char(39)+' and checktwo='+char(39)+'是'+char(39)+' and checkthree='+char(39)+'是'+char(39)+' and dep_id='+@dep_id; set @whereString+=case @style when '0' then ' and title like '+char(39)+'%'+@keyWord+'%'+char(39) when '1' then ' and author like '+char(39)+'%'+@keyWord+'%'+char(39) when '2' then ' and content like '+char(39)+'%'+@keyWord+'%'+char(39) when '' then '' end set @sqlString+=@whereString;execute( @sqlString)";

            //SqlParameter[] parasData = {
            //                               new SqlParameter("@dep_id",ViewState["dep_id"].ToString().Trim()),
            //                               new SqlParameter("@keyWord",ViewState["keyWord"].ToString().Trim()),
            //                               new SqlParameter("@style",ViewState["style"].ToString().Trim()),
            //                           };
            //SqlDataAdapter da = null;// sqlhelper.QueryAdapter(sqlDataString, "mis", parasData);
            //DataTable dt = new DataTable();
            //da.Fill(AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, dt);

            int itemStart = (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize;
            IList<SchoolModel> list44 = null;
            list44 = isession.CreateCriteria(typeof(SchoolModel))
               .SetFirstResult(itemStart)
               .SetMaxResults(AspNetPager1.PageSize)
               .List<SchoolModel>();
            repShowNews.DataSource = list44;
            repShowNews.DataBind();
        }

        //绑定总页数到aspnetpager控件  
        private void GetPager()
        {
            var query = isession.CreateCriteria(typeof(SchoolModel));
            //.Add(Restrictions.Eq("SchoolName", "qinghua"));
            var list1 = query.List<SchoolModel>();

            AspNetPager1.AlwaysShow = true;
            AspNetPager1.RecordCount = list1.Count;
            AspNetPager1.PageSize = 10;
        }

        //搜索  
        protected void btSearch_Click(object sender, EventArgs e)
        {
            ViewState["keyWord"] = txtkeyWord.Text.Trim();
            ViewState["style"] = ddlStyle.SelectedValue.Trim();
            //Response.Write(ViewState["style"].ToString().Trim() + ";" + ViewState["keyWord"].ToString());  
            //return;  
            GetPager();
            AspNetPager1.CurrentPageIndex = 1;
            GetDepNews();
        }

        //分页  
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            GetPager();
            GetDepNews();
        }

        ///   <summary>   
        ///   将指定字符串按指定长度进行剪切，   
        ///   </summary>   
        ///   <param   name= "oldStr "> 需要截断的字符串 </param>   
        ///   <param   name= "maxLength "> 字符串的最大长度 </param>   
        ///   <param   name= "endWith "> 超过长度的后缀 </param>   
        ///   <returns> 如果超过长度，返回截断后的新字符串加上后缀，否则，返回原字符串 </returns>   
        public static string StringTruncat(string oldStr, int maxLength, string endWith)
        {
            if (string.IsNullOrEmpty(oldStr) || maxLength < 1)
            {
                return endWith;
            }
            else
            {
                string strTmp = oldStr.Substring(0, maxLength);
                return strTmp + endWith;
            }
        }
    }
}