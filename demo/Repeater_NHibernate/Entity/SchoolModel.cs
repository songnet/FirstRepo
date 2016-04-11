using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repeater_NHibernate
{
    public class SchoolModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual int ID
        {
            get;
            set;
        }
        /// <summary>
        /// SchoolName
        /// </summary>
        public virtual string SchoolName
        {
            get;
            set;
        }
    }
}
