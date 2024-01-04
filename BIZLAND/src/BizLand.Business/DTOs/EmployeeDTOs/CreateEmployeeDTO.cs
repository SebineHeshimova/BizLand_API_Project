using BizLand.Core.Entity;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.DTOs.EmployeeDTOs
{
    public class CreateEmployeeDTO
    {
        public string FullName { get; set; }
        public int ProfessionId { get; set; }
        public IFormFile ImageFile { get; set; }
        public string TwitterUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string LinkedInUrl { get; set; }
    }
    public class CreateEmployeeDTOValidator : AbstractValidator<CreateEmployeeDTO>
    {
        public CreateEmployeeDTOValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Empty ola bilmez!")
                                    .NotNull().WithMessage("Null ola bilmez!")
                                    .MaximumLength(100).WithMessage("Uzunluq 100'den chox ola bilmez!")
                                    .MinimumLength(3).WithMessage("Uzunluq 3'den az ola bilmez!");
            RuleFor(x => x.TwitterUrl).NotEmpty().WithMessage("Empty ola bilmez!")
                                      .NotNull().WithMessage("Null ola bilmez!");
            RuleFor(x => x.LinkedInUrl).NotEmpty().WithMessage("Empty ola bilmez!")
                                       .NotNull().WithMessage("Null ola bilmez!");
            RuleFor(x => x.FacebookUrl).NotEmpty().WithMessage("Empty ola bilmez!")
                                       .NotNull().WithMessage("Null ola bilmez!");
            RuleFor(x => x.InstagramUrl).NotEmpty().WithMessage("Empty ola bilmez!")
                                        .NotNull().WithMessage("Null ola bilmez!");
            RuleFor(x => x.ProfessionId).NotEmpty().WithMessage("Empty ola bilmez!")
                                        .NotNull().WithMessage("Null ola bilmez!");
            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.ImageFile.Length > 1048576)
                {
                    context.AddFailure("ImageFile", "file olchusu boyukdur!");
                }
                if (x.ImageFile.ContentType != "image/jpeg" && x.ImageFile.ContentType != "image/png")
                {
                    context.AddFailure("ImageFile", "file yanlish formatdadir!");
                }
            });
        }
    }
}
