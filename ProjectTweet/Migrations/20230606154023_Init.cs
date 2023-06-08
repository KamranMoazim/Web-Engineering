using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTweet.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TweetUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TweetUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "TweetUserSet",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FollwerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TweetUserSet", x => new { x.FollwerId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TweetUserSet_TweetUsers_FollwerId",
                        column: x => x.FollwerId,
                        principalTable: "TweetUsers",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_TweetUserSet_TweetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "TweetUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TweetUserSet_UserId",
                table: "TweetUserSet",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TweetUserSet");

            migrationBuilder.DropTable(
                name: "TweetUsers");
        }
    }
}
