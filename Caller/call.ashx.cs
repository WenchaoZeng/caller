using System;
using System.Collections.Generic;
using System.Web;
using System.Reflection;
using System.IO;
using System.Text;

namespace name.zwc.Caller
{
    public class call : IHttpHandler
    {
        public readonly String HandlerNamesapce = "name.zwc.Caller.Handlers";

        public void ProcessRequest(HttpContext context)
        {
            String handlerName = context.Request.QueryString["h"];
            String methodName = context.Request.QueryString["m"];
            if (String.IsNullOrEmpty(handlerName) || String.IsNullOrEmpty(methodName))
            {
                return;
            }

            // 参数
            String input = new StreamReader(context.Request.InputStream, Encoding.UTF8).ReadToEnd();
            Dictionary<String, String> args = new Dictionary<String, String>();
            foreach (String key in context.Request.Params.Keys)
            {
                args.Add(key, context.Request.Params[key]);
            }

            // 构建处理器
            Assembly assembly = Assembly.Load(HandlerNamesapce + "." + handlerName);
            Type type = assembly.GetType(HandlerNamesapce + "." + handlerName);
            MethodInfo method = type.GetMethod(methodName);

            String result = (String)method.Invoke(null, new object[] { input, args });

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
}