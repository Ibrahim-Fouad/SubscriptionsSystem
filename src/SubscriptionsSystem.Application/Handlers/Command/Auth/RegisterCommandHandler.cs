using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SubscriptionsSystem.Application.Abstractions;
using SubscriptionsSystem.Application.DTOs.Auth;
using SubscriptionsSystem.Application.DTOs.Users;
using SubscriptionsSystem.Application.Exceptions.Users;
using SubscriptionsSystem.Application.Services;
using SubscriptionsSystem.Domain.Entities;

namespace SubscriptionsSystem.Application.Handlers.Command.Auth;

public class RegisterCommandHandler : IRequestHandler<RegisterDto, UserDto>
{
    private readonly IRepository<User> _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<RegisterCommandHandler> _logger;

    public RegisterCommandHandler(IRepository<User> userRepository, IUnitOfWork unitOfWork, IMapper mapper,
        ILogger<RegisterCommandHandler> logger)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<UserDto> Handle(RegisterDto request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Checking for username duplication");
        if (await _userRepository.Query.AnyAsync(u => u.Username == request.Username, cancellationToken))
            throw new DuplicatedUsernameException(request.Username);

        _logger.LogInformation("Username is not exists, creating new user with username and encrypted password.");
        var (passwordHash, passwordSalt) = Sha512PasswordService.Generate(request.Password);
        var user = User.Create(request.Username, passwordHash, passwordSalt);
        _userRepository.Add(user);

        _logger.LogInformation("Saving new user to database.");
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("New user has been created successfully!");
        return _mapper.Map<UserDto>(user);
    }
}