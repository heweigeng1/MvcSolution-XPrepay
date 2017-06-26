using FluentValidation;
using FluentValidation.Results;
using System;
using System.Web.Mvc;
using System.Web.Security;
using Xprepay.Data.Entities;
using Xprepay.Services.Mobile;
using Xprepay.Services.Mobile.SearchCriterias;
using Xprepay.Web.Mobile.ViewModels.Validation;
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
