using System.Linq;
using AutoMapper;
using Xprepay.Services.Dtos;
using Xprepay.Services.Admin.Dtos;
using Xprepay.Data.Entities;

namespace Xprepay.Services.Admin.Dtos
{
    public class CategoryDto: DtoBase
    {
        public string CategoryName { get; set; }
    }
}

namespace Xprepay
{
    public static class CategoryDtoExtAdmin
    {
        public static IQueryable<CategoryDto> ToDtos(this IQueryable<Category> query)
        {
            return from a in query
                   select new CategoryDto()
                   {
                       CategoryName=a.CategoryName,
                       CreatedTime=a.CreatedTime,
                       Delflag=a.Delflag,
                       Id=a.Id,
                       LastUpdatedTime=a.LastUpdatedTime
                   };
        }
        public static CategoryDto ToDto(this Category entity)
        {
            if (entity!=null)
            {
                return Mapper.Map<CategoryDto>(entity);
            }
            return new CategoryDto();
        }
    }
}

