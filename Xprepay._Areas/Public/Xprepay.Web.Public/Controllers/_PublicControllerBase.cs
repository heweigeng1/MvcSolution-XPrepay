using System;
using Xprepay.Web.Controllers;

namespace Xprepay.Web.Public.Controllers
{
    public class PublicControllerBase : XprepayControllerBase
    {
        protected override string AreaName => "public";
    }
}
