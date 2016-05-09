using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEchats.Handler
{
    /// <summary>
    /// DataHandler 的摘要说明
    /// </summary>
    public class DataHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            var type = context.Request.Params["type"];
            if (type == "search")
            {
                var name = context.Request.Params["name"];
                //获取数据，并转化为json
                var json = "{FBI:[{name:'rose',age:'25'},{name:'jack', age:'23'}],NBA:[{name:'tom', sex:'man'},{name:'jack', sex:'women'}]}";//省略
                context.Response.Write(json);
            }

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