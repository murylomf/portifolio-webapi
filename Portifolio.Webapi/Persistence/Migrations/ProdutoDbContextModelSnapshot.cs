﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portifolio.Webapi.Persistence;

#nullable disable

namespace Portifolio.Webapi.Persistence.Migrations
{
    [DbContext(typeof(ProdutoDbContext))]
    partial class ProdutoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Portifolio.Webapi.Models.Carteira", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(24)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdProduto")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Vencimento")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Carteira");
                });

            modelBuilder.Entity("Portifolio.Webapi.Models.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(24)
                        .HasColumnType("TEXT");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("Vencimento")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
