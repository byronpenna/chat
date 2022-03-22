using Chat.Entities.Interfaces;
using Chat.UseCases.GetMessage;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using CsvHelper.TypeConversion;
using Chat.UseCasesDTOs.GetStock;

namespace Chat.UseCases.GetStock
{
    public class GetStockInteractor : AsyncRequestHandler<GetStockInputPort>
    {

        readonly IMessageRepository MessageRepository;
        readonly IUnitOfWork UnitOfWork;
        public GetStockInteractor(
            IMessageRepository messageRepository,
            IUnitOfWork unitOfWork
            )
        {

            MessageRepository = messageRepository;
            UnitOfWork = unitOfWork;
        }

        protected override Task<int> Handle(
                GetStockInputPort request,
                CancellationToken cancellationToken)
        {
            string url = "https://stooq.com/q/l/?s="+request.RequestData.stockCode+"&f=sd2t2ohlcv&h&e=csv";
            string handleResponse = "";
            List<CSVStock> records = null;
            try
            {
                string CSVname = "";
                CSVname = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'.'mm'.'ss.fffffffK") +  ".csv";
                using (var client = new WebClient())
                {
                    client.DownloadFile(url,CSVname );
                }
                using (var streamReader = new StreamReader(CSVname))
                {
                    using (var csvReader = new CsvReader(streamReader, System.Globalization.CultureInfo.InvariantCulture))
                    {
                        records = csvReader.GetRecords<CSVStock>().ToList();
                    }
                }

            }
            catch(TypeConverterException ex)
            {
                handleResponse = "Stock code is not valid";
            }
            catch (Exception ex)
            {
                handleResponse = "Unexpected error";
            }
            if(records != null)
            {
                handleResponse = records[0].Open.ToString();
            }
            request.OutputPort.Handle(handleResponse);
            return Task.FromResult(1);
        }
    }


}
