﻿// <auto-generated />
using System;
using Banco.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ProjetoVitor.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20240711034711_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("Carros.Models.Carro", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("Ano")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Em")
                        .HasColumnType("TEXT");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Modelo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("carritos");
                });
#pragma warning restore 612, 618
        }
    }
}