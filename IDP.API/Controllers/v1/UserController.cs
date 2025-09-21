using Asp.Versioning;
using IDP.API.Controllers.BaseController;
using IDP.Application.Command.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IDP.API.Controllers.v1;

[ApiController]
[ApiVersion(1)]
[ApiVersion(2)]
[Route("api/v{v:apiVersion}/user")]
public class UserController : IBaseController
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        this._mediator = mediator;
    }
    [HttpPost]
    [MapToApiVersion(1)]
    [MapToApiVersion(2)]
    public async Task<IActionResult> Insert(UserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}