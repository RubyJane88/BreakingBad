﻿// <auto-generated />
using System;
using BreakingBad.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BreakingBad.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211118164439_Quotesdata")]
    partial class Quotesdata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BreakingBad.API.Models.Entities.Character", b =>
                {
                    b.Property<int>("CharId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharId"), 1L, 1);

                    b.Property<string>("Appearance")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BetterCallSaulAppearance")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Portrayed")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("CharId");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            CharId = 1,
                            Appearance = "Breaking Bad",
                            BetterCallSaulAppearance = "None",
                            Birthday = new DateTime(1984, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Category = "Breaking Bad",
                            Img = "https://vignette.wikia.nocookie.net/breakingbad/images/9/95/JesseS5.jpg/revision/latest?cb=20120620012441",
                            Name = "Jessie Pinkman",
                            Nickname = "Cap n' Cook",
                            Occupation = "Meth dealer",
                            Portrayed = "Aaron Paul"
                        });
                });

            modelBuilder.Entity("BreakingBad.API.Models.Entities.Episode", b =>
                {
                    b.Property<int>("EpisodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EpisodeId"), 1L, 1);

                    b.Property<DateTime>("AirDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Episodes")
                        .HasColumnType("int");

                    b.Property<string>("Season")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Series")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("EpisodeId");

                    b.ToTable("Episodes");

                    b.HasData(
                        new
                        {
                            EpisodeId = 60,
                            AirDate = new DateTime(2008, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Episodes = 14,
                            Season = "5",
                            Series = "1",
                            Title = "Ozymandias"
                        });
                });

            modelBuilder.Entity("BreakingBad.API.Models.Entities.Quote", b =>
                {
                    b.Property<int>("QuoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuoteId"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Quotes")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Series")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("QuoteId");

                    b.ToTable("Quotes");

                    b.HasData(
                        new
                        {
                            QuoteId = 4,
                            Author = "Walter White",
                            Quotes = "I watched Jane die. I was there. And I watched her die. I watched her overdose and choke to death. I could have saved her. But I didn’t.",
                            Series = "Breaking Bad"
                        },
                        new
                        {
                            QuoteId = 7,
                            Author = "Saul Goodman",
                            Quotes = "Yeah, you do seem to have a little s*** creek action going... You know, FYI, you can buy a paddle.",
                            Series = "Breaking Bad"
                        },
                        new
                        {
                            QuoteId = 9,
                            Author = "Jesse Pinkman",
                            Quotes = "Funyuns are awesome.",
                            Series = "Breaking Bad"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
