using Chat.Entities.POCOEntities;
using Chat.UseCases.Common.Ports;
using Chat.UseCasesDTOs.GetMessage;
using Chat.UseCasesDTOs.GetStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.UseCases.GetStock
{
    public class GetStockInputPort: IInputPort<GetMessageParams, string>
    {

        public GetMessageParams RequestData { get; }
        public IOutputPort<string> OutputPort { get; }

        public GetStockInputPort(
            GetMessageParams requestData, 
            IOutputPort<string> outputPort)
        {
            RequestData = requestData;
            OutputPort = outputPort;

        }
    }
}
