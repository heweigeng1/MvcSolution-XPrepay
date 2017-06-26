using FluentValidation;
using Xprepay.Data.Entities;

namespace Xprepay.Web.Mobile.ViewModels.Validation
{
    public class MobileOrderValidation : AbstractValidator<Order>
    {
        public MobileOrderValidation()
        {
            //添加
            RuleSet("Add", () =>
            {
                //RuleFor(MobileOrder => MobileOrder.Name).NotNull().WithMessage("商品名称不能为空!").Length(1,20).WithMessage("商品名称长度大于20.");
            });
        }
    }
}

