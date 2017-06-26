
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Web;
using System.Web.Mvc;
using Xprepay.Data.Entities;
using Xprepay.Excel;
using Xprepay.Services.Admin;
using Xprepay.Services.Admin.SearchCriterias;
using Xprepay.Web.Admin.ViewModels.Validation;
using Xprepay.Web.ViewModels;

namespace Xprepay.Web.Admin.Controllers
{
    public class OrderController : AdminControllerBase
    {
        public ActionResult Index()
        {
            return View(new LayoutViewModel());
        }
        public ActionResult List(OrderSearchCriteria csc, PageRequest request)
        {
            var list = Ioc.Get<IOrderService>().Search(csc, request);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add(Order entity)
        {
            ValidationResult result = new OrderValidation().Validate(entity, ruleSet: "Add");
            MsgModel model;
            if (result.IsValid)
            {
                model = new MsgModel(Ioc.Get<IOrderService>().Add(entity));
            }
            else
            {
                model = new MsgModel(result);
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Get(Guid id)
        {
            var data = Ioc.Get<IOrderService>().Get(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(Order entity)
        {
            ValidationResult result = new OrderValidation().Validate(entity, ruleSet: "Add");
            MsgModel model;
            if (result.IsValid)
            {
                model = new MsgModel(Ioc.Get<IOrderService>().Update(entity));
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
            MsgModel model = new MsgModel(Ioc.Get<IOrderService>().Delflag(id));
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 上下架
        /// </summary>
        /// <returns></returns>
        public ActionResult Status(Guid id)
        {
            MsgModel model = new MsgModel(Ioc.Get<IOrderService>().Status(id));
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public FilePathResult DownloadOrderDetile(OrderSearchCriteria csc)
        {
            HttpContext HttpCurrent = System.Web.HttpContext.Current;
            var data = Ioc.Get<IOrderDetailService>().GetOrderDetail(csc);
            string[] title = "1,2,3,4,5,6,7,8,9,10,11".Split(',');
            string filename = $"~/file/excel/Export/Order{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx";
            filename = HttpCurrent.Server.MapPath(filename);
            filename = EpplusHelper.SaveToExcel(data, filename, title);
            return File(filename, "application/octet-stream", $"订单{DateTime.Now.ToString("yyyyMMddHHmmss")}.xls");
        }
    }
}
