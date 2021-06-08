﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Samir_Cabrera.Movies.Data;

namespace Samir_Cabrera.Movies.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20210607120637_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13");

            modelBuilder.Entity("Samir_Cabrera.Movies.Entity.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Image");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d7ac925f-999b-49f8-b201-7405957685f7"),
                            MovieId = new Guid("2b983e46-e960-40af-9b03-3c62d9e140ab"),
                            Url = "s"
                        },
                        new
                        {
                            Id = new Guid("6bfae1bc-18ff-434b-b10c-0a2defb867bd"),
                            MovieId = new Guid("2b983e46-e960-40af-9b03-3c62d9e140ab"),
                            Url = "s"
                        },
                        new
                        {
                            Id = new Guid("7790df72-27a3-4a08-91ff-f428a1d6e919"),
                            MovieId = new Guid("aa3f8665-a004-4e5d-9296-5633579c9648"),
                            Url = "s"
                        });
                });

            modelBuilder.Entity("Samir_Cabrera.Movies.Entity.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Like")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ToViewLater")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("View")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("aa3f8665-a004-4e5d-9296-5633579c9648"),
                            Description = "http://sample.com",
                            Like = true,
                            Title = "s",
                            ToViewLater = false,
                            View = false
                        },
                        new
                        {
                            Id = new Guid("2b983e46-e960-40af-9b03-3c62d9e140ab"),
                            Description = "http://sample.com",
                            Like = true,
                            Title = "s",
                            ToViewLater = false,
                            View = false
                        });
                });

            modelBuilder.Entity("Samir_Cabrera.Movies.Entity.Image", b =>
                {
                    b.HasOne("Samir_Cabrera.Movies.Entity.Movie", null)
                        .WithMany("Images")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}