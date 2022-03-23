using Chat.Entities.Interfaces;
using Chat.Entities.POCOEntities;
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

        public GetRoomInteractor(
            IRoomRepository roomRepository,
            IUnitOfWork unitOfWork
            )
        {

            RoomRepository = roomRepository;
            UnitOfWork = unitOfWork;
        }

        protected override Task<string> Handle(
                GetRoomInputPort request,
                CancellationToken cancellationToken)
        {
            List<ChatRoom> rooms = null;
            try
            {
                rooms = RoomRepository.get();
            }catch (Exception ex)
            {

            }
            request.OutputPort.Handle(rooms);
            return Task.FromResult("1");
        }
    }
}
