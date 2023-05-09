﻿// <auto-generated />
using API_Labb_4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_Labb_4.Migrations
{
    [DbContext(typeof(APIDbContext))]
    partial class APIDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_Labb_4.Models.Hobbie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HobbieName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hobbies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Making music with sound",
                            HobbieName = "Music"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Getting that good K/D score",
                            HobbieName = "Gaming"
                        });
                });

            modelBuilder.Entity("API_Labb_4.Models.HobbieLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HobbieId")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HobbieId");

                    b.HasIndex("PersonId");

                    b.ToTable("HobbieLinks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HobbieId = 1,
                            Link = "Link to drums",
                            PersonId = 1
                        },
                        new
                        {
                            Id = 2,
                            HobbieId = 1,
                            Link = "Link to guitars",
                            PersonId = 2
                        },
                        new
                        {
                            Id = 3,
                            HobbieId = 2,
                            Link = "Link to Counter Strike",
                            PersonId = 3
                        },
                        new
                        {
                            Id = 4,
                            HobbieId = 2,
                            Link = "Link to Farming Simulator",
                            PersonId = 4
                        });
                });

            modelBuilder.Entity("API_Labb_4.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Claes",
                            PhoneNumber = "123123123"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Alex",
                            PhoneNumber = "456456456"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Krille",
                            PhoneNumber = "789789789"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Linus",
                            PhoneNumber = "147147147"
                        });
                });

            modelBuilder.Entity("API_Labb_4.Models.HobbieLink", b =>
                {
                    b.HasOne("API_Labb_4.Models.Hobbie", "Hobbie")
                        .WithMany("HobbieLinks")
                        .HasForeignKey("HobbieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Labb_4.Models.Person", "Person")
                        .WithMany("HobbieLinks")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hobbie");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("API_Labb_4.Models.Hobbie", b =>
                {
                    b.Navigation("HobbieLinks");
                });

            modelBuilder.Entity("API_Labb_4.Models.Person", b =>
                {
                    b.Navigation("HobbieLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
