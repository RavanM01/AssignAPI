using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskVeren.Business.DTOs.Topic
{
    public class CreateTopicDto
    {
        public string Name { get; set; }

    }
    public class CreateTopicValidator : AbstractValidator<CreateTopicDto>
    {
        public CreateTopicValidator() {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Error var")
            .NotNull()
            .WithMessage("Error var");
        }
    }


}
    