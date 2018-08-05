using CodeCommon.DBCommon;
using CodeCommon.PageCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeSite.system.controller
{
    /// <summary>
    /// sysTables 的摘要说明
    /// </summary>
    public class sysTables : BaseHandler
    {
        public void ViewList(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string html = RazorHandler.ParseRazor(context, "../View/sysTables.cshtml");
            context.Response.Write(html);
        }
    }
}