﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechAdvocacia.Infrastructure.Persistence;

#nullable disable

namespace TechAdvocacia.Infrastructure.Migrations
{
    [DbContext(typeof(TechAdvocaciaDbContext))]
    [Migration("20240202040955_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TechAdvocacia.Core.Entities.Advogado", b =>
                {
                    b.Property<int>("AdvogadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("AdvogadoId");

                    b.ToTable("Advogados");
                });

            modelBuilder.Entity("TechAdvocacia.Core.Entities.CasoJuridico", b =>
                {
                    b.Property<int>("CasoJuridicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AdvogadoId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.HasKey("CasoJuridicoId");

                    b.HasIndex("AdvogadoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("CasosJuridicos", (string)null);
                });

            modelBuilder.Entity("TechAdvocacia.Core.Entities.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("TechAdvocacia.Core.Entities.Documento", b =>
                {
                    b.Property<int>("DocumentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CasoJuridicoId")
                        .HasColumnType("int");

                    b.HasKey("DocumentoId");

                    b.HasIndex("CasoJuridicoId");

                    b.ToTable("Documentos");
                });

            modelBuilder.Entity("TechAdvocacia.Core.Entities.CasoJuridico", b =>
                {
                    b.HasOne("TechAdvocacia.Core.Entities.Advogado", "Advogado")
                        .WithMany("CasosJuridicos")
                        .HasForeignKey("AdvogadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechAdvocacia.Core.Entities.Cliente", "Cliente")
                        .WithMany("CasosJuridicos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advogado");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("TechAdvocacia.Core.Entities.Documento", b =>
                {
                    b.HasOne("TechAdvocacia.Core.Entities.CasoJuridico", "CasoJuridico")
                        .WithMany("Documentos")
                        .HasForeignKey("CasoJuridicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CasoJuridico");
                });

            modelBuilder.Entity("TechAdvocacia.Core.Entities.Advogado", b =>
                {
                    b.Navigation("CasosJuridicos");
                });

            modelBuilder.Entity("TechAdvocacia.Core.Entities.CasoJuridico", b =>
                {
                    b.Navigation("Documentos");
                });

            modelBuilder.Entity("TechAdvocacia.Core.Entities.Cliente", b =>
                {
                    b.Navigation("CasosJuridicos");
                });
#pragma warning restore 612, 618
        }
    }
}
