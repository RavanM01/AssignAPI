using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskVeren.Business.DTOs.Tag
{
    public class CreateTagDto
    {
        public string Name { get; set; }

    }
    public class CreateTagValidator : AbstractValidator<CreateTagDto>
    {
        public CreateTagValidator() {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Error var")
            .NotNull()
            .WithMessage("Error var");
        }
    }


}
    