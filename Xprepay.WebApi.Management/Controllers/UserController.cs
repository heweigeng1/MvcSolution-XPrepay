using System.Web.Http;
using Xprepay.Services;
using Xprepay.Services.Dtos;
using Xprepay.Services.SearchCriterias;
using Xprepay.Web.Controllers;

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
        [Route("search")]
        public StandardJsonResult<PageResult<UserDto>> Search([FromBody]SCUser model)
        {
            var result =new StandardJsonResult<PageResult<UserDto>>();
            return base.Try<PageResult<UserDto>>(() =>
            {
                result.Value = Ioc.Get<IUserService>().PageSearch(model);
            }, result);
        }
    }
}
