namespace Portifolio.Webapi.Contracts;

public class ProdutoRequest
{
    public Guid IdProduto { get; set; }
    public DateTime Vencimento { get; set; } = DateTime.Today.AddDays(30);
}