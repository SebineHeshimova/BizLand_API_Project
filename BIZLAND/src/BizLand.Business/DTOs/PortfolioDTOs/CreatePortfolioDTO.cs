using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.DTOs.PortfolioDTOs
{
    public class CreatePortfolioDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
        public string ProjectDate { get; set; }
        public string ProjectURL { get; set; }
        public int CategoryId { get; set; }
        public IFormFile ImageFile { get; set; }
        public List<IFormFile> ImageFiles { get; set; }
    }
    public class CreatePortfolioDTOValidator : AbstractValidator<CreatePortfolioDTO>
    {
        public CreatePortfolioDTOValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Empty ola bilmez!")
                                    .NotNull().WithMessage("Null ola bilmez!")
                                    .MaximumLength(50).WithMessage("Uzunluq 50'den chox ola bilmez!")
                                    .MinimumLength(3).WithMessage("Uzunluq 3'den az ola bilmez!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Empty ola bilmez!")
                                    .NotNull().WithMessage("Null ola bilmez!")
                                    .MaximumLength(200).WithMessage("Uzunluq 200'den chox ola bilmez!")
                                    .MinimumLength(3).WithMessage("Uzunluq 3'den az ola bilmez!");
            RuleFor(x => x.Client).NotEmpty().WithMessage("Empty ola bilmez!")
                                    .NotNull().WithMessage("Null ola bilmez!");
            RuleFor(x => x.ProjectDate).NotEmpty().WithMessage("Empty ola bilmez!")
                                    .NotNull().WithMessage("Null ola bilmez!");
            RuleFor(x => x.ProjectURL).NotEmpty().WithMessage("Empty ola bilmez!")
                                    .NotNull().WithMessage("Null ola bilmez!");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Empty ola bilmez!")
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
            RuleFor(x => x).Custom((x, context) =>
            {
                foreach(var file in x.ImageFiles)
                {
                    if (file.Length > 1048576)
                    {
                        context.AddFailure("ImageFiles", "file olchusu boyukdur!");
                    }
                    if (file.ContentType != "image/jpeg" && x.ImageFile.ContentType != "image/png")
                    {
                        context.AddFailure("ImageFiles", "file yanlish formatdadir!");
                    }
                }

            });
        }
    }
}
