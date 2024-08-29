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
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 8, 20, 23, 43, 9, 797, DateTimeKind.Local).AddTicks(5874), "land registry search", "Google" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2024, 8, 20, 23, 43, 9, 797, DateTimeKind.Local).AddTicks(5929), "InfoTrack", "Google" }
                });

            migrationBuilder.InsertData(
                table: "WebSearchResults",
                columns: new[] { "Id", "CreatedAt", "Rankings", "Url", "WebSearchId" },
                values: new object[,]
                {
                    { new Guid("10033b28-2d49-4fa7-9c9d-a9e6b1928606"), new DateTime(2024, 8, 24, 23, 43, 9, 797, DateTimeKind.Local).AddTicks(6121), "12, 30, 40, 48, 52, 66, 80", "https://www.google.co.uk/search?num=100&q=land+registry+search", new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("155727c9-4c45-403a-bbcd-aefff7ad7322"), new DateTime(2024, 8, 26, 23, 43, 9, 797, DateTimeKind.Local).AddTicks(6088), "3, 10, 16, 47", "https://www.google.co.uk/search?num=100&q=land+registry+search", new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("40e3845f-a97a-4690-859e-73690ba1eccd"), new DateTime(2024, 8, 24, 23, 43, 9, 797, DateTimeKind.Local).AddTicks(6105), "4, 8, 16, 32", "https://www.google.co.uk/search?num=100&q=land+registry+search", new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("564f0747-02e9-462e-8eb7-cdef43cb9128"), new DateTime(2024, 8, 26, 23, 43, 9, 797, DateTimeKind.Local).AddTicks(6116), "16, 26, 42, 60", "https://www.google.co.uk/search?num=100&q=land+registry+search", new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("5b55026f-eaf1-46a9-9408-25a21b7eafad"), new DateTime(2024, 8, 28, 23, 43, 9, 797, DateTimeKind.Local).AddTicks(6111), "20, 24, 42, 80, 87, 99", "https://www.google.co.uk/search?num=100&q=land+registry+search", new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("60fb4158-6289-4759-b6b3-a455eb8974fd"), new DateTime(2024, 8, 28, 23, 43, 9, 797, DateTimeKind.Local).AddTicks(6081), "1, 8, 16, 32", "https://www.google.co.uk/search?num=100&q=land+registry+search", new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("76c47b4d-f878-4800-a17d-099cc3ba01a0"), new DateTime(2024, 8, 23, 23, 43, 9, 797, DateTimeKind.Local).AddTicks(6108), "1, 8, 20, 32", "https://www.google.co.uk/search?num=100&q=land+registry+search", new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("84ebfc91-14dd-457b-aee4-fbacfbeca274"), new DateTime(2024, 8, 27, 23, 43, 9, 797, DateTimeKind.Local).AddTicks(6113), "23, 34, 67", "https://www.google.co.uk/search?num=100&q=land+registry+search", new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("9b6ea5b4-dae4-46e7-bdaf-a55573740ab4"), new DateTime(2024, 8, 27, 23, 43, 9, 797, DateTimeKind.Local).AddTicks(6085), "1, 4, 16, 47, 68", "https://www.google.co.uk/search?num=100&q=land+registry+search", new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("bdf46453-279c-4fb4-80b1-ba50a00502db"), new DateTime(2024, 8, 23, 23, 43, 9, 797, DateTimeKind.Local).AddTicks(6125), "1, 8, 18, 20, 40, 60, 82", "https://www.google.co.uk/search?num=100&q=land+registry+search", new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("c001922e-9ea1-4d78-8433-f7ac5ded15fb"), new DateTime(2024, 8, 25, 23, 43, 9, 797, DateTimeKind.Local).AddTicks(6119), "10, 18, 37, 67, 90, 98", "https://www.google.co.uk/search?num=100&q=land+registry+search", new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("e85ed73a-a272-404e-b52f-3a8d0b5518cd"), new DateTime(2024, 8, 25, 23, 43, 9, 797, DateTimeKind.Local).AddTicks(6102), "2, 7, 20, 60, 89", "https://www.google.co.uk/search?num=100&q=land+registry+search", new Guid("00000000-0000-0000-0000-000000000001") }
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
