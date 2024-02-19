using Microsoft.EntityFrameworkCore;
using Portifolio.Webapi.Persistence;
using Portifolio.Webapi.Persistence;

namespace Portifolio.Webapi.Common.Extensions;


public static class MigrationExtensions
{
    public static void ApplyMigrations(this WebApplication app)
    {
        try
        {
            using var scope = app.Services.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<ProdutoDbContext>();

            dbContext.Database.Migrate();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception occurred to execute migration : {0}", e.Message);
        }
    }
}
