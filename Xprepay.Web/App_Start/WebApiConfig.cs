using System.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Xprepay.Web.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //跨域配置
            var allowedMethods = ConfigurationManager.AppSettings["cors:allowedMethods"];
            var allowedOrigin = ConfigurationManager.AppSettings["cors:allowedOrigin"];
            var allowedHeaders = ConfigurationManager.AppSettings["cors:allowedHeaders"];
            config.EnableCors(new EnableCorsAttribute(allowedOrigin, allowedHeaders, allowedMethods)
            {
                SupportsCredentials = true,//支持用户凭证
            });

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            // config.MessageHandlers.Add(new AuthenticationHandler());
        }
    }
}
