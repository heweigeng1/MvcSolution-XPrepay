using System.Collections.Generic;
using System.Web.Http;
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
            return Json(new List<RoleDto>() { new RoleDto { RoleName="用户管理",No=1,Status=0} });
        }
        [HttpPost]
        [Route("search")]
        public IHttpActionResult Search([FromBody]RoleDto role)
        {
            return Json(new List<RoleDto>() { new RoleDto { RoleName = "用户管理", No = 1, Status = 0 } });
        }
    }
}
