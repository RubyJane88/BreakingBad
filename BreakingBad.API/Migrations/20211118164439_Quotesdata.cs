using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreakingBad.API.Migrations
{
    public partial class Quotesdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteId", "Author", "Quotes", "Series" },
                values: new object[] { 4, "Walter White", "I watched Jane die. I was there. And I watched her die. I watched her overdose and choke to death. I could have saved her. But I didn’t.", "Breaking Bad" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteId", "Author", "Quotes", "Series" },
                values: new object[] { 7, "Saul Goodman", "Yeah, you do seem to have a little s*** creek action going... You know, FYI, you can buy a paddle.", "Breaking Bad" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteId", "Author", "Quotes", "Series" },
                values: new object[] { 9, "Jesse Pinkman", "Funyuns are awesome.", "Breaking Bad" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: 9);
        }
    }
}
