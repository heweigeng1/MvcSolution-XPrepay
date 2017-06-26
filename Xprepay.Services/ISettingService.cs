using System.Collections.Generic;
using Xprepay.Data;

namespace Xprepay.Services
{
    public interface ISettingService
    {
        void Init(List<Setting> settings);
        List<Setting> GetAll();
        void Update(string key, string value);
    }
}
