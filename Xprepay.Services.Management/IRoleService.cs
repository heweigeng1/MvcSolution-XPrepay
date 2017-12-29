using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xprepay.Services.Management.Dtos;

namespace Xprepay.Services.Management
{
   public interface IRoleService
    {
        PageResult<RoleDto> Get(PageRequest request);
    }
}
