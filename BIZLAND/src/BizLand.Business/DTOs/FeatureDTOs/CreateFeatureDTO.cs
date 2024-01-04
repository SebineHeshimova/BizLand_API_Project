using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.DTOs.FeatureDTOs
{
    public class CreateFeatureDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
    public class CreateFeatureDTOValidator : AbstractValidator<CreateFeatureDTO>
    {
        public CreateFeatureDTOValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Empty ola bilmez!")
                               .NotNull().WithMessage("Null ola bilmez!")
                               .MaximumLength(100).WithMessage("Uzunluq 50'den chox ola bilmez!")
                               .MinimumLength(3).WithMessage("Uzunluq 3'den az ola bilmez!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Empty ola bilmez!")
                               .NotNull().WithMessage("Null ola bilmez!")
                               .MaximumLength(100).WithMessage("Uzunluq 200'den chox ola bilmez!")
                               .MinimumLength(3).WithMessage("Uzunluq 3'den az ola bilmez!");
            RuleFor(x => x.Icon).NotEmpty().WithMessage("Empty ola bilmez!")
                                .NotNull().WithMessage("Null ola bilmez!");
        }

    }
}
