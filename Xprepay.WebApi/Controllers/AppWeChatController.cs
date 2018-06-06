using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Xprepay.Services.WebApi.Dtos;
using Xprepay.WeChatUtils;
using Xprepay.Web.Controllers;
using System;

namespace Xprepay.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/wechat")]
    public class AppWeChatController : XprepayApiBase
    {
        /// <summary>
        /// 移动支付回调接口,并告诉微信已经成功接收
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("mobilePayNodify")]
        public async Task<HttpResponseMessage> MobilePayNodify()
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage (HttpStatusCode.OK);
            string requestxml = await Request.Content.ReadAsStringAsync();

            string return_string = string.Empty;
            SortedDictionary<string, string> map = new SortedDictionary<string, string>();
            object obj = WxUtils.XmlDeserialize(typeof(MobilePayCallbackDto), requestxml);
            //在此判断回调的来源是否是正确的.
            if (obj is MobilePayCallbackDto && ((MobilePayCallbackDto)obj).result_code == "SUCCESS")
            {
                string order = ((MobilePayCallbackDto)obj).out_trade_no;
                //支付成功,在此操作订单结果.
                map.Add("return_code", "SUCCESS");
                map.Add("return_msg", "");
            }
            else
            {
                map.Add("return_code", "FAIL");
                map.Add("return_msg", "统一下单失败");
            }
            var  xml =  Encoding.UTF8.GetBytes(map.SortedDictionaryToWxXml()); 
            httpResponse.Content = new StreamContent(new MemoryStream(xml));

            return httpResponse;
        }

        /// <summary>
        /// 统一下单接口,结合自己的项目.在客户端提交的时候添加订单参数
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("mobilePaying")]
        public MobilePayingOutput MobilePaying()
        {
            #region 统一下单map 请配置好WxConfig
            SortedDictionary<string, string> untifiedOrder = new SortedDictionary<string, string>()
            {
                {"appid",WxConfig.AppId},
                {"attach" , "wxpay" },
                {"body", "订单支付"},
                {"mch_id", WxConfig.MCH_ID },
                {"nonce_str", WxUtils.RandomStr(16)},
                {"notify_url", WxConfig.AppPayNodifyUrl},
                {"spbill_create_ip",""},//用户IP
                {"total_fee", "0.01"},//金额 这里需要修改为订单金额
                {"trade_type","APP" },
                {"out_trade_no",DateTime.Now.ToString("yyyyMMddHHmmss")+WxUtils.RandomStr(2) }
            };
            #endregion

            #region 生成sign
            string md5key = $@"{ untifiedOrder.SortedDictionaryToWxUrl()}&key={WxConfig.PARTNER_ID}";
            string sign = WxUtils.GetSign(md5key, "utf-8");
            #endregion

            #region 请求微信统一下单接口 获取预支付订单号
            string xml = untifiedOrder.SortedDictionaryToWxXml().Replace("</xml>", $@"<sign><![CDATA[{ sign }]]></sign></xml>");
            string callbackXml = WxUtils.PostToUnifiedOrder(xml);//请求微信统一下单接口
            MobilePayCallbackDto callbackobj = (MobilePayCallbackDto)WxUtils.XmlDeserialize(typeof(MobilePayCallbackDto), callbackXml);
            #endregion
            #region 用户端sign
            MobilePayingOutput output = new MobilePayingOutput
            {
                appid = WxConfig.AppId,
                noncestr = WxUtils.RandomStr(16),
                package = "Sign=WXPay",
                partnerid = WxConfig.PARTNER_ID,
                prepayid = callbackobj.prepay_id,
                timestamp = DateTime.UtcNow.ToTimeStamp(),
                sign = "",
            };
            var appmap = WxUtils.ObjToSortedDictionary(output);
            string appmd5key = $@"{ appmap.SortedDictionaryToWxUrl()}&key={WxConfig.PARTNER_ID}";
            output.sign = WxUtils.GetSign(appmd5key, "utf-8");
            #endregion
            return output;
        }
    }
}
