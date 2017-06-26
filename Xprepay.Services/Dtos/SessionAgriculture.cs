using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xprepay.Services.Dtos
{
    public class SessionAgriculture
    {
        public Guid Id { get; set; }
        public string GroupName { get; set; }
        public bool DelDlag { get; set; }
        public SessionAgriculture()
        {

        }
    }
}
