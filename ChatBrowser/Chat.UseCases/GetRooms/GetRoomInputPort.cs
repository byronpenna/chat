using System;
using Chat.Entities.POCOEntities;
using Chat.UseCases.Common.Ports;
using Chat.UseCasesDTOs.GetMessage;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.UseCasesDTOs.Rooms;

namespace Chat.UseCases.GetRooms
{
    public class GetRoomInputPort : IInputPort<GetRoomsParams, List<ChatRoom>>
    {

        public GetRoomsParams RequestData { get; }
        public IOutputPort<List<ChatRoom>> OutputPort { get; }
        public GetRoomInputPort(GetRoomsParams requestData, IOutputPort<List<ChatRoom>> outputPort)
        {
            RequestData = requestData;
            OutputPort = outputPort;
        }
    }
}
