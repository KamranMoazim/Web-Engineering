using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTweets2.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCcounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentsCount",
                table: "Tweets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedAt",
                table: "ReTweets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentsCount",
                table: "Tweets");

            migrationBuilder.DropColumn(
                name: "PostedAt",
                table: "ReTweets");
        }
    }
}
