using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubscriptionsSystem.Application.DTOs.Auth;
using SubscriptionsSystem.Application.DTOs.Users;
using SubscriptionsSystem.Application.Exceptions.Users;

namespace SubscriptionsSystem.API.Controllers;

public class AuthController : BaseApiController
{
    private readonly ISender _sender;

    public AuthController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    ///  Create new user with specified username and password.
    /// </summary>
    /// <param name="registerDto">Username and password of new user.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>User created</returns>
    [HttpPost("register")]
    [Produces(typeof(UserDto))]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterAsync(RegisterDto registerDto, CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(registerDto, cancellationToken));
    }
}