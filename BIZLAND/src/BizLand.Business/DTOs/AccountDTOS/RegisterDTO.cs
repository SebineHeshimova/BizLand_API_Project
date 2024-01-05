using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.DTOs.AccountDTOS
{
    public record RegisterDTO(string FullName, string UserName, string Password, string Email);
    
    public class RegisterDTOValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Empty ola bilmez!")
                                    .NotNull().WithMessage("Null ola bilmez!")
                                    .MaximumLength(50).WithMessage("Uzunluq 100'den chox ola bilmez!")
                                    .MinimumLength(3).WithMessage("Uzunluq 3'den az ola bilmez!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Empty ola bilmez!")
                                    .NotNull().WithMessage("Null ola bilmez!")
                                    .MaximumLength(100).WithMessage("Uzunluq 100'den chox ola bilmez!")
                                    .MinimumLength(3).WithMessage("Uzunluq 3'den az ola bilmez!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Empty ola bilmez!")
                                    .NotNull().WithMessage("Null ola bilmez!")
                                    .MaximumLength(30).WithMessage("Uzunluq 30'dan chox ola bilmez!")
                                    .MinimumLength(8).WithMessage("Uzunluq 8'den az ola bilmez!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Empty ola bilmez!")
                                    .NotNull().WithMessage("Null ola bilmez!")
                                    .MaximumLength(50).WithMessage("Uzunluq 50'den chox ola bilmez!")
                                    .MinimumLength(11).WithMessage("Uzunluq 11'den az ola bilmez!");
        }
    }
}
