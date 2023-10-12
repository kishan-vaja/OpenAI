using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenAI.Migrations
{
    public partial class RegistrationModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                table: "DbSet",
                type: "nvarchar(Max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(Max)");

            migrationBuilder.AlterColumn<int>(
                name: "Like",
                table: "DbSet",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ImageFilename",
                table: "DbSet",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "AnchorLink",
                table: "DbSet",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.CreateTable(
                name: "RegitrationSet",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Mobile = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegitrationSet", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegitrationSet");

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                table: "DbSet",
                type: "nvarchar(Max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(Max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Like",
                table: "DbSet",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageFilename",
                table: "DbSet",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AnchorLink",
                table: "DbSet",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);
        }
    }
}
