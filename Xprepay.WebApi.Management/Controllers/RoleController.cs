using System.Collections.Generic;
using System.Web.Http;
using Xprepay.Services.Management;
using Xprepay.Services.Management.Dtos;
using Xprepay.Web.Controllers;

namespace Xprepay.WebApi.Management.Controllers
{
    [RoutePrefix("management/role")]
    public class RoleController : XprepayApiBase
    {
        [HttpGet]
        [Route("login")]
        public IHttpActionResult Login()
        {
            return Json("test");
        }
        [HttpGet]
        [Route("get")]
        public IHttpActionResult Get()
        {
            return Json(Ioc.Get<IRoleService>().Get(new PageRequest { currentPage=1,pageSize=10,SortDirection=(SortDirection)1,sorter="RoleName"}));
          
        }
        [HttpPost]
        [Route("search")]
        public IHttpActionResult Search([FromUri]RoleDto role,PageRequest request)
        {
            return Json(Ioc.Get<IRoleService>().Get(request));
        }
    }
}
