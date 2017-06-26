
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Web.Mvc;
using Xprepay.Data.Entities;
using Xprepay.Services;
using Xprepay.Services.Admin;
using Xprepay.Services.Admin.SearchCriterias;
using Xprepay.Web.Admin.ViewModels;
using Xprepay.Web.Admin.ViewModels.Validation;
using Xprepay.Web.ViewModels;

namespace Xprepay.Web.Admin.Controllers
{
    public class DistributorController : AdminControllerBase
    {
        public ActionResult Index()
        {
            var model = new DistributorViewModel();
            model.AreaList = Ioc.Get<IAreaService>().GetList();
            return View(model);
        }
        public ActionResult List(DistributorSearchCriteria csc, PageRequest request)
        {
            var list = Ioc.Get<IDistributorService>().Search(csc, request);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add(Distributor entity)
        {
            ValidationResult result = new DistributorValidation().Validate(entity,ruleSet:"Add");
            MsgModel model;
            if (result.IsValid)
            {
                model = new MsgModel(Ioc.Get<IDistributorService>().Add(entity));
            }
            else
            {
                model = new MsgModel(result);
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Get(Guid id)
        {
            var data = Ioc.Get<IDistributorService>().Get(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(Distributor entity)
        {
            ValidationResult result = new DistributorValidation().Validate(entity, ruleSet: "Add");
            MsgModel model;
            if (result.IsValid)
            {
                model = new MsgModel(Ioc.Get<IDistributorService>().Update(entity));
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
            MsgModel model = new MsgModel(Ioc.Get<IDistributorService>().Delflag(id));
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 上下架
        /// </summary>
        /// <returns></returns>
        public ActionResult Status(Guid id)
        {
            MsgModel model = new MsgModel(Ioc.Get<IDistributorService>().Status(id));
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
