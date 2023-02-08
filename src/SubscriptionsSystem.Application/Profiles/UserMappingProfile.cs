using AutoMapper;
using SubscriptionsSystem.Application.DTOs.Users;
using SubscriptionsSystem.Domain.Entities;

namespace SubscriptionsSystem.Application.Profiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDto>()
            .ForCtorParam(nameof(UserDto.RegistrationDate),
                dest => dest.MapFrom(u => u.CreatedAtUtc));
    }
}