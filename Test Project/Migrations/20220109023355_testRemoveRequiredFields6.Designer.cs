﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicAPI.Contexts;

#nullable disable

namespace Test_Project.Migrations
{
    [DbContext(typeof(MusicContext))]
    [Migration("20220109023355_testRemoveRequiredFields6")]
    partial class testRemoveRequiredFields6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MusicAPI.Models.AlbumModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ArtistID")
                        .HasColumnType("int");

                    b.Property<int?>("ArtistModelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ArtistID");

                    b.HasIndex("ArtistModelId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("MusicAPI.Models.ArtistModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("MusicAPI.Models.SongModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AlbumID")
                        .HasColumnType("int");

                    b.Property<int?>("AlbumModelId")
                        .HasColumnType("int");

                    b.Property<int?>("ArtistID")
                        .HasColumnType("int");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumID");

                    b.HasIndex("AlbumModelId");

                    b.HasIndex("ArtistID");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("MusicAPI.Models.AlbumModel", b =>
                {
                    b.HasOne("MusicAPI.Models.ArtistModel", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistID");

                    b.HasOne("MusicAPI.Models.ArtistModel", null)
                        .WithMany("Albums")
                        .HasForeignKey("ArtistModelId");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("MusicAPI.Models.SongModel", b =>
                {
                    b.HasOne("MusicAPI.Models.AlbumModel", "Album")
                        .WithMany()
                        .HasForeignKey("AlbumID");

                    b.HasOne("MusicAPI.Models.AlbumModel", null)
                        .WithMany("Songs")
                        .HasForeignKey("AlbumModelId");

                    b.HasOne("MusicAPI.Models.ArtistModel", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistID");

                    b.Navigation("Album");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("MusicAPI.Models.AlbumModel", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("MusicAPI.Models.ArtistModel", b =>
                {
                    b.Navigation("Albums");
                });
#pragma warning restore 612, 618
        }
    }
}