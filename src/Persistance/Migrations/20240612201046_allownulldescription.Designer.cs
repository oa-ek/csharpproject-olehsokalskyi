﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistance;

#nullable disable

namespace Persistance.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240612201046_allownulldescription")]
    partial class allownulldescription
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DeveloperGame", b =>
                {
                    b.Property<Guid>("DevelopersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GamesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DevelopersId", "GamesId");

                    b.HasIndex("GamesId");

                    b.ToTable("DeveloperGame");
                });

            modelBuilder.Entity("Domain.Entities.Achievement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PlayersGet")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("Domain.Entities.AchievementUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AchievementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AchievementId");

                    b.HasIndex("UserId");

                    b.ToTable("AchievementUsers");
                });

            modelBuilder.Entity("Domain.Entities.Developer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("Domain.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("PublisherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trailer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Domain.Entities.GameTime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastPlayed")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("TotalTime")
                        .HasColumnType("time");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("GameTimes");
                });

            modelBuilder.Entity("Domain.Entities.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Domain.Entities.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8ea14626-e9fc-4c5f-a857-1705a57ca518"),
                            Title = "English"
                        },
                        new
                        {
                            Id = new Guid("39ac08c4-5538-41b3-9642-7d4953637b9d"),
                            Title = "Polish"
                        },
                        new
                        {
                            Id = new Guid("91b524fd-7a2e-49e3-9045-35087ecb4f05"),
                            Title = "German"
                        },
                        new
                        {
                            Id = new Guid("5264577d-51de-4a15-bf57-7697a238b0f0"),
                            Title = "French"
                        },
                        new
                        {
                            Id = new Guid("1af757cd-a85f-4132-b7db-b9abe86d4848"),
                            Title = "Spanish"
                        },
                        new
                        {
                            Id = new Guid("5bfe3e53-6abb-4351-bd98-0f3b96cde09d"),
                            Title = "Italian"
                        },
                        new
                        {
                            Id = new Guid("7c8e862c-b7d4-4ae2-bdf4-a3ca9187adf2"),
                            Title = "Ukraine"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Platform", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("Domain.Entities.Publisher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("Domain.Entities.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("RatingValue")
                        .HasColumnType("float");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Domain.Entities.RoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("04b93a99-7f05-490c-8b65-233d93af17a8"),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("5af06273-1ec8-40b6-9e41-9edca8019b04"),
                            Name = "User"
                        });
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ddf1a01f-09ff-4dba-8cbe-71b19a0108ca"),
                            Email = "user@gmail.com",
                            FirstName = "User",
                            LastName = "User",
                            PasswordHash = "$argon2id$v=19$m=65536,t=3,p=1$qeFiK6Jl6H04+Dl6BKsTCg$+BwGUX8lElCYi7ter8x5CSe/QpD0Xz7YJc5qJ0iU/YU",
                            RoleId = new Guid("5af06273-1ec8-40b6-9e41-9edca8019b04"),
                            UserName = "user@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("faf445bc-902c-4b07-86e0-5c59da6c554f"),
                            Email = "admin@admin.com",
                            FirstName = "Admin",
                            LastName = "Admin",
                            PasswordHash = "$argon2id$v=19$m=65536,t=3,p=1$Y/Evr2UMRpxc81SaUsoCWw$cQzWf8rcg8L/g0yC8asUtZzlTE2QRyzTnnZmzp4gukY",
                            RoleId = new Guid("04b93a99-7f05-490c-8b65-233d93af17a8"),
                            UserName = "admin@admin.com"
                        });
                });

            modelBuilder.Entity("GameGenre", b =>
                {
                    b.Property<Guid>("GamesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GenresId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GamesId", "GenresId");

                    b.HasIndex("GenresId");

                    b.ToTable("GameGenre");
                });

            modelBuilder.Entity("GameLanguage", b =>
                {
                    b.Property<Guid>("GamesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LanguagesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GamesId", "LanguagesId");

                    b.HasIndex("LanguagesId");

                    b.ToTable("GameLanguage");
                });

            modelBuilder.Entity("GamePlatform", b =>
                {
                    b.Property<Guid>("GamesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlatformsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GamesId", "PlatformsId");

                    b.HasIndex("PlatformsId");

                    b.ToTable("GamePlatform");
                });

            modelBuilder.Entity("GameUserEntity", b =>
                {
                    b.Property<Guid>("GamesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GamesId", "PlayersId");

                    b.HasIndex("PlayersId");

                    b.ToTable("GameUserEntity");
                });

            modelBuilder.Entity("DeveloperGame", b =>
                {
                    b.HasOne("Domain.Entities.Developer", null)
                        .WithMany()
                        .HasForeignKey("DevelopersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Achievement", b =>
                {
                    b.HasOne("Domain.Entities.Game", "Game")
                        .WithMany("Achievements")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Domain.Entities.AchievementUser", b =>
                {
                    b.HasOne("Domain.Entities.Achievement", "Achievement")
                        .WithMany()
                        .HasForeignKey("AchievementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserEntity", "User")
                        .WithMany("Achievements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Achievement");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Game", b =>
                {
                    b.HasOne("Domain.Entities.Publisher", "Publisher")
                        .WithMany("Games")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("Domain.Entities.GameTime", b =>
                {
                    b.HasOne("Domain.Entities.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserEntity", "User")
                        .WithMany("GameTimes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Rating", b =>
                {
                    b.HasOne("Domain.Entities.Game", "Game")
                        .WithMany("Ratings")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.HasOne("Domain.Entities.RoleEntity", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("GameGenre", b =>
                {
                    b.HasOne("Domain.Entities.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameLanguage", b =>
                {
                    b.HasOne("Domain.Entities.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Language", null)
                        .WithMany()
                        .HasForeignKey("LanguagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamePlatform", b =>
                {
                    b.HasOne("Domain.Entities.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Platform", null)
                        .WithMany()
                        .HasForeignKey("PlatformsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameUserEntity", b =>
                {
                    b.HasOne("Domain.Entities.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Game", b =>
                {
                    b.Navigation("Achievements");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("Domain.Entities.Publisher", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("Domain.Entities.RoleEntity", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.Navigation("Achievements");

                    b.Navigation("GameTimes");
                });
#pragma warning restore 612, 618
        }
    }
}