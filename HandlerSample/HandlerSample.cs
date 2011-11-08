using System;
using System.Collections.Generic;
using System.Web;
using System.Text;

// DLL名称: name.zwc.Caller.Handlers.HandlerSample
// 名空间: name.zwc.Caller.Handlers
// 类名: HandlerSample
// 方法定义: public static string SayHello(string input, Dictionary<string, string> args)
namespace name.zwc.Caller.Handlers
{
    public class HandlerSample
    {
        public static string SayHello(string input, Dictionary<string, string> args)
        {
            String result = "Hello " + args["name"];

            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("input:<br/>{0}<br/><br/>", input);
            builder.AppendFormat("return:<br/>{0}<br/><br/>", result);
            builder.AppendLine("args:<br/>");
            foreach (string key in args.Keys)
            {
                builder.AppendLine(key + ": " + args[key] + "<br/>");
            }
            return builder.ToString();
        }
    }
}