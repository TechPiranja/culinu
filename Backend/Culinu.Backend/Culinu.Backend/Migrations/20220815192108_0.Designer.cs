﻿// <auto-generated />
using System;
using Culinu.Backend;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Culinu.Backend.Migrations
{
    [DbContext(typeof(CulinuContext))]
    [Migration("20220815192108_0")]
    partial class _0
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Culinu.Backend.Models.IngredientModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("RecipeModelId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RecipeModelId");

                    b.ToTable("Ingredient", (string)null);
                });

            modelBuilder.Entity("Culinu.Backend.Models.RecipeDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("RecipeModelId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RecipeModelId");

                    b.ToTable("RecipeDescription", (string)null);
                });

            modelBuilder.Entity("Culinu.Backend.Models.RecipeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Recipe", (string)null);
                });

            modelBuilder.Entity("Culinu.Backend.Models.IngredientModel", b =>
                {
                    b.HasOne("Culinu.Backend.Models.RecipeModel", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeModelId");
                });

            modelBuilder.Entity("Culinu.Backend.Models.RecipeDescription", b =>
                {
                    b.HasOne("Culinu.Backend.Models.RecipeModel", null)
                        .WithMany("Descriptions")
                        .HasForeignKey("RecipeModelId");
                });

            modelBuilder.Entity("Culinu.Backend.Models.RecipeModel", b =>
                {
                    b.Navigation("Descriptions");

                    b.Navigation("Ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}