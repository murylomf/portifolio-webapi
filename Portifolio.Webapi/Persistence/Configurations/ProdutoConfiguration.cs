using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portifolio.Webapi.Models;

namespace Portifolio.Webapi.Persistence.Configurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.Property(p => p.Id)
            .IsRequired()
            .HasMaxLength(24);

        builder.Property(p => p.Vencimento)
            .IsRequired();

        builder.Property(p => p.Valor)
            .IsRequired();
    }
}