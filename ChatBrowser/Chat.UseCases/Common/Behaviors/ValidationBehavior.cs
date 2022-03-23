using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.UseCases.Common.Behaviors
{
    public class ValidationBehavior<TRequest,TResponse>: IPipelineBehavior<TRequest,TResponse> 
        where TRequest : IRequest<TResponse>
    {
        readonly IEnumerable<IValidator<TRequest>> Validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            Validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, 
            CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            
            return next();
        }
    }
}
