using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.DTOs.AccountDTOS
{
    public record LoginDTO(string UserNameorEmail, string Password);

    public class LoginDTOValidatpotor : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidatpotor()
        {
            RuleFor(x => x.UserNameorEmail).NotEmpty().WithMessage("Empty ola bilmez!")
                                           .NotNull().WithMessage("Null ola bilmez!")
                                           .MaximumLength(100).WithMessage("Uzunluq 100'den chox ola bilmez!")
                                           .MinimumLength(3).WithMessage("Uzunluq 3'den az ola bilmez!");
            RuleFor(x=>x.Password).NotEmpty().WithMessage("Empty ola bilmez!")
                                           .NotNull().WithMessage("Null ola bilmez!")
                                           .MaximumLength(30).WithMessage("Uzunluq 30'dan chox ola bilmez!")
                                           .MinimumLength(8).WithMessage("Uzunluq 8'den az ola bilmez!");
        }
    }


}
