using RazorEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CodeCommon.PageCommon
{
    public class RazorHandler
    {
        public static string ParseRazor(HttpContext context, string virPath, object model = null)
        {
            string path = context.Server.MapPath(virPath);
            string cacheName = File.GetLastWriteTime(path).ToString();
            string cshtml = File.ReadAllText(path);
            return Razor.Parse(cshtml, model, cacheName);
        }
    }
}
