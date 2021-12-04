﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Xpymb.TestExercises.GameRepository.Data;

namespace Xpymb.TestExercises.GameRepository.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211204131910_RenameGameTagTypesToGameTagsInGameInfoTable")]
    partial class RenameGameTagTypesToGameTagsInGameInfoTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("Xpymb.TestExercises.ASP.GameRepository.Data.Entities.GameInfoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("GameStudio")
                        .HasColumnType("TEXT");

                    b.Property<string>("GameTags")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("GamesInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
