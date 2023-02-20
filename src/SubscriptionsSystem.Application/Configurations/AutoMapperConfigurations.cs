using SubscriptionsSystem.Application.Profiles;
using System.Reflection;
using AutoMapper;

namespace SubscriptionsSystem.Application.Configurations;

public static class AutoMapperConfigurations
{
    public static Assembly Assemblies => typeof(UserMappingProfile).Assembly;

    public static MapperConfiguration MapperConfiguration => new(c => c.AddMaps(Assemblies));
}