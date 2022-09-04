using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Lingvo.Application.Auth.Authenticate;
using Lingvo.Application.Common.Responses;
using Lingvo.Application.Users;
using Lingvo.Application.Users.CreateUser;
using Lingvo.Domain.Auth;

namespace Lingvo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{

    private readonly IMediator _mediator;
    private readonly IUserSession _session;

    public UserController(IMediator mediator, IUserSession session)
    {
        _mediator = mediator;
        _session = session;
    }

    /// <summary>
    /// Create a new user
    /// </summary>
    /// <param name="request">The user information</param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var created = await _mediator.Send(request);

        return created.Match<IActionResult>(
           valid => CreatedAtAction(nameof(CreateUser), new { id = valid?.Id }, valid),
           badRequest => BadRequest(badRequest)
           );
    }

    /// <summary>
    /// Authenticates the user and returns the token information.
    /// </summary>
    /// <param name="request">Email and password information</param>
    /// <returns>Token information</returns>
    [HttpPost]
    [Route("authenticate")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(Jwt), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(UserBadRequest), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest request)
    {
        var result = await _mediator.Send(request);

        return result.Match<IActionResult>(
           valid => Ok(valid),
           badRequest => BadRequest(badRequest)
           );
    }
}
