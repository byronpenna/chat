using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Chat.UseCases.CreateUser;

namespace Chat.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IMediator Mediator;
        public UserController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpPost("create-user")]
        public async Task<ActionResult<int>> CreateUser(
            CreateUserInputPort userparams
            )
        {
            return await Mediator.Send(userparams);
        }
    }
}
