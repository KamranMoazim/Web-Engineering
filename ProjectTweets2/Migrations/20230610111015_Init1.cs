using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTweets2.Migrations
{
    /// <inheritdoc />
    public partial class Init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    msg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    From = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tag2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tag3 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagsId);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TweetId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                });

            migrationBuilder.CreateTable(
                name: "ReTweets",
                columns: table => new
                {
                    TweetId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TweetsTweetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReTweets", x => new { x.TweetId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "TweetLikes",
                columns: table => new
                {
                    TweetId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TweetsTweetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TweetLikes", x => new { x.TweetId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "Tweets",
                columns: table => new
                {
                    TweetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LikesCount = table.Column<int>(type: "int", nullable: false),
                    RetweetsCount = table.Column<int>(type: "int", nullable: false),
                    CommentsCount = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tweets", x => x.TweetId);
                    table.ForeignKey(
                        name: "FK_Tweets_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "TagsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TagLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TweetsTweetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Tweets_TweetsTweetId",
                        column: x => x.TweetsTweetId,
                        principalTable: "Tweets",
                        principalColumn: "TweetId");
                });

            migrationBuilder.CreateTable(
                name: "UserSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FollwerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSet_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TweetId",
                table: "Comments",
                column: "TweetId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReTweets_TweetsTweetId",
                table: "ReTweets",
                column: "TweetsTweetId");

            migrationBuilder.CreateIndex(
                name: "IX_ReTweets_UserId",
                table: "ReTweets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TweetLikes_TweetsTweetId",
                table: "TweetLikes",
                column: "TweetsTweetId");

            migrationBuilder.CreateIndex(
                name: "IX_TweetLikes_UserId",
                table: "TweetLikes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tweets_TagsId",
                table: "Tweets",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tweets_UserId",
                table: "Tweets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_TweetsTweetId",
                table: "User",
                column: "TweetsTweetId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSet_UserId",
                table: "UserSet",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tweets_TweetId",
                table: "Comments",
                column: "TweetId",
                principalTable: "Tweets",
                principalColumn: "TweetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_User_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReTweets_Tweets_TweetsTweetId",
                table: "ReTweets",
                column: "TweetsTweetId",
                principalTable: "Tweets",
                principalColumn: "TweetId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReTweets_User_UserId",
                table: "ReTweets",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TweetLikes_Tweets_TweetsTweetId",
                table: "TweetLikes",
                column: "TweetsTweetId",
                principalTable: "Tweets",
                principalColumn: "TweetId");

            migrationBuilder.AddForeignKey(
                name: "FK_TweetLikes_User_UserId",
                table: "TweetLikes",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tweets_User_UserId",
                table: "Tweets",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Tweets_TweetsTweetId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "ReTweets");

            migrationBuilder.DropTable(
                name: "TweetLikes");

            migrationBuilder.DropTable(
                name: "UserSet");

            migrationBuilder.DropTable(
                name: "Tweets");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
