using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repeater_NHibernate
{
    public class SearchRequest
    {
        /// <summary>
        /// 检测用户的父账号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 检测用户的子账号
        /// </summary>
        public string SchoolName { get; set; }



        #region
        /// <summary>
        /// 分页参数 所在页
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 分页参数 每页多少条
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 分页参数 数据总数
        /// </summary>
        public int TotalItemCount { get; set; }


        #endregion

        public override string ToString()
        {
            return String.Format("ID:{0}, SchoolName:{1}",
                                 ID, SchoolName);
        }
    }
}
