using FluentValidation;
using Xprepay.Data.Entities;

namespace Xprepay.Web.Admin.ViewModels.Validation
{
    public class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            //添加
            RuleSet("Add", () =>
            {
                RuleFor(Category => Category.Name).NotNull().WithMessage("商品名称不能为空!").Length(1,20).WithMessage("商品名称长度大于20.");
            });
        }
    }
}

