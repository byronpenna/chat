using Chat.UseCases.CreateUser;
using Chat.Entities.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Chat.Entities.Exceptions;
using Chat.Entities.POCOEntities;

namespace Chat.UseCases.Login
{
    public class LoginInteractor: AsyncRequestHandler<LoginInputPort>
    {
        readonly IUserRepository UserRepository;
        readonly IUnitOfWork UnitOfWork;
        public LoginInteractor(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {

            UserRepository = userRepository;
            UnitOfWork = unitOfWork;
        }
        protected override Task Handle(
                LoginInputPort request,
                CancellationToken cancellationToken)
        {
            User logedUser = null;
            try
            {
                User user = new User
                {
                    UserName = request.RequestData.UserName,
                    Password = request.RequestData.Password
                };
                logedUser = UserRepository.Login(user);
            }
            catch (Exception ex)
            {
                throw new GeneralException("An error has been ocurred", ex.Message);
            }
            int id = -1;
            if(logedUser != null)
            {
                id = logedUser.Id;
            }
            request.OutputPort.Handle(id);
            return Task.FromResult(logedUser);
        }
    }
}
