using AutoMapper;
using SubscriptionsSystem.Application.DTOs.Features;
using SubscriptionsSystem.Domain.Entities;

namespace SubscriptionsSystem.Application.Profiles;

public class FeatureMappingProfile : Profile
{
    public FeatureMappingProfile()
    {
        CreateMap<Feature, FeatureDto>();
    }
}