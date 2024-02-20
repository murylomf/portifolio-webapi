using Carter;
using Carter.OpenApi;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portifolio.Webapi.Contracts;
using Portifolio.Webapi.Persistence;

namespace Portifolio.Webapi.Endpoints;

public class Produto
{
    public record Command(Guid Id, string Valor, string Vencimento) : IRequest;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Vencimento)
                .NotEmpty();

            RuleFor(x => x.Valor)
                .NotEmpty();
        }
    }

    public class Handler(ProdutoDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var produto = new Models.Produto
            {
                Id = request.Id,
                Valor = request.Valor,
                Vencimento = request.Vencimento
            };

            context.Produtos?.Add(produto);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}

public class ProdutoModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/create-produto", async (ISender sender, CreateProdutoRequest request) =>
            {
                var query = new Produto.Command(request.Id, request.Valor, request.Vencimento);
                await sender.Send(query);
            })
            .Accepts<CreateProdutoRequest>("application/json")
            .WithTags("Produto")
            .WithName("CreateProduct")
            .IncludeInOpenApi();

        app.MapGet("/api/produtos", async ([FromServices] ProdutoDbContext context)
                => await context.Produtos
                    .AsSingleQuery()
                    .ToListAsync())
            .WithTags("Produto")
            .WithName("GetProduct")
            .IncludeInOpenApi();
    }
}