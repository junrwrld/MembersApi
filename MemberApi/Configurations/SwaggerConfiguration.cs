using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Member.API.Configurations;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerOptionsConfiguration>();

        return services;
    }

    public static void UseSwaggerConfiguration(
    this IApplicationBuilder app,
    IApiVersionDescriptionProvider provider)
    {
        // Redireciona /swagger para /index.html
        app.Use(async (context, next) =>
        {
            if (context.Request.Path.Equals("/swagger", StringComparison.OrdinalIgnoreCase))
            {
                context.Response.Redirect("/index.html");
                return;
            }

            await next();
        });

        app.UseSwagger();

        app.UseSwaggerUI(options =>
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json",
                    $"API {description.GroupName.ToUpperInvariant()}");
            }
        });
    }

}