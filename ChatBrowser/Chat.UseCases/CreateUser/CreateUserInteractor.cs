using Chat.Entities.Exceptions;
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

namespace Chat.UseCases.CreateUser
{
    public class CreateUserInteractor : AsyncRequestHandler<CreateUserInputPort>
    {
        readonly IUserRepository UserRepository;
        readonly IUnitOfWork UnitOfWork;

        readonly IEnumerable<IValidator<CreateUserInputPort>> Validators;
        public CreateUserInteractor(IUserRepository userRepository,
            IUnitOfWork unitOfWork,

            IEnumerable<IValidator<CreateUserInputPort>> validators
            )
        {
            UserRepository = userRepository;   
            UnitOfWork = unitOfWork;
            Validators = validators;
        }
        protected async override Task Handle(
            CreateUserInputPort request, 
            CancellationToken cancellationToken)
        {
             await Validator<CreateUserInputPort>.Validate(request, Validators);

            User user = new User
            {
                Id = request.RequestData.id,
                Email = request.RequestData.Email,
                UserName = request.RequestData.username,
                Password = request.RequestData.Password
            };
            UserRepository.Create(user);
            try
            {
                await UnitOfWork.SaveChangesAsync();
            }catch (Exception ex) 
            {
                throw new GeneralException("Error creating user", ex.Message);
            }
            request.OutputPort.Handle(user.Id);
        }
    }
}
