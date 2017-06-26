using AutoMapper;
using Xprepay.Services.Admin.AutoMapperAdmin;
using Xprepay.Services.Mobile.AutoMapperMobile;

namespace Xprepay.Web.Main.AutoMapperConfigure
{
    public class Configuration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperAdminConfigure>();
                cfg.AddProfile<AutoMapperMobileConfigure>();
            });
        }
    }
}