using Microsoft.EntityFrameworkCore;
using Portifolio.Webapi.Models;

namespace Portifolio.Webapi.Persistence;

public class ProdutoDbContext(DbContextOptions<ProdutoDbContext> options)
    : DbContext(options)
{
    public DbSet<Produto>? Produtos { get; set; }
    public DbSet<Carteira>? Carteira { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutoDbContext).Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(255);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseSqlite(@"Data Source=Persistence/produtos.db")
            .LogTo(Console.WriteLine)
            .EnableSensitiveDataLogging();
    
}