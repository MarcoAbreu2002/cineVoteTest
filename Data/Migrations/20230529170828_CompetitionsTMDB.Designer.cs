﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace cineVote.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230529170828_CompetitionsTMDB")]
    partial class CompetitionsTMDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("cineVote.Models.Domain.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CategoryId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<int?>("Competition_Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CategoryDescription");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CategoryName");

                    b.HasKey("CategoryId");

                    b.HasIndex("Competition_Id");

                    b.ToTable("tblCategory");
                });

            modelBuilder.Entity("cineVote.Models.Domain.CategoryNominee", b =>
                {
                    b.Property<int>("CategoryNomineeKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryNomineeKey"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryId");

                    b.Property<int>("NomineeId")
                        .HasColumnType("int")
                        .HasColumnName("NomineeId");

                    b.HasKey("CategoryNomineeKey");

                    b.HasIndex("CategoryId");

                    b.HasIndex("NomineeId");

                    b.ToTable("tblCategoryNominee");
                });

            modelBuilder.Entity("cineVote.Models.Domain.Competition", b =>
                {
                    b.Property<int>("Competition_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Competition_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Competition_Id"), 1L, 1);

                    b.Property<string>("AdminId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("AdminId");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("Category");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("EndDate");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit")
                        .HasColumnName("IsPublic");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<int?>("ResultsResultId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("StartDate");

                    b.HasKey("Competition_Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("ResultsResultId");

                    b.ToTable("tblCompetition");
                });

            modelBuilder.Entity("cineVote.Models.Domain.Nominee", b =>
                {
                    b.Property<int>("NomineeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("NomineeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NomineeId"), 1L, 1);

                    b.Property<int?>("Competition_Id")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FullName");

                    b.Property<string>("ProfilePictureURL")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ProfilePictureURL");

                    b.Property<int>("TMDBId")
                        .HasColumnType("int")
                        .HasColumnName("TMDBId");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.HasKey("NomineeId");

                    b.HasIndex("Competition_Id");

                    b.ToTable("tblNominee");
                });

            modelBuilder.Entity("cineVote.Models.Domain.NomineeCompetition", b =>
                {
                    b.Property<int>("NomineeCompetitionKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NomineeCompetitionKey"), 1L, 1);

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int")
                        .HasColumnName("CompetitionId");

                    b.Property<int>("NomineeId")
                        .HasColumnType("int")
                        .HasColumnName("NomineeId");

                    b.HasKey("NomineeCompetitionKey");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("NomineeId");

                    b.ToTable("tblNomineeCompetition");
                });

            modelBuilder.Entity("cineVote.Models.Domain.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("notificationId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.HasKey("NotificationId");

                    b.ToTable("tblNotification");
                });

            modelBuilder.Entity("cineVote.Models.Domain.Person", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Email1");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FirstName");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("imageUrl");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit")
                        .HasColumnName("IsAdmin");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastName");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Password");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int")
                        .HasColumnName("PersonId");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("cineVote.Models.Domain.Result", b =>
                {
                    b.Property<int>("ResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ResultID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResultId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryId");

                    b.Property<int>("NomineeId")
                        .HasColumnType("int")
                        .HasColumnName("NomineeId");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int")
                        .HasColumnName("SubscriptionId");

                    b.HasKey("ResultId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("NomineeId");

                    b.HasIndex("SubscriptionId")
                        .IsUnique();

                    b.ToTable("tblResult");
                });

            modelBuilder.Entity("cineVote.Models.Domain.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<int>("MovieId")
                        .HasColumnType("int")
                        .HasColumnName("MovieId");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.HasKey("RoleId");

                    b.HasIndex("MovieId");

                    b.ToTable("tblRole");
                });

            modelBuilder.Entity("cineVote.Models.Domain.Subscription", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Subscription_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscriptionId"), 1L, 1);

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int")
                        .HasColumnName("Competition_Id");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Subscription_name");

                    b.HasKey("SubscriptionId");

                    b.HasIndex("CompetitionId");

                    b.ToTable("tblSubscription");
                });

            modelBuilder.Entity("cineVote.Models.Domain.SubscriptionNotifications", b =>
                {
                    b.Property<int>("SubscriptionNotificationsKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscriptionNotificationsKey"), 1L, 1);

                    b.Property<int>("NotificationId")
                        .HasColumnType("int")
                        .HasColumnName("NotificationId");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int")
                        .HasColumnName("SubscriptionId");

                    b.HasKey("SubscriptionNotificationsKey");

                    b.HasIndex("NotificationId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("tblSubscriptionNotifications");
                });

            modelBuilder.Entity("cineVote.Models.Domain.Vote", b =>
                {
                    b.Property<int>("VoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Vote_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VoteId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryId");

                    b.Property<int>("NomineeId")
                        .HasColumnType("int")
                        .HasColumnName("NomineeId");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int")
                        .HasColumnName("SubscriptionId");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.Property<string>("UserId1")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("VoteId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("NomineeId");

                    b.HasIndex("SubscriptionId");

                    b.HasIndex("UserId1");

                    b.ToTable("tblVotes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ParticipantRole", b =>
                {
                    b.Property<int>("ParticipantsNomineeId")
                        .HasColumnType("int");

                    b.Property<int>("RolesRoleId")
                        .HasColumnType("int");

                    b.HasKey("ParticipantsNomineeId", "RolesRoleId");

                    b.HasIndex("RolesRoleId");

                    b.ToTable("ParticipantRole");
                });

            modelBuilder.Entity("SubscriptionUser", b =>
                {
                    b.Property<string>("UsersRegisteredId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("subscritionsSubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("UsersRegisteredId", "subscritionsSubscriptionId");

                    b.HasIndex("subscritionsSubscriptionId");

                    b.ToTable("SubscriptionUser");
                });

            modelBuilder.Entity("cineVote.Models.Domain.Admin", b =>
                {
                    b.HasBaseType("cineVote.Models.Domain.Person");

                    b.Property<int>("Competition_Id")
                        .HasColumnType("int")
                        .HasColumnName("Competition_Id");

                    b.ToTable("tblAdmin");
                });

            modelBuilder.Entity("cineVote.Models.Domain.Movie", b =>
                {
                    b.HasBaseType("cineVote.Models.Domain.Nominee");

                    b.Property<string>("Director")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Director");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Genre");

                    b.Property<string>("Plot")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Plot");

                    b.Property<int?>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("Rating");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Title");

                    b.ToTable("tblMovie");
                });

            modelBuilder.Entity("cineVote.Models.Domain.Participant", b =>
                {
                    b.HasBaseType("cineVote.Models.Domain.Nominee");

                    b.Property<int?>("Age")
                        .HasColumnType("int")
                        .HasColumnName("Age");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Gender");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nationality");

                    b.ToTable("tblParticipant");
                });

            modelBuilder.Entity("cineVote.Models.Domain.User", b =>
                {
                    b.HasBaseType("cineVote.Models.Domain.Person");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int")
                        .HasColumnName("SubscriptionId");

                    b.ToTable("tblUser");
                });

            modelBuilder.Entity("cineVote.Models.Domain.Category", b =>
                {
                    b.HasOne("cineVote.Models.Domain.Competition", null)
                        .WithMany("CategoryEntity")
                        .HasForeignKey("Competition_Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("cineVote.Models.Domain.CategoryNominee", b =>
                {
                    b.HasOne("cineVote.Models.Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("cineVote.Models.Domain.Nominee", "Nominee")
                        .WithMany("CategoryNominees")
                        .HasForeignKey("NomineeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Nominee");
                });

            modelBuilder.Entity("cineVote.Models.Domain.Competition", b =>
                {
                    b.HasOne("cineVote.Models.Domain.Admin", null)
                        .WithMany("competitions")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("cineVote.Models.Domain.Result", "Results")
                        .WithMany("Competition")
                        .HasForeignKey("ResultsResultId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Results");
                });

            modelBuilder.Entity("cineVote.Models.Domain.Nominee", b =>
                {
                    b.HasOne("cineVote.Models.Domain.Competition", null)
                        .WithMany("Nominees")
                        .HasForeignKey("Competition_Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("cineVote.Models.Domain.NomineeCompetition", b =>
                {
                    b.HasOne("cineVote.Models.Domain.Competition", "Competition")
                        .WithMany()
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("cineVote.Models.Domain.Nominee", "Nominee")
                        .WithMany("NomineeCompetitions")
                        .HasForeignKey("NomineeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Competition");

                    b.Navigation("Nominee");
                });

            modelBuilder.Entity("cineVote.Models.Domain.Result", b =>
                {
                    b.HasOne("cineVote.Models.Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("cineVote.Models.Domain.Nominee", "Nominee")
                        .WithMany("Results")
                        .HasForeignKey("NomineeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("cineVote.Models.Domain.Subscription", "Subscription")
                        .WithOne("Result")
                        .HasForeignKey("cineVote.Models.Domain.Result", "SubscriptionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Nominee");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("cineVote.Models.Domain.Role", b =>
                {
                    b.HasOne("cineVote.Models.Domain.Movie", "Movie")
                        .WithMany("Roles")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("cineVote.Models.Domain.Subscription", b =>
                {
                    b.HasOne("cineVote.Models.Domain.Competition", "Competition")
                        .WithMany()
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Competition");
                });

            modelBuilder.Entity("cineVote.Models.Domain.SubscriptionNotifications", b =>
                {
                    b.HasOne("cineVote.Models.Domain.Notification", "Notification")
                        .WithMany("SubscriptionNotifications")
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("cineVote.Models.Domain.Subscription", "Subscription")
                        .WithMany("SubscriptionNotifications")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Notification");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("cineVote.Models.Domain.Vote", b =>
                {
                    b.HasOne("cineVote.Models.Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("cineVote.Models.Domain.Nominee", "Nominee")
                        .WithMany()
                        .HasForeignKey("NomineeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("cineVote.Models.Domain.Subscription", "Subscription")
                        .WithMany("VotesReceived")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("cineVote.Models.Domain.User", "User")
                        .WithMany("votes")
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Nominee");

                    b.Navigation("Subscription");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("cineVote.Models.Domain.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("cineVote.Models.Domain.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("cineVote.Models.Domain.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("cineVote.Models.Domain.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ParticipantRole", b =>
                {
                    b.HasOne("cineVote.Models.Domain.Participant", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsNomineeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("cineVote.Models.Domain.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesRoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SubscriptionUser", b =>
                {
                    b.HasOne("cineVote.Models.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UsersRegisteredId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("cineVote.Models.Domain.Subscription", null)
                        .WithMany()
                        .HasForeignKey("subscritionsSubscriptionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("cineVote.Models.Domain.Admin", b =>
                {
                    b.HasOne("cineVote.Models.Domain.Person", null)
                        .WithOne()
                        .HasForeignKey("cineVote.Models.Domain.Admin", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("cineVote.Models.Domain.Movie", b =>
                {
                    b.HasOne("cineVote.Models.Domain.Nominee", null)
                        .WithOne()
                        .HasForeignKey("cineVote.Models.Domain.Movie", "NomineeId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("cineVote.Models.Domain.Participant", b =>
                {
                    b.HasOne("cineVote.Models.Domain.Nominee", null)
                        .WithOne()
                        .HasForeignKey("cineVote.Models.Domain.Participant", "NomineeId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("cineVote.Models.Domain.User", b =>
                {
                    b.HasOne("cineVote.Models.Domain.Person", null)
                        .WithOne()
                        .HasForeignKey("cineVote.Models.Domain.User", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("cineVote.Models.Domain.Competition", b =>
                {
                    b.Navigation("CategoryEntity");

                    b.Navigation("Nominees");
                });

            modelBuilder.Entity("cineVote.Models.Domain.Nominee", b =>
                {
                    b.Navigation("CategoryNominees");

                    b.Navigation("NomineeCompetitions");

                    b.Navigation("Results");
                });

            modelBuilder.Entity("cineVote.Models.Domain.Notification", b =>
                {
                    b.Navigation("SubscriptionNotifications");
                });

            modelBuilder.Entity("cineVote.Models.Domain.Result", b =>
                {
                    b.Navigation("Competition");
                });

            modelBuilder.Entity("cineVote.Models.Domain.Subscription", b =>
                {
                    b.Navigation("Result");

                    b.Navigation("SubscriptionNotifications");

                    b.Navigation("VotesReceived");
                });

            modelBuilder.Entity("cineVote.Models.Domain.Admin", b =>
                {
                    b.Navigation("competitions");
                });

            modelBuilder.Entity("cineVote.Models.Domain.Movie", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("cineVote.Models.Domain.User", b =>
                {
                    b.Navigation("votes");
                });
#pragma warning restore 612, 618
        }
    }
}
