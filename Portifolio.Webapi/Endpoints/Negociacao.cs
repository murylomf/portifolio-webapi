using Carter;
using Carter.OpenApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portifolio.Webapi.Contracts;
using Portifolio.Webapi.Models;
using Portifolio.Webapi.Persistence;

namespace Portifolio.Webapi.Endpoints;

public class NegociacaoModule () : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/negociar/vender", async ([FromServices] ProdutoDbContext context, ProdutoRequest request) =>
            {
                var produto = await context.Carteira
                    .AsSingleQuery()
                    .FirstOrDefaultAsync(x => x.IdProduto == request.IdProduto);
                
                context.Carteira.Remove(produto!);
                await context.SaveChangesAsync();

            })
            .Accepts<ProdutoRequest>("application/json")
            .WithTags("negociar")
            .WithName("vender")
            .IncludeInOpenApi();
        
        app.MapPost("api/negociar/comprar", async ([FromServices] ProdutoDbContext context, ProdutoRequest request) =>
            {
                var vencimento = DateTime.Today.AddDays(30);
                
                var produto = new Carteira
                {
                    Vencimento = vencimento,
                    IdProduto = request.IdProduto
                };
                
                
                context.Carteira.Add(produto);
                await context.SaveChangesAsync();
        
            })
            .Accepts<ProdutoRequest>("application/json")
            .WithTags("negociar")
            .WithName("comprar")
            .IncludeInOpenApi();
    }
}