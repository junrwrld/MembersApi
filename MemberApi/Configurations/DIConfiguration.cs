using Member.Domain;
using Member.Domain.Interfaces;
using Member.Domain.Utils;

namespace Member.API.Configurations;

public static class DIConfiguration
{
    public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        //Configuration
        services.AddHttpContextAccessor();
        services.AddMvcCore().AddApiExplorer();
        services.AddScoped<INotificationService, NotificationService>();

        return services;
    }
}
