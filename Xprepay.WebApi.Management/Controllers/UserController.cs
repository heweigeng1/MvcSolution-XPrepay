using System.Web.Http;
using Xprepay.Web.Controllers;
using Xprepay.WebApi.Management.ViewModels;

namespace Xprepay.WebApi.Management.Controllers
{
    [RoutePrefix("management/user")]
    public class UserController: XprepayApiBase
    {
        [Route("get")]
        public StandardJsonResult Get()
        {
            return base.Try(() =>
            {
                new KnownException("LOGERROR");
            });
        }
        [HttpPost]
        [Route("login")]
        public StandardJsonResult Login([FromBody]LoginModel model)
        {
            return base.Try(() =>
            {
                new KnownException("LOGERROR");
            });
        }
    }
}
