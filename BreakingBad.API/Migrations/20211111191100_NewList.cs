using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreakingBad.API.Migrations
{
    public partial class NewList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BetterCallSaulAppearance",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "CharId",
                keyValue: 1,
                column: "BetterCallSaulAppearance",
                value: "None");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BetterCallSaulAppearance",
                table: "Characters");
        }
    }
}
