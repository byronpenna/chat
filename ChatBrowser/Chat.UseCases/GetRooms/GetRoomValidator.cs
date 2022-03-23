using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.UseCases.GetRooms
{
    public class GetRoomValidator: AbstractValidator<GetRoomInputPort>
    {
        public GetRoomValidator()
        {
            RuleFor(u => 1).NotEmpty();
        }
    }
}
