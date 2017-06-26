using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Xprepay;
using Xprepay.Services.Admin;
using Xprepay.Web.Admin.ViewModels;

namespace Xprepay.Web.Admin.Controllers
{
    public class RoleController : AdminControllerBase
    {
        public ActionResult Index()
        {
            var model = new RoleIndexViewModel();
            return AreaView("role/index.cshtml", model);
        }

        public ActionResult List()
        {
            return Json("");
        }
        public ActionResult SearchUsers(string keyword, Guid? roleId, PageRequest request)
        {
            var service = Ioc.Get<IRoleService>();
            var list = service.SearchUsers(keyword, roleId, request);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult Add()
        {
            var service = Ioc.Get<IRoleService>();
            var roles = service.GetAll();
            return AreaPartialView("role/add.cshtml", roles);
        }

        [HttpPost]
        public StandardJsonResult Save(string username, List<Guid> roleIds)
        {
            return base.Try(() =>
            {
                var service = Ioc.Get<IRoleService>();
                service.SaveUserRoles(username, roleIds);
            });
        }

        [HttpPost]
        public StandardJsonResult Delete(string username)
        {
            return base.Try(() =>
            {
                var service = Ioc.Get<IRoleService>();
                service.DeleteAllRoles(username);
            });
        }
    }
}
