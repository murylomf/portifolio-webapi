using Carter;
using Carter.OpenApi;
using FluentValidation;
using MediatR;
using Portifolio.Webapi.Contracts;
using Portifolio.Webapi.Common.Pesistence;
using Portifolio.Webapi.Models;

namespace Portifolio.Webapi.Features;

public class CreateProduto
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
            var produto = new Produto
            {
                Id = request.Id,
                Valor = request.Valor,
                Vencimento = request.Vencimento
            };
            context.Produtos.Add(produto);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}

public class CreateProdutoModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/fidc/receive-signed-envelope", async (ISender sender, CreateProdutoRequest request) =>
            {
                var query = new CreateProduto.Command(request.Id, request.Valor, request.Vencimento);
                await sender.Send(query);

            })
            .Accepts<CreateProdutoRequest>("application/json")
            .WithTags("Produto")
            .WithName("CreateProduto")
            .IncludeInOpenApi();
    }
}