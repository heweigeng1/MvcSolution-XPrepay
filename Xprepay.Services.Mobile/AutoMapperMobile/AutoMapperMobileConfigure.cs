using AutoMapper;
using Xprepay.Data;
using Xprepay.Data.Entities;
using Xprepay.Data.Enums;
using Xprepay.Services.Mobile.Dtos;
using System;

namespace Xprepay.Services.Mobile.AutoMapperMobile
{
    public class AutoMapperMobileConfigure : Profile
    {
        public AutoMapperMobileConfigure()
        {
            CreateMap<Order, MobileOrderDto>();
        }
    }
}
