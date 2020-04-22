﻿// <auto-generated />
using System;
using Exercise_08.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Exercise_08.Migrations
{
    [DbContext(typeof(AnimalDbContext))]
    partial class AnimalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Exercise_08.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("AnimalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<int>("IdOwner")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdOwner");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("Exercise_08.Models.AnimalClinic", b =>
                {
                    b.Property<int>("IdAnimalClinic")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int>("IdOwner")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("IdAnimalClinic");

                    b.HasIndex("IdOwner");

                    b.ToTable("AnimalClinics");
                });

            modelBuilder.Entity("Exercise_08.Models.AnimalType", b =>
                {
                    b.Property<int>("IdAnimalType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAnimalType");

                    b.ToTable("Animal_Type");
                });

            modelBuilder.Entity("Exercise_08.Models.Owner", b =>
                {
                    b.Property<int>("IdOwner")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("IdOwner");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("Exercise_08.Models.Animal", b =>
                {
                    b.HasOne("Exercise_08.Models.Owner", "Owner")
                        .WithMany("Animals")
                        .HasForeignKey("IdOwner")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Exercise_08.Models.AnimalClinic", b =>
                {
                    b.HasOne("Exercise_08.Models.Owner", "Owner")
                        .WithMany("AnimalClinics")
                        .HasForeignKey("IdOwner")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}