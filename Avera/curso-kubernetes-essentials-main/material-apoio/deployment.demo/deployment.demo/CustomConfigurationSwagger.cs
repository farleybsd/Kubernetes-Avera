using Microsoft.OpenApi.Models;
namespace Microsoft.Extensions.Configuration;

public static class CustomConfigurationSwagger
{
    public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Deployment - Demo",
                Contact = new OpenApiContact()
                {
                    Email = "bruno.brito@avera.com.br",
                    Name = "Bruno Brito",
                    Url = new Uri("https://avera.com.br")
                }
            });
        });

        return services;
    }

    public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
    {
        app
            .UseSwagger()
            .UseSwaggerUI();
        return app;
    }
}