using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xprepay.Web.Controllers;

namespace Xprepay.Web.Mobile.Controllers
{
    public class MobileControllerBase: XprepayControllerBase
    {
        protected override string AreaName => "mobile";
    }
}
