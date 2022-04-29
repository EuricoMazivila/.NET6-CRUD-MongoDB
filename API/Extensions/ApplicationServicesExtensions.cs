using Application.Repository;

namespace API.Extensions;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IPeopleRepository, PeopleRepository>();
        return services;
    }
}