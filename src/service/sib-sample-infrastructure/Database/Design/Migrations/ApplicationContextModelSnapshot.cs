﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SibSample.Infrastructure.Database;

namespace SibSample.Infrastructure.Database.Design.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    internal partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SibSample.Domain.Users.Documents.Document", b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("uuid");

                b.Property<int>("DocumentType")
                    .HasColumnType("integer");

                b.Property<Guid?>("UserId")
                    .HasColumnType("uuid");

                b.Property<string>("Value")
                    .HasColumnType("text");

                b.HasKey("Id");

                b.HasIndex("UserId");

                b.ToTable("Documents");
            });

            modelBuilder.Entity("SibSample.Domain.Users.User", b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("uuid");

                b.Property<string>("Name")
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("Users");
            });

            modelBuilder.Entity("SibSample.Domain.Users.Documents.Document", b =>
            {
                b.HasOne("SibSample.Domain.Users.User", "User")
                    .WithMany("Documents")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("SibSample.Domain.Users.User", b =>
            {
                b.OwnsOne("SibSample.Domain.Users.Email", "Email", b1 =>
                {
                    b1.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b1.Property<string>("Value")
                        .HasColumnName("Email")
                        .HasColumnType("text");

                    b1.HasKey("UserId");

                    b1.HasIndex("Value");

                    b1.ToTable("Users");

                    b1.WithOwner()
                        .HasForeignKey("UserId");
                });
            });
#pragma warning restore 612, 618
        }
    }
}