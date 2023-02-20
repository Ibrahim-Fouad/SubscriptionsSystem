using AutoMapper.QueryableExtensions;
using SubscriptionsSystem.Application.Configurations;

namespace SubscriptionsSystem.Application.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<TResult> MapTo<TResult>(this IQueryable queryable)

    {
        return queryable.ProjectTo<TResult>(AutoMapperConfigurations.MapperConfiguration);
    }
}