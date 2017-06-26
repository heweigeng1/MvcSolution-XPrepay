using FluentValidation;
using Xprepay.Data.Entities;

namespace Xprepay.Web.Admin.ViewModels.Validation
{
    public class DistributorValidation : AbstractValidator<Distributor>
    {
        public DistributorValidation()
        {
            //添加
            RuleSet("Add", () =>
            {
                RuleFor(Distributor => Distributor.DistributorName).NotNull().WithMessage("不能为空!").Length(1, 200).WithMessage("名称长度大于200.");
                RuleFor(Distributor => Distributor.DistributorAddress).NotNull().WithMessage("不能为空!").Length(1, 500).WithMessage("地址长度大于20.");
                RuleFor(Distributor => Distributor.Contact).NotNull().WithMessage("不能为空!").Length(1, 20).WithMessage("地址长度大于20.");
                RuleFor(Distributor => Distributor.PhoneNum).NotNull().WithMessage("手机号不能为空!").Matches(@"0?(1)[0-9]{10}").WithMessage("手机号格式不正确");
                RuleFor(Distributor => Distributor.AreaId).NotNull().WithMessage("未选择地区!");
            });
        }
    }
}

