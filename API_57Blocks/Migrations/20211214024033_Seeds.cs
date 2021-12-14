using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_57Blocks.Migrations
{
    public partial class Seeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Name", "Artist", "Album", "Year", "Genre", "scope" },
                values: new object[] { "That Ain't Love", "REO Speedwagon", "Life as We Know It", 1987, "Rock", "public"});
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Name", "Artist", "Album", "Year", "Genre", "scope" },
                values: new object[] { "Beds Are Burning", "Midnight Oil", "Diesel and Dust", 1987, "Rock", "public" });
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Name", "Artist", "Album", "Year", "Genre", "scope" },
                values: new object[] { "Take On Me", "A-ha", "Hunting High and Low", 1985, "Rock", "public" });
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Name", "Artist", "Album", "Year", "Genre", "scope" },
                values: new object[] { "Don't Stop Me Now", "Queen", "Jazz", 1978, "Rock", "public" });
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Name", "Artist", "Album", "Year", "Genre", "scope" },
                values: new object[] { "Your Love", "The Outfield", "Play Deep", 1985, "Rock", "public" });
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Name", "Artist", "Album", "Year", "Genre", "scope" },
                values: new object[] { "Burning Heart", "Survivor", "Rocky IV", 1985, "Rock", "public" });
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Name", "Artist", "Album", "Year", "Genre", "scope" },
                values: new object[] { "The Final Countdown", "Europe", "The Final Countdown", 1986, "Rock", "public" });
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Name", "Artist", "Album", "Year", "Genre", "scope" },
                values: new object[] { "Wonderwall", "Oasis", "(What's the Story) Morning Glory?", 1995, "Rock", "public" });
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Name", "Artist", "Album", "Year", "Genre", "scope" },
                values: new object[] { "Dreams", "The Cranberries", "Everybody Else Is Doing It, So Why Can't We?", 1993, "Rock", "public" });
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Name", "Artist", "Album", "Year", "Genre", "scope" },
                values: new object[] { "Big In Japan", "Alphaville", "Forever Young", 1984, "Rock", "public" });
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Name", "Artist", "Album", "Year", "Genre", "scope" },
                values: new object[] { "Innuendo", "Queen", "Innuendo", 1991, "Rock", "public" });
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Name", "Artist", "Album", "Year", "Genre", "scope" },
                values: new object[] { "Nothing Else Matters", "Metallica", "Metallica", 1991, "Rock", "public" });
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Name", "Artist", "Album", "Year", "Genre", "scope" },
                values: new object[] { "Karma Chameleon", "Culture Club", "Colour by Numbers", 1983, "Rock", "public" });
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Name", "Artist", "Album", "Year", "Genre", "scope" },
                values: new object[] { "Go West", "Pet Shop Boys", "Very", 1993, "Rock", "public" });
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Name", "Artist", "Album", "Year", "Genre", "scope" },
                values: new object[] { "Karma Police", "Radiohead", "OK Computer", 1997, "Rock", "public" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
