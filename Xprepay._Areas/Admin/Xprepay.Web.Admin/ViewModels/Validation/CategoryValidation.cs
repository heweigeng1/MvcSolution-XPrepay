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
                RuleFor(Category => Category.CategoryName).NotNull().WithMessage("不能为空!").Length(1,20).WithMessage("长度大于20!");
            });
        }
    }
}

