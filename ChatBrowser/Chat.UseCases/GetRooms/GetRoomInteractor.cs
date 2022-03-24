using Chat.Entities.Interfaces;
using Chat.Entities.POCOEntities;
using Chat.UseCases.Common.Validators;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
namespace Chat.UseCases.GetRooms
{
    public class GetRoomInteractor : AsyncRequestHandler<GetRoomInputPort>
    {

        readonly IRoomRepository RoomRepository;
        readonly IUnitOfWork UnitOfWork;
        readonly IEnumerable<IValidator<GetRoomInputPort>> Validators;

        public GetRoomInteractor(
            IRoomRepository roomRepository,
            IUnitOfWork unitOfWork,
            IEnumerable<IValidator<GetRoomInputPort>> validators

            )
        {

            RoomRepository = roomRepository;
            UnitOfWork = unitOfWork;
            Validators = validators;
        }

        protected async override Task Handle(
                GetRoomInputPort request,
                CancellationToken cancellationToken)
        {
            await Validator<GetRoomInputPort>.Validate(request, Validators);

            List<ChatRoom> rooms = null;
            try
            {
                rooms = RoomRepository.get();
            }catch (Exception)
            {

            }
            request.OutputPort.Handle(rooms);
        }
    }
}
