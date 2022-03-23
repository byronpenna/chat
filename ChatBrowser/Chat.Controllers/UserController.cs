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
using Chat.UseCasesDTOs.GetStock;
using Chat.UseCases.GetStock;
using Chat.UseCases.GetRooms;
using Chat.UseCasesDTOs.Rooms;
using Chat.Entities.POCOEntities;

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
        // get request
        [HttpGet("get-rooms")]
        public async Task<ActionResult<List<ChatRoom>>> getRooms([FromQuery]GetRoomsParams roomParams)
        {

            GetRoomPresenter presenter = new GetRoomPresenter();
            var res = new GetRoomInputPort(roomParams, presenter);
            var x = await Mediator.Send(res);
            return presenter.Content;
        }
        [HttpGet("get-message-by-room")]
        public async Task<ActionResult<string >> getMessageByRoom([FromQuery]GetMessageByRoomParams messageparams)
        {
            MessageByRoomPresenter presenter = new MessageByRoomPresenter();
            var res = new GetMessageByRoomInputPort(messageparams, presenter);
            await Mediator.Send(res);
            return presenter.Content;
        }
        [HttpGet("get-stock-by-command")]
        public async Task<ActionResult<string>> getStockByCommand([FromQuery]GetMessageParams getStockParams)
        {
            GetStockPresenter presenter = new GetStockPresenter();
            var res = new GetStockInputPort(getStockParams, presenter);
            await Mediator.Send(res);
            return presenter.Content;
        }
    }
}
