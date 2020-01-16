﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaFesta.DAO;

namespace SistemaFesta.Migrations
{
    [DbContext(typeof(FestaContext))]
    [Migration("20200116194743_Mac")]
    partial class Mac
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SistemaFesta.Models.Administrador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ControleAcesso");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("Administrador");
                });

            modelBuilder.Entity("SistemaFesta.Models.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ");

                    b.Property<string>("CPF")
                        .IsRequired();

                    b.Property<string>("ComfirmarSenha")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<bool>("ControleAcesso");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("NomeEmpresa")
                        .IsRequired();

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Telefone")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("SistemaFesta.Models.Tema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<int>("FornecedorId");

                    b.Property<string>("Imagem");

                    b.Property<string>("LinkAlbum")
                        .IsRequired();

                    b.Property<string>("LinkSolicitarFesta")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Temas");
                });

            modelBuilder.Entity("SistemaFesta.Models.Tema", b =>
                {
                    b.HasOne("SistemaFesta.Models.Fornecedor", "Fornecedor")
                        .WithMany("Temas")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
