using System;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Xprepay.Data.Enums;
using Xprepay.Web.ViewModels;

namespace Xprepay.Web.Controllers
{
    public class FileUploadController : Controller
    {
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            MsgModel model = new MsgModel();
            //string path = Ioc.Get<ISaveFileService>().SaveExcel(file, "/file/excel/ConstructionIndustryData/");
            HttpContext HttpCurrent = System.Web.HttpContext.Current;
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UploadImg()
        {
            var file = Request.Files["file"];
            MsgModel model = new MsgModel { Msg = "上传异常", State = (int)EnumMsgState.失败, Url = "" };
            //判断是否为图片图片,尺寸
            if (file.ValidImgExt())
            {
                Image img = Image.FromStream(file.InputStream);
                try
                {
                    model.Url = img.SaveImg(Path.GetExtension(file.FileName).ToLower());
                    model.State = (int)EnumMsgState.成功;
                    model.Msg = "添加成功";
                }
                catch (Exception ex)
                {
                    Logger.Error("file", ex);
                }
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
