using Chat.Entities.Exceptions;
using Chat.Entities.Interfaces;
using Chat.Entities.POCOEntities;
using Chat.Repositories.EFCore.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Threading.Tasks;

namespace Chat.UseCases.CreateMessage
{
    public class CreateMessageInteractor: AsyncRequestHandler<CreateMessageInputPort>
    {

        readonly IMessageRepository MessageRepository;
        readonly IUnitOfWork UnitOfWork;
        public CreateMessageInteractor(IMessageRepository messageRepository, IUnitOfWork unitOfWork)
        {
            MessageRepository = messageRepository;
            UnitOfWork = unitOfWork;
        }
        protected async override Task Handle(
            CreateMessageInputPort request,
            CancellationToken cancellationToken)
        {

            Message message = new Message
            {
                content = request.RequestData.Content,
                UserId = request.RequestData.UserId,
                RoomId = request.RequestData.RoomId
                
            };
            MessageRepository.Create(message);
            try
            {
                await UnitOfWork.SaveChangesAsync();
            }catch(Exception ex)
            {
                throw new GeneralException("Error creating message", ex.Message);
            }
            request.OutputPort.Handle(1);
        }
     }
}
