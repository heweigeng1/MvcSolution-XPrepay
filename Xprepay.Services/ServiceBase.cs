using System;
using Xprepay.Data;

namespace Xprepay.Services
{
    public interface IServiceBase
    {

    }

    public abstract class ServiceBase
    {
        protected XprepayDbContext NewDB()
        {
            return new XprepayDbContext();
        }

        protected void Try(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Logger.Error("ServiceBase.Try", ex);
            }
        }
    }
}
