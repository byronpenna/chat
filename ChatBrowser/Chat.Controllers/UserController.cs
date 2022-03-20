using Chat.Presenters;
using Chat.UseCases.CreateUser;
using Chat.UseCasesDTOs.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController
    {
        readonly IMediator Mediator;
        public UserController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpPost("create-user")]
        public async Task<ActionResult<int>> CreateUser(CreateUserParams userparams)
        {
            CreateUserPresenter Presenter = new CreateUserPresenter();

            await Mediator.Send(new CreateUserInputPort(userparams, Presenter));
            return Presenter.Content;
        }

    }
}
