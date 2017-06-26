using FluentValidation;
using FluentValidation.Results;
using System;
using System.Web;
using System.Web.Mvc;
using Xprepay.Data;
using Xprepay.Data.Entities;
using Xprepay.Data.Enums;
using Xprepay.Services.Admin;
using Xprepay.Services.Admin.SearchCriterias;
using Xprepay.Web.Admin.ViewModels;
using Xprepay.Web.Admin.ViewModels.Validation;
using Xprepay.Web.ViewModels;

namespace Xprepay.Web.Admin.Controllers
{
    public class UserController : AdminControllerBase
    {
        public ActionResult Index()
        {
            var model = new UserIndexViewModel();
            return AreaView("user/index.cshtml", model);
        }
        public ActionResult List(UserSearchCriteria criteria, PageRequest request)
        {
            var service = Ioc.Get<IUserService>();
            var list = service.Search(criteria, request);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add(User user)
        {
            ValidationResult result = new UserValidation().Validate(user, ruleSet: "Add");
            MsgModel model;
            if (result.IsValid)
            {
                model = new MsgModel(Ioc.Get<Services.IUserService>().Add(user));
            }
            else
            {
                model = new MsgModel(result);
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Get(Guid id)
        {
            var user = Ioc.Get<Services.IUserService>().Get(id).ToDto();
            return Json(user, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 只修改UserName NickName，phonenum
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ActionResult Update(User user)
        {
            ValidationResult result = new UserValidation().Validate(user, ruleSet: "Update");//校验
            MsgModel model;
            if (result.IsValid)
            {
                model = new MsgModel(Ioc.Get<Services.IUserService>().Update(user));
            }
            else
            {
                model = new MsgModel(result);
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ActionResult ChangePassword(User user)
        {
            ValidationResult result = new UserValidation().Validate(user, ruleSet: "ChangePassword");
            MsgModel model = new MsgModel(result);
            if (result.IsValid)
            {
                model = new MsgModel(Ioc.Get<Services.IUserService>().ChangePassword(user));
            }
            else
            {
                model = new MsgModel(result);
            }
            return Json(model, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// 修改delflag
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delflag(Guid id)
        {
            MsgModel model = new MsgModel(Ioc.Get<Services.IUserService>().Delflag(id));
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserDistributor(Guid userId)
        {
            var model = new UserDistributorViewModel()
            {
                Uid = userId,
                DList = Ioc.Get<IDistributorService>().GetList(),
                UserDList = Ioc.Get<IUserDistributorRLService>().GetUserDistributor(userId)
            };
            return View(model);
        }
        public ActionResult AddUserDistributor(UserDistributorRL rl)
        {
            MsgModel model = new MsgModel(Ioc.Get<IUserDistributorRLService>().Add(rl));
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DelUserDistributor(UserDistributorRL rl)
        {
            MsgModel model = new MsgModel(Ioc.Get<IUserDistributorRLService>().Del(rl));
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取用户管理店铺列表
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public ActionResult GetUserDistributor()
        {
            LayoutViewModel model = new LayoutViewModel();
            var user = model.GetSession().User;
            var data = Ioc.Get<IUserDistributorRLService>().GetUserDistributor(user.Id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
