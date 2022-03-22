using Chat.Presenters;
using Chat.UseCases.CreateUser;
using Chat.UseCases.Login;
using Chat.UseCasesDTOs.CreateUser;
using Chat.UseCasesDTOs.CreateMessage;

using Chat.UseCasesDTOs.GetMessage;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.UseCases.CreateMessage;
using Chat.UseCases.GetMessage;

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
        [HttpPost("get-by-email-pass")]
        public async Task<ActionResult<int>> GetByEmailPass(LoginParams logParams)
        {
            LoginPresenter Presenter = new LoginPresenter();
            var res = new LoginInputPort(logParams, Presenter);
            await Mediator.Send(res);
            return Presenter.Content;
        }

        [HttpPost("save-message")]
        public async Task<ActionResult<int>> SaveMessage(CreateMessageParams messageparams)
        {
            LoginPresenter Presenter = new LoginPresenter();
            var res = new CreateMessageInputPort(messageparams, Presenter);
            await Mediator.Send(res);
            return Presenter.Content;
        }

        [HttpPost("get-message-by-room")]
        public async Task<ActionResult<string>> getMessageByRoom(GetMessageByRoomParams messageparams)
        {
            MessageByRoomPresenter presenter = new MessageByRoomPresenter();
            var res = new GetMessageByRoomInputPort(messageparams, presenter);
            var x = await Mediator.Send(res);
            return presenter.Content;
        }
        [HttpPost("get-stock-by-command")]
        public async Task<ActionResult<string>> getStockByCommand()
        {

        }
    }
}
