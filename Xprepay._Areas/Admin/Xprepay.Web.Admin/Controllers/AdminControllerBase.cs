using Xprepay.Data;
using Xprepay.Web.Controllers;
using Xprepay.Web.Security;

namespace Xprepay.Web.Admin.Controllers
{
    [MvcAuthorize(Roles ="admin")]
    public class AdminControllerBase : XprepayControllerBase
    {
        protected override string AreaName => "admin";
    }
}
