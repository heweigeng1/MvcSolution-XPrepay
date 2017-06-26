using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xprepay.Services;

namespace Xprepay.Web.Mobile
{
    public class MobileAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Mobile";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            Ioc.RegisterInheritedTypes(typeof(Services.Mobile.IMobileOrderService).Assembly, typeof(ServiceBase));

            var ns = new[] { "Xprepay.Web.Mobile.Controllers.*" };
            context.Map("mobile", "home", "index", ns);
            context.Map("mobile/{controller}/{action}/{id}", new { controller = "home", action = "index", id = UrlParameter.Optional }, ns);
        }
    }
}
