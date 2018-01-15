using System;
using System.ComponentModel.DataAnnotations;
using Xprepay.Paging;

namespace Xprepay.Services.SearchCriterias
{
    public class SCUser:PageInput
    {
        //[Display(Name = "userName")]
        public string UserName { get; set; }
        //[Display(Name = "phoneNum")]
        public string PhoneNum { get; set; }
        //[Display(Name = "userType")]
        public int UserType { get; set; }
        //[Display(Name = "strTime")]
        public DateTime? StrTime { get; set; }
        //[Display(Name = "endTime")]
        public DateTime? EndTime { get; set; }

    }
}
