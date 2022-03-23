using Chat.Entities.Exceptions;
using Chat.Entities.Interfaces;
using Chat.Entities.POCOEntities;
using Chat.Repositories.EFCore.Repositories;
using Chat.UseCases.Common.Validators;
using FluentValidation;
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
        readonly IEnumerable<IValidator<CreateMessageInputPort>> Validators;
        public CreateMessageInteractor(
            IMessageRepository messageRepository, 
            IUnitOfWork unitOfWork,
            IEnumerable<IValidator<CreateMessageInputPort>> validators
            )
        {
            MessageRepository = messageRepository;
            UnitOfWork = unitOfWork;
            Validators = validators; 
        }
        protected async override Task Handle(
            CreateMessageInputPort request,
            CancellationToken cancellationToken)
        {
            var x = await Validator<CreateMessageInputPort>.Validate(request, Validators);

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
