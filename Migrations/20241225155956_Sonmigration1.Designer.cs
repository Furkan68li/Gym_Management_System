﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SporSalonuYönetimSistemi.Models.Data;

#nullable disable

namespace SporSalonuYönetimSistemi.Migrations
{
    [DbContext(typeof(SporSalonuDbContext))]
    [Migration("20241225155956_Sonmigration1")]
    partial class Sonmigration1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SporSalonuYönetimSistemi.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("SporSalonuYönetimSistemi.Models.Alet", b =>
                {
                    b.Property<int>("AletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AletId"));

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AletAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AletTuru")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AlimTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Durum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Miktar")
                        .HasColumnType("int");

                    b.HasKey("AletId");

                    b.ToTable("Aletler");
                });

            modelBuilder.Entity("SporSalonuYönetimSistemi.Models.Ders", b =>
                {
                    b.Property<int>("DersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DersId"));

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Aktif")
                        .HasColumnType("bit");

                    b.Property<DateTime>("BaslangicSaati")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BitisSaati")
                        .HasColumnType("datetime2");

                    b.Property<string>("DersAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DersYeri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EgitmenId")
                        .HasColumnType("int");

                    b.HasKey("DersId");

                    b.HasIndex("EgitmenId");

                    b.ToTable("Dersler");
                });

            modelBuilder.Entity("SporSalonuYönetimSistemi.Models.Egitmen", b =>
                {
                    b.Property<int>("EgitmenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EgitmenId"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Deneyim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Iletisim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UzmanlikAlani")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EgitmenId");

                    b.ToTable("Egitmenler");
                });

            modelBuilder.Entity("SporSalonuYönetimSistemi.Models.GelirGider", b =>
                {
                    b.Property<int>("GelirGiderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GelirGiderId"));

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Miktar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tipi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GelirGiderId");

                    b.ToTable("GelirGider");
                });

            modelBuilder.Entity("SporSalonuYönetimSistemi.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("AbonelikBaslangicTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("AbonelikBitisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<int>("AylikUcret")
                        .HasColumnType("int");

                    b.Property<string>("Eposta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IndirimOrani")
                        .HasColumnType("int");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UyelikSuresi")
                        .HasColumnType("int");

                    b.Property<string>("UyelikTuru")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("SporSalonuYönetimSistemi.Models.Ders", b =>
                {
                    b.HasOne("SporSalonuYönetimSistemi.Models.Egitmen", "Egitmen")
                        .WithMany()
                        .HasForeignKey("EgitmenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Egitmen");
                });
#pragma warning restore 612, 618
        }
    }
}