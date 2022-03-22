using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.UseCases.CreateMessage
{
    public class CreateMessageValidator: AbstractValidator<CreateMessageInputPort>
    {
        public CreateMessageValidator()
        {
            RuleFor(u => u.RequestData.Content).NotEmpty().WithMessage("You must define content");
        }
    }
}
