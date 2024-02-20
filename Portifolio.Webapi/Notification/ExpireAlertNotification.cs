using MediatR;
using Microsoft.EntityFrameworkCore;
using Portifolio.Webapi.Persistence;

namespace Portifolio.Webapi.Notification;

public class ExpireAlertNotification
{
    public record Notification() : INotification;
    
    public class Handler(
        ProdutoDbContext context,
        IMediator mediator,
        ILogger<ExpireAlertNotification> logger): INotificationHandler<Notification>
    {
        
        public async Task Handle(Notification notification, CancellationToken cancellationToken)
        {
            if (context.Carteira != null)
            {
                var produtos = await context.Carteira.AsSingleQuery().ToListAsync(cancellationToken);
                var today = DateTime.Today;
            
                if (produtos.Count > 0)
                {
                    logger.LogInformation("verificando vencimentos");
                
                    produtos.ForEach((produto) =>
                    {
                        var diff = produto.Vencimento - today;
                    
                        if (diff.TotalDays < 7)
                        {
                            logger.LogInformation("Produto prestes a vencer: " + produto.Id);
                        }
                    } );
              
                }
            }
        }
    }
}
