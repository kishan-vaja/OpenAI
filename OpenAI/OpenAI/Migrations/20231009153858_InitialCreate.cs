using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenAI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenAIName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(Max)", nullable: false),
                    ImageFilename = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    AnchorLink = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Like = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSet", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbSet");
        }
    }
}
