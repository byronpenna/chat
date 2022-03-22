using Chat.UseCases.GetMessage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.UseCases.GetStock
{
    public class GetStockValidatior: AbstractValidator<GetStockInputPort>
    {
        public GetStockValidatior()
        {

            RuleFor(u => u.RequestData.stockCode)
                .NotEmpty().WithMessage("You must define the message");
        }
    }
}
