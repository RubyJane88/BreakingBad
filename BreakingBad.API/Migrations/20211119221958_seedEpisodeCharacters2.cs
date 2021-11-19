using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreakingBad.API.Migrations
{
    public partial class seedEpisodeCharacters2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 60);

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "EpisodeId", "AirDate", "Characters", "Episodes", "Season", "Series", "Title" },
                values: new object[] { 6, new DateTime(2008, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Walter White;Jesse Pinkman;Skyler White;Hank Schrader;Marie Schrader;Walter White Jr.;Tuco Salamanca", 6, "1", "Breaking Bad", "Crazy Handful of Nothin" });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "EpisodeId", "AirDate", "Characters", "Episodes", "Season", "Series", "Title" },
                values: new object[] { 27, new DateTime(2008, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Walter White;Hank Schrader", 14, "5", "1", "Ozymandias" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 27);

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "EpisodeId", "AirDate", "Characters", "Episodes", "Season", "Series", "Title" },
                values: new object[] { 60, new DateTime(2008, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Walter White;Hank Schrader", 14, "5", "1", "Ozymandias" });
        }
    }
}
