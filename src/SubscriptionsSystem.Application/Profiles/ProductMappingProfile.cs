using AutoMapper;
using SubscriptionsSystem.Application.DTOs.Products;
using SubscriptionsSystem.Domain.Entities;

namespace SubscriptionsSystem.Application.Profiles;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}