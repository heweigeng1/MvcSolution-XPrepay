using FluentValidation;
using FluentValidation.Results;
using System;
using System.Web.Mvc;
using Xprepay.Data.Entities;
using Xprepay.Services.Admin;
using Xprepay.Services.Admin.SearchCriterias;
using Xprepay.Web.Admin.ViewModels;
using Xprepay.Web.Admin.ViewModels.Validation;
using Xprepay.Web.ViewModels;

namespace Xprepay.Web.Admin.Controllers
{
    public class CommodityController : AdminControllerBase
    {
        public ActionResult Index()
        {
            return View(new LayoutViewModel());
        }
        public ActionResult List(CommoditySearchCriteria csc, PageRequest request)
        {
            var list = Ioc.Get<ICommodityService>().Search(csc, request);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add(Commodity cmd)
        {
            ValidationResult result = new CommodityValidation().Validate(cmd, ruleSet: "Add");
            MsgModel model;
            if (result.IsValid)
            {
                model = new MsgModel(Ioc.Get<ICommodityService>().Add(cmd));
            }
            else
            {
                model = new MsgModel(result);
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Get(Guid id)
        {
            var data = Ioc.Get<ICommodityService>().Get(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(Commodity cmd)
        {
            ValidationResult result = new CommodityValidation().Validate(cmd, ruleSet: "Add");
            MsgModel model;
            if (result.IsValid)
            {
                model = new MsgModel(Ioc.Get<ICommodityService>().Update(cmd));
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
            MsgModel model = new MsgModel(Ioc.Get<ICommodityService>().Delflag(id));
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 上下架
        /// </summary>
        /// <returns></returns>
        public ActionResult Status(Guid id)
        {
            MsgModel model = new MsgModel(Ioc.Get<ICommodityService>().Status(id));
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Template(Guid? id)
        {
            var model = new CommodityViewModel();
            if (id!=null)
            {
                model.Commodity = Ioc.Get<ICommodityService>().Get(id.Value);
            }
            model.CategoryList = Ioc.Get<ICategoryService>().GetList();
            return View(model);
        }
    }
}
