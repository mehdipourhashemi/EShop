using Asp.Versioning;
using Auth;
using IDP.API.Controllers.BaseController;
using IDP.Application.Command.User;
using IDP.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IDP.API.Controllers.v1;

[ApiController]
[ApiVersion(1)]
[ApiVersion(2)]
[Route("api/v{v:apiVersion}/user/[action]")]
public class UserController : IBaseController
{
    private readonly IMediator _mediator;
    private readonly IJWTHandler _jwt;
    public UserController(IMediator mediator, IJWTHandler jWT)
    {
        this._mediator = mediator;
        _jwt = jWT;
    }
    [HttpPost]
    [MapToApiVersion(1)]
    [MapToApiVersion(2)]
    public async Task<IActionResult> Insert([FromForm] UserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> testJWT(Guid UserId)
    {
        var jwt = _jwt.Create(UserId);
        return Ok(jwt);
    }
}