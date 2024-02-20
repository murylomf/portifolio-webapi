namespace Portifolio.Webapi.Models;

public class Carteira
{
    public Guid Id { get; set; }
    public Guid IdProduto { get; set; }
    public string Vencimento { get; set; }
}