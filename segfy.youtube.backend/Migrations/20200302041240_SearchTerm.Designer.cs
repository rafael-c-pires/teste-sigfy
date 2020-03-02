﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using segfy.youtube.backend.Repository;

namespace segfy.youtube.backend.Migrations
{
    [DbContext(typeof(YoutubeDbContext))]
    [Migration("20200302041240_SearchTerm")]
    partial class SearchTerm
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("segfy.youtube.backend.Models.SearchLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ChannelId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ChannelTitle")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("PublishedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("SearchTermId")
                        .HasColumnType("int");

                    b.Property<string>("Thumbnails")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("VideoId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("VideoTitle")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("SearchTermId");

                    b.ToTable("SearchLogs");
                });

            modelBuilder.Entity("segfy.youtube.backend.Models.SearchTerm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("SearchedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Term")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("SearchTerm");
                });

            modelBuilder.Entity("segfy.youtube.backend.Models.SearchLog", b =>
                {
                    b.HasOne("segfy.youtube.backend.Models.SearchTerm", "SearchTerm")
                        .WithMany()
                        .HasForeignKey("SearchTermId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}