using Chat.Entities.POCOEntities;
using Chat.UseCases.Common.Ports;
using Chat.UseCasesDTOs.CreateMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.UseCases.CreateMessage
{
    public class CreateMessageInputPort:IInputPort<CreateMessageParams,int>
    {

        public CreateMessageParams RequestData { get; }

        public IOutputPort<int> OutputPort { get; }
        public CreateMessageInputPort(CreateMessageParams requestData,
            IOutputPort<int> outputPort
            )
        {
            RequestData = requestData;
            OutputPort = outputPort;
        }
    }
}
