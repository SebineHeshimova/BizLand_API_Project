using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.DTOs.SliderDTOs
{
    public class GetSliderDTO
    {
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Description { get; set; }
        public string Button1Text { get; set; }
        public string Button1Url { get; set; }
        public string Button2Text { get; set; }
        public string Button2Url { get; set; }
    }
    public class GetSliderDTOValidator : AbstractValidator<GetSliderDTO>
    {
        public GetSliderDTOValidator()
        {
            RuleFor(x => x.Title1).NotEmpty().WithMessage("Empty ola bilmez!")
                                    .NotNull().WithMessage("Null ola bilmez!")
                                    .MaximumLength(20).WithMessage("Uzunluq 20'den chox ola bilmez!")
                                    .MinimumLength(3).WithMessage("Uzunluq 3'den az ola bilmez!");
            RuleFor(x => x.Title2).NotEmpty().WithMessage("Empty ola bilmez!")
                                    .NotNull().WithMessage("Null ola bilmez!")
                                    .MaximumLength(10).WithMessage("Uzunluq 10'dan chox ola bilmez!")
                                    .MinimumLength(3).WithMessage("Uzunluq 3'den az ola bilmez!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Empty ola bilmez!")
                                    .NotNull().WithMessage("Null ola bilmez!")
                                    .MaximumLength(50).WithMessage("Uzunluq 50'den chox ola bilmez!")
                                    .MinimumLength(3).WithMessage("Uzunluq 3'den az ola bilmez!");
            RuleFor(x => x.Button1Text).NotEmpty().WithMessage("Empty ola bilmez!")
                                    .NotNull().WithMessage("Null ola bilmez!")
                                    .MaximumLength(20).WithMessage("Uzunluq 20'den chox ola bilmez!")
                                    .MinimumLength(3).WithMessage("Uzunluq 3'den az ola bilmez!");
            RuleFor(x => x.Button2Text).NotEmpty().WithMessage("Empty ola bilmez!")
                                    .NotNull().WithMessage("Null ola bilmez!")
                                    .MaximumLength(20).WithMessage("Uzunluq 20'den chox ola bilmez!")
                                    .MinimumLength(3).WithMessage("Uzunluq 3'den az ola bilmez!");
            RuleFor(x => x.Button1Url).NotEmpty().WithMessage("Empty ola bilmez!")
                                    .NotNull().WithMessage("Null ola bilmez!");
            RuleFor(x => x.Button2Url).NotEmpty().WithMessage("Empty ola bilmez!")
                                    .NotNull().WithMessage("Null ola bilmez!");
        }
    }
}
