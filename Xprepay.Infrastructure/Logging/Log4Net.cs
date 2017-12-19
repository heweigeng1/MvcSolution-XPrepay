using log4net;
using log4net.Config;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Xprepay
{
    public class Log4Net
    {
        public static ILog loginfo = LogManager.GetLogger("Loginfo");
        public static ILog logerror = LogManager.GetLogger("FileLogger");
        public static Regex htmlTagReg = new Regex(@"<\w+>|</\w+>", RegexOptions.IgnoreCase);

        public static void SetConfig()
        {
            XmlConfigurator.Configure();
        }
        public static void SetConfig(FileInfo configFile)
        {
            XmlConfigurator.Configure(configFile);
        }

        public static void Log(string info)
        {
            loginfo.Info("访问地址：系统<br />\r\nIP 地  址：N/A <br />\r\n日志内容：<span style=\"color:green\">" + info + "</span>");
        }



        public static void Logmsg(string info)
        {
            if (!loginfo.IsInfoEnabled) return;
            loginfo.Info("日志内容：<span style=\"color:green\">" + info + "</span>");
        }


        private static string AppendLog(NameValueCollection nameValueCollection)
        {
            var stringBuilder = new StringBuilder();
            foreach (var o in nameValueCollection)
            {
                stringBuilder.AppendLine(o.ToString());
                stringBuilder.AppendLine("<br />");
            }
            return stringBuilder.ToString();
        }

        public static void Error(string error, Exception exception)
        {
            logerror.Error("访问地址：系统<br />\r\nIP 地  址：N/A <br />\r\n错误内容：<span style=\"color:red\">" + error + "</span>", exception);
        }
    }
}
