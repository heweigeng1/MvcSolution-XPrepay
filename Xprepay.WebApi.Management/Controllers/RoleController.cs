using System.Web.Http;
using Xprepay.Services.Management;
using Xprepay.Services.Management.Dtos;
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
        public StandardJsonResult<PageResult<RoleDto>> Get()
        {
            var result = new StandardJsonResult<PageResult<RoleDto>>();
            return base.Try<PageResult<RoleDto>>(() =>
            {
                result.Value = Ioc.Get<IRoleService>().Get(new PageRequest());
            }, result);
        }
        [HttpPost]
        [Route("search")]
        [ApiAuthorize(Roles = "admin")]
        public StandardJsonResult<PageResult<RoleDto>> Search([FromBody]SCRole role)
        {
            var result = new StandardJsonResult<PageResult<RoleDto>>();
            return base.Try<PageResult<RoleDto>>(() =>
            {
                result.Value = Ioc.Get<IRoleService>().Get(role.Pagination);
            }, result);

        }
    }
}
