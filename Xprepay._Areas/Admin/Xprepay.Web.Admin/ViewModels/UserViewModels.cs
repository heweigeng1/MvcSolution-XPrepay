using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Xprepay.Data;
using Xprepay.Services.Admin;
using Xprepay.Web.ViewModels;

namespace Xprepay.Web.Admin.ViewModels
{
    public class UserIndexViewModel: LayoutViewModel
    {
    }

    public class UserEditorViewModel
    {
        private readonly Guid _userId;

        public User User { get; set; }

        public UserEditorViewModel(Guid userId)
        {
            _userId = userId;
        }
        
    }
}
