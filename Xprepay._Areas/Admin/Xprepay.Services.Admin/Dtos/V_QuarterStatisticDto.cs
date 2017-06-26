using MvcSolution.Data;
using MvcSolution.Data.Entities;
using MvcSolution.Services.Admin.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcSolution.Services.Admin.Dtos
{
    public class V_QuarterStatisticDto : AreaQuarterStatisticDto
    {
        public Guid QSId { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int QuarterStatus { get; set; }
    }
}
namespace MvcSolution
{
    //public static class V_QuarterStatisticDtoExtAdmin
    //{
    //    public static IQueryable<V_QuarterStatisticDto> Build(this IQueryable<AreaQuarterStatistic> query, MvcSolutionDbContext db)
    //    {
    //        return (from d in query
    //                select new V_QuarterStatisticDto
    //                {
    //                    Id = d.Id,
    //                    Delflag = d.Delflag,
    //                    Quarter = d.Quarter,
    //                    QuarterYear = d.QuarterYear,
    //                    QuarterName = d.QuarterName,
    //                    Name = d.PrimaryIndustryRecords.SingleOrDefault().Name,
    //                    QuarterStatus = d.PrimaryIndustryRecords.SingleOrDefault().Status
    //                }).Union(from d in query
    //                         select new V_QuarterStatisticDto
    //                         {
    //                             Id = d.Id,
    //                             Delflag = d.Delflag,
    //                             Quarter = d.Quarter,
    //                             QuarterYear = d.QuarterYear,
    //                             QuarterName = d.QuarterName,
    //                             Name = d.BasicGdpDatas.SingleOrDefault().ReportName,
    //                             QuarterStatus = d.BasicGdpDatas.SingleOrDefault().Status
    //                         }).Union(from d in query
    //                                  select new V_QuarterStatisticDto
    //                                  {
    //                                      Id = d.Id,
    //                                      Delflag = d.Delflag,
    //                                      Quarter = d.Quarter,
    //                                      QuarterYear = d.QuarterYear,
    //                                      QuarterName = d.QuarterName,
    //                                      QSId=d.SmallScaleIndustrys.SingleOrDefault().Id,
    //                                      Name = d.SmallScaleIndustrys.SingleOrDefault().SmallScaleIndustryName,
    //                                      QuarterStatus = d.SmallScaleIndustrys.SingleOrDefault().Status
    //                                  }).Union(from d in query
    //                                           select new V_QuarterStatisticDto
    //                                           {
    //                                               Id = d.Id,
    //                                               Delflag = d.Delflag,
    //                                               Quarter = d.Quarter,
    //                                               QuarterYear = d.QuarterYear,
    //                                               QuarterName = d.QuarterName,
    //                                               Name = d.QuotaTrades.SingleOrDefault().QuotaTradeName,
    //                                               QuarterStatus = d.QuotaTrades.SingleOrDefault().Status
    //                                           });
    //    }
    //}
}
