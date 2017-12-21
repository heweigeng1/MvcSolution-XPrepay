using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Xprepay.Services;
using Xprepay.Web.ViewModels;

namespace Xprepay.Web.Public.Controllers
{
    public class HomeController : PublicControllerBase
    {
        [HttpGet]
        public ActionResult Login()
        {
            return AreaView("home/Login.cshtml", new LayoutViewModel());
        }

        [HttpPost]
        public StandardJsonResult Login(string UserName, string Password)
        {
           var url= HttpContext.Request.UrlReferrer.AbsolutePath;
            return base.Try(() =>
            {
                if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
                {
                    throw new KnownException("请输入用户名与密码");
                }
              //throw  new Exception("测试");
                var service = Ioc.Get<IUserService>();
                service.Login(UserName, Password,url);
                var user = service.Get(UserName);
                base.LoginUser(user.Id);
            });
        }
        public ActionResult Login(string returnUrl)
        {
            var model = new LayoutViewModel<string>();
            model.Model = returnUrl;
            return AreaView("home/login.cshtml", model);
        }
        public ActionResult MobileLogin()
        {
            return View(new LayoutViewModel());
        }
    }
}
