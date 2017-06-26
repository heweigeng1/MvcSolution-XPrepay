using System.Web.Mvc;
using Xprepay.Services;

namespace Xprepay.Web.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Admin";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            Ioc.RegisterInheritedTypes(typeof(Services.Admin.IUserService).Assembly, typeof(ServiceBase));

            var ns = new[] { "Xprepay.Web.Admin.Controllers.*" };

            context.Map("admin", "home", "index", ns);
            context.Map("admin/{controller}/{action}/{id}", new { controller = "home", action = "index", id = UrlParameter.Optional }, ns);
        }
    }
}
