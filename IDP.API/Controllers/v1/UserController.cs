using IDP.API.Controllers.BaseController;
using IDP.Application.Command.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IDP.API.Controllers.v1;

[ApiController]
[Route("api/user/[action]")]
public class UserController : IBaseController
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        this._mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Insert(UserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}