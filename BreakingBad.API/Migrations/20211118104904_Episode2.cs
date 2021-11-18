using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreakingBad.API.Migrations
{
    public partial class Episode2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Season",
                table: "Episodes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "EpisodeId", "AirDate", "Episodes", "Season", "Series", "Title" },
                values: new object[] { 60, new DateTime(2008, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, "5", "1", "Ozymandias" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 60);

            migrationBuilder.DropColumn(
                name: "Season",
                table: "Episodes");
        }
    }
}
