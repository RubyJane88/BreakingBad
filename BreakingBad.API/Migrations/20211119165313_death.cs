using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreakingBad.API.Migrations
{
    public partial class death : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deaths",
                columns: table => new
                {
                    DeathId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deaths = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Cause = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Responsible = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastWords = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Season = table.Column<int>(type: "int", nullable: false),
                    Episode = table.Column<int>(type: "int", nullable: false),
                    NumberOfDeaths = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deaths", x => x.DeathId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deaths");
        }
    }
}
