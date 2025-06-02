// SwaggerOptionsConfiguration.cs
using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen; // Namespace correto para SwaggerGenOptions
using Microsoft.OpenApi.Models;

namespace Member.API.Configurations;

public class SwaggerOptionsConfiguration : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public SwaggerOptionsConfiguration(IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(
                description.GroupName,
                new OpenApiInfo
                {
                    Title = $"Member WebAPI {description.ApiVersion}",
                    Version = description.ApiVersion.ToString(),
                    Description = $"API Documentation for Member WebAPI {description.ApiVersion}",
                    Contact = new OpenApiContact
                    {
                        Name = "João Batista",
                        Email = "batistasousajoao@gmail.com"
                    }
                });
        }
    }
}