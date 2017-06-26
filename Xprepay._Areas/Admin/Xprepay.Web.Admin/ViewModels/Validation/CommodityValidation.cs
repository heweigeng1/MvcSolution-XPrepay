using FluentValidation;
using Xprepay.Data.Entities;

namespace Xprepay.Web.Admin.ViewModels.Validation
{
    public class CommodityValidation : AbstractValidator<Commodity>
    {
        public CommodityValidation()
        {
            //添加
            RuleSet("Add", () =>
            {
                RuleFor(Commodity => Commodity.Name).NotNull().WithMessage("商品名称不能为空!").Length(1,20).WithMessage("商品名称长度大于20.");
                RuleFor(Commodity => Commodity.Price).NotNull().WithMessage("不能为空.").GreaterThan(0M).WithMessage("价钱应大于0.");
                RuleFor(Commodity => Commodity.Stock).NotNull().WithMessage("不能为空.").GreaterThan(0).WithMessage("库存应大于0.");
                RuleFor(Commodity => Commodity.CategoryId).NotNull().WithMessage("未选择类型.");
            });
        }
    }
}
