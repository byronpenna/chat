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
using Chat.UseCases.Common.Validators;
using FluentValidation;

namespace Chat.UseCases.GetStock
{
    public class GetStockInteractor : AsyncRequestHandler<GetStockInputPort>
    {

        readonly IMessageRepository MessageRepository;
        readonly IUnitOfWork UnitOfWork;
        readonly IEnumerable<IValidator<GetStockInputPort>> Validators;

        public GetStockInteractor(
            IMessageRepository messageRepository,
            IUnitOfWork unitOfWork,
            IEnumerable<IValidator<GetStockInputPort>> validators

            )
        {

            MessageRepository = messageRepository;
            UnitOfWork = unitOfWork;
            Validators = validators;
        }

        protected async override Task Handle(
                GetStockInputPort request,
                CancellationToken cancellationToken)
        {
            await Validator<GetStockInputPort>.Validate(request, Validators);


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
            catch(TypeConverterException)
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
            if (
                handleResponse != "Stock code is not valid"
                && handleResponse != "Unexpected error"
                )
            {
                handleResponse = request.RequestData.stockCode + " quote is $" + handleResponse + " per share ";
            }

            request.OutputPort.Handle(handleResponse);
        }
    }


}
