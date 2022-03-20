using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.UseCases.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserInputPort>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.RequestData.Email).NotEmpty().WithMessage("You must define email in user creation process");
            // regular expresion for email
            RuleFor(u => u.RequestData.username).NotEmpty().WithMessage("You must define user name ");

        }
    }
}
