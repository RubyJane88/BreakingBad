using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreakingBad.API.Migrations
{
    public partial class seedEpisodeCharacters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Characters",
                table: "Episodes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 60,
                column: "Characters",
                value: "Walter White;Hank Schrader");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Characters",
                table: "Episodes");
        }
    }
}
