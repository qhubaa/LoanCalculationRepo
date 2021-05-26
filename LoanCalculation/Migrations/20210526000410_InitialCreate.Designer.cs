﻿// <auto-generated />
using LoanCalculation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoanCalculation.Migrations
{
    [DbContext(typeof(LoanContext))]
    [Migration("20210526000410_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LoanCalculation.Data.Entities.LoanConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AmountAdministrationFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("AnnualInterestRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PercentageAdministrationFee")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("LoanConfiguration");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AmountAdministrationFee = 1000m,
                            AnnualInterestRate = 5m,
                            PercentageAdministrationFee = 1m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
