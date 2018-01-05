using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xprepay.Paging
{
    public class PageInput
    {
        [Display(Name = "pagination")]
        public PageRequest Pagination { get; set; } = new PageRequest();
    }
}
