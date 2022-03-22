using Chat.Entities.POCOEntities;
using Chat.UseCases.Common.Ports;
using Chat.UseCasesDTOs.GetMessage;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.UseCases.GetMessage
{
    public class GetMessageByRoomInputPort: IInputPort<GetMessageByRoomParams, List<Message>>
    {

        public GetMessageByRoomParams RequestData { get; }
        public IOutputPort<List<Message>> OutputPort { get; }
        public GetMessageByRoomInputPort(GetMessageByRoomParams requestData, IOutputPort<List<Message>> outputPort)
        {
            RequestData = requestData;
            OutputPort = outputPort;
        }
    }
}
