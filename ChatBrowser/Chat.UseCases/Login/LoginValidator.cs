using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.UseCases.Login
{
    public class LoginValidator:AbstractValidator<LoginInputPort>
    {
        public LoginValidator()
        { 
            RuleFor(u => u.RequestData.UserName).NotEmpty().WithMessage("You must define a user name");
        }
    }
}
