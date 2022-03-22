using Chat.Entities.Interfaces;
using Chat.Entities.POCOEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.UseCases.GetMessage
{
    public class GetMessageByRoomInteractor : AsyncRequestHandler<GetMessageByRoomInputPort>
    {

        readonly IMessageRepository MessageRepository;
        readonly IUnitOfWork UnitOfWork;

        public GetMessageByRoomInteractor(
            IMessageRepository messageRepository,
            IUnitOfWork unitOfWork
            )
        {

            MessageRepository = messageRepository;
            UnitOfWork = unitOfWork;
        }

        protected override Task<string> Handle(
                GetMessageByRoomInputPort request,
                CancellationToken cancellationToken)
        {
            List<Message> messages = null;
            try
            {
                messages = MessageRepository.GetByChatRoom(request.RequestData.roomID);
            }
            catch (Exception ex)
            {

            }
            request.OutputPort.Handle(messages);
            return Task.FromResult("1");
        }
    }
}
