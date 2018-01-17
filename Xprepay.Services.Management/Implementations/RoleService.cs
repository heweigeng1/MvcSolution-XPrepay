using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xprepay.Services.Management.Dtos;

namespace Xprepay.Services.Management.Implementations
{
    public class RoleService : ServiceBase, IRoleService
    {
        public PageResult<RoleDto> Get(PageRequest result)
        {
            List<RoleDto> dto = new List<RoleDto>();
            for (int i = 0; i < 2; i++)
            {
                dto.Add(new RoleDto { RoleName = $"用户管理{i}", No = i, Status = 0 });
            }
            return dto.AsQueryable().ToPageResult(result);
        }
    }
}
