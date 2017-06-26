using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xprepay.Services.Mobile.Dtos
{
    public class OrderErrors
    {
        public string Message { get; set; }
        public string Name { get; set; }
        public int ErrorType { get; set; }
    }
}
