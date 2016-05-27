using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace WebProgressBar
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            string data = "ajax返回result";
            context.Response.ContentType = "text/plain";
            Thread.Sleep(5000);
            context.Response.Write(data);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}