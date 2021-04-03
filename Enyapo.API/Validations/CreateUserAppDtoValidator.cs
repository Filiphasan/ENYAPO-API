using Enyapo.Core.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enyapo.API.Validations
{
    public class CreateUserAppDtoValidator : AbstractValidator<CreateUserAppDto>
    {
        public CreateUserAppDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı zorunludur!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-Mail alanı zorunludur!").EmailAddress().WithMessage("E-Mail uygun formatta değildir!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı zorunludur!").Length(6, 20).WithMessage("Şifre alanı 6 ile 20 karakter arasında olmalıdır!");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ad alanı zorunludur!");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyad alanı zorunludur!");
        }
    }
}
