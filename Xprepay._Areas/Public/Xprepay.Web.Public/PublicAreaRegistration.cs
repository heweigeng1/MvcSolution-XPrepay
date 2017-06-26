using System.Web.Mvc;
using Xprepay.Services;

namespace Xprepay.Web.Public
{
    public class AppAreaRegistration : AreaRegistration
    {
        public const string Name = "Public";

        public override string AreaName => Name;

        public override void RegisterArea(AreaRegistrationContext context)
        {
            Ioc.RegisterInheritedTypes(typeof(Services.Public.IUserService).Assembly, typeof(ServiceBase));

            var ns = new[] {"Xprepay.Web.Public.Controllers.*"};

            //context.Map("p/{urlKey}", "article", "details", ns);
            context.Map("login", "home", "login", ns);
            context.Map("logout", "home", "logout", ns);
            context.Map("public/{controller}/{action}/{id}", new { controller = "home", action = "login", id = UrlParameter.Optional }, ns);
        }
    }
}
