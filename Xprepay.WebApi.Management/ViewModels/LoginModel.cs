using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xprepay.WebApi.Management.ViewModels
{
    public class LoginModel
    {
        [Display(Name = "userName")]
        public string UserName { get; set; }
        [Display(Name = "password")]
        public string PassWord { get; set; }
    }
}
