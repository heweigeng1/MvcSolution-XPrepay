using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Xprepay.Web.Security
{
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        public ApiAuthorizeAttribute()
        {

        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
            //请求是否允许匿名
            if (!attributes.Any(a => a is AllowAnonymousAttribute))
            {
                var actionAttributes = actionContext.ActionDescriptor.GetCustomAttributes<ApiAuthorizeAttribute>(true);
                this.Roles = actionAttributes.FirstOrDefault().Roles;
                if (!ValidateRoles(this.Roles))
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
        }
        protected override void HandleUnauthorizedRequest(HttpActionContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            var response = filterContext.Response = filterContext.Response ?? new HttpResponseMessage();
            StandardJsonResult result = new StandardJsonResult();
            result.Fail("无此操作权限");
            response.Content= new StringContent(JsonConvert.SerializeObject(result), Encoding.UTF8, "application/json"); 
        }
        private bool ValidateRoles(string roles)
        {
            var session = HttpContext.Current.Session.GetMvcSession();
            if (session.User != null)
            {
                return roles.Split(',').Any(r => session.User.Roles.Any(c => c == r));
            }
            else
            {
                return false;
            }
        }
    }
}
