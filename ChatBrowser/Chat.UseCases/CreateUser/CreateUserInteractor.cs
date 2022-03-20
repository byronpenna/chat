using Chat.Entities.Exceptions;
using Chat.Entities.Interfaces;
using Chat.Entities.POCOEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.UseCases.CreateUser
{
    public class CreateUserInteractor : IRequestHandler<CreateUserInputPort, int>
    {
        readonly IUserRepository UserRepository;
        readonly IUnitOfWork UnitOfWork;
        public CreateUserInteractor(IUserRepository userRepository,IUnitOfWork unitOfWork)
        {
            UserRepository = userRepository;   
            UnitOfWork = unitOfWork;
        }
        public async Task<int> Handle(
            CreateUserInputPort request, 
            CancellationToken cancellationToken)
        {
            User user = new User
            {
                Id = request.id,
                Email = request.Email,
                UserName = request.username,
                Password = request.Password
            };
            UserRepository.Create(user);
            try
            {
                await UnitOfWork.SaveChangesAsync();
            }catch (Exception ex) 
            {
                throw new GeneralException("Error creating user", ex.Message);
            }
            return user.Id;
        }
    }
}
