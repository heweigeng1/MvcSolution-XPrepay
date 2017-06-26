using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xprepay.Data.Entities
{
    public class UserDistributorRL
    {
        public Guid UserId { get; set; }
        public virtual User User{get;set;}
        public Guid DistributorId { get; set; }
        public virtual Distributor Distributor { get; }
    }
}
