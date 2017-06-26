using System.Web.Mvc;
using System.Web.Security;
using Xprepay.Data;
using Xprepay.Services;
using Xprepay.Web.Security;
using Xprepay.Web.ViewModels;

namespace Xprepay.Web.Public.Controllers
{
    public class AccountController : PublicControllerBase
    {
        public ActionResult Register()
        {
            var model = new LayoutViewModel();
            return AreaView("account/registerStep1.cshtml", model);
        }
    }
}
