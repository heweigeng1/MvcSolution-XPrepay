using System.Linq;
using AutoMapper;
using Xprepay.Services.Dtos;
using Xprepay.Services.Admin.Dtos;
using Xprepay.Data.Entities;

namespace Xprepay.Services.Admin.Dtos
{
    public class testDto: DtoBase
    {

    }
}

namespace Xprepay
{
    public static class testDtoExtAdmin
    {
        public static IQueryable<testDto> ToDtos(this IQueryable<test> query)
        {
            return from a in query
                   select new testDto()
                   {

                   };
        }
        public static testDto ToDto(this test entity)
        {
            if (entity!=null)
            {
                return Mapper.Map<testDto>(entity);
            }
            return new testDto();
        }
    }
}

