
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Web.Mvc;
using Xprepay.Data.Entities;
using Xprepay.Services;
using Xprepay.Services.SearchCriterias;
using Xprepay.Web.Admin.ViewModels.Validation;
using Xprepay.Web.ViewModels;

namespace Xprepay.Web.Admin.Controllers
{
    public class AreaController : AdminControllerBase
    {
        public ActionResult Index()
        {
            return View(new LayoutViewModel());
        }
        public ActionResult List(AreaSearchCriteria csc, PageRequest request)
        {
            var list = Ioc.Get<IAreaService>().Search(csc, request);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add(Area entity)
        {
            ValidationResult result = new AreaValidation().Validate(entity,ruleSet:"Add");
            MsgModel model;
            if (result.IsValid)
            {
                model = new MsgModel(Ioc.Get<IAreaService>().Add(entity));
            }
            else
            {
                model = new MsgModel(result);
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Get(Guid id)
        {
            var data = Ioc.Get<IAreaService>().Get(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(Area entity)
        {
            ValidationResult result = new AreaValidation().Validate(entity, ruleSet: "Add");
            MsgModel model;
            if (result.IsValid)
            {
                model = new MsgModel(Ioc.Get<IAreaService>().Update(entity));
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
            MsgModel model = new MsgModel(Ioc.Get<IAreaService>().Delflag(id));
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetList()
        {
            var data = Ioc.Get<IAreaService>().GetList();
            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}
