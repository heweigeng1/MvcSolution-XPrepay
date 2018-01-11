using System.Web.Http;
using Xprepay.Services.Management;
using Xprepay.Services.Management.SearchCriterias;
using Xprepay.Web.Controllers;
using Xprepay.Web.Security;

namespace Xprepay.WebApi.Management.Controllers
{
    [RoutePrefix("management/role")]
    public class RoleController : XprepayApiBase
    {
      
        [HttpGet]
        [Route("get")]
        [ApiAuthorize(Roles = "admin")]
        public IHttpActionResult Get()
        {
            return Json(Ioc.Get<IRoleService>().Get(new PageRequest { CurrentPage=1,PageSize=10,SortDirection= "descend",Sorter="RoleName"}));
        }
        [HttpPost]
        [Route("search")]
        [ApiAuthorize(Roles = "admin")]
        public IHttpActionResult Search([FromBody]SCRole role)
        {
            return Json(Ioc.Get<IRoleService>().Get(role.Pagination));
        }
        [HttpPost]
        [Route("ylogin")]
        [ApiAuthorize(Roles = "aaa")]
        public StandardJsonResult Login()
        {
            return base.Try(() =>
            {
                new KnownException("LOGERROR");
            });
        }
    }
}
