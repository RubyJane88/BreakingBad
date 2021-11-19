using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreakingBad.API.Migrations
{
    public partial class seedDataDeath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Deaths",
                columns: new[] { "DeathId", "Cause", "Deaths", "Episode", "LastWords", "NumberOfDeaths", "Responsible", "Season" },
                values: new object[] { 23, "Ran over with a van, then shot in the head.", "Rival Dealers", 12, "Unknown", 2, "Walter White", 3 });

            migrationBuilder.InsertData(
                table: "Deaths",
                columns: new[] { "DeathId", "Cause", "Deaths", "Episode", "LastWords", "NumberOfDeaths", "Responsible", "Season" },
                values: new object[] { 28, "Shot in close range.", "Cartel Assassins", 4, "Unknown", 2, "Mike Ehrmantraut", 4 });

            migrationBuilder.InsertData(
                table: "Deaths",
                columns: new[] { "DeathId", "Cause", "Deaths", "Episode", "LastWords", "NumberOfDeaths", "Responsible", "Season" },
                values: new object[] { 40, "Multiple gunshots.", "Bodyguards of Gus Fring", 13, "What, you got a problem with stairs?", 2, "Walter White", 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Deaths",
                keyColumn: "DeathId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Deaths",
                keyColumn: "DeathId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Deaths",
                keyColumn: "DeathId",
                keyValue: 40);
        }
    }
}
