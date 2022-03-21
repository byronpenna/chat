using Chat.UseCases.Common.Ports;
using Chat.UseCasesDTOs.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.UseCases.Login
{
    public class LoginInputPort : IInputPort<LoginParams, int>
    {

        public LoginParams RequestData { get; }
        public IOutputPort<int> OutputPort { get; } 

        public LoginInputPort(LoginParams requestData,IOutputPort<int> outputPort)
        {
            RequestData = requestData;
            OutputPort = outputPort;    
        }

    }
}
