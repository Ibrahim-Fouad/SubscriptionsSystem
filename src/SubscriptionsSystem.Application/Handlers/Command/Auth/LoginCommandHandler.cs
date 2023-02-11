using System.Security.Claims;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SubscriptionsSystem.Application.Abstractions;
using SubscriptionsSystem.Application.DTOs.Auth;
using SubscriptionsSystem.Application.Exceptions.Users;
using SubscriptionsSystem.Application.Options;
using SubscriptionsSystem.Application.Services;
using SubscriptionsSystem.Domain.Entities;

namespace SubscriptionsSystem.Application.Handlers.Command.Auth;

internal class LoginCommandHandler : IRequestHandler<LoginDto, UserWithTokenDto>
{
    private readonly IRepository<User> _userRepository;
    private readonly IMapper _mapper;
    private readonly JwtOptions _jwtOptions;
    private readonly ILogger<LoginCommandHandler> _logger;

    public LoginCommandHandler(IRepository<User> userRepository, IMapper mapper, IOptions<JwtOptions> jwtOptions,
        ILogger<LoginCommandHandler> logger)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
        _jwtOptions = jwtOptions.Value;
    }

    public async Task<UserWithTokenDto> Handle(LoginDto request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Checking if username '{request.Username}' is exists.", request.Username);
        var user = await _userRepository.Query
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Username == request.Username, cancellationToken);

        if (user is null)
        {
            _logger.LogInformation("Username '{request.Username}' is not found.", request.Username);
            throw new InvalidUsernameOrPasswordException();
        }

        if (!Sha512PasswordService.ValidatePassword(request.Password, user.PasswordHash, user.PasswordSalt))
        {
            _logger.LogInformation("Wrong password for user '{request.Username}'", request.Username);
            throw new InvalidUsernameOrPasswordException();
        }

        _logger.LogInformation("Logging in success for user '{request.Username}', generating JWT token...", request.Username);
        var userWithToken = _mapper.Map<UserWithTokenDto>(user);
        userWithToken.Token = GenerateToken(user);
        return userWithToken;
    }

    private string GenerateToken(User user)
    {
        var claims = new Claim[]
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Username)
        };

        var expirationDate =
            DateTime.Now.AddHours(_jwtOptions.ExpirationInHours == 0 ? 5 : _jwtOptions.ExpirationInHours);

        return JwtService.GenerateToken(claims, _jwtOptions.Key, expirationDate);
    }
}