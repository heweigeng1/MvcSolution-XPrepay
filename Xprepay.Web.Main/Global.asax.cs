using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Xprepay.Services;

namespace Xprepay.Web.Main
{
    public class MainApplication : MvcApplication
    {
        protected override void OnApplicationStart()
        {
            SettingContext.Instance.Init();
            AutoMapperConfigure.Configuration.Configure();//automapper
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }

        protected override void RegisterRoutes(RouteCollection routes)
        {
            var Common = new[] { "Xprepay.Web.Controllers.*" };
            routes.Map("img/{size}/default-{name}.{format}", "image", "SystemDefault", Common);
            routes.Map("img/{size}/t{imageType}t{yearMonth}-{id}.{format}", "image", "index", Common);
            routes.Map("img/{size}/{parameter}", "image", "index", Common);
            routes.Map("common/{controler}/{action}/{id}", new { controller = "FileUpload", action = "UploadFile", id = UrlParameter.Optional }, Common);
            
            var ns = new[] { "Xprepay.Web.Public.Controllers.*" };
            var defaults = new { controller = "Home", action = "Login", id = UrlParameter.Optional };

            routes.Map("", defaults, ns);
            routes.Map("{controler}/{action}/{id}", defaults, ns);
        }

        protected override void RegisterIoc()
        {
            Ioc.RegisterInheritedTypes(typeof(ServiceBase).Assembly, typeof(ServiceBase));
        }
        /// <summary>
        /// webapi start session
        /// </summary>
        protected void Application_PostAuthorizeRequest()
        {
            System.Web.HttpContext.Current.SetSessionStateBehavior(System.Web.SessionState.SessionStateBehavior.Required);
        }
    }
}