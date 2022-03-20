using Chat.Entities.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.WebExceptionsPresenter
{
    public class ValidationExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
        {
            var Exception = context.Exception as ValidationException;
            StringBuilder Builder = new StringBuilder();
            foreach(var Failure in Exception.Errors)
            {
                Builder.AppendLine(
                   String.Format("Propiedad {0}. Error {1}", Failure.PropertyName, Failure.ErrorMessage)
                    );
            }
            return SetResult(context, 
                StatusCodes.Status400BadRequest, 
                "Error in input data", 
                Builder.ToString());

        }

    }
}
