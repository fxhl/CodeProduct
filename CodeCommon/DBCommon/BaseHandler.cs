using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace CodeCommon.DBCommon
{
    public class BaseHandler : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"];
            Type type = this.GetType();
            MethodInfo methodinfo = type.GetMethod(action);
            if (methodinfo == null)
            {
                throw new Exception("action不存在");
            }
            //object[] paAttrs = methodinfo.GetCustomAttributes(typeof(PowerActionAttribute), false);
            //if (paAttrs.Length > 0)
            //{
            //    PowerActionAttribute poweraction = (PowerActionAttribute)paAttrs[0];
            //}
            methodinfo.Invoke(this, new object[] { context });
        }
    }
}
