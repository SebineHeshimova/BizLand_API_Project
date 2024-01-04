using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.DTOs.ProfessionDTOs
{
    public class GetProfessionDTO
    {
        public string Name { get; set; }
    }
    public class GetProfessionDTOValidator : AbstractValidator<GetProfessionDTO>
    {
        public GetProfessionDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Empty ola bilmez!")
                              .NotNull().WithMessage("Null ola bilmez!")
                              .MaximumLength(50).WithMessage("Maximum uzunluq 50'den chox ola bilmez!")
                              .MinimumLength(3).WithMessage("Minimum uzunluq 3'den kichik olabilmez!");

        }
    }
}
