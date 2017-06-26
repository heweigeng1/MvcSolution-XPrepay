using FluentValidation;
using Xprepay.Data.Entities;

namespace Xprepay.Web.Admin.ViewModels.Validation
{
    public class AreaValidation : AbstractValidator<Area>
    {
        public AreaValidation()
        {
            //添加
            RuleSet("Add", () =>
            {
                RuleFor(Area => Area.Name).NotNull().WithMessage("不能为空!").Length(1,200).WithMessage("长度大于200.");
            });
        }
    }
}

