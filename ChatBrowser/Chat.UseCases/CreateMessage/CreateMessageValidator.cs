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
            RuleFor(u => u.RequestData.Content.ToString())
                .NotEmpty()
                .WithMessage("You must define a message");
            RuleFor(u => u.RequestData.RoomId)
                .NotEmpty()
                .WithMessage("Room must define a room");

            RuleFor(u => u.RequestData.UserId)
                .NotEmpty()
                .WithMessage("Room must define a user");
        }
        
    }
}
