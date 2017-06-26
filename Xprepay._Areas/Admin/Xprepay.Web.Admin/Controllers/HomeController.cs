using System.Web.Mvc;
using System.Web.Security;
using Xprepay.Web.ViewModels;

namespace Xprepay.Web.Admin.Controllers
{
    public  class HomeController:AdminControllerBase
    {
        public ActionResult Index()
        {
            return View(new LayoutViewModel());
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            GetSession().Logout();
            Session.Abandon();
            return Redirect("/Login");
        }
    }
}
