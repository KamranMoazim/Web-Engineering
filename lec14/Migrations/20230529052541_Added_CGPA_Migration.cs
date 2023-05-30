using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lec14.Migrations
{
    /// <inheritdoc />
    public partial class Added_CGPA_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "CGPA",
                table: "Profile",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CGPA",
                table: "Profile");
        }
    }
}
