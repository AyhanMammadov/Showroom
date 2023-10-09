using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Showroom.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTestDriveUsersConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "TestDriveUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                defaultValue: "Unknown",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true,
                oldDefaultValue: "Unknown");

            migrationBuilder.CreateTable(
                name: "CarsUrls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlAdres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarsUrls", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarsUrls");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "TestDriveUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                defaultValue: "Unknown",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true,
                oldDefaultValue: "Unknown");
        }
    }
}
