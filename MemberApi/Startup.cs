using System.IO.Compression;
using Asp.Versioning.ApiExplorer;
using dotenv.net;
using Member.API.Configurations;
using Member.Infrastructure.Data;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

namespace Member.API;

public class Startup
{
    public IConfiguration Configuration { get; }
    public IWebHostEnvironment Env { get; }

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        DotEnv.Load();
        Configuration = configuration;
        Env = env;
    }

    public void ConfigureServices(IServiceCollection services)
    {

        Console.WriteLine("CONNECTION STRING: " + Configuration.GetConnectionString("DefaultConnection"));


        services.AddDbContext<PostgreeDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));


        services.Configure<GzipCompressionProviderOptions>(options => { options.Level = CompressionLevel.Optimal; });

        services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
            options.Providers.Add<GzipCompressionProvider>();
        });

        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
        });

        services.AddDependencyInjectionConfiguration();
        services.AddControllers();
        services.AddWebApiConfiguration(Configuration);
        services.AddSwaggerConfiguration();
        services.AddEndpointsApiExplorer();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
    {
        app.UseStaticFiles(); // ⬅️ Necessário para servir /index.html
        app.UseCors("CorsPolicy");
        app.UseResponseCompression();
        app.UseRouting();

        // 🔁 Redirecionar /swagger → /index.html ANTES do Swagger ser processado
        app.MapWhen(ctx => ctx.Request.Path.Equals("/swagger", StringComparison.OrdinalIgnoreCase), builder =>
        {
            builder.Run(context =>
            {
                context.Response.Redirect("/index.html");
                return Task.CompletedTask;
            });
        });

        // ✅ Swagger config com múltiplas versões
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Member API V1");
            c.RoutePrefix = string.Empty; // Serve Swagger UI em /
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        }); 
    }

}