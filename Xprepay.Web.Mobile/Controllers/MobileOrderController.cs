
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Xprepay.Data.Entities;
using Xprepay.Services.Mobile;
using Xprepay.Services.Mobile.SearchCriterias;
using Xprepay.Web.Mobile.ViewModels.Validation;
using Xprepay.Web.Security;
using Xprepay.Web.ViewModels;

namespace Xprepay.Web.Mobile.Controllers
{
    [MvcAuthorize]
    public class MobileOrderController : MobileControllerBase
    {
        public ActionResult Index()
        {
            return View(new LayoutViewModel());
        }
        public ActionResult List(MobileOrderSearchCriteria csc, PageRequest request)
        {
            var list = Ioc.Get<IMobileOrderService>().Search(csc, request);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add(Order entity)
        {
            ValidationResult result = new MobileOrderValidation().Validate(entity, ruleSet: "Add");
            MsgModel model;
            if (result.IsValid)
            {
                model = new MsgModel(Ioc.Get<IMobileOrderService>().Add(entity));
            }
            else
            {
                model = new MsgModel(result);
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Get(Guid id)
        {
            var data = Ioc.Get<IMobileOrderService>().Get(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(Order entity)
        {
            ValidationResult result = new MobileOrderValidation().Validate(entity, ruleSet: "Add");
            MsgModel model;
            if (result.IsValid)
            {
                model = new MsgModel(Ioc.Get<IMobileOrderService>().Update(entity));
            }
            else
            {
                model = new MsgModel(result);
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public ActionResult Delflag(Guid id)
        {
            MsgModel model = new MsgModel(Ioc.Get<IMobileOrderService>().Delflag(id));
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 上下架
        /// </summary>
        /// <returns></returns>
        public ActionResult Status(Guid id)
        {
            MsgModel model = new MsgModel(Ioc.Get<IMobileOrderService>().Status(id));
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="bind"></param>
        /// <returns></returns>
        public ActionResult PlaceAnOrder(MobileOrderBindModel bind)
        {
            LayoutViewModel mode = new LayoutViewModel();
            bind.BuyerId = mode.GetSession().User.Id;
            var data = Ioc.Get<IMobileOrderService>().PlaceAnOrder(bind);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
