using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lec14.Migrations
{
    /// <inheritdoc />
    public partial class RemovedCGPA_Raiwind_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CGPA",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "raivind",
                table: "Profile");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "CGPA",
                table: "Profile",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "raivind",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
