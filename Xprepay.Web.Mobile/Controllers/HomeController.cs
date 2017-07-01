using System.Web.Mvc;
using System.Web.Security;
using Xprepay.Web.Security;
using Xprepay.Web.ViewModels;

namespace Xprepay.Web.Mobile.Controllers
{
    [MvcAuthorize]
    public class HomeController : MobileControllerBase
    {
        public ActionResult Index()
        {
            return View(new LayoutViewModel());
        }
        public ActionResult Logout(string pageKind)
        {
            FormsAuthentication.SignOut();
            GetSession().Logout();
            Session.Abandon();
            return Redirect("/Public/Home/MobileLogin");
        }
    }
}
