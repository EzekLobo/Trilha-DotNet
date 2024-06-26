﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrdemDeServico.Infrastructure.Persistence;

#nullable disable

namespace OrdemDeServico.Infra.Migrations
{
    [DbContext(typeof(OrdemDeServicoContext))]
    [Migration("20240225181215_addUsuarios")]
    partial class addUsuarios
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ClienteId");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Complemento")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("EnderecoId");

                    b.ToTable("Endereco", (string)null);
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.OrdemServico", b =>
                {
                    b.Property<int>("OrdemServicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset>("DataDeEmissao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("PrestadorDeServicoId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("OrdemServicoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PrestadorDeServicoId");

                    b.ToTable("OrdemServico", (string)null);
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.Pagamento", b =>
                {
                    b.Property<int>("PagamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset>("DataPagamento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MetodoPagamento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("OrdemServicoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<float>("Valor")
                        .HasColumnType("float");

                    b.HasKey("PagamentoId");

                    b.HasIndex("OrdemServicoId");

                    b.ToTable("Pagamento", (string)null);
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.PrestadorDeServico", b =>
                {
                    b.Property<int>("PrestadorDeServicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("PrestadorDeServicoId");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("PrestadorDeServico", (string)null);
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.Servico", b =>
                {
                    b.Property<int>("ServicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("Precos")
                        .HasColumnType("float");

                    b.HasKey("ServicoId");

                    b.ToTable("Servico", (string)null);
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.ServicoOrdemServico", b =>
                {
                    b.Property<int>("ServicoOrdemServicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int>("OrdemServicoId")
                        .HasColumnType("int");

                    b.Property<int>("ServicoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ServicoOrdemServicoId");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.HasIndex("OrdemServicoId");

                    b.HasIndex("ServicoId");

                    b.ToTable("ServicoOrdemServico", (string)null);
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("UsuarioId");

                    b.ToTable("usuarios", (string)null);
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.Cliente", b =>
                {
                    b.HasOne("OrdemDeServico.Domain.Entities.Endereco", "Endereco")
                        .WithOne("Cliente")
                        .HasForeignKey("OrdemDeServico.Domain.Entities.Cliente", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.OrdemServico", b =>
                {
                    b.HasOne("OrdemDeServico.Domain.Entities.Cliente", "Cliente")
                        .WithMany("OrdemServico")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrdemDeServico.Domain.Entities.PrestadorDeServico", "PrestadorDeServico")
                        .WithMany("OrdemServico")
                        .HasForeignKey("PrestadorDeServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("PrestadorDeServico");
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.Pagamento", b =>
                {
                    b.HasOne("OrdemDeServico.Domain.Entities.OrdemServico", "OrdemServico")
                        .WithMany("Pagamentos")
                        .HasForeignKey("OrdemServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrdemServico");
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.PrestadorDeServico", b =>
                {
                    b.HasOne("OrdemDeServico.Domain.Entities.Endereco", "Endereco")
                        .WithOne("PrestadorDeServico")
                        .HasForeignKey("OrdemDeServico.Domain.Entities.PrestadorDeServico", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.ServicoOrdemServico", b =>
                {
                    b.HasOne("OrdemDeServico.Domain.Entities.Endereco", "Endereco")
                        .WithOne("ServicoOrdemServico")
                        .HasForeignKey("OrdemDeServico.Domain.Entities.ServicoOrdemServico", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrdemDeServico.Domain.Entities.OrdemServico", "OrdemServico")
                        .WithMany("ServicoOrdemServico")
                        .HasForeignKey("OrdemServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrdemDeServico.Domain.Entities.Servico", "Servico")
                        .WithMany("ServicoOrdemServico")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("OrdemServico");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("OrdemServico");
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.Endereco", b =>
                {
                    b.Navigation("Cliente");

                    b.Navigation("PrestadorDeServico");

                    b.Navigation("ServicoOrdemServico");
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.OrdemServico", b =>
                {
                    b.Navigation("Pagamentos");

                    b.Navigation("ServicoOrdemServico");
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.PrestadorDeServico", b =>
                {
                    b.Navigation("OrdemServico");
                });

            modelBuilder.Entity("OrdemDeServico.Domain.Entities.Servico", b =>
                {
                    b.Navigation("ServicoOrdemServico");
                });
#pragma warning restore 612, 618
        }
    }
}
