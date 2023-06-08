using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTweets2.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedReTweets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReTweets_Tweets_UserReTweetsTweetId",
                table: "ReTweets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReTweets",
                table: "ReTweets");

            migrationBuilder.DropIndex(
                name: "IX_ReTweets_UserReTweetsTweetId",
                table: "ReTweets");

            migrationBuilder.DropColumn(
                name: "UserReTweetsTweetId",
                table: "ReTweets");

            migrationBuilder.AddColumn<int>(
                name: "TweetsTweetId",
                table: "ReTweets",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReTweets",
                table: "ReTweets",
                columns: new[] { "TweetId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_ReTweets_TweetsTweetId",
                table: "ReTweets",
                column: "TweetsTweetId");

            migrationBuilder.CreateIndex(
                name: "IX_ReTweets_UserId",
                table: "ReTweets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReTweets_Tweets_TweetsTweetId",
                table: "ReTweets",
                column: "TweetsTweetId",
                principalTable: "Tweets",
                principalColumn: "TweetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReTweets_Tweets_TweetsTweetId",
                table: "ReTweets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReTweets",
                table: "ReTweets");

            migrationBuilder.DropIndex(
                name: "IX_ReTweets_TweetsTweetId",
                table: "ReTweets");

            migrationBuilder.DropIndex(
                name: "IX_ReTweets_UserId",
                table: "ReTweets");

            migrationBuilder.DropColumn(
                name: "TweetsTweetId",
                table: "ReTweets");

            migrationBuilder.AddColumn<int>(
                name: "UserReTweetsTweetId",
                table: "ReTweets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReTweets",
                table: "ReTweets",
                columns: new[] { "UserId", "UserReTweetsTweetId" });

            migrationBuilder.CreateIndex(
                name: "IX_ReTweets_UserReTweetsTweetId",
                table: "ReTweets",
                column: "UserReTweetsTweetId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReTweets_Tweets_UserReTweetsTweetId",
                table: "ReTweets",
                column: "UserReTweetsTweetId",
                principalTable: "Tweets",
                principalColumn: "TweetId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
