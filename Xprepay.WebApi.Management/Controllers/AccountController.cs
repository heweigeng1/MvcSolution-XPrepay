using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xprepay.Web.Controllers;
using System.Web.Http;
using Xprepay.WebApi.Management.ViewModels;

namespace Xprepay.WebApi.Management.Controllers
{
    [RoutePrefix("management/account")]
    public class AccountController : XprepayApiBase
    {
        [HttpPost]
        [Route("login")]
        public StandardJsonResult Login([FromBody]LoginModel model)
        {
            return base.Try(() =>
            {
               //throw new Exception("test");
            });
        }
    }
}
