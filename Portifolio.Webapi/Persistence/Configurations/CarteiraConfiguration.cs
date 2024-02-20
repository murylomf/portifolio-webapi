using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portifolio.Webapi.Models;

namespace Portifolio.Webapi.Persistence.Configurations;

public class CarteiraConfiguration : IEntityTypeConfiguration<Carteira>
{
    public void Configure(EntityTypeBuilder<Carteira> builder)
    {
        builder.Property(c => c.Id)
            .IsRequired()
            .HasMaxLength(24);

        builder.Property(c => c.IdProduto)
            .IsRequired();

        builder.Property(c => c.Vencimento)
            .IsRequired();
    }
}