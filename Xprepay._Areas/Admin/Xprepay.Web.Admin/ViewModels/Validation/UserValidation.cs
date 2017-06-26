using FluentValidation;
using Xprepay.Data;

namespace Xprepay.Web.Admin.ViewModels.Validation
{
    public  class UserValidation: AbstractValidator<User>
    {
        public UserValidation()
        {
            //添加
            RuleSet("Add", () =>
            {
                RuleFor(User => User.UserName).NotNull().WithMessage("用户名不能为空!").Length(3, 16).WithMessage("用户名应为3-16位!");
                RuleFor(User => User.NickName).NotNull().WithMessage("昵称不能为空!");
                RuleFor(User => User.Password).NotNull().WithMessage("密码不能为空!").Length(6, 16).WithMessage("密码应为6-16位!");
                RuleFor(User => User.PhoneNum).NotNull().WithMessage("手机号不能为空!").Matches(@"0?(1)[0-9]{10}").WithMessage("手机号格式不正确");
            });
            //修改
            RuleSet("Update", () =>
            {
                RuleFor(User => User.UserName).NotNull().WithMessage("用户名不能为空!").Length(3, 16).WithMessage("用户名应为3-16位!");
                RuleFor(User => User.NickName).NotNull().WithMessage("昵称不能为空!");
                RuleFor(User => User.PhoneNum).NotNull().WithMessage("手机号不能为空!").Matches(@"0?(1)[0-9]{10}").WithMessage("手机号格式不正确");
            });
            RuleSet("ChangePassword", () =>
            {
                RuleFor(User => User.Password).NotNull().WithMessage("密码不能为空!").Length(6, 16).WithMessage("密码应为6-16位!");
            });
        }
    }
}
