using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xprepay.Paging;

namespace Xprepay.Services.Management.SearchCriterias
{
   public class SCRole: PageInput
    {
        public string RoleName { get; set; }
    }
}
