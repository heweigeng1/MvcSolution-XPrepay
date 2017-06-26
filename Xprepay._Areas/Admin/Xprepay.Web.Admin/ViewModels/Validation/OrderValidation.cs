using FluentValidation;
using Xprepay.Data.Entities;

namespace Xprepay.Web.Admin.ViewModels.Validation
{
    public class OrderValidation : AbstractValidator<Order>
    {
        public OrderValidation()
        {
            //添加
            RuleSet("Add", () =>
            {
                //RuleFor(Order => Order.Name).NotNull().WithMessage("商品名称不能为空!").Length(1,20).WithMessage("商品名称长度大于20.");
            });
        }
    }
}

