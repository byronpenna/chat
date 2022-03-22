using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.UseCases.GetMessage
{
    public class GetMessageByRoomValidator: AbstractValidator<GetMessageByRoomInputPort>
    {
        public GetMessageByRoomValidator()
        {
            RuleFor(u => u.RequestData.roomID)
                .NotEmpty().WithMessage("You must define room ID");
        }
    }
}
