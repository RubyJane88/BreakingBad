using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreakingBad.API.Migrations
{
    public partial class List : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Appearance",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "CharId",
                keyValue: 1,
                columns: new[] { "Appearance", "Category" },
                values: new object[] { "Breaking Bad", "Breaking Bad" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Appearance",
                table: "Characters");

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Characters",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "CharId",
                keyValue: 1,
                column: "Category",
                value: 1);
        }
    }
}
