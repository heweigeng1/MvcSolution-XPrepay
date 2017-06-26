
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Web.Mvc;
using Xprepay.Data.Entities;
using Xprepay.Services.Admin;
using Xprepay.Services.Admin.SearchCriterias;
using Xprepay.Web.Admin.ViewModels.Validation;
using Xprepay.Web.ViewModels;

namespace Xprepay.Web.Admin.Controllers
{
    public class CategoryController : AdminControllerBase
    {
        public ActionResult Index()
        {
            return View(new LayoutViewModel());
        }
        public ActionResult List(CategorySearchCriteria csc, PageRequest request)
        {
            var list = Ioc.Get<ICategoryService>().Search(csc, request);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add(Category entity)
        {
            ValidationResult result = new CategoryValidation().Validate(entity,ruleSet:"Add");
            MsgModel model;
            if (result.IsValid)
            {
                model = new MsgModel(Ioc.Get<ICategoryService>().Add(entity));
            }
            else
            {
                model = new MsgModel(result);
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Get(Guid id)
        {
            var data = Ioc.Get<ICategoryService>().Get(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(Category entity)
        {
            ValidationResult result = new CategoryValidation().Validate(entity, ruleSet: "Add");
            MsgModel model;
            if (result.IsValid)
            {
                model = new MsgModel(Ioc.Get<ICategoryService>().Update(entity));
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
            MsgModel model = new MsgModel(Ioc.Get<ICategoryService>().Delflag(id));
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 上下架
        /// </summary>
        /// <returns></returns>
        public ActionResult Status(Guid id)
        {
            MsgModel model = new MsgModel(Ioc.Get<ICategoryService>().Status(id));
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
