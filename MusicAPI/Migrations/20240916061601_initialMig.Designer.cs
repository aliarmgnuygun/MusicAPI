﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories.EFCore;

#nullable disable

namespace MusicAPI.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20240916061601_initialMig")]
    partial class initialMig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CikisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("SanatciId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SanatciId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("Entities.Models.CalmaListesi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CalmaListesi");
                });

            modelBuilder.Entity("Entities.Models.CalmaListesiSarkilari", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CalmaListesiId")
                        .HasColumnType("int");

                    b.Property<int>("SarkiId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CalmaListesiId");

                    b.HasIndex("SarkiId");

                    b.ToTable("CalmaListesiSarkilari");
                });

            modelBuilder.Entity("Entities.Models.Sanatci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KurulusTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Sanatci");
                });

            modelBuilder.Entity("Entities.Models.Sarki", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int>("SanatciId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("SanatciId");

                    b.ToTable("Sarki");
                });

            modelBuilder.Entity("Entities.Models.Album", b =>
                {
                    b.HasOne("Entities.Models.Sanatci", "Sanatci")
                        .WithMany("Albumler")
                        .HasForeignKey("SanatciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sanatci");
                });

            modelBuilder.Entity("Entities.Models.CalmaListesiSarkilari", b =>
                {
                    b.HasOne("Entities.Models.CalmaListesi", "CalmaListesi")
                        .WithMany("CalmaListesiSarkilari")
                        .HasForeignKey("CalmaListesiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Sarki", "Sarki")
                        .WithMany()
                        .HasForeignKey("SarkiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CalmaListesi");

                    b.Navigation("Sarki");
                });

            modelBuilder.Entity("Entities.Models.Sarki", b =>
                {
                    b.HasOne("Entities.Models.Album", "Album")
                        .WithMany("Sarkilar")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Models.Sanatci", "Sanatci")
                        .WithMany("Sarkilar")
                        .HasForeignKey("SanatciId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Sanatci");
                });

            modelBuilder.Entity("Entities.Models.Album", b =>
                {
                    b.Navigation("Sarkilar");
                });

            modelBuilder.Entity("Entities.Models.CalmaListesi", b =>
                {
                    b.Navigation("CalmaListesiSarkilari");
                });

            modelBuilder.Entity("Entities.Models.Sanatci", b =>
                {
                    b.Navigation("Albumler");

                    b.Navigation("Sarkilar");
                });
#pragma warning restore 612, 618
        }
    }
}
