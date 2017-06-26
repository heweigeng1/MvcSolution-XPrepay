using AutoMapper;


namespace Xprepay.Services.WebApi.AutoMapperWebApi
{
    public class AutoMapperWebApiConfigure
    {
        public static AutoMapperWebApiConfigure Instance { get; }
        static AutoMapperWebApiConfigure()
        {
            Instance = new AutoMapperWebApiConfigure();
        }
        public void Init()
        {
            Mapper.Initialize(c =>
            {

            });
        }
    }
}
