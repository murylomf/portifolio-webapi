namespace Portifolio.Webapi.Contracts;

public class CreateProdutoRequest
{
    public Guid Id { get; set; }
    public string Valor { get; set; }
    public string Vencimento { get; set; }
}