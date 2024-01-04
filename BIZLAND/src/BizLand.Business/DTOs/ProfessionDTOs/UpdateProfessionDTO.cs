﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.DTOs.ProfessionDTOs
{
    public class UpdateProfessionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateProfessionDTOValidator : AbstractValidator<UpdateProfessionDTO>
    {
        public UpdateProfessionDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Empty ola bilmez!")
                              .NotNull().WithMessage("Null ola bilmez!")
                              .MaximumLength(50).WithMessage("Maximum uzunluq 50'den chox ola bilmez!")
                              .MinimumLength(3).WithMessage("Minimum uzunluq 3'den kichik olabilmez!");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Empty ola bilmez!")
                              .NotNull().WithMessage("Null ola bilmez!");
        }
    }
}
