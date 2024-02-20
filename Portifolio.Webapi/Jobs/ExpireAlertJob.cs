using MediatR;
using Microsoft.EntityFrameworkCore;
using Portifolio.Webapi.Notification;
using Portifolio.Webapi.Persistence;

namespace Portifolio.Webapi.Jobs;


public class ExpireAlertJob(
    ILogger<ExpireAlertJob> logger,
    IServiceScopeFactory service) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("verificando vencimentos");
            
            using var scope = service.CreateScope();
            var mediator = scope.ServiceProvider.GetService<IMediator>();
            await mediator!.Publish(new ExpireAlertNotification.Notification(),
                stoppingToken);
            
            await Task.Delay(TimeSpan.FromDays(5), stoppingToken);
        }
    }
}