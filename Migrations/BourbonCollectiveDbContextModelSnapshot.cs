﻿// <auto-generated />
using BEBourbonCollective;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BEBourbonCollective.Migrations
{
    [DbContext(typeof(BourbonCollectiveDbContext))]
    partial class BourbonCollectiveDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BEBourbonCollective.Models.Bourbon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DistilleryId")
                        .HasColumnType("integer");

                    b.Property<bool>("EmptyBottle")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("OpenBottle")
                        .HasColumnType("boolean");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DistilleryId");

                    b.HasIndex("UserId");

                    b.ToTable("Bourbons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DistilleryId = 1,
                            EmptyBottle = false,
                            Name = "Buffalo Trace Kentucky Straight Bourbon Whiskey",
                            OpenBottle = true,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            DistilleryId = 2,
                            EmptyBottle = false,
                            Name = "Straight Bourbon Whiskey",
                            OpenBottle = false,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("BEBourbonCollective.Models.Distillery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Distilleries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Frankfort",
                            Name = "Buffalo Trace",
                            State = "Kentucky"
                        },
                        new
                        {
                            Id = 2,
                            City = "Versailles",
                            Name = "Woodford Reserve",
                            State = "Kentucky"
                        },
                        new
                        {
                            Id = 3,
                            City = "Loretto",
                            Name = "Maker's Mark",
                            State = "Kentucky"
                        },
                        new
                        {
                            Id = 4,
                            City = "Lawrenceburg",
                            Name = "Four Roses",
                            State = "Kentucky"
                        },
                        new
                        {
                            Id = 5,
                            City = "Frankfort",
                            Name = "Whiskey Thief",
                            State = "Kentucky"
                        },
                        new
                        {
                            Id = 6,
                            City = "Bardstown",
                            Name = "Willett",
                            State = "Kentucky"
                        },
                        new
                        {
                            Id = 7,
                            City = "Frankfort",
                            Name = "Castle & Key",
                            State = "Kentucky"
                        },
                        new
                        {
                            Id = 8,
                            City = "Louisville",
                            Name = "Evan Williams",
                            State = "Kentucky"
                        },
                        new
                        {
                            Id = 9,
                            City = "Shively",
                            Name = "Stitzel-Weller",
                            State = "Kentucky"
                        },
                        new
                        {
                            Id = 10,
                            City = "Lousiville",
                            Name = "Angel's Envy",
                            State = "Kentucky"
                        });
                });

            modelBuilder.Entity("BEBourbonCollective.Models.TradeRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Approved")
                        .HasColumnType("boolean");

                    b.Property<bool>("Pending")
                        .HasColumnType("boolean");

                    b.Property<int>("RequestedFromBourbonId")
                        .HasColumnType("integer");

                    b.Property<int>("RequestedFromUserId")
                        .HasColumnType("integer");

                    b.Property<int>("RequestingBourbonId")
                        .HasColumnType("integer");

                    b.Property<int>("RequestingFromBourbonId")
                        .HasColumnType("integer");

                    b.Property<int>("RequestingUserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RequestedFromBourbonId");

                    b.HasIndex("RequestedFromUserId");

                    b.HasIndex("RequestingFromBourbonId");

                    b.HasIndex("RequestingUserId");

                    b.ToTable("TradeRequests");
                });

            modelBuilder.Entity("BEBourbonCollective.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirebaseId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Brandenburg",
                            Email = "felicia_mings@yahoo.com",
                            FirebaseId = "C0wunKp1sIQRM9YR48JnQPlNXt92",
                            FullName = "Felicia Yahoo",
                            State = "Kentucky",
                            Username = "bourbondrinker01"
                        });
                });

            modelBuilder.Entity("BEBourbonCollective.Models.UserBourbon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BourbonId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BourbonId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBourbons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BourbonId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("BEBourbonCollective.Models.Bourbon", b =>
                {
                    b.HasOne("BEBourbonCollective.Models.Distillery", "Distillery")
                        .WithMany()
                        .HasForeignKey("DistilleryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BEBourbonCollective.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Distillery");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BEBourbonCollective.Models.TradeRequest", b =>
                {
                    b.HasOne("BEBourbonCollective.Models.Bourbon", "RequestedFromBourbon")
                        .WithMany()
                        .HasForeignKey("RequestedFromBourbonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BEBourbonCollective.Models.User", "RequestedFromUser")
                        .WithMany()
                        .HasForeignKey("RequestedFromUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BEBourbonCollective.Models.Bourbon", "RequestingFromBourbon")
                        .WithMany()
                        .HasForeignKey("RequestingFromBourbonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BEBourbonCollective.Models.User", "RequestingUser")
                        .WithMany()
                        .HasForeignKey("RequestingUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequestedFromBourbon");

                    b.Navigation("RequestedFromUser");

                    b.Navigation("RequestingFromBourbon");

                    b.Navigation("RequestingUser");
                });

            modelBuilder.Entity("BEBourbonCollective.Models.UserBourbon", b =>
                {
                    b.HasOne("BEBourbonCollective.Models.Bourbon", "Bourbon")
                        .WithMany()
                        .HasForeignKey("BourbonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BEBourbonCollective.Models.User", "User")
                        .WithMany("UserBourbons")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bourbon");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BEBourbonCollective.Models.User", b =>
                {
                    b.Navigation("UserBourbons");
                });
#pragma warning restore 612, 618
        }
    }
}
