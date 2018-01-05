using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xprepay.Services.Dtos;

namespace Xprepay.Services.Management.Dtos
{
    public class RoleDto: DtoBase
    {
        public int No { get; set; }
        public string RoleName { get; set; }
        public int? Status { get; set; }
    }
}
