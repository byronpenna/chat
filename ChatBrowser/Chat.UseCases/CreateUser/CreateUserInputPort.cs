using MediatR;
using Chat.UseCases.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.UseCasesDTOs.CreateUser;
using Chat.UseCases.Common.Ports;

namespace Chat.UseCases.CreateUser
{
    public class CreateUserInputPort : IInputPort<CreateUserParams, int> 
    {
        public CreateUserParams RequestData { get; }

        public IOutputPort<int> OutputPort { get; }

        public CreateUserInputPort(CreateUserParams requestData,
            IOutputPort<int> outputPort
            )
        {
            RequestData = requestData;
            OutputPort = outputPort;
        }
    }
}
