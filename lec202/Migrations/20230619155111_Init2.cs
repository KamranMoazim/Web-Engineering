using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lec202.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DescriptionId",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Category_DescriptionId",
                table: "Category",
                column: "DescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_CategoryDescription_DescriptionId",
                table: "Category",
                column: "DescriptionId",
                principalTable: "CategoryDescription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_CategoryDescription_DescriptionId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_DescriptionId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "DescriptionId",
                table: "Category");
        }
    }
}
