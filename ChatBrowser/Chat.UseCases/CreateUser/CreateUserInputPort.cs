using MediatR;
using Chat.UseCases.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.UseCasesDTOs.CreateUser;
namespace Chat.UseCases.CreateUser
{
    public class CreateUserInputPort : CreateUserParams,IRequest<int>
    {

    }
}
