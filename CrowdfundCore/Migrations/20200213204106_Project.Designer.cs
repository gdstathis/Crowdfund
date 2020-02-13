﻿// <auto-generated />
using System;
using CrowdfundCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrowdfundCore.Migrations
{
    [DbContext(typeof(CrowdfundDbContext))]
    [Migration("20200213204106_Project")]
    partial class Project
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CrowdfundCore.Model.User", b =>
                {
                    b.Property<int>("id_user")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_user");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CrowdfundCore.Project", b =>
                {
                    b.Property<string>("id_project")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Creatorid_user")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("budget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("dateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("deadline")
                        .HasColumnType("datetime2");

                    b.Property<int>("projectCategory")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_project");

                    b.HasIndex("Creatorid_user");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("CrowdfundCore.Project", b =>
                {
                    b.HasOne("CrowdfundCore.Model.User", "Creator")
                        .WithMany()
                        .HasForeignKey("Creatorid_user");
                });
#pragma warning restore 612, 618
        }
    }
}
