using Member.Domain;
using Member.Domain.Interfaces;
using Member.Domain.Interfaces.Repositories;
using Member.Domain.Interfaces.Services;
using Member.Domain.Utils;
using Member.Infrastructure.Repositories;

namespace Member.API.Configurations;

public static class DIConfiguration
{
    public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        //Configuration
        services.AddHttpContextAccessor();
        services.AddMvcCore().AddApiExplorer();
        services.AddScoped<INotificationService, NotificationService>();

        //Service
        services.AddScoped<IMemberService, MemberService>();

        //Repositories
        services.AddScoped<IMemberRepository, MemberRepository>();

        //AutoMapper
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


        return services;
    }
}
