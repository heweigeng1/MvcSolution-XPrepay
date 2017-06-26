using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace XPrepay.Web.Api.Controllers
{
   
    [RoutePrefix("api/account")]
    public class AccountController: ApiController
    {
        [Route("login")]
        public IHttpActionResult Login()
        {
            return Json("test");
        }
    }
}
