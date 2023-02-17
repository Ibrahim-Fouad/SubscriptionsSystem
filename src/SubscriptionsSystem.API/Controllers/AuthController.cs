using System.Reflection.Metadata;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubscriptionsSystem.Application.DTOs.Auth;
using SubscriptionsSystem.Application.DTOs.Users;
using SubscriptionsSystem.Domain.Shared;

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
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterAsync(RegisterDto registerDto, CancellationToken cancellationToken)
    {
        return HandleResult(await _sender.Send(registerDto, cancellationToken));
    }

    /// <summary>
    /// Login to system with with credentials.
    /// </summary>
    /// <param name="loginDto">Username and password of user.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Login information with token.</returns>
    [HttpPost("login")]
    [ProducesResponseType(typeof(UserWithTokenDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> LoginAsync(LoginDto loginDto, CancellationToken cancellationToken)
    {
        return HandleResult(await _sender.Send(loginDto, cancellationToken));
    }
}