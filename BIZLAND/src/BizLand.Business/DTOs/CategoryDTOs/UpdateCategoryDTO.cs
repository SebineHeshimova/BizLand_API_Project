using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.DTOs.CategoryDTOs
{
    public class UpdateCategoryDTO
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
    }
    public class UpdateCategoryDTOValidator : AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryDTOValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Empty ola bilmez!")
                              .NotNull().WithMessage("Null ola bilmez!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Empty ola bilmez!")
                                .NotNull().WithMessage("Null ola bilmez!")
                                .MaximumLength(30).WithMessage("Uzunluq 30'dan chox ola bilmez!")
                                .MinimumLength(3).WithMessage("Uzunluq 3'den az ola bilmez!");
        }
    }
}
