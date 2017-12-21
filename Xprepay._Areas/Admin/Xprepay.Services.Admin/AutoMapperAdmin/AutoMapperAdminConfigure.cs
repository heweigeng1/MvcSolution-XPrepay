using AutoMapper;
using Xprepay.Data;
using Xprepay.Data.Entities;
using Xprepay.Data.Enums;
using Xprepay.Services.Admin.Dtos;
using System;
using Xprepay.Services.Dtos;

namespace Xprepay.Services.Admin.AutoMapperAdmin
{
    public class AutoMapperAdminConfigure : Profile
    {
        public AutoMapperAdminConfigure()
        {
            CreateMap<Area, AreaDto>().ForMember(dest => dest.Delflag, opt => opt.MapFrom(src => Enum.GetName(typeof(EnumDelflag), src.Delflag)));
            CreateMap<Role, UserRoleDto>();
            CreateMap<User, UserDto>();
            CreateMap<Commodity, CommodityDto>();
            CreateMap<Distributor, DistributorDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<Area, AreaDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<OrderDetail, OrderDetailDto>();
        }
    }
}
