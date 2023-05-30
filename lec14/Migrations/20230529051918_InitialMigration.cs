using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lec14.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.CreateTable(
            //     name: "Profile",
            //     columns: table => new
            //     {
            //         ProfileId = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //         Lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //         TagLine = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //         Birthdate = table.Column<DateTime>(type: "datetime", nullable: false),
            //         JoinedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK__Profile__290C88E438553137", x => x.ProfileId);
            //     });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropTable(
            //     name: "Profile");
        }
    }
}
