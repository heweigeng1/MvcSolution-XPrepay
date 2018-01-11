using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Xprepay.Web.Controllers;

namespace Xprepay.WebApi.Controllers
{
    [RoutePrefix("api/account")]
    public class AppAccountController : XprepayApiBase
    {
        [HttpGet]
        [Route("login")]
        public IHttpActionResult Login()
        {
            throw new KnownException("test");
            return Json("test");
        }
    }
}
