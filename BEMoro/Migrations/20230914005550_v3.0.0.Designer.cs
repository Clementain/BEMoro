﻿// <auto-generated />
using System;
using BEMoro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BEMoro.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20230914005550_v3.0.0")]
    partial class v300
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BEMoro.Models.Documento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("ArchivoPdf")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<int>("EncargadoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EncargadoId");

                    b.ToTable("documento");
                });

            modelBuilder.Entity("BEMoro.Models.Encargado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TramiteServicio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("encargado");
                });

            modelBuilder.Entity("BEMoro.Models.Noticia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<byte[]>("Imagen1")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<byte[]>("Imagen2")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("Nota")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NotaI1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NotaI2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Subtitulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("noticia");
                });

            modelBuilder.Entity("BEMoro.Models.ProgramaSocial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("Documento")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.HasKey("Id");

                    b.ToTable("programaSocial");
                });

            modelBuilder.Entity("BEMoro.Models.Documento", b =>
                {
                    b.HasOne("BEMoro.Models.Encargado", "Encargado")
                        .WithMany()
                        .HasForeignKey("EncargadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Encargado");
                });
#pragma warning restore 612, 618
        }
    }
}
