<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Data;
using System.Collections;
using System.Collections.Generic;

public class Handler : IHttpHandler
{

    List<object> lists = new List<object>();
    string result = "";
    JavaScriptSerializer jsS = new JavaScriptSerializer();

    public void ProcessRequest(HttpContext context)
    {

        string command = context.Request["cmd"];

        switch (command)
        {
            case "pie":
                GetPie(context);
                break;
            case "bar":
                GetBars(context);
                break;
        };

    }

    public void GetPie(HttpContext context)
    {
        lists = new List<object>();
        var obj = new { name = "2014 - 01 - 10", value = "4" };
        lists.Add(obj);
        jsS = new JavaScriptSerializer();
        result = jsS.Serialize(lists);
        context.Response.Write(result);

    }

    public void GetBars(HttpContext context)
    {
        lists = new List<object>();
        var obj = new { name = "2014 - 01 - 10", value = "4" };
        lists.Add(obj);
        jsS = new JavaScriptSerializer();
        result = jsS.Serialize(lists);
        context.Response.Write(result);
    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}