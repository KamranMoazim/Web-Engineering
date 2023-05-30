using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lec14.Migrations
{
    /// <inheritdoc />
    public partial class raivind_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "raivind",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "raivind",
                table: "Profile");
        }
    }
}
