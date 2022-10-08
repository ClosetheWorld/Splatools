﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Splatools.Infrastructure.Database;

#nullable disable

namespace Splatools.Migrations
{
    [DbContext(typeof(SplatDbContext))]
    [Migration("20221008183036_add-AuthenticationParameter-InsertionTime")]
    partial class addAuthenticationParameterInsertionTime
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Splatools.Domain.Entities.AuthenticationParameter", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Challenge")
                        .IsRequired()
                        .HasMaxLength(52)
                        .HasColumnType("nvarchar(52)");

                    b.Property<long>("InsertionTime")
                        .HasColumnType("bigint");

                    b.HasKey("Key");

                    b.ToTable("AuthenticationParameters");
                });
#pragma warning restore 612, 618
        }
    }
}