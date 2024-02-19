using System.Reflection;
using Carter;
using Carter.OpenApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Portifolio.Webapi.Common.Pesistence;
using Microsoft.Extensions.Options;
using Portifolio.Webapi.Persistence;

namespace Portifolio.Webapi;

public static class DependencyInjection
{
    private static readonly Assembly Assembly = typeof(Program).Assembly;
    
    public static IServiceCollection AddWebApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCarter();
        services.AddDbContext<ProdutoDbContext>(options =>
        {
            options.UseSqlite("Data Source=Persistence/produtos.db");
        });

        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly));

        return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Description = "Portifólio API",
                Version = "v1",
                Title = "Portifólio API",
            });

            options.DocInclusionPredicate((s, description) =>
                description.ActionDescriptor.EndpointMetadata.OfType<IIncludeOpenApi>().Any());
        });

        return services;
    }
}