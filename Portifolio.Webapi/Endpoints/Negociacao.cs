using Carter;
using Carter.OpenApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portifolio.Webapi.Contracts;
using Portifolio.Webapi.Persistence;

namespace Portifolio.Webapi.Endpoints;

public class NegociacaoModule () : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/negociar/vender", async ([FromServices] ProdutoDbContext context, VendaProdutoRequest request) =>
            {
                var produto = await context.Produtos
                    .AsSingleQuery()
                    .FirstOrDefaultAsync(x => x.Id == request.IdProduto);
                
                context.Produtos.Remove(produto!);
                await context.SaveChangesAsync();

            })
            .Accepts<VendaProdutoRequest>("application/json")
            .WithTags("Produto")
            .WithName("CreateProduct")
            .IncludeInOpenApi();
    }
}