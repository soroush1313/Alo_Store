using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alo_Store.Application.Services.Users.Commands.RegisterUser;
using Alo_Store.Domain.Entities.Users;
using FluentValidation;

namespace Alo_Store.Application.FluentValidation
{
    public class UserValidator:AbstractValidator<RequestRegisterUserDto>
    {
        public UserValidator()
        {
            RuleFor(e => e.FullName).NotNull().WithMessage("نام را وارد نمایید").Length(5,50);
            RuleFor(e => e.Password).NotEmpty().WithMessage("رمز عبور را وارد نمایید")
                .Length(8).WithMessage("رمز عبور باید حداقل 8 کاراکتر باشد")
                .Equal(e => e.RePassword).WithMessage("رمز عبور و تکرار آن برابر نیستند");
            RuleFor(e => e.Email).EmailAddress().WithMessage("ایمیل را به درستی وارد نمایید");
        }
    }
}
