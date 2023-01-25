﻿// <auto-generated />
using System;
using Biblioteka.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Biblioteka.Migrations
{
    [DbContext(typeof(BibliotekaContext))]
    [Migration("20230125024419_AddBorrows")]
    partial class AddBorrows
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("Biblioteka.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.Property<int>("CopiesInLibrary")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CoverUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Isbn")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ReaderId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("BookId");

                    b.HasIndex("ReaderId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Biblioteka.Models.Reader", b =>
                {
                    b.Property<int>("ReaderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("ReaderId");

                    b.ToTable("Readers");
                });

            modelBuilder.Entity("Biblioteka.Models.Book", b =>
                {
                    b.HasOne("Biblioteka.Models.Reader", null)
                        .WithMany("CurrentlyBorrowed")
                        .HasForeignKey("ReaderId");
                });

            modelBuilder.Entity("Biblioteka.Models.Reader", b =>
                {
                    b.Navigation("CurrentlyBorrowed");
                });
#pragma warning restore 612, 618
        }
    }
}
