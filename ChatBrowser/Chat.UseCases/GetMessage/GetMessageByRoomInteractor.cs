using Chat.Entities.Interfaces;
using Chat.Entities.POCOEntities;
using Chat.UseCases.Common.Validators;
using Chat.UseCases.CreateUser;
using FluentValidation;
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

        readonly IEnumerable<IValidator<GetMessageByRoomInputPort>> Validators;
        public GetMessageByRoomInteractor(
            IMessageRepository messageRepository,
            IUnitOfWork unitOfWork,

            IEnumerable<IValidator<GetMessageByRoomInputPort>> validators
            )
        {

            MessageRepository = messageRepository;
            UnitOfWork = unitOfWork;
            Validators = validators;
        }

        protected async override Task Handle(
                GetMessageByRoomInputPort request,
                CancellationToken cancellationToken)
        {
            await Validator<GetMessageByRoomInputPort>.Validate(request, Validators);

            List<Message> messages = null;
            try
            {
                messages = MessageRepository.GetByChatRoom(request.RequestData.roomID);
            }
            catch (Exception)
            {

            }
            request.OutputPort.Handle(messages);
        }
    }
}
