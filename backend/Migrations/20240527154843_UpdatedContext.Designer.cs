﻿// <auto-generated />
using System;
using Kinopoisk.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240527154843_UpdatedContext")]
    partial class UpdatedContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Kinopoisk.Models.CountryModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("countries");
                });

            modelBuilder.Entity("Kinopoisk.Models.GenreModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("genres");
                });

            modelBuilder.Entity("Kinopoisk.Models.MovieCountryModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("char(36)")
                        .HasColumnName("country_id");

                    b.Property<Guid>("MovieInfoId")
                        .HasColumnType("char(36)")
                        .HasColumnName("movie_info_id");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("MovieInfoId");

                    b.ToTable("movies_countries");
                });

            modelBuilder.Entity("Kinopoisk.Models.MovieGenreModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("char(36)")
                        .HasColumnName("genre_id");

                    b.Property<Guid>("MovieInfoId")
                        .HasColumnType("char(36)")
                        .HasColumnName("movie_info_id");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("MovieInfoId");

                    b.ToTable("movies_genres");
                });

            modelBuilder.Entity("Kinopoisk.Models.MovieInfoModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("NameEn")
                        .HasColumnType("longtext")
                        .HasColumnName("name_en");

                    b.Property<string>("NameRu")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name_ru");

                    b.Property<string>("PosterUrl")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("poster_url");

                    b.Property<string>("PosterUrlPreview")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("poster_url_preview");

                    b.Property<double>("Rating")
                        .HasColumnType("double")
                        .HasColumnName("rating");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("type");

                    b.Property<int>("Year")
                        .HasColumnType("int")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.ToTable("movie_infos");
                });

            modelBuilder.Entity("Kinopoisk.Models.MovieModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<Guid>("MovieInfoId")
                        .HasColumnType("char(36)")
                        .HasColumnName("movie_info_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Uri")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("uri");

                    b.HasKey("Id");

                    b.HasIndex("MovieInfoId")
                        .IsUnique();

                    b.ToTable("movies");
                });

            modelBuilder.Entity("Kinopoisk.Models.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_admin");

                    b.Property<bool>("IsAuthorized")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_authorized");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("password_digest");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("username");

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("427954ad-7625-45c5-a76e-3b2363cc1fd6"),
                            Email = "admin@gmail.com",
                            IsAdmin = true,
                            IsAuthorized = false,
                            Password = "Admin",
                            Username = "Admin",
                            isActive = true
                        });
                });

            modelBuilder.Entity("Kinopoisk.Models.MovieCountryModel", b =>
                {
                    b.HasOne("Kinopoisk.Models.CountryModel", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kinopoisk.Models.MovieInfoModel", "MovieInfo")
                        .WithMany()
                        .HasForeignKey("MovieInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("MovieInfo");
                });

            modelBuilder.Entity("Kinopoisk.Models.MovieGenreModel", b =>
                {
                    b.HasOne("Kinopoisk.Models.GenreModel", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kinopoisk.Models.MovieInfoModel", "MovieInfo")
                        .WithMany()
                        .HasForeignKey("MovieInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("MovieInfo");
                });

            modelBuilder.Entity("Kinopoisk.Models.MovieModel", b =>
                {
                    b.HasOne("Kinopoisk.Models.MovieInfoModel", "MovieInfo")
                        .WithOne("Movie")
                        .HasForeignKey("Kinopoisk.Models.MovieModel", "MovieInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MovieInfo");
                });

            modelBuilder.Entity("Kinopoisk.Models.MovieInfoModel", b =>
                {
                    b.Navigation("Movie");
                });
#pragma warning restore 612, 618
        }
    }
}
