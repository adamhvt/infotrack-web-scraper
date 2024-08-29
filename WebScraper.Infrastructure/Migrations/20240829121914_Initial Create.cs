using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebScraper.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WebSearches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SearchExpression = table.Column<string>(type: "TEXT", nullable: false),
                    SearchProvider = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebSearches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebSearchResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    WebSearchId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    Rankings = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebSearchResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebSearchResults_WebSearches_WebSearchId",
                        column: x => x.WebSearchId,
                        principalTable: "WebSearches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "WebSearches",
                columns: new[] { "Id", "CreatedAt", "SearchExpression", "SearchProvider" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 8, 21, 13, 19, 14, 301, DateTimeKind.Local).AddTicks(2860), "land registry search", "Google" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2024, 8, 21, 13, 19, 14, 301, DateTimeKind.Local).AddTicks(2903), "InfoTrack", "Google" }
                });

            migrationBuilder.InsertData(
                table: "WebSearchResults",
                columns: new[] { "Id", "CreatedAt", "Rankings", "Url", "WebSearchId" },
                values: new object[,]
                {
                    { new Guid("01de3384-e11a-4975-94cc-f1a9b6f52488"), new DateTime(2024, 8, 29, 13, 19, 14, 301, DateTimeKind.Local).AddTicks(3061), "20, 24, 42, 80, 87, 99", "https://www.google.co.uk/search?num=100&q=infotrack", new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("1b714f56-5f51-4e26-a31e-50d455c5d189"), new DateTime(2024, 8, 27, 13, 19, 14, 301, DateTimeKind.Local).AddTicks(3040), "3, 10, 16, 47", "https://www.google.co.uk/search?num=100&q=land+registry+search", new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("1dbca726-b004-4a6d-b91b-7ab37fadd560"), new DateTime(2024, 8, 27, 13, 19, 14, 301, DateTimeKind.Local).AddTicks(3066), "16, 26, 42, 60", "https://www.google.co.uk/search?num=100&q=infotrack", new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("2235ea13-bc83-44ea-9424-2ffa878a263e"), new DateTime(2024, 8, 25, 13, 19, 14, 301, DateTimeKind.Local).AddTicks(3071), "12, 30, 40, 48, 52, 66, 80", "https://www.google.co.uk/search?num=100&q=infotrack", new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("29eedcd4-033e-476f-ade5-8665fb228ce6"), new DateTime(2024, 8, 24, 13, 19, 14, 301, DateTimeKind.Local).AddTicks(3075), "1, 8, 18, 20, 40, 60, 82", "https://www.google.co.uk/search?num=100&q=infotrack", new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("3b3949a9-1614-48fb-a609-905e618d84aa"), new DateTime(2024, 8, 25, 13, 19, 14, 301, DateTimeKind.Local).AddTicks(3055), "4, 8, 16, 32", "https://www.google.co.uk/search?num=100&q=land+registry+search", new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("81298a31-b95c-4a25-9ba6-ce43f417a542"), new DateTime(2024, 8, 28, 13, 19, 14, 301, DateTimeKind.Local).AddTicks(3063), "23, 34, 67", "https://www.google.co.uk/search?num=100&q=infotrack", new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("8f9b4f4c-dd32-4fb2-9ea1-6e67aeb195c8"), new DateTime(2024, 8, 26, 13, 19, 14, 301, DateTimeKind.Local).AddTicks(3052), "2, 7, 20, 60, 89", "https://www.google.co.uk/search?num=100&q=land+registry+search", new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("959d698f-6b88-458e-a0ae-525d44d3c9d2"), new DateTime(2024, 8, 28, 13, 19, 14, 301, DateTimeKind.Local).AddTicks(3037), "1, 4, 16, 47, 68", "https://www.google.co.uk/search?num=100&q=land+registry+search", new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("c30e6ae6-327c-4d62-8d24-ffd431eaf32f"), new DateTime(2024, 8, 29, 13, 19, 14, 301, DateTimeKind.Local).AddTicks(3033), "1, 8, 16, 32", "https://www.google.co.uk/search?num=100&q=land+registry+search", new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("fb29a0cf-759a-44b5-bb85-d8b87f8bc776"), new DateTime(2024, 8, 26, 13, 19, 14, 301, DateTimeKind.Local).AddTicks(3069), "10, 18, 37, 67, 90, 98", "https://www.google.co.uk/search?num=100&q=infotrack", new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("fb6b78d0-1394-40a8-b6fe-309729034dfe"), new DateTime(2024, 8, 24, 13, 19, 14, 301, DateTimeKind.Local).AddTicks(3058), "1, 8, 20, 32", "https://www.google.co.uk/search?num=100&q=land+registry+search", new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WebSearchResults_WebSearchId",
                table: "WebSearchResults",
                column: "WebSearchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WebSearchResults");

            migrationBuilder.DropTable(
                name: "WebSearches");
        }
    }
}
