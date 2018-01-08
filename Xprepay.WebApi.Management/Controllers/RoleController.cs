using System.Web.Http;
using Xprepay.Services.Management;
using Xprepay.Services.Management.SearchCriterias;
using Xprepay.Web.Controllers;

namespace Xprepay.WebApi.Management.Controllers
{
    [RoutePrefix("management/role")]
    public class RoleController : XprepayApiBase
    {
      
        [HttpGet]
        [Route("get")]
        public IHttpActionResult Get()
        {
            return Json(Ioc.Get<IRoleService>().Get(new PageRequest { CurrentPage=1,PageSize=10,SortDirection= "descend",Sorter="RoleName"}));
          
        }
        [HttpPost]
        [Route("search")]
        public IHttpActionResult Search([FromBody]SCRole role)
        {
            return Json(Ioc.Get<IRoleService>().Get(role.Pagination));
        }
        [HttpPost]
        [Route("ylogin")]
        public StandardJsonResult Login()
        {
            return base.Try(() =>
            {
                new KnownException("LOGERROR");
            });
        }
    }
}
