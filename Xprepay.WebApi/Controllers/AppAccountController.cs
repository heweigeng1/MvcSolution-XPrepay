using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Xprepay.Web.Controllers;

namespace Xprepay.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/account")]
    public class AppAccountController : XprepayApiBase
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("login")]
        public IHttpActionResult Login()
        {

            return Json("test");
        }
    }
}
