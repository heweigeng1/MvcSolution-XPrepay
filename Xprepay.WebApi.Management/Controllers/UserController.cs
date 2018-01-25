using System;
using System.Web.Http;
using Xprepay.Data;
using Xprepay.Data.Enums;
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
        [Route("index")]
        public StandardJsonResult<PageResult<UserDto>> Index()
        {
            var result = new StandardJsonResult<PageResult<UserDto>>();
            return base.Try<PageResult<UserDto>>(() =>
            {
                result.Value = Ioc.Get<IUserService>().PageSearch(new SCUser());
            }, result);
        }
        [HttpPost]
        [Route("delflag")]
        public StandardJsonResult Delflag([FromBody]SCKey model)
        {
            return base.Try(() =>
            {
                Ioc.Get<IUserService>().Delflag(model.Id);
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
        [HttpPost]
        [Route("resetPassword")]
        public StandardJsonResult ResetPassword([FromBody]SCKey model)
        {
            return base.Try(() =>
            {
                Ioc.Get<IUserService>().ResetPassword(model.Id);
            });
        }
        [HttpPost]
        [Route("add")]
        public StandardJsonResult Add([FromBody]User user)
        {
            return base.Try(() =>
            {
                Ioc.Get<IUserService>().Add(user);
            });
        }
        [HttpPost]
        [Route("updateadmin")]
        public StandardJsonResult UpdateAdmin([FromBody]User user)
        {
            return base.Try(() =>
            {
                Ioc.Get<IUserService>().Update(user);
            });
        }
    }
}
