using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTweets2.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Tweets_TweetId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_TweetId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "TweetId",
                table: "Tags");

            migrationBuilder.AddColumn<int>(
                name: "TagsId",
                table: "Tweets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tweets_TagsId",
                table: "Tweets",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tweets_Tags_TagsId",
                table: "Tweets",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "TagsId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tweets_Tags_TagsId",
                table: "Tweets");

            migrationBuilder.DropIndex(
                name: "IX_Tweets_TagsId",
                table: "Tweets");

            migrationBuilder.DropColumn(
                name: "TagsId",
                table: "Tweets");

            migrationBuilder.AddColumn<int>(
                name: "TweetId",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TweetId",
                table: "Tags",
                column: "TweetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Tweets_TweetId",
                table: "Tags",
                column: "TweetId",
                principalTable: "Tweets",
                principalColumn: "TweetId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
