using Chat.Entities.POCOEntities;
using Chat.UseCases.Common.Ports;
using Chat.UseCasesDTOs.GetMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.UseCases.GetStock
{
    public class GetStockInputPort: IInputPort<GetMessageByRoomParams, List<Message>>
    {

        public GetMessageByRoomParams RequestData { get; }
        public IOutputPort<List<Message>> OutputPort { get; }

        public GetStockInputPort(
            GetMessageByRoomParams requestData, 
            IOutputPort<List<Message>> outputPort)
        {

        }
    }
}
