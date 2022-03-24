using MediatR;
using Chat.UseCases.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.UseCasesDTOs.CreateUser;
using Chat.UseCases.Common.Ports;
using Chat.Entities.POCOEntities;

namespace Chat.UseCases.CreateUser
{
    public class CreateUserInputPort : IInputPort<CreateUserParams, User> 
    {
        public CreateUserParams RequestData { get; }

        public IOutputPort<User> OutputPort { get; }

        public CreateUserInputPort(CreateUserParams requestData,
            IOutputPort<User> outputPort
            )
        {
            RequestData = requestData;
            OutputPort = outputPort;
        }
    }
}
