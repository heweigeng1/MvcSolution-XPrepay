using System;
using System.Web.Http;
using System.Web.Security;
using Xprepay.Web.Security;

namespace Xprepay.Web.Controllers
{
    
    public abstract class XprepayApiBase : ApiController
    {
        public XprepayApiBase()
        {

        }

        protected MvcSession GetSession()
        {
            return System.Web.HttpContext.Current.Session.GetMvcSession();
        }
        protected StandardJsonResult Try(Action action)
        {
            var result = new StandardJsonResult();
            result.Try(action);
            return result;
        }
        protected StandardJsonResult<T> Try<T>(Action action, StandardJsonResult<T> result)
        {
            result.Try(() =>
            {
                action();
            });
            return result;
        }
        protected void LoginUser(Guid userId)
        {
            GetSession().Login(userId);
        }
        protected void ApiLogin(Guid userid, string token)
        {

        }
        protected void LoginByOpenid(string openid, string token)
        {

        }
        protected string GetTicket(string phonenum, string passwork)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, phonenum, DateTime.Now,
                            DateTime.Now.AddHours(1), true, string.Format("{0}&{1}", phonenum, passwork),
                            FormsAuthentication.FormsCookiePath);
            return FormsAuthentication.Encrypt(ticket);
        }

    }
}
