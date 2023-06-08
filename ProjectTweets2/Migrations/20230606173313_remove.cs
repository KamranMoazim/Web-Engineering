using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTweets2.Migrations
{
    /// <inheritdoc />
    public partial class remove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReTweets",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserReTweetsTweetId = table.Column<int>(type: "int", nullable: false),
                    TweetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReTweets", x => new { x.UserId, x.UserReTweetsTweetId });
                    table.ForeignKey(
                        name: "FK_ReTweets_Tweets_UserReTweetsTweetId",
                        column: x => x.UserReTweetsTweetId,
                        principalTable: "Tweets",
                        principalColumn: "TweetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReTweets_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TweetLikes",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LikedTweetsTweetId = table.Column<int>(type: "int", nullable: false),
                    TweetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TweetLikes", x => new { x.LikedTweetsTweetId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TweetLikes_Tweets_LikedTweetsTweetId",
                        column: x => x.LikedTweetsTweetId,
                        principalTable: "Tweets",
                        principalColumn: "TweetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TweetLikes_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_ReTweets_UserReTweetsTweetId",
                table: "ReTweets",
                column: "UserReTweetsTweetId");

            migrationBuilder.CreateIndex(
                name: "IX_TweetLikes_UserId",
                table: "TweetLikes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSet_UserId",
                table: "UserSet",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReTweets");

            migrationBuilder.DropTable(
                name: "TweetLikes");

            migrationBuilder.DropTable(
                name: "UserSet");
        }
    }
}
