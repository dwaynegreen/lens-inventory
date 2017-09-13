﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SeeMoreInventory.Models;
using System;

namespace SeeMoreInventory.Migrations
{
    [DbContext(typeof(LensContext))]
    partial class LensContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SeeMoreInventory.Models.Lens", b =>
                {
                    b.Property<string>("ProductLabel")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30);

                    b.Property<bool>("AntiReflectiveCoating");

                    b.Property<int?>("Axis");

                    b.Property<decimal>("Cylinder");

                    b.Property<int>("LowInventoryWarning");

                    b.Property<int?>("MaterialId");

                    b.Property<int?>("RemainingCount");

                    b.Property<decimal>("Sphere");

                    b.Property<bool>("Transitions");

                    b.HasKey("ProductLabel");

                    b.HasIndex("MaterialId");

                    b.ToTable("Lenses");
                });

            modelBuilder.Entity("SeeMoreInventory.Models.LensHistory", b =>
                {
                    b.Property<string>("ProductLabel")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30);

                    b.Property<bool>("AntiReflectiveCoating");

                    b.Property<int?>("Axis");

                    b.Property<decimal>("Cylinder");

                    b.Property<DateTime>("InsertDate");

                    b.Property<int?>("MaterialId");

                    b.Property<int>("Quantity");

                    b.Property<int?>("RemainingCount");

                    b.Property<decimal>("Sphere");

                    b.Property<bool>("Transitions");

                    b.HasKey("ProductLabel");

                    b.HasIndex("MaterialId");

                    b.ToTable("LensHistory");
                });

            modelBuilder.Entity("SeeMoreInventory.Models.MaterialType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("MaterialType");
                });

            modelBuilder.Entity("SeeMoreInventory.Models.Lens", b =>
                {
                    b.HasOne("SeeMoreInventory.Models.MaterialType", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId");
                });

            modelBuilder.Entity("SeeMoreInventory.Models.LensHistory", b =>
                {
                    b.HasOne("SeeMoreInventory.Models.MaterialType", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId");
                });
#pragma warning restore 612, 618
        }
    }
}
