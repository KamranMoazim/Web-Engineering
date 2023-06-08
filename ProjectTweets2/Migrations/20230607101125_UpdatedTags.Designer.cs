﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectTweets2.Models.DB;

#nullable disable

namespace ProjectTweets2.Migrations
{
    [DbContext(typeof(MyTweetsDbContext))]
    [Migration("20230607101125_UpdatedTags")]
    partial class UpdatedTags
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectTweets2.Models.DB.Comments", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("TweetId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("TweetId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ProjectTweets2.Models.DB.ReTweets", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("UserReTweetsTweetId")
                        .HasColumnType("int");

                    b.Property<int>("TweetId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "UserReTweetsTweetId");

                    b.HasIndex("UserReTweetsTweetId");

                    b.ToTable("ReTweets");
                });

            modelBuilder.Entity("ProjectTweets2.Models.DB.Tags", b =>
                {
                    b.Property<int>("TagsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagsId"));

                    b.Property<string>("Tag1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tag2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tag3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagsId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ProjectTweets2.Models.DB.TweetLikes", b =>
                {
                    b.Property<int>("LikedTweetsTweetId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("TweetId")
                        .HasColumnType("int");

                    b.HasKey("LikedTweetsTweetId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("TweetLikes");
                });

            modelBuilder.Entity("ProjectTweets2.Models.DB.Tweets", b =>
                {
                    b.Property<int>("TweetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TweetId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LikesCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("RetweetsCount")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TweetId");

                    b.HasIndex("TagsId");

                    b.HasIndex("UserId");

                    b.ToTable("Tweets");
                });

            modelBuilder.Entity("ProjectTweets2.Models.DB.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("JoinedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TagLine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ProjectTweets2.Models.DB.UserSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FollwerId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserSet");
                });

            modelBuilder.Entity("ProjectTweets2.Models.DB.Comments", b =>
                {
                    b.HasOne("ProjectTweets2.Models.DB.Tweets", "Tweets")
                        .WithMany("Comments")
                        .HasForeignKey("TweetId");

                    b.HasOne("ProjectTweets2.Models.DB.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");

                    b.Navigation("Tweets");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectTweets2.Models.DB.ReTweets", b =>
                {
                    b.HasOne("ProjectTweets2.Models.DB.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectTweets2.Models.DB.Tweets", null)
                        .WithMany()
                        .HasForeignKey("UserReTweetsTweetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectTweets2.Models.DB.TweetLikes", b =>
                {
                    b.HasOne("ProjectTweets2.Models.DB.Tweets", null)
                        .WithMany()
                        .HasForeignKey("LikedTweetsTweetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectTweets2.Models.DB.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectTweets2.Models.DB.Tweets", b =>
                {
                    b.HasOne("ProjectTweets2.Models.DB.Tags", "Tags")
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectTweets2.Models.DB.User", "User")
                        .WithMany("Tweets")
                        .HasForeignKey("UserId");

                    b.Navigation("Tags");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectTweets2.Models.DB.UserSet", b =>
                {
                    b.HasOne("ProjectTweets2.Models.DB.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectTweets2.Models.DB.Tweets", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("ProjectTweets2.Models.DB.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Tweets");
                });
#pragma warning restore 612, 618
        }
    }
}