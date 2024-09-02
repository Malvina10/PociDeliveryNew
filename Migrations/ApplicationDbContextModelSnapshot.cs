﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PociDelivery.Data;

#nullable disable

namespace PociDelivery.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PociDelivery.Models.Dergesa", b =>
                {
                    b.Property<int>("IDDergesa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDDergesa"), 1L, 1);

                    b.Property<string>("AdresaMarresit")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Cmimi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmriMarresit")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IDKlienti")
                        .HasColumnType("int");

                    b.Property<int>("IDPikaPostare")
                        .HasColumnType("int");

                    b.Property<int>("IDSportelisti")
                        .HasColumnType("int");

                    b.Property<string>("MbiemriMarresit")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NumerTelefoni")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IDDergesa");

                    b.HasIndex("IDKlienti");

                    b.HasIndex("IDPikaPostare");

                    b.HasIndex("IDSportelisti");

                    b.ToTable("Dergesat");
                });

            modelBuilder.Entity("PociDelivery.Models.Paketa", b =>
                {
                    b.Property<int>("IDPaketa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDPaketa"), 1L, 1);

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDPikaPostareFillim")
                        .HasColumnType("int");

                    b.Property<int>("IDPikaPostareFund")
                        .HasColumnType("int");

                    b.Property<int>("IDTransportuesi")
                        .HasColumnType("int");

                    b.HasKey("IDPaketa");

                    b.HasIndex("IDPikaPostareFillim");

                    b.HasIndex("IDPikaPostareFund");

                    b.HasIndex("IDTransportuesi");

                    b.ToTable("Paketat");
                });

            modelBuilder.Entity("PociDelivery.Models.Perdoruesi", b =>
                {
                    b.Property<int>("IDPerdoruesi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDPerdoruesi"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Emri")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Fjalekalimi")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("IDPikaPostare")
                        .HasColumnType("int");

                    b.Property<int>("IDRoli")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Mbiemri")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IDPerdoruesi");

                    b.HasIndex("IDPikaPostare");

                    b.HasIndex("IDRoli");

                    b.ToTable("Perdoruesit");
                });

            modelBuilder.Entity("PociDelivery.Models.PikaPostare", b =>
                {
                    b.Property<int>("IDPikaPostare")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDPikaPostare"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Pikapostare")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte>("Statusi")
                        .HasColumnType("tinyint");

                    b.Property<string>("Vendndodhja")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("IDPikaPostare");

                    b.ToTable("PikatPostare");
                });

            modelBuilder.Entity("PociDelivery.Models.Reporti", b =>
                {
                    b.Property<int>("IDReporti")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDReporti"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDPerdoruesi")
                        .HasColumnType("int");

                    b.Property<string>("Permbajtja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Tipi")
                        .HasColumnType("tinyint");

                    b.HasKey("IDReporti");

                    b.HasIndex("IDPerdoruesi");

                    b.ToTable("Reportet");
                });

            modelBuilder.Entity("PociDelivery.Models.Roli", b =>
                {
                    b.Property<int>("IDRoli")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDRoli"), 1L, 1);

                    b.Property<string>("EmerRoli")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IDRoli");

                    b.ToTable("Rolet");
                });

            modelBuilder.Entity("PociDelivery.Models.Statusi", b =>
                {
                    b.Property<int>("IDStatusi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDStatusi"), 1L, 1);

                    b.Property<string>("EmerStatusi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IDStatusi");

                    b.ToTable("Statuset");
                });

            modelBuilder.Entity("PociDelivery.Models.StatusiDergesa", b =>
                {
                    b.Property<int>("IDStatusiDergesa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDStatusiDergesa"), 1L, 1);

                    b.Property<byte>("Fshire")
                        .HasColumnType("tinyint");

                    b.Property<int>("IDDergesa")
                        .HasColumnType("int");

                    b.Property<int>("IDStatusi")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("IDStatusiDergesa");

                    b.HasIndex("IDDergesa");

                    b.HasIndex("IDStatusi");

                    b.ToTable("StatusetDergesa");
                });

            modelBuilder.Entity("PociDelivery.Models.StatusiPaketa", b =>
                {
                    b.Property<int>("IDStatusiPaketa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDStatusiPaketa"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Fshire")
                        .HasColumnType("tinyint");

                    b.Property<int>("IDPaketa")
                        .HasColumnType("int");

                    b.Property<int>("IDStatusi")
                        .HasColumnType("int");

                    b.HasKey("IDStatusiPaketa");

                    b.HasIndex("IDPaketa");

                    b.HasIndex("IDStatusi");

                    b.ToTable("StatusetPaketa");
                });

            modelBuilder.Entity("PociDelivery.Models.ZonaMbulimit", b =>
                {
                    b.Property<int>("IDZonaMbulimit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDZonaMbulimit"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDPikaPostare")
                        .HasColumnType("int");

                    b.Property<byte>("Statusi")
                        .HasColumnType("tinyint");

                    b.Property<string>("Zona")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IDZonaMbulimit");

                    b.HasIndex("IDPikaPostare");

                    b.ToTable("ZonatMbulimit");
                });

            modelBuilder.Entity("PociDelivery.Models.Dergesa", b =>
                {
                    b.HasOne("PociDelivery.Models.Perdoruesi", "Klient")
                        .WithMany("Klient")
                        .HasForeignKey("IDKlienti")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PociDelivery.Models.PikaPostare", "PikaPostare")
                        .WithMany("Dergesat")
                        .HasForeignKey("IDPikaPostare")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PociDelivery.Models.Perdoruesi", "Sportelist")
                        .WithMany("Sportelist")
                        .HasForeignKey("IDSportelisti")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Klient");

                    b.Navigation("PikaPostare");

                    b.Navigation("Sportelist");
                });

            modelBuilder.Entity("PociDelivery.Models.Paketa", b =>
                {
                    b.HasOne("PociDelivery.Models.PikaPostare", "PikaPostareFillim")
                        .WithMany("PaketatFillim")
                        .HasForeignKey("IDPikaPostareFillim")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PociDelivery.Models.PikaPostare", "PikaPostareFund")
                        .WithMany("PaketatFund")
                        .HasForeignKey("IDPikaPostareFund")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PociDelivery.Models.Perdoruesi", "Transportuesi")
                        .WithMany("Paketat")
                        .HasForeignKey("IDTransportuesi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PikaPostareFillim");

                    b.Navigation("PikaPostareFund");

                    b.Navigation("Transportuesi");
                });

            modelBuilder.Entity("PociDelivery.Models.Perdoruesi", b =>
                {
                    b.HasOne("PociDelivery.Models.PikaPostare", "PikaPostare")
                        .WithMany("Perdoruesit")
                        .HasForeignKey("IDPikaPostare");

                    b.HasOne("PociDelivery.Models.Roli", "Roli")
                        .WithMany()
                        .HasForeignKey("IDRoli")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PikaPostare");

                    b.Navigation("Roli");
                });

            modelBuilder.Entity("PociDelivery.Models.Reporti", b =>
                {
                    b.HasOne("PociDelivery.Models.Perdoruesi", "Perdoruesi")
                        .WithMany("Reportet")
                        .HasForeignKey("IDPerdoruesi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perdoruesi");
                });

            modelBuilder.Entity("PociDelivery.Models.StatusiDergesa", b =>
                {
                    b.HasOne("PociDelivery.Models.Dergesa", "Dergesa")
                        .WithMany("StatusiDergesa")
                        .HasForeignKey("IDDergesa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PociDelivery.Models.Statusi", "Statusi")
                        .WithMany("StatusiDergesa")
                        .HasForeignKey("IDStatusi")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Dergesa");

                    b.Navigation("Statusi");
                });

            modelBuilder.Entity("PociDelivery.Models.StatusiPaketa", b =>
                {
                    b.HasOne("PociDelivery.Models.Paketa", "Paketa")
                        .WithMany("StatusiPaketa")
                        .HasForeignKey("IDPaketa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PociDelivery.Models.Statusi", "Statusi")
                        .WithMany("StatusiPaketa")
                        .HasForeignKey("IDStatusi")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Paketa");

                    b.Navigation("Statusi");
                });

            modelBuilder.Entity("PociDelivery.Models.ZonaMbulimit", b =>
                {
                    b.HasOne("PociDelivery.Models.PikaPostare", "PikaPostare")
                        .WithMany("ZonaMbulimit")
                        .HasForeignKey("IDPikaPostare")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PikaPostare");
                });

            modelBuilder.Entity("PociDelivery.Models.Dergesa", b =>
                {
                    b.Navigation("StatusiDergesa");
                });

            modelBuilder.Entity("PociDelivery.Models.Paketa", b =>
                {
                    b.Navigation("StatusiPaketa");
                });

            modelBuilder.Entity("PociDelivery.Models.Perdoruesi", b =>
                {
                    b.Navigation("Klient");

                    b.Navigation("Paketat");

                    b.Navigation("Reportet");

                    b.Navigation("Sportelist");
                });

            modelBuilder.Entity("PociDelivery.Models.PikaPostare", b =>
                {
                    b.Navigation("Dergesat");

                    b.Navigation("PaketatFillim");

                    b.Navigation("PaketatFund");

                    b.Navigation("Perdoruesit");

                    b.Navigation("ZonaMbulimit");
                });

            modelBuilder.Entity("PociDelivery.Models.Roli", b =>
                {
                    b.Navigation("Perdoruesit");
                });

            modelBuilder.Entity("PociDelivery.Models.Statusi", b =>
                {
                    b.Navigation("StatusiDergesa");

                    b.Navigation("StatusiPaketa");
                });
#pragma warning restore 612, 618
        }
    }
}
