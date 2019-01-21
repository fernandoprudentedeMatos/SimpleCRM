﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleCRM;

namespace SimpleCRM.Migrations
{
    [DbContext(typeof(CRMDbContext))]
    [Migration("20190121040416_AdicionandoCamposTelefoneEDateCreated")]
    partial class AdicionandoCamposTelefoneEDateCreated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SimpleCRM.Models.CostumerModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<string>("Endereco");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.ToTable("Costumers");
                });
#pragma warning restore 612, 618
        }
    }
}
